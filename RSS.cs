using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Carteleria_Digital
{
    public class RSS:ContenidoBanner
    {
        public virtual string descripcion { get; set; }

        public RSS() { }

        public RSS(string url1,string desc)
        {
            this.texto = url1;
            this.descripcion = desc;
        }

        /// <summary>
        /// Obtiene el texto del RSS proveniente de la URL cargada en la clase
        /// </summary>
        /// <returns></returns>
           public override string obtenerTexto()
           {
               XmlDocument elXML = new XmlDocument();
               try
               {   //Carga el archivo RSS desde la URL entrante
                        elXML.Load(texto);   
                       // Carga los items del archivo RSS
                       XmlNodeList nodosRss = elXML.SelectNodes("rss/channel/item");
                       StringBuilder contenidoDelRss = new StringBuilder();
                
                       // Itera a travez de los items del RSS
                       foreach (XmlNode nodoRSS in nodosRss)
                       {
                           XmlNode subNodo = nodoRSS.SelectSingleNode("title");
                           string titulo = subNodo != null ? subNodo.InnerText : "";

                           subNodo = nodoRSS.SelectSingleNode("description");
                           string descripcion = subNodo != null ? subNodo.InnerText : "";

                           contenidoDelRss.Append("  " + titulo + "  " + descripcion);
                       }
                       //Almacena en un archivo txt el RSS leido
                       using (StreamWriter textoDeArchivo = new StreamWriter("rssanterior.txt"))
                           {
                             textoDeArchivo.WriteLine(contenidoDelRss.ToString());
                           }

                       // Retorna el string que contiene los items del RSS
                             XDocument doc = XDocument.Parse(contenidoDelRss.ToString());
                             return doc.ToString();
                   }
                   catch
                   {   //Si no se tiene exito al leer la URL, carga el ultimo RSS leido. Si tampoco exite el archivo, devuelve una cadena informando el error.
                               try {
                                  using (StreamReader readtext = new StreamReader("rssanterior.txt"))
                                    {return readtext.ReadToEnd();}
                                   } catch { return " ERROR "; }
                    }
           }
    }
}
