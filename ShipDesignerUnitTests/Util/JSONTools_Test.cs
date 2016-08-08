using System.IO;
using SimpleJSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine.Utility;
using System.Collections.Generic;

namespace Util
{
	[TestClass]
	public class GetJSONNode_Test
	{
		[TestMethod]
		public void JSONTools_NullValueForNullInput()
		{
			string emptyString = null;
			JSONNode node = JSONTools.GetJSONNode(emptyString);
			Assert.IsNull(node);
		}

		[TestMethod]
		public void JSONTools_NullValueForBadFilePathInput()
		{
			string badFilePath = "This is a bad file path";
			JSONNode node = JSONTools.GetJSONNode(badFilePath);
			Assert.IsNull(node);
		}

		[TestMethod]
		public void JSONTools_NotNullValueForWellFormedJSON()
		{
			string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "Util", "TestNameInputFile.json");

			JSONNode node = JSONTools.GetJSONNode(inputFile);

			Assert.IsNotNull(node);
		}

		[TestMethod]
		public void JSONTools_JSONArrayReturnsNotNullList()
		{
			string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "Util", "TestNameInputFile.json");

			List<string> list = JSONTools.GetJsonArrayAsList(inputFile, "Name");

			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void JSONTools_JSONArrayReturnsNonEmptyStringsInList()
		{
			string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "Util", "TestNameInputFile.json");

			List<string> list = JSONTools.GetJsonArrayAsList(inputFile, "Name");

			bool notEmpty = true;
			foreach(string item in list)
			{
				if (item.Equals(""))
					notEmpty = false;
			}

			Assert.IsTrue(notEmpty);
		}
	}
}
