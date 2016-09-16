# WCF RESTService Skeleton
A simple skeleton for a WCF based REST Service.  Provides examples for GET, POST, and SyndicationFeed.  This should allow anyone to get a REST service up and running in seconds.  Originally built with Mono and MonoDevelop, but should work without an issue with Visual Studio and DotNet.

As this code is clearly a functionless skeleton, I release this code without any caveats.  For those who care, I have attached the MIT license to make things simple. 

## Getting Started

Using the Release Configuration, set the WCFRESTServiceHost as your start up project.  Hit F5, and wait for the console window to appear.  You will be able to accept REST requests when a console window with the following appears:
```
WCF REST Service is currently listening on port: 12345
Press any key to stop service...
```

You can issue a response to the service by simply calling the following:
```
curl http://localhost:12345/ReturnExample/
```
You should get this as your response:
```
{"MeaningfulNumber": 42, "Name":"Adams"}
```

### Unit Testing a WCF Service

An example of how one might Unit Test a WCF service is also included.  To unit test the WCF service, we make use of the Moq and WCFMock libraries to mock the WebOperationContext.  

If one observes "WCFRESTService.cs", they would notice this using statement:
```
#if DEBUG
using WebOperationContext = System.ServiceModel.Web.MockedWebOperationContext;
#endif
```
This statement is a compiler directive which inserts the using line during the DEBUG configuration only.  This line will force the WebOperationContext to utilize the mocked WebOperationContext from WCFMock.dll.
