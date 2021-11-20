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
using System.Collections.Generic;
using System.Windows;

namespace KeyAuth
{
    public class api
    {
        public string name, ownerid, secret, version;
        public api(string name, string ownerid, string secret, string version)
        {

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
            {
                error("Application not setup correctly. Please watch video link found in Program.cs");
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

            [DataMember]
            public List<msg> messages { get; set; }
        }

        public class msg
        {
            public string message { get; set; }
            public string author { get; set; }
            public string timestamp { get; set; }
        }

        [DataContract]
        private class user_data_structure
        {
            [DataMember]
            public string username { get; set; }

            [DataMember]
            public string ip { get; set; }
            [DataMember]
            public string hwid { get; set; }
            [DataMember]
            public string createdate { get; set; }
            [DataMember]
            public string lastlogin { get; set; }
            [DataMember]
            public List<Data> subscriptions { get; set; } // array of subscriptions (basically multiple user ranks for user with individual expiry dates
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
                ["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
                ["enckey"] = encryption.encrypt(enckey, secret, init_iv),
                ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                ["init_iv"] = init_iv
            };

            var response = req(values_to_upload);


            if (response == "KeyAuth_Invalid")
            {
                error("Application not found");
                Environment.Exit(0);
            }

            response = encryption.decrypt(response, secret, init_iv);
            var json = response_decoder.string_to_generic<response_structure>(response);

            if (json.success)
            {
                sessionid = json.sessionid;
                initzalized = true;
            }
            else if (json.message == "invalidver")
            {
                Process.Start(json.download);
                Environment.Exit(0);
            }
            else
            {
                error(json.message);
                Environment.Exit(0);
            }

        }

        public void register(string username, string pass, string key)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
            }
            else
            {
                load_user_data(json.info);
                // optional success msg
            }
        }

