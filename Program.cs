using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.Odbc;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            OdbcConnection odbcConnect = new OdbcConnection("Driver={SQL Server};Server=manoj-in09;Database=config;Uid=manoj_n;Pwd=test@123;");
            string att1=null, att2= null;
            odbcConnect.Open();

            XmlDocument doc = new XmlDocument();
            doc.Load("C:/Users/manoj/source/repos/ConsoleApp4/sample1.xml");
            //XmlNodeList list = doc.GetElementsByTagName("appSettings");
            XmlNodeList root = doc.GetElementsByTagName("appSettings");
            Console.WriteLine(root);
            foreach(XmlElement node in root[0])
            {
                //Console.WriteLine(node.Attributes[1].Value);
                att1 = node.Attributes[0].Value;
                att2 = node.Attributes[1].Value;
                OdbcCommand command = new OdbcCommand("Insert into attValues(KeyValue, ValueKey) values ('" + att1 + "','" + att2 + "')", odbcConnect);
                command.ExecuteNonQuery();

            }
            // Console.WriteLine(node.Attributes[0].Value + "\t");//+node.ChildNodes.);

            //command.Parameters.AddWithValue("@att1", att1);
            //command.Parameters.AddWithValue("@att2", att2);
            
            odbcConnect.Close();
            Console.ReadLine();
        }
    }
}
