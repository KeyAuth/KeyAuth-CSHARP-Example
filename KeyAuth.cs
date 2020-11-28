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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Security.Principal;

namespace KeyAuth {
    public class api {

        public void init(string name, string secret, string ownerid) {
            try {

                var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

                var values_to_upload = new NameValueCollection {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = init_iv
                };

                var response = req(values_to_upload);

                response = encryption.decrypt(response, secret, init_iv);

                if (response == "KeyAuth_Disabled") {
                Console.WriteLine("\n\n  This application is disabled");
		Thread.Sleep(3500);
		return;
                }
                else if (response == "KeyAuth_Initialized") {
                // optional success message. Make sure to string encrypt for security
                }
                else
		{
                Console.WriteLine("\n\n  Application Failed To Connect. Try again or contact application owner");
		Thread.Sleep(3500);
		return;
                }
                


            }
            catch (CryptographicException) {
                messagebox.show("Invalid API/Encryption key", messagebox.icons.error);

                return;
            }
        }

        public void login(string key, string name, string secret, string ownerid) {
            string hwid = WindowsIdentity.GetCurrent().User.Value;
	    var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want
            var values_to_upload = new NameValueCollection {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
                ["key"] = encryption.encrypt(key, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);

	    if (response == "KeyAuth_Valid") {
// optional success message. Make sure to string encrypt for security
	    }
            else if (response == "KeyAuth_Invalid") {
            Console.WriteLine("\n\n  Key not found.");
	    Thread.Sleep(3500);
	    return;
            }
            else if (response == "KeyAuth_InvalidHWID") {
            Console.WriteLine("\n\n  This computer doesn't match the computer the key is locked to. If you reset your computer, contact the application owner.");
	    Thread.Sleep(3500);
	    return;
            }
            else if (response == "KeyAuth_Expired") {
            Console.WriteLine("\n\n  This key is expired.");
	    Thread.Sleep(3500);
	    return;
            }
	    else
            {
            Console.WriteLine("\n\n  Failed to connect to login.");
	    Thread.Sleep(3500);
	    return;
            }
        }

        private string req(NameValueCollection post_data) {
            using (WebClient client = new WebClient()) {
                client.Headers["User-Agent"] = "KeyAuth";

                // ServicePointManager.ServerCertificateValidationCallback = others.pin_public_key;

                var raw_response = client.UploadValues("https://keyauth.com/api/", post_data);

                // ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };

                return Encoding.Default.GetString(raw_response);
            }
        }
    }

    public static class others {
        public static DateTime unix_to_date(double unixTimeStamp) =>
    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();

        public static bool pin_public_key(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
            certificate.GetPublicKeyString() == "3082010A0282010100C7429D4B4591E50FE4B3ABDA72DB3F3EA578E12B9CD4E228E4EDFAC3F9681F354C913386A13E88181D1B14D91723FB50770C5DC94FCA59D4DEE4F6632041EFE76C3B6BCFF6B8F5B38AF92547D04BD08AF71087B094F5DFE8760C8CD09A3771836807588B02282BEC7C4CD73EE7C650C0A7C7F36F2FA56DA17E892B2760C4C75950EA5C90CD4EA301EC0CBC36B8372FE8515A7131CC6DF13A97D95B94C6A92AC4E5BFF217FCB20B3C01DB085229E919555D426D919E9A9F0D4C599FE7473FA7DBDE9B33279E2FC29F6CE09FA1269409E4A82175C8E0B65723DB6F856A53E3FD11363ADD63D1346790A3E4D1E454D1714ECED9815A0F85C5019C0D4DC3D58234C10203010001";
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
            certificate.GetPublicKeyString() == "3082010A0282010100C7429D4B4591E50FE4B3ABDA72DB3F3EA578E12B9CD4E228E4EDFAC3F9681F354C913386A13E88181D1B14D91723FB50770C5DC94FCA59D4DEE4F6632041EFE76C3B6BCFF6B8F5B38AF92547D04BD08AF71087B094F5DFE8760C8CD09A3771836807588B02282BEC7C4CD73EE7C650C0A7C7F36F2FA56DA17E892B2760C4C75950EA5C90CD4EA301EC0CBC36B8372FE8515A7131CC6DF13A97D95B94C6A92AC4E5BFF217FCB20B3C01DB085229E919555D426D919E9A9F0D4C599FE7473FA7DBDE9B33279E2FC29F6CE09FA1269409E4A82175C8E0B65723DB6F856A53E3FD11363ADD63D1346790A3E4D1E454D1714ECED9815A0F85C5019C0D4DC3D58234C10203010001";
    }

    public static class messagebox {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWND, string message, string caption, uint icon);

        public enum icons : long {
            exclamation = 0x00000030L,
            warning = 0x00000030L,
            information = 0x00000040L,
            asterisk = 0x00000040L,
            question = 0x00000020L,
            stop = 0x00000010L,
            error = 0x00000010L,
            hand = 0x00000010L
        }

        public static int show(string text, icons ico) {
            return MessageBox((IntPtr)0, text, "cAuth", (uint)ico);
        }
    }

    public class json_wrapper {
        public static bool is_serializable(Type to_check) =>
            to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);

        public json_wrapper(object obj_to_work_with) {
            current_object = obj_to_work_with;

            var object_type = current_object.GetType();

            serializer = new DataContractJsonSerializer(object_type);

            if (!is_serializable(object_type))
                throw new Exception($"the object {current_object} isn't a serializable");
        }


        public object string_to_object(string json) {
            var buffer = Encoding.Default.GetBytes(json);

            //SerializationException = session expired

            using (var mem_stream = new MemoryStream(buffer))
                return serializer.ReadObject(mem_stream);
        }

        private DataContractJsonSerializer serializer;

        private object current_object;
    }
}
