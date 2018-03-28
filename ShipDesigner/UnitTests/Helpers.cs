using System.IO;

namespace ShipDesignerUnitTests
{
    public static class Helpers
    {
        public static string GetInputFile()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Util", "TestNameInputFile.json");
        }

        public static string GetInputFile(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Util", (fileName + ".json"));
        }

        public static string GetRootDirectory()
        {
            string parent = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
            return Path.Combine(parent, "ShipDesigner");
        }
    }
}
