using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookedCookie
{
	public class BrowserType
	{
		public static readonly BrowserType Other = new BrowserType(null);
		[Obsolete("IEは未対応！", true)]
		public static readonly BrowserType IE = new BrowserType(null);
		public static readonly BrowserType Chrome = new BrowserType(new BrowserChrome());



		internal IBrowser CookieReaderClass { get; private set; }
		private BrowserType(IBrowser browser)
		{
			this.CookieReaderClass = browser;
			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
		}

		void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			if(CookieReaderClass != null)
				CookieReaderClass.Dispose();
		}
	}
}
