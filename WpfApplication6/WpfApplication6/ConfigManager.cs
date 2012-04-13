using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
namespace WpfApplication6
{
    public static class ConfigManager
    {
        public static string StorageFileName = ConfigurationManager.AppSettings["StorageFileName"];
        public static string GoodsFileName = ConfigurationManager.AppSettings["GoodsFileName"];
      
    }
}
