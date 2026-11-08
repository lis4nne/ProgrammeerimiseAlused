using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        // 1. Loome listi, kuhu kogume kõik uudised
        var allNews = new List<Uudis>();

        // 2. Loeme ERR-i RSS-voo
        LeiaUudised("https://www.err.ee/rss", "ERR", allNews);

        // 3. Loeme Postimehe RSS-voo
        LeiaUudised("https://www.postimees.ee/rss", "Postimees", allNews);

        // 4. Sorteerime uuemate järgi ja võtame 20 tükki
        var viimased = allNews.OrderByDescending(x => x.Aeg).Take(20);

        // 5. Kirjutame tulemuse HTML faili
        using (StreamWriter sw = new StreamWriter("uudised.html"))
        {
            sw.WriteLine("<ul>");
            foreach (var u in viimased)
            {
                sw.WriteLine($"    <li><a href=\"{u.Link}\">{u.Pealkiri}</a><br />{u.Aeg} | {u.Väljaanne}<br />{u.Kirjeldus}</li>");
            }
            sw.WriteLine("</ul>");
        }

        Console.WriteLine("Valmis! Fail 'uudised.html' on loodud.");
    }

    // Abimeetod ühe voo lugemiseks
    static void LeiaUudised(string url, string valjaanne, List<Uudis> list)
    {
        try
        {
            XDocument doc = XDocument.Load(url);

            foreach (var item in doc.Descendants("item"))
            {
                list.Add(new Uudis
                {
                    Pealkiri = item.Element("title")?.Value,
                    Link = item.Element("link")?.Value,
                    Kirjeldus = item.Element("description")?.Value,
                    Aeg = DateTime.TryParse(item.Element("pubDate")?.Value, out DateTime d) ? d : DateTime.Now,
                    Väljaanne = valjaanne
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Viga voo {valjaanne} lugemisel: {ex.Message}");
        }
    }
}

// Uudise andmemudel
class Uudis
{
    public string Pealkiri { get; set; }
    public string Link { get; set; }
    public string Kirjeldus { get; set; }
    public DateTime Aeg { get; set; }
    public string Väljaanne { get; set; }
}