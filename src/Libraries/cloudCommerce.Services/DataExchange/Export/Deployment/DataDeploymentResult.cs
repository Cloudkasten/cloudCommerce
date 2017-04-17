using System;

namespace cloudCommerce.Services.DataExchange.Export.Deployment
{
	[Serializable]
	public class DataDeploymentResult
	{
		/// <summary>
		/// Whether the deployment succeeded
		/// </summary>
		public bool Succeeded
		{
			get { return LastError.IsEmpty(); }
		}

		public string LastError { get; set; }

		/// <summary>
		/// Last execution date
		/// </summary>
		public DateTime LastExecutionUtc { get; set; }
	}
}
