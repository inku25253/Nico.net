using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CookedCookie
{
	public class CookieOven
	{



		public static CookieContainer GetCookie(Uri uri, BrowserType type)
		{
			CookieContainer result = new CookieContainer();
			type.CookieReaderClass.GetContainer(uri, result);
			return result;
		}
	}
}
