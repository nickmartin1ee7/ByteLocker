using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ByteLocker
{
    static class BusinessLogic
    {
        private static byte[] key;
        private static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };   // TODO: Pending change for AES
        //private static string path;

        internal static bool Encrypt(string file, string _key)
        {
            key = Encoding.ASCII.GetBytes(_key);
            //path = Path.GetDirectoryName(file);
            return FileHandler(file, true);
        }

        internal static bool Decrypt(string file, string _key)
        {
            key = Encoding.ASCII.GetBytes(_key);
            //path = Path.GetDirectoryName(file);
            return FileHandler(file, false);
        }

        private static DialogResult WarnSecurity(long fileLen)
        {
            return MessageBox.Show($"Warning! Key size ({key.Length}) is less than file content ({fileLen}) size. It's recommended to use a key of equal length or else the encryption will be vulnerable to cracking.\n\nDo you want to autogenerate a secure key?", "ByteLocker - Security Warning", MessageBoxButtons.YesNoCancel);
        }

        private static void GenAutoKey(string path, long fileLen)
        {
            path = path.Substring(0, path.IndexOf(Regex.Match(path, @"(?!\\)[^\\]*\\[^\\]*$").Value));  // Thank you, Termininja (https://stackoverflow.com/questions/34413374/how-to-find-the-second-last-indexof-a-value-in-a-string/34413521)
            Random r = new Random(DateTime.Now.Millisecond);
            //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            char[] autoKeyCharArray = new char[fileLen];

            for (int i = 0; i < fileLen; i++)
                autoKeyCharArray[i] = (char)r.Next(33, 126 + 1);

            key = Encoding.ASCII.GetBytes(autoKeyCharArray);

            string keyFile = path + $"key_{r.Next()}.txt";
            using (FileStream fs = new FileStream(keyFile, FileMode.Create, FileAccess.Write))
            {
                fs.Write(key, 0, key.Length);
                MessageBox.Show("Key stored at:\n" + keyFile);
            }
        }

        private static bool FileHandler(string file, bool isPlainText)
        {
            try
            {
                if (File.Exists(file))
                {
                    return ContentsHandler(file, isPlainText);
                }
                else if (Directory.Exists(file))
                {
                    string[] files = Directory.GetFiles(file);
                    List<bool> successes = new List<bool>();
                    for (int i = 0; i < files.Length; ++i)
                    {
                        successes.Add(ContentsHandler(files[i], isPlainText));
                    }
                    if (successes.TrueForAll((e) => e))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }

        private static bool ContentsHandler(string file, bool isPlainText)
        {
            if (isPlainText)
            {
                long fileLen = new FileInfo(file).Length;
                DialogResult makeSecure = DialogResult.No;
                if (key.Length < fileLen)
                    makeSecure = WarnSecurity(fileLen);
                if (makeSecure == DialogResult.Yes)
                {
                    GenAutoKey(file, fileLen);
                }
                else if (makeSecure == DialogResult.No)
                {
                    // Continue
                }
                else if (makeSecure == DialogResult.Cancel)
                    return false;
                else return false;
            }

            try
            {
                using (FileStream fsSource = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    fsSource.Close();

                    // Modify
                    if (isPlainText)
                        bytes = Encode(bytes, key);
                    else
                        bytes = Decode(bytes, key);

                    // Out
                    try
                    {
                        if (bytes != null)
                        {
                            numBytesToRead = bytes.Length;
                            using (FileStream fsNew = new FileStream(file, FileMode.Create, FileAccess.Write))
                                fsNew.Write(bytes, 0, numBytesToRead);
                        }
                        else
                            MessageBox.Show($"Failed to read:\n{file}", "ByteLocker - Sorry!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                return true;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #region Byte Operation Functions
        private static byte[] Encode(byte[] b, byte[] key)
        {
            try
            {
                b = XORCrypt(b, key);
                //b = AESEncrypt(b, key);
                b = Encoding.ASCII.GetBytes(Convert.ToBase64String(b));
                return b;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Not base64 format\n" + e);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        private static byte[] Decode(byte[] b, byte[] key)
        {
            try
            {
                string s = Encoding.ASCII.GetString(b);
                b = Convert.FromBase64String(s);
                //b = AESDecrypt(b, key);
                b = XORCrypt(b, key);
                return b;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Not base64 format\n" + e);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Not implemented cryptography
        private static byte[] AESEncrypt(byte[] plainData, byte[] key)
        {
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = 128;
            crypt.Key = hash.ComputeHash(key);
            crypt.IV = IV;

            byte[] cipherData = new byte[plainData.Length];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(cipherData, 0, cipherData.Length);
                }
                return cipherData;
            }
        }

        private static byte[] AESDecrypt(byte[] cipherData, byte[] key)
        {
            byte[] plainData = new byte[cipherData.Length];
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = hash.ComputeHash(key);
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(cipherData))
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    plainData = new byte[plainData.Length];
                    cryptoStream.Read(plainData, 0, plainData.Length);
                }
            }
            return plainData;
        }
        #endregion 

        #region Implemented cryptography
        private static byte[] XORCrypt(byte[] b, byte[] keyBytes)
        {
            int j = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (j < keyBytes.Length)
                {
                    b[i] = (byte)(b[i] ^ keyBytes[j]);
                    j++;
                }
                else
                    j = 0;
            }
            return b;
        }
        #endregion
    }
}
