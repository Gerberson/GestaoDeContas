using System.Globalization;
using System.Xml;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value) => !IsNullOrEmpty(value);

        public static int ToInt(this string value)
        {
            int numero;
            int.TryParse(value, out numero);
            return numero;
        }
        public static int ToInt(this uint value)
        {
            return Convert.ToInt32(value);
        }

        public static Int16 ToInt16(this string value)
        {
            Int16 numero;
            Int16.TryParse(value, out numero);
            return numero;
        }

        public static byte ToByte(this string value)
        {
            byte numero;
            byte.TryParse(value, out numero);
            return numero;
        }

        public static DateTime ToDateTime(this string value)
        {
            DateTime numero;
            DateTime.TryParse(value, out numero);
            return numero;
        }
        public static DateTimeOffset ToDateTimeOffset(this string value)
        {
            DateTimeOffset numero;
            DateTimeOffset.TryParse(value, out numero);
            return numero;
        }

        public static bool ToBool(this string value)
        {
            bool numero;
            bool.TryParse(value, out numero);
            return numero;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal numero;
            decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out numero);
            return numero;
        }

        public static double ToDouble(this string value)
        {
            double numero;
            double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out numero);
            return numero;
        }

        public static XmlDocument LoadXmlDocument(this string xml)
        {
            XmlDocument loadXml = new XmlDocument();

            if (!xml.IsNullOrEmpty())
            {
                loadXml.LoadXml(xml);
            }

            return loadXml;
        }

        public static string StringJoin(this string[] obj, string separador, string concat = "'")
        {
            string[] newObj = new string[obj.Length];
            for (int i = 0; i < obj.Length; i++)
            {
                newObj[i] = $"{concat}{obj[i]}{concat}";
            }

            return string.Join(separador, newObj);
        }

        public static string StringJoin(this int[] obj, string separador, string concat = "'")
        {
            string[] newObj = new string[obj.Length];
            for (int i = 0; i < obj.Length; i++)
            {
                newObj[i] = $"{concat}{obj[i]}{concat}";
            }

            return string.Join(separador, newObj);
        }

        public static string AttribuiteValue(this XmlDocument obj, string tag, string nameAttr)
        {
            return obj.GetElementsByTagName(tag)[0].Attributes.GetNamedItem(nameAttr).Value;
        }

        public static string AttribuiteValue(this XmlNode obj, string tag, string nameAttr)
        {
            var xml = obj.OuterXml.LoadXmlDocument();
            return xml.GetElementsByTagName(tag)[0].Attributes.GetNamedItem(nameAttr).Value;
        }

        public static string GetXmlValue(this XmlNode obj, string tag)
        {
            return obj.OuterXml.LoadXmlDocument().GetElementsByTagName(tag)[0].InnerText;
        }

        public static string GetXmlValue(this XmlDocument obj, string tag)
        {
            return obj.GetElementsByTagName(tag)[0].InnerText;
        }
    }
}
