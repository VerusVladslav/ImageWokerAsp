using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ImageWorkerASP.NET.Images.Helper
{
    public static class Config
    {
        public static string ProductImagePath { get { return ConfigurationManager.AppSettings["ProductImagePath"]; } }
        public static string Domain { get { return ConfigurationManager.AppSettings[" DomainProject"]; } }

       
    }
}