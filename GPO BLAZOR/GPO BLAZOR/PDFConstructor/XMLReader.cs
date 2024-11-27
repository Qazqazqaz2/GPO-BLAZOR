using System.Runtime.Serialization.DataContracts;
using System.Xml;

namespace GPO_BLAZOR.DBAgents
{
    public abstract class XMLReader
    {
        //Здесь функция получения LINQ XML файлов, через имя папки
        // ИЛИ
        //Чтение XML калбеком

        protected IEnumerable<XmlDocument> GetDocument (string FieldName)
        {
            string[] files = Directory.GetFiles(FieldName);
            
            foreach (string file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                yield return doc;
            }
            yield break;
        }

        protected void F ()
        {
            XmlDocument document = new XmlDocument();

            XmlElement item = document.DocumentElement;

        }


    }
}
