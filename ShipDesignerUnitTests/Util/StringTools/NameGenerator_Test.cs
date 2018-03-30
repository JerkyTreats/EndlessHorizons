using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using System;
using Engine.Utility;
using System.Threading;
using System.Collections.Generic;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class NameGenerator_Test
	{
		[OneTimeSetUp]
		public void Init()
		{
			Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
		}

		[Test]
		public void NameGenerator_TestInputFileExists()
		{
			Assert.IsTrue(File.Exists(Helpers.GetInputFile()));
		}

		[Test]
		public void NameGenerator_ReturnsNotNullForWellFormedData()
		{
			string generatedName = NameGenerator.GenerateRandomName(Helpers.GetInputFile(),"Name");
			Trace.WriteLine(generatedName);
			Assert.IsNotNull(generatedName);
		}

		[Test]
		public void NameGenerator_ReturnStringDifferentFromInputString()
		{
			string inputName = "Azeby"; //Found in TestNameInputFile.json
			string generatedName = NameGenerator.GenerateRandomName(Helpers.GetInputFile(),"Name");
			Assert.AreNotEqual(inputName, generatedName);
		}

		[Test]
		public void NameGenerator_Meta_GenerateFileOfRandomNames()
		{
			string path = GetPath("random_names");
			using (StreamWriter outputFile = new StreamWriter(path))
			{
				for (int i = 0; i <= 100; i++)
				{
					string generatedName = NameGenerator.GenerateRandomName(Helpers.GetInputFile("planet_input"), "Name");
					Trace.WriteLine(generatedName);
					outputFile.WriteLine(generatedName);
					Thread.Sleep(20);
				}
			}
		}

		[Test]
		public void NameGenerator_Meta_GenerateFileOfMarkovNames()
		{
			Random rnd = new Random();
			string path = GetPath("markov_names");
			string input = Helpers.GetInputFile("planet_input");
			List<string> inputs = JSONTools.GetJsonArrayAsList(input, "Name");

			using (StreamWriter outputFile = new StreamWriter(path))
			{
				for (int i = 0; i <= 100; i++)
				{
					string generatedName = NameGenerator.GenerateMarkovName(inputs ,rnd);
					Trace.WriteLine(generatedName);
					outputFile.WriteLine(generatedName);
					//Thread.Sleep(20);
				}
			}
		}

		[Test]
		public void NameGenerator_ReturnedNameIsCapitalizedCorrectly()
		{
			Random rnd = new Random();
			string generatedName = NameGenerator.GenerateMarkovName(JSONTools.GetJsonArrayAsList(Helpers.GetInputFile("planet_input"), "Name"), rnd);

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
