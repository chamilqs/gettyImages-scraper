# WebScraper de Imágenes Getty Images

Este es un simple proyecto de scraping en C# que te permite obtener enlaces de imágenes de Getty Images a partir de una URL específica. Puedes usar este scraper para recopilar enlaces de imágenes de Getty Images para un tema o palabra clave específica.

## Instrucciones de Uso

1. Clona este repositorio o descarga el archivo ZIP.

2. Abre el proyecto en Visual Studio o tu entorno de desarrollo C# preferido.

3. Abre el archivo `Program.cs` y busca la siguiente línea:

   ```csharp
   string url = "PASTE HERE THE URL FROM GETTYIMAGES";
   ```

4. Reemplaza `"PASTE HERE THE URL FROM GETTYIMAGES"` con la URL de la página de Getty Images desde la cual deseas obtener enlaces de imágenes.

5. Ejecuta la aplicación en tu consola con el comando `dotnet run`
   El scraper realizará lo siguiente:

   - Realizará una solicitud a la página web y obtendrá su contenido HTML.
   - Encontrará todas las etiquetas de imagen en la página.
   - Recorrerá todas las etiquetas de imagen y extraerá el atributo `src`.
   - Modificará cada enlace para tener el formato correcto.
   - Escribirá los enlaces de las imágenes en un archivo de texto llamado `enlaces_imagenes.txt`.
   - Abrirá un navegador Edge y visitará cada enlace de imagen, registrando los enlaces visitados en un archivo de texto llamado `enlaces_visitados.txt`.

7. Una vez que el proceso haya finalizado, encontrarás los enlaces de las imágenes en el archivo `enlaces_imagenes.txt` y los enlaces visitados en el archivo `enlaces_visitados.txt`. El que debería de servirte es el llamado `enlaces_visitados.txt` ya que el llamado `enlaces_imagenes.txt` solo se usa de referencia para Selenium WebDriver

## Requisitos

Asegúrate de tener los siguientes requisitos instalados antes de ejecutar el scraper:

- [Visual Studio](https://visualstudio.microsoft.com/) o un entorno de desarrollo C# compatible.
- [Selenium WebDriver](https://www.selenium.dev/documentation/en/webdriver) para C#.
- [HtmlAgilityPack](https://html-agility-pack.net/) para analizar el contenido HTML de la página web.

## Notas

- Este scraper se proporciona con fines educativos y de demostración. Asegúrate de cumplir con los términos de uso de Getty Images o cualquier otro sitio web que estés raspando.
- Ten en cuenta que el scraping de sitios web puede estar sujeto a cambios en la estructura del sitio y a políticas de uso, por lo que es posible que debas ajustar el código según sea necesario.

