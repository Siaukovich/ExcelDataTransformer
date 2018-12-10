using System.Configuration;

namespace Cells.Configuration
{
    public static class ConfigValues
    {
        public static string CsvFileFullPath { get; set; }

        public static string ExcelTableFullPath { get; set; }

        static ConfigValues()
        {
            CsvFileFullPath = GetValueFromConfig("csvFileFullPath");
            ExcelTableFullPath = GetValueFromConfig("excelTableFullPath");
        }

        private static string GetValueFromConfig(string key) => ConfigurationManager.AppSettings[key];
    }
}
