using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;

namespace WCFRestService
{
	public class WCFRESTService : IWCFRESTService
	{
		/// <summary>
		/// Example on how to return an object via the service
		/// </summary>
		/// <returns>Your serializable object</returns>
		public ExampleObject ReturnExample()
		{
			ExampleObject returnValue = new ExampleObject ();
			returnValue.Name = "Adams";
			returnValue.MeaningfulNumber = 42;
			WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			return returnValue;
		}

		/// <summary> 
		/// Example on how to post a JSON object to the service
		/// </summary>
		/// <param name="inputObject">A Serializable Object (JSON)</param>
		public void PostExample(ExampleObject inputObject)
		{
			if(inputObject == null)
				WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
			if (inputObject.MeaningfulNumber == 42) {
				WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
				WebOperationContext.Current.OutgoingResponse.Headers.Add ("Location", @"http://en.wikipedia.org/wiki/42_(number)#The_Hitchhiker.27s_Guide_to_the_Galaxy");
			} else {
				WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			}	
		}

		/// <summary>
		/// Example on how to return an RSS Feed
		/// </summary>
		/// <param name="input">Your input via the URL parameter</param>
		/// <returns>RSS Feed</returns>
		public SyndicationFeedFormatter ReturnFeed(string input)
		{
			SyndicationFeed queryFeed = new SyndicationFeed("WCF REST Example", "RSS Feed", new Uri("http://www.google.ca/"), "ExampleID", DateTime.UtcNow);

			List<SyndicationItem> resultItems = new List<SyndicationItem> ();

			SyndicationItem newResultItem = new SyndicationItem();
			newResultItem.Id = Guid.NewGuid().ToString();
			newResultItem.Title = new TextSyndicationContent("Canadian Bacon");
			newResultItem.BaseUri = new Uri("http://www.google.ca/");
			newResultItem.AttributeExtensions.Add(new XmlQualifiedName("DateTimeUTC"), DateTime.UtcNow.ToString());
			newResultItem.AttributeExtensions.Add(new XmlQualifiedName("ARandomString"), Guid.NewGuid().ToString());
			newResultItem.AttributeExtensions.Add(new XmlQualifiedName("YourInputValue"), input);
			resultItems.Add (newResultItem);

			queryFeed.AttributeExtensions.Add(new XmlQualifiedName("TotalResults"), resultItems.Count.ToString());
			queryFeed.Items = resultItems;
			return new Rss20FeedFormatter(queryFeed);
		}
	}
}