# KeyAuth-CSHARP-Example
KeyAuth CSHARP Example For The https://keyauth.cc Authentication system.

**What is KeyAuth?**

KeyAuth is an Open source authentication system with cloud hosting plans as well. Client SDKs available for C++, C#, Python, Rust, PHP, JS, GO, Ruby and VB.NET. KeyAuth has several unique features such as memory streaming, webhook function where you can send requests to API without leaking the API, discord webhook notifications, ban the user securely through the application at your discretion. Feel free to join https://discord.gg/keyauth If you are experiencing account issues.

**Customer connection issues?**

This is common amongst all authentication systems. Program obfuscation causes false positives in virus scanners, and with the scale of KeyAuth this is perceived as a malicious domain. So, `keyauth.com` and `keyauth.win` have been blocked by many internet providers. for dashbord, reseller panel, customer panel, use `keyauth.cc`

For API, `keyauth.cc` will not work because I purposefully blocked it on there so `keyauth.cc` doesn't get blocked also. So, you should create your own domain and follow this tutorial video https://www.youtube.com/watch?v=a2SROFJ0eYc. The tutorial video shows you how to create a domain name for 100% free if you don't want to purchase one.

**`KeyAuthApp` instance definition**

Visit and select your application, then click on the **C#** tab

It'll provide you with the code which you should replace with in the `Program.cs` file (or `Login.cs` file if using Form example)

```cs
public static api KeyAuthApp = new api(
    name: "example",
    ownerid: "JjPMBVlIOd",
    secret: "db40d586f4b189e04e5c18c3c94b7e72221be3f6551995adc05236948d1762bc",
    version: "1.0"
);
```

**Initialize application**

You must call this function prior to using any other KeyAuth function. Otherwise the other KeyAuth function won't work.

```cs
KeyAuthApp.init();
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
```

**Display application information**

```cs
Console.WriteLine("\n App data:");
Console.WriteLine(" Number of users: " + KeyAuthApp.app_data.numUsers);
Console.WriteLine(" Number of online users: " + KeyAuthApp.app_data.numOnlineUsers);
Console.WriteLine(" Number of keys: " + KeyAuthApp.app_data.numKeys);
Console.WriteLine(" Application Version: " + KeyAuthApp.app_data.version);
Console.WriteLine(" Customer panel link: " + KeyAuthApp.app_data.customerPanelLink);
```

**Check session validation**

Use this to see if the user is logged in or not.

```cs
KeyAuthApp.check();
Console.WriteLine($" Current Session Validation Status: {KeyAuthApp.response.message}");
```

**Check blacklist status**

Check if HWID or IP Address is blacklisted. You can add this if you want, just to make sure nobody can open your program for less than a second if they're blacklisted. Though, if you don't mind a blacklisted user having the program for a few seconds until they try to login and register, and you care about having the quickest program for your users, you shouldn't use this function then. If a blacklisted user tries to login/register, the KeyAuth server will check if they're blacklisted and deny entry if so. So the check blacklist function is just auxiliary function that's optional.

```cs
if(KeyAuthApp.checkblack()) {
    Environment.Exit(0);  // terminate program if user blacklisted.
}
```

**Login with username/password**

```cs
string username;
string password;
Console.WriteLine("\n\n Enter username: ");
username = Console.ReadLine();
Console.WriteLine("\n\n Enter password: ");
password = Console.ReadLine();
KeyAuthApp.login(username, password);
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
```

**Register with username/password/key**

```cs
string username;
string password;
string key;
Console.WriteLine("\n\n Enter username: ");
username = Console.ReadLine();
Console.WriteLine("\n\n Enter password: ");
password = Console.ReadLine();
Console.WriteLine("\n\n Enter license: ");
key = Console.ReadLine();
KeyAuthApp.register(username, password, key);
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
```

**Upgrade user username/key**

Used so the user can add extra time to their account by claiming new key.

> **Warning**
> No password is needed to upgrade account. So, unlike login, register, and license functions - you should **not** log user in after successful upgrade.

