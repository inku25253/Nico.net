using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CookedCookie
{
	internal class BrowserChrome :IBrowser, IDisposable
	{
		public static string GoogleChromeCookiePath
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\User Data\Default\Cookies");
			}
		}
		private const string TempChromeCookie = "tmp\\ChromeCookies";
		private static readonly UTF8Encoding encoding = new UTF8Encoding();
		SQLiteConnection sql_connection;
		public BrowserChrome()
		{
			InitSql();
		}
		private void InitSql()
		{
			if(File.Exists(TempChromeCookie))
				File.Delete(TempChromeCookie);
			Directory.CreateDirectory("tmp");
			File.Copy(GoogleChromeCookiePath, TempChromeCookie);
			sql_connection = new SQLiteConnection("Data Source=" + TempChromeCookie);
			sql_connection.Open();

		}

		#region IBrowser メンバー

		public void GetContainer(Uri uri, CookieContainer result)
		{


			string sqlQuery = "SELECT host_key,name,value,path,encrypted_value FROM cookies";

			using(var command = sql_connection.CreateCommand())
			{

				if(uri != null)
				{
					string host_key = "." + uri.Host;
					sqlQuery += " WHERE host_key=@host_key";
					command.Parameters.Add(new SQLiteParameter("host_key", host_key));
				}
				command.CommandText = sqlQuery;
				var reader = command.ExecuteReader();


				while(reader.Read())
				{
					string host = reader["host_key"] as string;
					string name = reader["name"] as string;
					string value = reader["value"] as string;
					string path = reader["path"] as string;
					byte[] encrypted_value = reader["encrypted_value"] as byte[];

					if(string.IsNullOrEmpty(value))
					{
						byte[] rawData = ProtectedData.Unprotect(encrypted_value, null, DataProtectionScope.CurrentUser);
						value = encoding.GetString(rawData);
					}
					if(string.IsNullOrEmpty(name) == false)
					{
						try
						{
							result.Add(new Cookie(name, value, path, host));
						}
						catch(CookieException ex) { Console.WriteLine("Invalid Cookie: " + host); }
					}
				}
			}

		}

		#endregion

		#region IDisposable メンバー

		public void Dispose()
		{
			sql_connection.Dispose();
			try
			{
				Directory.Delete("tmp", true);
			}
			catch(IOException) { }
		}

		#endregion
	}
}
