using System;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Security.Principal;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Threading;
using Cryptographic;
using System.Runtime.InteropServices;

namespace KeyAuth
{
    public class api
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();

        // Import the required Atom Table functions from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern ushort GlobalAddAtom(string lpString);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern ushort GlobalFindAtom(string lpString);

        public string name, ownerid, version, path, seed;

        private static readonly object _sigLock = new object();
        private static readonly object _sessionLock = new object();
        private static readonly object _networkLock = new object();

        /// <summary>
        /// Set up your application credentials in order to use keyauth
        /// </summary>
        /// <param name="name">Application Name</param>
        /// <param name="ownerid">Your OwnerID, found in your account settings.</param>
        /// <param name="version">Application Version, if version doesnt match it will open the download link you set up in your application settings and close the app, if empty the app will close</param>
        public api(string name, string ownerid, string version, string path = null)
        {
            if (ownerid.Length != 10)
            {
                Process.Start("https://youtube.com/watch?v=RfDTdiBq4_o");
                Process.Start("https://keyauth.cc/app/");
                Thread.Sleep(2000);
                error("Application not setup correctly. Please watch the YouTube video for setup.");
                TerminateProcess(GetCurrentProcess(), 1);
            }

            this.name = name;

            this.ownerid = ownerid;

            this.version = version;

            this.path = path;
        }

        #region structures
        [DataContract]
        private class response_structure
        {
            [DataMember]
            public bool success { get; set; }

            [DataMember]
            public bool newSession { get; set; }

            [DataMember]
            public string sessionid { get; set; }

            [DataMember]
            public string contents { get; set; }

            [DataMember]
            public string response { get; set; }

            [DataMember]
            public string message { get; set; }

            [DataMember]
            public string ownerid { get; set; }

            [DataMember]
            public string download { get; set; }

            [DataMember(IsRequired = false, EmitDefaultValue = false)]
            public user_data_structure info { get; set; }

            [DataMember(IsRequired = false, EmitDefaultValue = false)]
            public app_data_structure appinfo { get; set; }

            [DataMember]
            public List<msg> messages { get; set; }

            [DataMember]
            public List<users> users { get; set; }

            [DataMember(Name = "2fa", IsRequired = false, EmitDefaultValue = false)] // Ensure mapping to "2fa"
            public TwoFactorData twoFactor { get; set; } // Add a property for the 2FA data
        }

        public class msg
        {
            public string message { get; set; }
            public string author { get; set; }
            public string timestamp { get; set; }
        }

        public class users
        {
            public string credential { get; set; }
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

        [DataContract]
        private class app_data_structure
        {
            [DataMember]
            public string numUsers { get; set; }
            [DataMember]
            public string numOnlineUsers { get; set; }
            [DataMember]
            public string numKeys { get; set; }
            [DataMember]
            public string version { get; set; }
            [DataMember]
            public string customerPanelLink { get; set; }
            [DataMember]
            public string downloadLink { get; set; }
        }
        #endregion
        private static string sessionid, enckey;
        bool initialized;
        /// <summary>
        /// Initializes the connection with keyauth in order to use any of the functions
        /// </summary>
        public void init()
        {
            lock (_sessionLock)
            {
                Random random = new Random();

                // Generate a random length for the string (let's assume between 5 and 50 characters)
                int length = random.Next(5, 51); // Min length: 5, Max length: 50

                StringBuilder sb = new StringBuilder(length);

                // Define the range of printable ASCII characters (32-126)
                for (int i = 0; i < length; i++)
                {
                    // Generate a random printable ASCII character
                    char randomChar = (char)random.Next(32, 127); // ASCII 32 to 126
                    sb.Append(randomChar);
                }

                seed = sb.ToString();
                checkAtom();

                var values_to_upload = new NameValueCollection
                {
                    ["type"] = "init",
                    ["ver"] = version,
                    ["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
                    ["name"] = name,
                    ["ownerid"] = ownerid
                };

                if (!string.IsNullOrEmpty(path))
                {
                    values_to_upload.Add("token", File.ReadAllText(path));
                    values_to_upload.Add("thash", TokenHash(path));
                }

                var response = req(values_to_upload);

                if (response == "KeyAuth_Invalid")
                {
                    error("Application not found");
                    TerminateProcess(GetCurrentProcess(), 1);
                }

                var json = response_decoder.string_to_generic<response_structure>(response);
                if (json.ownerid == ownerid)
                {
                    load_response_struct(json);
                    if (json.success)
                    {
                        sessionid = json.sessionid;
                        initialized = true;
                    }
                    else if (json.message == "invalidver")
                    {
                        app_data.downloadLink = json.download;
                    }
                }
                else
                {
                    TerminateProcess(GetCurrentProcess(), 1);
                }
            }
        }

        void checkAtom()
        {
            Thread atomCheckThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(60000); // give people 1 minute to login

                    ushort foundAtom = GlobalFindAtom(seed);
                    if (foundAtom == 0)
                    {
                        TerminateProcess(GetCurrentProcess(), 1);
                    }
                }
            });

