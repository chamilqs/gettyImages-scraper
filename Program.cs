using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL de la página web que deseas escrapear
            // Example: https://www.gettyimages.com.mx/search/2/image?phrase=Lionel+Messi
            string url = "PASTE HERE THE URL FROM GETTYIMAGES";

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n Iniciando scraping de imágenes de " + url + "...");
            Console.ResetColor();

            // Realiza una solicitud a la página web y obtén su contenido HTML
            var web = new HtmlWeb();
            var doc = web.Load(url);

            Console.WriteLine("Contenido HTML cargado.");

            // Encuentra todas las etiquetas de imagen en la página
            var image_tags = doc.DocumentNode.Descendants("img");

            Console.WriteLine($"Encontradas {image_tags.Count()} etiquetas de imagen en la página.");

            // Recorre todas las etiquetas de imagen y extrae el atributo src
            var image_links = new List<string>();
            foreach (var tag in image_tags)
            {
                string src = tag.GetAttributeValue("src", "");
                if (src.StartsWith("http"))
                {
                    image_links.Add(src);
                }
            }

            Console.WriteLine("\n Encontrados " + image_links.Count + " enlaces de imágenes en la página.");

            // Modifica cada enlace para tener el formato correcto
            var new_image_links = new List<string>();
            foreach (var link in image_links)
            {
                var regex = new Regex(@"\/(\d+)");
                var match = regex.Match(link);
                if (match.Success)
                {
                    var id = match.Groups[1].Value;
                    var new_link = "https://www.gettyimages.com.mx/detail/" + id;
                    new_image_links.Add(new_link);
                }
                else
                {
                    new_image_links.Add(link);
                }
            }

            // Escribe los enlaces de las imágenes en un archivo de texto
            using (StreamWriter writer = new StreamWriter("enlaces_imagenes.txt"))
            {
                foreach (var link in new_image_links)
                {
                    writer.WriteLine(link);
                }
            }

            Console.WriteLine("\n Los enlaces de las imágenes se han escrito en el archivo 'enlaces_imagenes.txt'.");

            // Abre un navegador Edge y visita cada enlace de imagen
            using (var driver = new EdgeDriver())
            {
                foreach (var link in new_image_links)
                {
                    driver.Navigate().GoToUrl(link);
                    Thread.Sleep(1000); // Espera 1 segundos para que la página cargue completamente
                    string currentUrl = driver.Url;
                    Console.WriteLine("\n La página " + currentUrl + " ha sido cargada.");

                    // Copia el enlace visitado al archivo de texto
                    using (StreamWriter writer = new StreamWriter("enlaces_visitados.txt", true))
                    {
                        writer.WriteLine(currentUrl);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n Proceso finalizado.");
            Console.ResetColor();
        }
    }
}
