using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string url = "http://data.fixer.io/api/latest?";
            string key = "access_key=4956d8d673426858ff3d9f2884b17087";
            string format = "&format=0";
            string page = "";
            //string final = "";
            string moeda1 = "\"GBP\"";
            string valor1 = "";

            Console.WriteLine("starting...");
            try
            {
                string responseBody = await client
                    .GetStringAsync(
                    url +
                    key +
                    format 
                    );
                page = responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message:{e}");
            }


            var items = page.Split(',');

            foreach(string item in items){

                bool i = false;
                foreach(string bit in item.Split(':'))
                {
                    if(i == true)
                    {
                        valor1 = bit;
                    }
                    if (i == false)
                    {
                        if(bit == moeda1)
                        {
                            i = true;
                        }
                    }
                    

                }
            }
            Console.WriteLine($"O euro está valendo está valendo {valor1} da moeda {moeda1}");
            Console.ReadLine();
        }
    }
}
