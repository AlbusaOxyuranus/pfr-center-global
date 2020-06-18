using System;
using System.Reflection;

namespace PFRCenterGlobal.Helpers
{
    public class HelperVersion
    {
        private static HelperVersion _instance;

        public HelperVersion() { }

        public static HelperVersion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HelperVersion();
                }
                return _instance;
            }
        }

        private static string versionToStr = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /*"Версия: " +
         Assembly.GetExecutingAssembly().GetName().HelperVersion + " Build " + "\n(" +
         new FileInfo(Assembly.GetExecutingAssembly().FullName).LastWriteTime.ToString("yyyy.MM.dd-HH:mm") + ")";
         */
        //static string _nameDeveloper =  (AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
        //           typeof(AssemblyProductAttribute));
        public static string VersionValue
        {
            get { return versionToStr; }
            set { versionToStr = value; }

        }
        static string getNameDeveloper;
        public static string GetNameDeveloper
        {
            get
            {

                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                getNameDeveloper = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                return getNameDeveloper;
            }
            set { getNameDeveloper = value; }
        }
    }
}