```
string username;
string password;
string key;
Console.WriteLine("\n\n Enter username: ");
username = Console.ReadLine();
Console.WriteLine("\n\n Enter license: ");
key = Console.ReadLine();
KeyAuthApp.upgrade(username, key);
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
```

**Login with just license key**

Users can use this function if their license key has never been used before, and if it has been used before. So if you plan to just allow users to use keys, you can remove the login and register functions from your code.

```cs
string key;
Console.WriteLine("\n\n Enter license: ");
key = Console.ReadLine();
KeyAuthApp.license(key);
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
```

**Login with web loader**

Have your users login through website. Tutorial video here https://www.youtube.com/watch?v=9-qgmsUUCK4 you can use your own domain for customer panel also, https://www.youtube.com/watch?v=iHQe4GLvgaE

```cs
KeyAuthApp.web_login();

Console.WriteLine("\n Waiting for button to be clicked");
KeyAuthApp.button("close");
```

**User Data**

Show information for current logged-in user.

```cs
Console.WriteLine("\n User data:");
Console.WriteLine(" Username: " + KeyAuthApp.user_data.username);
Console.WriteLine(" IP address: " + KeyAuthApp.user_data.ip);
Console.WriteLine(" Hardware-Id: " + KeyAuthApp.user_data.hwid);
Console.WriteLine(" Created at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.createdate)));
if (!String.IsNullOrEmpty(KeyAuthApp.user_data.lastlogin)) // don't show last login on register since there is no last login at that point
    Console.WriteLine(" Last login at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.lastlogin)));
Console.WriteLine(" Your subscription(s):");
for (var i = 0; i < KeyAuthApp.user_data.subscriptions.Count; i++)
{
    Console.WriteLine(" Subscription name: " + KeyAuthApp.user_data.subscriptions[i].subscription + " - Expires at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.subscriptions[i].expiry)) + " - Time left in seconds: " + KeyAuthApp.user_data.subscriptions[i].timeleft);
}
```

**Check subscription name of user**

If you want to wall off parts of your app to only certain users, you can have multiple subscriptions with different names. Then, when you create licenses that correspond to the level of that subscription, users who use those licenses will get a subscription with the name of the subscription that corresponds to the level of the license key they used. The `SubExist` function is in the `Program.cs` file

```cs
if (SubExist("default", KeyAuthApp.user_data.subscriptions.Count))
{
    Console.WriteLine(" Default Subscription Exists");
}
// See if another sub exists with name 
if (SubExist("premium", KeyAuthApp.user_data.subscriptions.Count))
{
    Console.WriteLine(" Premium Subscription Exists");
}
```

**Show list of online users**

```cs
var onlineUsers = KeyAuthApp.fetchOnline();
if (onlineUsers != null)
{
    Console.Write("\n Online users: ");
    foreach (var user in onlineUsers)
    {
        Console.Write(user.credential + ", ");
    }
    Console.WriteLine("\n");
}
```

**Application variables**

A string that is kept on the server-side of KeyAuth. On the dashboard you can choose for each variable to be authenticated (only logged in users can access), or not authenticated (any user can access before login). These are global and static for all users, unlike User Variables which will be dicussed below this section.

```cs
string appvar = KeyAuthApp.var("variableNameHere");
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
else
    Console.WriteLine("\n App variable data: " + appvar);
```

**User Variables**

User variables are strings kept on the server-side of KeyAuth. They are specific to users. They can be set on Dashboard in the Users tab, via SellerAPI, or via your loader using the code below. `discord` is the user variable name you fetch the user variable by. `test#0001` is the variable data you get when fetching the user variable.

```cs
KeyAuthApp.setvar("discord", "test#0001");
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
else
    Console.WriteLine("\n Successfully set user variable");
```

And here's how you fetch the user variable:

```cs
string uservar = KeyAuthApp.getvar("discord");
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
else
    Console.WriteLine("\n User variable value: " + uservar);
```

