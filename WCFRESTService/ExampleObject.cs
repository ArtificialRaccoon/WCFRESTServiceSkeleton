using System;
using System.Runtime.Serialization;

namespace WCFRestService 
{
	/// <summary>
	/// Example on how to create a serializable object which can be returned via
	/// a WCF Service.  Anything not listed as a datamember will not get
	/// written to the JSON.
	/// </summary>
	[DataContract]
	public class ExampleObject
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int MeaningfulNumber { get; set; }
	}
}