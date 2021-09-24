using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

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
            public string sessionid { get; set; }

            [DataMember]
            public string contents { get; set; }

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
            public string username { get; set; }

            [DataMember]
            public List<Data> subscriptions { get; set; }
            
            [DataMember]
            public string ip { get; set; }
        }
        #endregion
        private string sessionid, enckey;
        bool initzalized;
        public void init()
        {
            enckey = encryption.sha256(encryption.iv_key());
            var init_iv = encryption.sha256(encryption.iv_key());
            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
                ["ver"] = encryption.encrypt(version, secret, init_iv),
                ["enckey"] = encryption.encrypt(enckey, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);
            

            if(response == "KeyAuth_Invalid")
            {
                MessageBox.Show("Application not found.");
                Environment.Exit(0);
            }

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);            

            if (json.success)
            {
                sessionid = json.sessionid;
                initzalized = true;
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

        public bool register(string username, string pass, string key)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return false;
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register")),
                ["username"] = encryption.encrypt(username, enckey, init_iv),
                ["pass"] = encryption.encrypt(pass, enckey, init_iv),
                ["key"] = encryption.encrypt(key, enckey, init_iv),
                ["hwid"] = encryption.encrypt(hwid, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                return false;
            }
            else
            {
                load_user_data(json.info);
                // optional success msg
                return true;
            }
        }

        public bool login(string username, string pass)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return false;
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
                ["username"] = encryption.encrypt(username, enckey, init_iv),
                ["pass"] = encryption.encrypt(pass, enckey, init_iv),
                ["hwid"] = encryption.encrypt(hwid, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                return false;
            }
            else
            {
                load_user_data(json.info);
                // optional success msg
                return true;
            }
        }

        public void upgrade(string username, string key)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return;
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade")),
                ["username"] = encryption.encrypt(username, enckey, init_iv),
                ["key"] = encryption.encrypt(key, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show(json.message);
                // optional success msg
            }
        }

        public bool license(string key)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return false;
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license")),
                ["key"] = encryption.encrypt(key, enckey, init_iv),
                ["hwid"] = encryption.encrypt(hwid, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);
            
            response = encryption.decrypt(response, enckey, init_iv);

            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                Environment.Exit(0);
                return false;
            }
            else
            {
                // optional success msg
                load_user_data(json.info);
                return true;
            }
        }

        public void ban()
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return;
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban")),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
                Environment.Exit(0);
            }
            else
            {
                // optional success msg
            }
        }

        public string var(string varid)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return "";
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var")),
                ["varid"] = encryption.encrypt(varid, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
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
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return;
            }

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook")),
                ["webid"] = encryption.encrypt(webid, enckey, init_iv),
                ["params"] = encryption.encrypt(param, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);

            response = encryption.decrypt(response, enckey, init_iv);
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

        public byte[] download(string fileid)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return new byte[0];
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file")),
                ["fileid"] = encryption.encrypt(fileid, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);
            
            response = encryption.decrypt(response, enckey, init_iv);
            
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (!json.success)
            {
                MessageBox.Show(json.message);
            }
            else
            {
                // optional success message
            }

            return encryption.str_to_byte_arr(json.contents);
        }

        public void log(string message)
        {
            if (!initzalized)
            {
                MessageBox.Show("Please initzalize first");
                return;
            }

            var init_iv = encryption.sha256(encryption.iv_key());
            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log")),
                ["pcuser"] = encryption.encrypt(Environment.UserName, enckey, init_iv),
                ["message"] = encryption.encrypt(message, enckey, init_iv),
                ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            req(values_to_upload);
        }

        private static string req(NameValueCollection post_data)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var raw_response = client.UploadValues("https://keyauth.business/1.0/", post_data);

                    return Encoding.Default.GetString(raw_response);
                }
            }
            catch 
            {
                MessageBox.Show("Connection failure. Please try again, or contact us for help.");
                Thread.Sleep(3500);
                Environment.Exit(0);
                return "nothing";
            }
        }


        #region user_data
        public user_data_class user_data = new user_data_class();

        public class user_data_class
        {
            public string username { get; set; }
            public List<Data> subscriptions { get; set; }
            public string ip { get; set; }
        }
        public class Data
        {
            public string subscription { get; set; }
            public string expiry { get; set; }
        }
        private void load_user_data(user_data_structure data) {
            user_data.username = data.username;
            user_data.ip = data.ip;
            user_data.subscriptions = data.subscriptions;
        }
        #endregion

        private json_wrapper response_decoder = new json_wrapper(new response_structure());
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

        public T string_to_generic<T>(string json) =>
            (T)string_to_object(json);

        private DataContractJsonSerializer serializer;

        private object current_object;
    }
}
