using System.Xml;

namespace DapperRepoWinForm.Utilities
{
    class ConnectionDB
    {

        public static string xml_conn(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/Conexion");
            string proServer = "", proDatabase = "", proUser = "", proPassword = "";

            foreach (XmlNode node in nodeList)
            {
                proServer = node.SelectSingleNode("Server").InnerText;
                proDatabase = node.SelectSingleNode("Database").InnerText;
                proUser = node.SelectSingleNode("User").InnerText;
                proPassword = node.SelectSingleNode("Password").InnerText;
              
            }
            return ("Server = " + proServer + "; Database =" + proDatabase + "; User Id = " + proUser + ";Password = " + proPassword + ";");

        }

    }
}
