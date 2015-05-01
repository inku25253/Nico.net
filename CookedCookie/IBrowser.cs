using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookedCookie
{
	internal interface IBrowser :IDisposable
	{

		void GetContainer(Uri uri, CookieContainer result);
	}
}