            atomCheckThread.IsBackground = true; // Ensure the thread does not block program exit
            atomCheckThread.Start();
        }

        public static string TokenHash(string tokenPath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var s = File.OpenRead(tokenPath))
                {
                    byte[] bytes = sha256.ComputeHash(s);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }
        /// <summary>
        /// Checks if Keyauth is been Initalized
        /// </summary>
        public void CheckInit()
        {
            if (!initialized)
            {
                error("You must run the function KeyAuthApp.init(); first");
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }

        /// <summary>
        /// Converts Unix time to Days,Months,Hours
        ///</summary>
        /// <param name="subscription">Subscription Number</param>
        /// <param name="Type">You can choose between Days,Hours,Months </param>
        public string expirydaysleft(string Type, int subscription)
        {
            CheckInit();

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(long.Parse(user_data.subscriptions[subscription].expiry)).ToLocalTime();
            TimeSpan difference = dtDateTime - DateTime.Now;
            switch (Type.ToLower())
            {
                case "months":
                    return Convert.ToString(difference.Days / 30);
                case "days":
                    return Convert.ToString(difference.Days);
                case "hours":
                    return Convert.ToString(difference.Hours);
            }
            return null;

        }

        /// <summary>
        /// Registers the user using a license and gives the user a subscription that matches their license level
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="pass">Password</param>
        /// <param name="key">License key</param>
        public void register(string username, string pass, string key, string email = "")
        {
            CheckInit();

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "register",
                ["username"] = username,
                ["pass"] = pass,
                ["key"] = key,
                ["email"] = email,
                ["hwid"] = hwid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                GlobalAddAtom(seed);
                GlobalAddAtom(ownerid);

                load_response_struct(json);
                if (json.success)
                    load_user_data(json.info);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Allow users to enter their account information and recieve an email to reset their password.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        public void forgot(string username, string email)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "forgot",
                ["username"] = username,
                ["email"] = email,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
        }
        /// <summary>
        /// Authenticates the user using their username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="pass">Password</param>
        public void login(string username, string pass, string code = null)
        {
            CheckInit();

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "login",
                ["username"] = username,
                ["pass"] = pass,
                ["hwid"] = hwid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid,
                ["code"] = code ?? null
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                GlobalAddAtom(seed);
                GlobalAddAtom(ownerid);

                load_response_struct(json);
                if (json.success)
                    load_user_data(json.info);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }

        public void logout()
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "logout",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }

        public void web_login()
        {
            CheckInit();

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            string datastore, datastore2, outputten;

        start:

            HttpListener listener = new HttpListener();

            outputten = "handshake";
            outputten = "http://localhost:1337/" + outputten + "/";

            listener.Prefixes.Add(outputten);

            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse responsepp = context.Response;

            responsepp.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            responsepp.AddHeader("Access-Control-Allow-Origin", "*");
            responsepp.AddHeader("Via", "hugzho's big brain");
            responsepp.AddHeader("Location", "your kernel ;)");
            responsepp.AddHeader("Retry-After", "never lmao");
            responsepp.Headers.Add("Server", "\r\n\r\n");

            if (request.HttpMethod == "OPTIONS")
            {
                responsepp.StatusCode = (int)HttpStatusCode.OK;
                Thread.Sleep(1); // without this, the response doesn't return to the website, and the web buttons can't be shown
                listener.Stop();
                goto start;
            }

            listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
            listener.UnsafeConnectionNtlmAuthentication = true;
            listener.IgnoreWriteExceptions = true;

            string data = request.RawUrl;

            datastore2 = data.Replace("/handshake?user=", "");
            datastore2 = datastore2.Replace("&token=", " ");

            datastore = datastore2;

            string user = datastore.Split()[0];
            string token = datastore.Split(' ')[1];

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "login",
                ["username"] = user,
                ["token"] = token,
                ["hwid"] = hwid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            bool success = true;
            if (json.ownerid == ownerid)
            {
                GlobalAddAtom(seed);
                GlobalAddAtom(ownerid);

                load_response_struct(json);

                if (json.success)
                {
                    load_user_data(json.info);

                    responsepp.StatusCode = 420;
                    responsepp.StatusDescription = "SHEESH";
                }
                else
                {
                    Console.WriteLine(json.message);
                    responsepp.StatusCode = (int)HttpStatusCode.OK;
                    responsepp.StatusDescription = json.message;
                    success = false;
                }
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }

            byte[] buffer = Encoding.UTF8.GetBytes("Complete");

            responsepp.ContentLength64 = buffer.Length;
            Stream output = responsepp.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            Thread.Sleep(1); // without this, the response doesn't return to the website, and the web buttons can't be shown
            listener.Stop();

            if (!success)
                TerminateProcess(GetCurrentProcess(), 1);

        }

        /// <summary>
        /// Use Buttons from KeyAuth Customer Panel
        /// </summary>
        /// <param name="button">Button Name</param>

        public void button(string button)
        {
            CheckInit();

            HttpListener listener = new HttpListener();

            string output;

            output = button;
            output = "http://localhost:1337/" + output + "/";

            listener.Prefixes.Add(output);

            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse responsepp = context.Response;

            responsepp.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            responsepp.AddHeader("Access-Control-Allow-Origin", "*");
            responsepp.AddHeader("Via", "hugzho's big brain");
            responsepp.AddHeader("Location", "your kernel ;)");
            responsepp.AddHeader("Retry-After", "never lmao");
            responsepp.Headers.Add("Server", "\r\n\r\n");

            responsepp.StatusCode = 420;
            responsepp.StatusDescription = "SHEESH";

            listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
            listener.UnsafeConnectionNtlmAuthentication = true;
            listener.IgnoreWriteExceptions = true;

            listener.Stop();
        }

        /// <summary>
        /// Gives the user a subscription that has the same level as the key
        /// </summary>
        /// <param name="username">Username of the user thats going to get upgraded</param>
        /// <param name="key">License with the same level as the subscription you want to give the user</param>
        public void upgrade(string username, string key)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "upgrade",
                ["username"] = username,
                ["key"] = key,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                json.success = false;
                load_response_struct(json);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }

        /// <summary>
        /// Authenticate without using usernames and passwords
        /// </summary>
        /// <param name="key">Licence used to login with</param>
        public void license(string key, string code = null)
        {
            CheckInit();

            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "license",
                ["key"] = key,
                ["hwid"] = hwid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid,
                ["code"] = code ?? null
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);

            if (json.ownerid == ownerid)
            {
                GlobalAddAtom(seed);
                GlobalAddAtom(ownerid);

                load_response_struct(json);
                if (json.success)
                    load_user_data(json.info);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Checks if the current session is validated or not
        /// </summary>
        public void check()
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "check",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Disable two factor authentication (2fa)
        /// </summary>
        public void disable2fa(string code)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "2fadisable",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid,
                ["code"] = code
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
        }
        /// <summary>
        /// Enable two factor authentication (2fa)
        /// </summary>
        public void enable2fa(string code = null)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "2faenable",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid,
                ["code"] = code
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);

            if (json.success)
            {
                if (code == null) // First time enabling 2FA, no code provided
                {
                    // Display the secret code to the user
                    Clipboard.SetText(json.twoFactor.SecretCode);
                    System.Windows.MessageBox.Show($"Your 2FA Secret Code has been copied to your clipboard! \n\n: {json.twoFactor.SecretCode}", "2FA Secret");

                }
                else // Code provided by the user
                {
                    System.Windows.MessageBox.Show("2FA has been successfully enabled!", "2FA Setup");
                }
            }
            else
            {
                Thread.Sleep(3000);
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Change the data of an existing user variable, *User must be logged in*
        /// </summary>
        /// <param name="var">User variable name</param>
        /// <param name="data">The content of the variable</param>
        public void setvar(string var, string data)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "setvar",
                ["var"] = var,
                ["data"] = data,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Gets the an existing user variable
        /// </summary>
        /// <param name="var">User Variable Name</param>
        /// <returns>The content of the user variable</returns>
        public string getvar(string var)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "getvar",
                ["var"] = var,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
                if (json.success)
                    return json.response;
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
            return null;
        }
        /// <summary>
        /// Bans the current logged in user
        /// </summary>
        public void ban(string reason = null)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "ban",
                ["reason"] = reason,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
        /// <summary>
        /// Gets an existing global variable
        /// </summary>
        /// <param name="varid">Variable ID</param>
        /// <returns>The content of the variable</returns>
        public string var(string varid)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "var",
                ["varid"] = varid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
                if (json.success)
                    return json.message;
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
            return null;
        }
        /// <summary>
        /// Fetch usernames of online users
        /// </summary>
        /// <returns>ArrayList of usernames</returns>
        public List<users> fetchOnline()
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "fetchOnline",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);

            if (json.success)
                return json.users;
            return null;
        }
        /// <summary>
        /// Fetch app statistic counts
        /// </summary>
        public void fetchStats()
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "fetchStats",
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);

            if (json.success)
                load_app_data(json.appinfo);
        }
        /// <summary>
        /// Gets the last 50 sent messages of that channel
        /// </summary>
        /// <param name="channelname">The channel name</param>
        /// <returns>the last 50 sent messages of that channel</returns>
        public List<msg> chatget(string channelname)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "chatget",
                ["channel"] = channelname,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
            if (json.success)
            {
                return json.messages;
            }
            return null;
        }
        /// <summary>
        /// Sends a message to the given channel name
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="channelname">Channel Name</param>
        /// <returns>If the message was sent successfully, it returns true if not false</returns>
        public bool chatsend(string msg, string channelname)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "chatsend",
                ["message"] = msg,
                ["channel"] = channelname,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
            if (json.success)
                return true;
            return false;
        }
        /// <summary>
        /// Checks if the current ip address/hwid is blacklisted
        /// </summary>
        /// <returns>If found blacklisted returns true if not false</returns>
        public bool checkblack()
        {
            CheckInit();
            string hwid = WindowsIdentity.GetCurrent().User.Value;

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "checkblacklist",
                ["hwid"] = hwid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
                if (json.success)
                    return true;
                else
                    return false;
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
            return true; // return yes blacklisted if the OwnerID is spoofed
        }
        /// <summary>
        /// Sends a request to a webhook that you've added in the dashboard in a safe way without it being showed for example a http debugger
        /// </summary>
        /// <param name="webid">Webhook ID</param>
        /// <param name="param">Parameters</param>
        /// <param name="body">Body of the request, empty by default</param>
        /// <param name="conttype">Content type, empty by default</param>
        /// <returns>the webhook's response</returns>
        public string webhook(string webid, string param, string body = "", string conttype = "")
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "webhook",
                ["webid"] = webid,
                ["params"] = param,
                ["body"] = body,
                ["conttype"] = conttype,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            if (json.ownerid == ownerid)
            {
                load_response_struct(json);
                if (json.success)
                    return json.response;
            }
            else
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
            return null;
        }
        /// <summary>
        /// KeyAuth acts as proxy and downlods the file in a secure way
        /// </summary>
        /// <param name="fileid">File ID</param>
        /// <returns>The bytes of the download file</returns>
        public byte[] download(string fileid)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {

                ["type"] = "file",
                ["fileid"] = fileid,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
            if (json.success)
                return encryption.str_to_byte_arr(json.contents);
            return null;
        }
        /// <summary>
        /// Logs the IP address,PC Name with a message, if a discord webhook is set up in the app settings, the log will get sent there and the dashboard if not set up it will only be in the dashboard
        /// </summary>
        /// <param name="message">Message</param>
        public void log(string message)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "log",
                ["pcuser"] = Environment.UserName,
                ["message"] = message,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            req(values_to_upload);
        }
        /// <summary>
        /// Change the username of a user, *User must be logged in*
        /// </summary>
        /// <param username="username">New username.</param>
        public void changeUsername(string username)
        {
            CheckInit();

            var values_to_upload = new NameValueCollection
            {
                ["type"] = "changeUsername",
                ["newUsername"] = username,
                ["sessionid"] = sessionid,
                ["name"] = name,
                ["ownerid"] = ownerid
            };

            var response = req(values_to_upload);

            var json = response_decoder.string_to_generic<response_structure>(response);
            load_response_struct(json);
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
            string folder = @"Logs", file = Path.Combine(folder, "ErrorLogs.txt");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(file))
            {
                using (FileStream stream = File.Create(file))
                {
                    File.AppendAllText(file, DateTime.Now + " > This is the start of your error logs file");
                }
            }

            File.AppendAllText(file, DateTime.Now + $" > {message}" + Environment.NewLine);

            Process.Start(new ProcessStartInfo("cmd.exe", $"/c start cmd /C \"color b && title Error && echo {message} && timeout /t 5\"")
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            });
            TerminateProcess(GetCurrentProcess(), 1);
        }

        private static string req(NameValueCollection post_data)
        {
            lock (_networkLock)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Proxy = null;

                        ServicePointManager.ServerCertificateValidationCallback += assertSSL;

                        var raw_response = client.UploadValues("https://keyauth.win/api/1.3/", post_data);

                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                        sigCheck(Encoding.UTF8.GetString(raw_response), client.ResponseHeaders, post_data.Get(0));

                        Logger.LogEvent(Encoding.Default.GetString(raw_response) + "\n");

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
                            Logger.LogEvent("You're connecting too fast to loader, slow down.");
                            TerminateProcess(GetCurrentProcess(), 1);
                            return "";
                        default: // site won't resolve. you should use keyauth.uk domain since it's not blocked by any ISPs
                            error("Connection failure. Please try again, or contact us for help.");
                            Logger.LogEvent("Connection failure. Please try again, or contact us for help.");
                            TerminateProcess(GetCurrentProcess(), 1);
                            return "";
                    }
                }
            }
        }

        private static bool assertSSL(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if ((!certificate.Issuer.Contains("Google Trust Services") && !certificate.Issuer.Contains("Let's Encrypt")) || sslPolicyErrors != SslPolicyErrors.None)
            {
                error("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. & echo: & echo If not, ask the developer of the program to use custom domains to fix this.");
                Logger.LogEvent("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. If not, ask the developer of the program to use custom domains to fix this.");
                return false;
            }
            return true;
        }

        private static void sigCheck(string resp, WebHeaderCollection headers, string type)
        {
            if (type == "log" || type == "file") // log doesn't return a response.
            {
                return;
            }
            lock (_sigLock)
            {

                try
                {
                    string signature = headers["x-signature-ed25519"];
                    string timestamp = headers["x-signature-timestamp"];

                    // Try to parse the input string to a long Unix timestamp
                    if (!long.TryParse(timestamp, out long unixTimestamp))
                    {
                        TerminateProcess(GetCurrentProcess(), 1);
                    }

                    // Convert the Unix timestamp to a DateTime object (in UTC)
                    DateTime timestampTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;

                    // Get the current UTC time
                    DateTime currentTime = DateTime.UtcNow;

                    // Calculate the difference between the current time and the timestamp
                    TimeSpan timeDifference = currentTime - timestampTime;

                    // Check if the timestamp is within 20 seconds of the current time
                    if (timeDifference.TotalSeconds > 20)
                    {
                        TerminateProcess(GetCurrentProcess(), 1);
                    }

                    var byteSig = encryption.str_to_byte_arr(signature);
                    var byteKey = encryption.str_to_byte_arr("5586b4bc69c7a4b487e4563a4cd96afd39140f919bd31cea7d1c6a1e8439422b");
                    // ... read the body from the request ...
                    // ... add the timestamp and convert it to a byte[] ...
                    string body = timestamp + resp;
                    var byteBody = Encoding.Default.GetBytes(body);

                    Console.Write(" Authenticating"); // there's also ... dots being created inside the CheckValid() function BELOW

                    bool signatureValid = Ed25519.CheckValid(byteSig, byteBody, byteKey); // the ... dots in the console are from this function!
                    if (!signatureValid)
                    {
                        error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
                        Logger.LogEvent(resp + "\n");
                        TerminateProcess(GetCurrentProcess(), 1);
                    }
                }
                catch
                {
                    error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
                    Logger.LogEvent(resp + "\n");
                    TerminateProcess(GetCurrentProcess(), 1);
                }
            }
        }

        #region app_data
        public app_data_class app_data = new app_data_class();

        public class app_data_class
        {
            public string numUsers { get; set; }
            public string numOnlineUsers { get; set; }
            public string numKeys { get; set; }
            public string version { get; set; }
            public string customerPanelLink { get; set; }
            public string downloadLink { get; set; }
        }

        private void load_app_data(app_data_structure data)
        {
            app_data.numUsers = data.numUsers;
            app_data.numOnlineUsers = data.numOnlineUsers;
            app_data.numKeys = data.numKeys;
            app_data.version = data.version;
            app_data.customerPanelLink = data.customerPanelLink;
        }
        #endregion

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
            public string key { get; set; }
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

        [DataContract]
        private class TwoFactorData
        {
            [DataMember(Name = "secret_code")]
            public string SecretCode { get; set; }

            [DataMember(Name = "QRCode")]
            public string QRCode { get; set; }
        }

        #region response_struct
        public response_class response = new response_class();

        public class response_class
        {
            public bool success { get; set; }
            public string message { get; set; }
        }

        private void load_response_struct(response_structure data)
        {
            response.success = data.success;
            response.message = data.message;
        }
        #endregion

        private json_wrapper response_decoder = new json_wrapper(new response_structure());
    }

    public static class Logger
    {
        public static bool IsLoggingEnabled { get; set; } = false; // Disabled by default
        public static void LogEvent(string content)
        {
            if (!IsLoggingEnabled)
            {
                //Console.WriteLine("Debug mode disabled."); // Optional: Message when logging is disabled
                return; // Exit the method if logging is disabled
            }

            string exeName = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);

            string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "KeyAuth", "debug", exeName);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFileName = $"{DateTime.Now:MMM_dd_yyyy}_logs.txt";
            string logFilePath = Path.Combine(logDirectory, logFileName);

            try
            {
                // Redact sensitive fields - Add more if you would like. 
                content = RedactField(content, "sessionid");
                content = RedactField(content, "ownerid");
                content = RedactField(content, "app");
                content = RedactField(content, "version");
                content = RedactField(content, "fileid");
                content = RedactField(content, "webhooks");
                content = RedactField(content, "nonce");

                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"[{DateTime.Now}] [{AppDomain.CurrentDomain.FriendlyName}] {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging data: {ex.Message}");
            }
        }

        private static string RedactField(string content, string fieldName)
        {
            // Basic pattern matching to replace values of sensitive fields
            string pattern = $"\"{fieldName}\":\"[^\"]*\"";
            string replacement = $"\"{fieldName}\":\"REDACTED\"";

            return System.Text.RegularExpressions.Regex.Replace(content, pattern, replacement);
        }
    }

    public static class encryption
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();

        public static string HashHMAC(string enckey, string resp)
        {
            byte[] key = Encoding.UTF8.GetBytes(enckey);
            byte[] message = Encoding.UTF8.GetBytes(resp);
            var hash = new HMACSHA256(key);
            return byte_arr_to_str(hash.ComputeHash(message));
        }

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
                api.error("The session has ended, open program again.");
                TerminateProcess(GetCurrentProcess(), 1);
                return null;
            }
        }

        public static string iv_key() =>
            Guid.NewGuid().ToString().Substring(0, 16);
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
