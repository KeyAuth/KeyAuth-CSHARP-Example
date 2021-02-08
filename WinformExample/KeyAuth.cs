using System;
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
using System.Threading;
using System.Windows.Forms;

namespace KeyAuth {
    public class api
    {
        public string name, ownerid, secret, version;
        public api(string name, string ownerid, string secret, string version)
        {

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
            {
                MessageBox.Show("Application not setup correctly. Please watch video link found in Login.cs");
                Environment.Exit(0);
            }

            this.name = name;

            this.ownerid = ownerid;

            this.secret = secret;

            this.version = version;
        }

        #region structures
        [DataContract]
        private class response_structure
        {
            [DataMember]
            public bool success { get; set; }

            [DataMember]
            public string response { get; set; }

            [DataMember]
            public string message { get; set; }
            
            [DataMember]
            public string download { get; set; }

            [DataMember(IsRequired = false, EmitDefaultValue = false)]
            public user_data_structure info { get; set; }
        }

        [DataContract]
        private class user_data_structure
        {
            [DataMember]
            public string key { get; set; }

            [DataMember]
            public string expiry { get; set; } //timestamp

            [DataMember]
            public int level { get; set; }
            
            [DataMember]
            public string note { get; set; }
        }
        #endregion

        public void init()
        {
            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
                ["ver"] = encryption.encrypt(version, secret, init_iv),
                ["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (json.success)
            {
                // optional success message
            }
            else if(json.message == "invalidver")
            {
                Process.Start(json.download);
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show(json.message);
                Environment.Exit(0);
            }

        }
        
        public void register(string username, string pass, string key)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register")),
                ["username"] = encryption.encrypt(username, secret, init_iv),
                ["pass"] = encryption.encrypt(pass, secret, init_iv),
                ["key"] = encryption.encrypt(key, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
            }
            else
            {
                // optional success msg
            }
        }

        public void login(string username, string pass)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
                ["username"] = encryption.encrypt(username, secret, init_iv),
                ["pass"] = encryption.encrypt(pass, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
            }
            else
            {
                // optional success msg
            }
        }

        public bool license(string key)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license")),
                ["key"] = encryption.encrypt(key, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                return false;
            }
            else
            {
                load_user_data(json.info);
                File.WriteAllText(@"C:\ProgramData\" + name, key);
                return true;
            }
        }

        public string var(string varid)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var")),
                ["key"] = encryption.encrypt(user_data.key, secret, init_iv),
                ["varid"] = encryption.encrypt(varid, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                return "";
            }
            else
            {
                return json.message;
            }
        }
        
                public void webhook(string webid, string param)
        {
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook")),
                ["key"] = encryption.encrypt(user_data.key, secret, init_iv),
                ["webid"] = encryption.encrypt(webid, secret, init_iv),
                ["params"] = encryption.encrypt(param, secret, init_iv),
                ["hwid"] = encryption.encrypt(hwid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
            }
            else
            {
                // optional success message
            }
        }

        public void download(string fileid, string path)
        {
            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file")),
                ["fileid"] = encryption.encrypt(fileid, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = dl(values_to_upload, path);
        }

        public void log(string message)
        {
            var init_iv = encryption.sha256(encryption.iv_key()); // can be changed to whatever you want
            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log")),
                ["key"] = encryption.encrypt(user_data.key, secret, init_iv),
                ["message"] = encryption.encrypt(message, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            req(values_to_upload);
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

        private static string req(NameValueCollection post_data)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] = "KeyAuth";

                    ServicePointManager.ServerCertificateValidationCallback = others.pin_public_key;

                    var raw_response = client.UploadValues("https://keyauth.com/api/v5/", post_data);

                    ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };

                    return Encoding.Default.GetString(raw_response);
                }
            }
            catch 
            {
                
                MessageBox.Show("SSL Pin Error. Please try again with apps that modify network activity closed/disabled.");
                Environment.Exit(0);
                return "lmao";
            }
        }

        private static string dl(NameValueCollection post_data, string path)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] = "KeyAuth";

                    ServicePointManager.ServerCertificateValidationCallback = others.pin_public_key;

                    byte[] result = client.UploadValues("https://keyauth.com/api/v3/", post_data);

                    ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };

                    File.WriteAllBytes(path, result);
                    return "";
                }
            }
            catch
            {

                MessageBox.Show("SSL Pin Error. Please try again with apps that modify network activity closed/disabled.");
                Environment.Exit(0);
                return "lmao";
            }
        }


        #region user_data
        public user_data_class user_data = new user_data_class();

        public class user_data_class {
            public string key { get; set; }
            public DateTime expiry { get; set; }
            public int level { get; set; }
            public string note { get; set; }
        }
        private void load_user_data(user_data_structure data) {
            user_data.key = data.key;

            user_data.expiry = others.unix_to_date(Convert.ToDouble(data.expiry));

            user_data.level = data.level;
            
            user_data.note = data.note;
        }
        #endregion

        private json_wrapper response_decoder = new json_wrapper(new response_structure());
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

        public string to_json_string() {
            using (var mem_stream = new MemoryStream()) {
                serializer.WriteObject(mem_stream, current_object);

                mem_stream.Position = 0;

                using (var reader = new StreamReader(mem_stream))
                    return reader.ReadToEnd();
            }
        }

        public object string_to_object(string json) {
            var buffer = Encoding.Default.GetBytes(json);

            //SerializationException = session expired

            using (var mem_stream = new MemoryStream(buffer))
                return serializer.ReadObject(mem_stream);
        }

        #region extras
        
        public dynamic string_to_dynamic(string json) =>
            (dynamic)string_to_object(json);

        public T string_to_generic<T>(string json) =>
            (T)string_to_object(json);

        public dynamic to_json_dynamic() =>
            string_to_object(to_json_string());

        #endregion

        private DataContractJsonSerializer serializer;

        private object current_object;
    }
}
