# Unofficial BaasBox .Net SDK
BaasBox is an Open Source project that aims to provide a backend for mobile and web apps.

Further information can be found at [www.baasbox.com](http://www.baasbox.com/ "BaasBox site").

BaasBox .Net SDK targets: Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin.Android, Xamarin.iOS, Xamarin.iOS (Classic) and should work on any system which supports .Net 4.5.

# BaasBox .Net SDK
This SDK is still under development. At this moment it has:

1. User management (registration, login, change/reset password, logout)
2. Collection management (create, delete)
3. Documents management (create, retrieve, search, modify, delete)

There is a big bunch of functionality missing (social, push notifications, files, etc), so feel free to make requests, report issues or even better - to contribute to this project.

# How to use
1. Add a reference to BaasBoxNet project
2. Create a `BaasBox` client object: <br />`var box = new BaasBox("<server_ip>", "<appcode>");`
3. Use it! At first you need to signup or login with your user. This can be done with `BaasBox.UserManagement.SignupAsync` or `BaasBox.UserManagement.LoginAsync`.<br />***Hint:*** register instances of `IBaasBoxUserManagement`, `IBaasBoxCollections` and `IBaasBoxDocuments` in your DI container and use them instead of direct call to BaasBox client object.
4. Create first collection. <br />`await box.Collections.CreateAsync(CollectionName);`
5. Create class that inherits from `BaasDocument`. Create default constructor and set `BaasDocumentClass` property to your collection name.
6. Create instance of your `BaasDocument` object and put it into cloud via <br />`await box.Documents.CreateAsync(CollectionName);`

Please refer to `BBWPDemo` project. It is a simple Windows Phone application which just shows how to use basic SDK functionality.

# ToDo
1. Add more validations to SDK methods.
2. Wrap all SDK exceptions into `BaasException`.
3. Implement more original SDK methods.
