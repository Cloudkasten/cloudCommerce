using System;
using System.Windows.Forms;

namespace cloudCommerceNetWebApiClient
{
	static class Program
	{
		public static string AppName { get { return "cloudCommerce.Net Web API Client v.1.3"; } }
		public static string ConsumerName { get { return "My shopping data consumer v.1.3"; } }

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
