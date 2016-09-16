using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace WCFRESTServiceHost
{
	class MainClass
	{
		/// <summary>
		/// Example on how to self host a WCF Service.
		/// </summary>
		public static void Main (string[] args)
		{
			int port = 12345;
			Uri baseAddress = new Uri(string.Format("http://localhost:{0}/", port));
			using (WebServiceHost host = new WebServiceHost (typeof(WCFRestService.WCFRESTService), baseAddress)) {
				ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
				sdb.IncludeExceptionDetailInFaults = true;						
				host.Open();
				Console.WriteLine (string.Format("WCF REST Service is currently listening on port: {0}", port));
				Console.WriteLine ("Press any key to stop service...");
				Console.ReadLine ();
				host.Close(); 
			}
		}
	}
}
