using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Grade_Calculator_by_John_Chittam
{
    public static class Serializer
    {
        public static void Serialize(List<CategoryData> categoryData, string fileName)
        {
            var folder = Application.UserAppDataPath;
            var writer = new StreamWriter($"{folder}\\{fileName}.xml");
            var serializer = new XmlSerializer(typeof(List<CategoryData>));
            serializer.Serialize(writer, categoryData);
        }

        public static List<CategoryData> Deserialize(string fileName)
        {
            try
            {
                var folder = Application.UserAppDataPath;
                var reader = new StreamReader($"{folder}\\{fileName}.xml");
                var serializer = new XmlSerializer(typeof(List<CategoryData>));
                return (List<CategoryData>)serializer.Deserialize(reader);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
