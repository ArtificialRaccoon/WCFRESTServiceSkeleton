using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Syndication;

namespace WCFRestService
{
	[ServiceContract]
	[ServiceKnownType(typeof(Rss20FeedFormatter))]
	public interface IWCFRESTService
	{
		[OperationContract]
		[WebGet(UriTemplate = "ReturnExample/", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		ExampleObject ReturnExample();

		[OperationContract]
		[WebInvoke(UriTemplate = "PostExample/", BodyStyle = WebMessageBodyStyle.Bare, Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		void PostExample(ExampleObject inputObject);

		[OperationContract]
		[WebGet(UriTemplate = "ReturnFeed?q={input}", BodyStyle = WebMessageBodyStyle.Bare)]
		SyndicationFeedFormatter ReturnFeed(string input);
	}
}