# Unofficial BaasBox .Net SDK
BaasBox is an Open Source project that aims to provide a backend for mobile and web apps.

Further information can be found at [www.baasbox.com](http://www.baasbox.com/ "BaasBox site").

BaasBox .Net SDK targets: Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin.Android, Xamarin.iOS, Xamarin.iOS (Classic) and should work on any system which supports .Net 4.5.

# BaasBox .Net SDK
This SDK is still under development. At this moment we have:

1. User management (registration, login, change/reset password, logout)
2. Collection management (create, delete)
3. Documents management (create, retrieve, search, modify, delete)

There is a big bunch of functionality is missing (social, push notifications, files, etc), so feel free to make request, report issues or even better - to contribute to this project.

# How to use
1. Add a reference to BaasBoxNet project
2. Create a `BaasBox` client object: `var box = new BaasBox("<server_ip>", "<appcode>");`
3. Use it! BaasBox client object have 3 fields - UserManagement, Collection and Documents, which provides access to the whole current SDK functionality.

Please refer to `BBWPDemo` project. It is a simple Windows Phone application which just shows how to use basic SDK functionality.
