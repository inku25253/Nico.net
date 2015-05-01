using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nico.net
{
	public class NicoXmlRegistry
	{
		private static readonly Dictionary<string,Type> dataClasses = new Dictionary<string, Type>();
		static NicoXmlRegistry()
		{
			Regist(typeof(NicoAlertInfo));	// <getalertstatus>
			Regist(typeof(NicoResponse));	// <chat>
			Regist(typeof(NicoThread));		// <thread>
		}



		public static void Regist(Type xmldataclass)
		{
			var attributes = xmldataclass.GetCustomAttributes(typeof(XmlRootAttribute), false);
			if(attributes.Length <= 0)
				throw new ArgumentException("xmldataclassにXmlRoot属性が含まれていません。");

			XmlRootAttribute xmlroot_attribute = (XmlRootAttribute)attributes[0];

			dataClasses.Add(xmlroot_attribute.ElementName, xmldataclass);
		}
		public static object Deserialize(string xml)
		{
			string xmlname = xml.Split(new[] { ' ' }, 2)[0].Substring(1);

			if(dataClasses.ContainsKey(xmlname) == false)
			{
				throw new InvalidOperationException("未登録のデータを受信しました。: " + xmlname);
			}
			Type classType = dataClasses[xmlname];

			XmlSerializer serializer = new XmlSerializer(classType);

			return serializer.Deserialize(new StringReader(xml));
		}

	}
}
