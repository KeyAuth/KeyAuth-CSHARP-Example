using System;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Principal;

namespace KeyAuth
{
    public class api
    {

        public static void init(string name, string secret, string ownerid)
        {
            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
                ["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            if (response == "KeyAuth_Disabled")
            {
                Console.WriteLine("\n\n  This application is disabled");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
            else if (response == "KeyAuth_WrongHash")
            {
                Console.WriteLine("\n\n  Application Hash is Incorrect. This program was modified since the hash was last set.\n  Inform the application owner to 'reset app hash' in their settings");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
            else if (response == "KeyAuth_Initialized")
            {
                // optional success message. Make sure to string encrypt for security
            }
            else
            {
                Console.WriteLine("\n\n  Application Failed To Connect. Try again or contact application owner");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }

        }

        public static void login(string key, string name, string secret, string ownerid)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want
            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
                ["key"] = encryption.encrypt(key, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);

            if (response == "KeyAuth_Valid")
            {
                // optional success message. Make sure to string encrypt for security
                File.WriteAllText(@"C:\ProgramData\keyauthkeysave.txt", key);
            }
            else if (response == "KeyAuth_Invalid")
            {
                Console.WriteLine("\n\n  Key not found.");
                File.Delete(@"C:\ProgramData\keyauthkeysave.txt");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
            else if (response == "KeyAuth_InvalidHWID")
            {
                Console.WriteLine("\n\n  This computer doesn't match the computer the key is locked to. If you reset your computer, contact the application owner.");
                File.Delete(@"C:\ProgramData\keyauthkeysave.txt");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
            else if (response == "KeyAuth_Expired")
            {
                Console.WriteLine("\n\n  This key is expired.");
                File.Delete(@"C:\ProgramData\keyauthkeysave.txt");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n\n  Failed to connect to login.");
                File.Delete(@"C:\ProgramData\keyauthkeysave.txt");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
        }

        public static bool level(string level,string key, string name, string secret, string ownerid)
        {

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want
            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("level")),
                ["key"] = encryption.encrypt(key, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);

            if (response == level)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

            public static string checksum(string filename)
        {
            string result;
            using (MD5 md = MD5.Create())
            {
                using (FileStream fileStream = File.OpenRead(filename))
                {
                    byte[] value = md.ComputeHash(fileStream);
                    result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
                }
            }
            return result;
        }

        private static string req(NameValueCollection post_data) {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] = "KeyAuth";

                    ServicePointManager.ServerCertificateValidationCallback = others.pin_public_key;

                    var raw_response = client.UploadValues("https://keyauth.com/api/", post_data);

                    ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };

                    return Encoding.Default.GetString(raw_response);
                }
            }
            catch (System.Net.WebException exception)
            {
                Console.WriteLine("\n\n  SSL Pin Error. Please try again with apps that modify network activity closed/disabled.");
                Thread.Sleep(3500);
                Environment.Exit(0);
                return "lmao"; 
            }
        }
    }

    public static class others {
        public static DateTime unix_to_date(double unixTimeStamp) =>
    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();

        public static bool pin_public_key(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
            certificate.GetPublicKeyString() == "0480126A944139DFDCF7808EF35430F592F6C1BDDEF3AB693563B3521FFBBA907E0A44F99FF43B8A1D68CA89778AA06BEA97A72EFF4C1BBAB49F9B84F154D57944";
    }

    public static class encryption {
        public static string byte_arr_to_str(byte[] ba) {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] str_to_byte_arr(string hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string encrypt_string(string plain_text, byte[] key, byte[] iv) {
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            using (MemoryStream mem_stream = new MemoryStream()) {
                using (ICryptoTransform aes_encryptor = encryptor.CreateEncryptor()) {
                    using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_encryptor, CryptoStreamMode.Write)) {
                        byte[] p_bytes = Encoding.Default.GetBytes(plain_text);

                        crypt_stream.Write(p_bytes, 0, p_bytes.Length);

                        crypt_stream.FlushFinalBlock();

                        byte[] c_bytes = mem_stream.ToArray();

                        return byte_arr_to_str(c_bytes);
                    }
                }
            }
        }

        public static string decrypt_string(string cipher_text, byte[] key, byte[] iv) {
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            using (MemoryStream mem_stream = new MemoryStream()) {
                using (ICryptoTransform aes_decryptor = encryptor.CreateDecryptor()) {
                    using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_decryptor, CryptoStreamMode.Write)) {
                        byte[] c_bytes = str_to_byte_arr(cipher_text);

                        crypt_stream.Write(c_bytes, 0, c_bytes.Length);

                        crypt_stream.FlushFinalBlock();

                        byte[] p_bytes = mem_stream.ToArray();

                        return Encoding.Default.GetString(p_bytes, 0, p_bytes.Length);
                    }
                }
            }
        }

        public static string iv_key() =>
            Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));

        public static string sha256(string r) =>
            byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));

        public static string encrypt(string message, string enc_key, string iv) {
            byte[] _key = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));

            byte[] _iv = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));

            return encrypt_string(message, _key, _iv);
        }

        public static string decrypt(string message, string enc_key, string iv) {
            byte[] _key = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));

            byte[] _iv = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));

            return decrypt_string(message, _key, _iv);
        }

        public static DateTime unix_to_date(double unixTimeStamp) =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();

        public static bool pin_public_key(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
            certificate.GetPublicKeyString() == "0480126A944139DFDCF7808EF35430F592F6C1BDDEF3AB693563B3521FFBBA907E0A44F99FF43B8A1D68CA89778AA06BEA97A72EFF4C1BBAB49F9B84F154D57944";
    }

    }

