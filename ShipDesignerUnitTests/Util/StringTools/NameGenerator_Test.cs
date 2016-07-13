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
			string path = GetPath("random_names");
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

		[TestMethod]
		public void NameGenerator_Meta_GenerateFileOfMarkovNames()
		{
			Random rnd = new Random();
			string path = GetPath("markov_names");
			string input = Helpers.GetInputFile("planet_input");

			using (StreamWriter outputFile = new StreamWriter(path))
			{
				for (int i = 0; i <= 100; i++)
				{
					string generatedName = Util.NameGenerator.GenerateMarkovName(input,"Name",rnd);
					Trace.WriteLine(generatedName);
					outputFile.WriteLine(generatedName);
					//Thread.Sleep(20);
				}
			}
		}

		[TestMethod]
		public void NameGenerator_ReturnedNameIsCapitalizedCorrectly()
		{
			Random rnd = new Random();
			string generatedName = Util.NameGenerator.GenerateMarkovName(Helpers.GetInputFile("planet_input"), "Name", rnd);

			bool allWordsCapped = true;
			foreach(string word in generatedName.Split())
			{
				string firstLetter = word[0].ToString();
				string firstLetterCapped = firstLetter.ToUpper();
				if (firstLetter != firstLetterCapped)
					allWordsCapped = false;
			}

			Assert.IsTrue(allWordsCapped);
		}

		private string GetPath(string name)
		{

			string fileName = string.Format("unit_tests_{0}_{1}.txt", name, DateTime.Now.ToString("ddMMyyyy_hhmm_ssfff"));
			string path = Path.Combine(Directory.GetCurrentDirectory(), "output");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			path = Path.Combine(path, (fileName));
			return path;
		}
	}
}