**Application Logs**

Can be used to log data. Good for anti-debug alerts and maybe error debugging. If you set Discord webhook in the app settings of the Dashboard, it will send log messages to your Discord webhook rather than store them on site. It's recommended that you set Discord webhook, as logs on site may be deleted after a couple months of their creation.

You can use the log function before login & after login.

```cs
KeyAuthApp.log("hello I wanted to log this");
```

**Ban the user**

Ban the user and blacklist their HWID and IP Address. Good function to call upon if you use anti-debug and have detected an intrusion attempt.

Function only works after login.

```cs
KeyAuthApp.ban();
```

**Server-sided webhooks**

Tutorial video https://www.youtube.com/watch?v=ENRaNPPYJbc

Send HTTP requests to URLs securely without leaking the URL in your application. You should definitely use if you want to send requests to SellerAPI from your application, otherwise if you don't use you'll be leaking your seller key to everyone. And then someone can mess up your application.

1st example is how to send request with no POST data. just a GET request to the URL. `7kR0UedlVI` is the webhook ID, `https://keyauth.win/api/seller/?sellerkey=sellerkeyhere&type=black` is what you should put as the webhook endpoint on the dashboard. This is the part you don't want users to see. And then you have `&ip=1.1.1.1&hwid=abc` in your program code which will be added to the webhook endpoint on the keyauth server and then the request will be sent.

2nd example includes post data. it is form data. it is an example request to the KeyAuth API. `7kR0UedlVI` is the webhook ID, `https://keyauth.win/api/1.2/` is the webhook endpoint.

3rd examples included post data though it's JSON. It's an example reques to Discord webhook `7kR0UedlVI` is the webhook ID, `https://discord.com/api/webhooks/...` is the webhook endpoint.

```cs
// example to send normal request with no POST data
string resp = KeyAuthApp.webhook("7kR0UedlVI", "&ip=1.1.1.1&hwid=abc");

// example to send form data
resp = KeyAuthApp.webhook("7kR0UedlVI", "", "type=init&name=test&ownerid=j9Gj0FTemM", "application/x-www-form-urlencoded");

// example to send JSON
resp = KeyAuthApp.webhook("7kR0UedlVI", "", "{\"content\": \"webhook message here\",\"embeds\": null}", "application/json"); // if Discord webhook message successful, response will be empty

if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
else
    Console.WriteLine("\n Response received from webhook request: " + resp);
```

**Download file**

Keep files secure by providing KeyAuth your file download link on the KeyAuth dashboard. Make sure this is a direct download link (as soon as you go to the link, it starts downloading without you clicking anything). The KeyAuth download function provides the bytes, and then you get to decide what to do with those. This example shows how to write it to a file named `text.txt` in the same folder as the program, though you could execute with RunPE or whatever you want.

`385624` is the webhook ID you get from the dashboard after adding file.

```cs
byte[] result = KeyAuthApp.download("385624");
if (!KeyAuthApp.response.success)
{
    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
    Thread.Sleep(1500);
    Environment.Exit(0);
}
else
    File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\test.txt", result);
```

**Chat channels**

Allow users to communicate amongst themselves in your program.

Example from the form example on how to fetch the chat messages.

```cs
var messages = Login.KeyAuthApp.chatget("chatChannelNameHere");
if (messages == null)
{
    dataGridView1.Rows.Insert(0, "KeyAuth", "No Chat Messages", UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds()));
}
else
{
    foreach (var message in messages)
    {
        dataGridView1.Rows.Insert(0, message.author, message.message, UnixTimeToDateTime(long.Parse(message.timestamp)));
    }
}
```

Example from the form example on how to send chat message.

```cs
if (Login.KeyAuthApp.chatsend(chatmsg.Text, chatchannel))
{
    dataGridView1.Rows.Insert(0, Login.KeyAuthApp.user_data.username, chatmsg.Text, UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds()));
}
else
    chatmsg.Text = "Status: " + Login.KeyAuthApp.response.message;
```