        public void login(string username, string pass)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
            }
            else
            {
                load_user_data(json.info);
                // optional success msg
            }
        }

        public void upgrade(string username, string key)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
            }
            else
            {
                // optional success msg
            }
        }

        public void license(string key)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
            }
            else
            {
                // optional success msg
                load_user_data(json.info);
            }
        }

        public void setvar(string var, string data)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar")),
                ["var"] = encryption.encrypt(var, enckey, init_iv),
                ["data"] = encryption.encrypt(data, enckey, init_iv),
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
                error(json.message);
                Environment.Exit(0);
            }
            else
            {
                // optional success msg
            }
        }

        public string getvar(string var)
        {

            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar")),
                ["var"] = encryption.encrypt(var, enckey, init_iv),
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
                error(json.message);
                Environment.Exit(0);
                return null;
            }
            else
            {
                // optional success msg
                return json.response;
            }
        }

        public void ban()
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
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
                error("Please initzalize first");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
                return null;
            }
            else
            {
                return json.message;
            }
        }

        public List<msg> chatget(string channelname)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget")),
                ["channel"] = encryption.encrypt(channelname, enckey, init_iv),
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
                error(json.message);
                Environment.Exit(0);
                return null;
            }
            else
            {
                return json.messages;
            }
        }

        public bool chatsend(string msg, string channelname)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend")),
                ["message"] = encryption.encrypt(msg, enckey, init_iv),
                ["channel"] = encryption.encrypt(channelname, enckey, init_iv),
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
                error(json.message);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkblack()
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var init_iv = encryption.sha256(encryption.iv_key());

            var values_to_upload = new NameValueCollection
            {
                ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist")),
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
                return false;
            }
            else
            {
                return true;
            }
        }

        public void webhook(string webid, string param)
        {
            if (!initzalized)
            {
                error("Please initzalize first");
                Environment.Exit(0);
            }

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
                error(json.message);
                Environment.Exit(0);
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
                error("Please initzalize first. File is empty since no request could be made.");
                Environment.Exit(0);
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
                error(json.message);
                Environment.Exit(0);
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
                error("Please initzalize first");
                Environment.Exit(0);
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
        public static void error(string message)
        {
            Process.Start(new ProcessStartInfo("cmd.exe", $"/c start cmd /C \"color b && title Error && echo {message} && timeout /t 5\"")
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            });
            Environment.Exit(0);
        }
        private static string req(NameValueCollection post_data)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var raw_response = client.UploadValues("https://keyauth.win/api/1.0/", post_data);

                    return Encoding.Default.GetString(raw_response);
                }
            }
            catch (WebException webex)
            {
                var response = (HttpWebResponse)webex.Response;
                switch (response.StatusCode)
                {
                    case (HttpStatusCode)429: // client hit our rate limit
                        error("You're connecting too fast to loader, slow down.");
                        Environment.Exit(0);
                        return "";
                        break;
                    default: // site won't resolve. you should use keyauth.uk domain since it's not blocked by any ISPs
                        error("Connection failure. Please try again, or contact us for help.");
                        Environment.Exit(0);
                        return "";
                }
            }
        }


        #region user_data
        public user_data_class user_data = new user_data_class();

        public class user_data_class
        {
            public string username { get; set; }
            public string ip { get; set; }
            public string hwid { get; set; }
            public string createdate { get; set; }
            public string lastlogin { get; set; }
            public List<Data> subscriptions { get; set; } // array of subscriptions (basically multiple user ranks for user with individual expiry dates
        }
        public class Data
        {
            public string subscription { get; set; }
            public string expiry { get; set; }
            public string timeleft { get; set; }
        }

        private void load_user_data(user_data_structure data)
        {
            user_data.username = data.username;
            user_data.ip = data.ip;
            user_data.hwid = data.hwid;
            user_data.createdate = data.createdate;
            user_data.lastlogin = data.lastlogin;
            user_data.subscriptions = data.subscriptions; // array of subscriptions (basically multiple user ranks for user with individual expiry dates 
        }
        #endregion

        private json_wrapper response_decoder = new json_wrapper(new response_structure());
    }

    public static class encryption
    {
        public static string byte_arr_to_str(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] str_to_byte_arr(string hex)
        {
            try
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }
            catch
            {
                MessageBox.Show("The session has ended, open program again.");
                Environment.Exit(0);
                return null;
            }
        }

        public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
        {
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            using (MemoryStream mem_stream = new MemoryStream())
            {
                using (ICryptoTransform aes_encryptor = encryptor.CreateEncryptor())
                {
                    using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_encryptor, CryptoStreamMode.Write))
                    {
                        byte[] p_bytes = Encoding.Default.GetBytes(plain_text);

                        crypt_stream.Write(p_bytes, 0, p_bytes.Length);

                        crypt_stream.FlushFinalBlock();

                        byte[] c_bytes = mem_stream.ToArray();

                        return byte_arr_to_str(c_bytes);
                    }
                }
            }
        }

        public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
        {
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            using (MemoryStream mem_stream = new MemoryStream())
            {
                using (ICryptoTransform aes_decryptor = encryptor.CreateDecryptor())
                {
                    using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_decryptor, CryptoStreamMode.Write))
                    {
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

        public static string encrypt(string message, string enc_key, string iv)
        {
            byte[] _key = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));

            byte[] _iv = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));

            return encrypt_string(message, _key, _iv);
        }

        public static string decrypt(string message, string enc_key, string iv)
        {
            byte[] _key = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));

            byte[] _iv = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));

            return decrypt_string(message, _key, _iv);
        }
    }

    public class json_wrapper
    {
        public static bool is_serializable(Type to_check) =>
            to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);

        public json_wrapper(object obj_to_work_with)
        {
            current_object = obj_to_work_with;

            var object_type = current_object.GetType();

            serializer = new DataContractJsonSerializer(object_type);

            if (!is_serializable(object_type))
                throw new Exception($"the object {current_object} isn't a serializable");
        }

        public object string_to_object(string json)
        {
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