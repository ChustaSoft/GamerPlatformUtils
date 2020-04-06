﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure
{
	public class FileRepository : IFileRepository
	{
		public FileRepository()
		{
		}

		public Dictionary<string, string> ReadXML(string path)
		{
			XDocument doc = XDocument.Load(path);
			Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

			foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
			{
				dataDictionary.Add(GetElementProperty(element, "key"), (GetElementProperty(element, "value")));
			}
			return dataDictionary;
		}

		private string GetElementProperty(XElement element, string propertyName)
		{
			return element.Attributes(propertyName).FirstOrDefault()?.Value;
		}

		public void WriteXML()
		{
			throw new NotImplementedException();
		}
	}
}
