﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace TestSecond.Utils
//{
//    public class Utils
//    {
        
//        public static User GetInfoFromFile()
//        {
//            User user = new User();
//            XmlDocument xmlDoc = new XmlDocument();

//            try
//            {
//                xmlDoc.Load("C:\\Учёба БГТУ\\3 курс\\6 семестр\\Лабораторные\\Тестирование программного обеспечения\\lab11\\TestSecond\\Input.xml");

//                user.username = xmlDoc.SelectSingleNode("/credentials/login").InnerText;
//                user.password = xmlDoc.SelectSingleNode("/credentials/password").InnerText;

//                return user;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
//                return null;
//            }
//        }
//        public static string GetQuantitySymbols(string str)
//        {
//            return str.Length.ToString();
//        }
//        public static string RemoveQuotes(string input)
//        {
//            string resultStr = input.Replace("«", "");
//            resultStr = resultStr.Replace("»", "");
//            return resultStr;
//        }
//    }
//}
