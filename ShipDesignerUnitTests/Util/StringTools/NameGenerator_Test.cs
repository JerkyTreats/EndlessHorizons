using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class NameGenerator_Test
	{
		[TestMethod]
		public void NameGenerator_TestInputFileExists()
		{
			Assert.IsTrue(File.Exists(Helpers.GetInputFile()));
		}

		[TestMethod]
		public void NameGenerator_ReturnsNotNullForWellFormedData()
		{
			string generatedName = Util.NameGenerator.GenerateRandomName(Helpers.GetInputFile(),"Name");
			Trace.WriteLine(generatedName);
			Assert.IsNotNull(generatedName);
		}

		[TestMethod]
		public void NameGenerator_ReturnStringDifferentFromInputString()
		{
			string inputName = "Azeby"; //Found in TestNameInputFile.json
			string generatedName = Util.NameGenerator.GenerateRandomName(Helpers.GetInputFile(),"Name");
			Assert.AreNotEqual(inputName, generatedName);
		}

		[TestMethod]
		public void NameGenerator_Meta_GenerateFileOfRandomNames()
		{
			string fileName = string.Format("unit_tests_random_names_{0}.txt", DateTime.Now.ToString("ddMMyyyy_hhmm_ssfff"));
			string path = Path.Combine(Directory.GetCurrentDirectory(), "output");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			path = Path.Combine(path, (fileName));

			using (StreamWriter outputFile = new StreamWriter(path))
			{
				for (int i = 0; i <= 100; i++)
				{
					string generatedName = Util.NameGenerator.GenerateRandomName(Helpers.GetInputFile("planet_input"), "Name");
					Trace.WriteLine(generatedName);
					outputFile.WriteLine(generatedName);
					Thread.Sleep(20);
				}
			}
		}
	}
}
