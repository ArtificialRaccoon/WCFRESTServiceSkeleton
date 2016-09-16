using NUnit.Framework;
using System;
using WCFRestService;
using Moq;
using System.ServiceModel;
using System.ServiceModel.Web;
using WebOperationContext = System.ServiceModel.Web.MockedWebOperationContext;

namespace WCFRESTServiceUnitTesting
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void ExampleTestCase ()
		{
			WCFRESTService restService = new WCFRESTService();
			Mock<IWebOperationContext> mockContext = new Mock<IWebOperationContext> { DefaultValue = DefaultValue.Mock };
			using (new MockedWebOperationContext (mockContext.Object)) { 
				WCFRestService.ExampleObject returnValue = restService.ReturnExample ();
				Assert.IsNotNull(returnValue);
				Assert.IsTrue(returnValue.MeaningfulNumber == 42);
				mockContext.VerifySet(x => x.OutgoingResponse.StatusCode, System.Net.HttpStatusCode.OK);
			}
		}
	}
}