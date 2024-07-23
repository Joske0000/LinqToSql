using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var dbContext = new LinqSqlDataContext("Data Source=JOSE\\MSSQLSERVER01;Initial Catalog=linq_to_sql;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

            // UnosZaposlenika(dbContext);

            var upit = from zaposlenik in dbContext.Zaposleniks
                       where zaposlenik.ImePrezime.StartsWith("Ivan")
                       select zaposlenik
                       ;

            


            Console.ReadKey();
        }




        private static void UnosZaposlenika(LinqSqlDataContext dbContext)
        {
            var zaposlenik = new Zaposlenik()
            {
                ImePrezime = "Ivan Horvat",
                Email = "ivanhorvat@gmail.com",
                Telefon = "0981234567",
                Adresa = "Zagreb",
                OdjelID = 1
            };

            dbContext.Zaposleniks.InsertOnSubmit(zaposlenik);    
            
            dbContext.SubmitChanges();
        }
    }
}
