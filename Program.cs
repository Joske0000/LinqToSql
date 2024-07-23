using System;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;


namespace LinqToSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connStr = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            var dbContext = new LinqSqlDataContext(connStr);

            // var dbContext = new LinqSqlDataContext("Data Source=JOSE\\MSSQLSERVER01;Initial Catalog=linq_to_sql;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

            // UnosZaposlenika(dbContext);
            // var dbContext = new LinqToSqlDataContext("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=linq_to_sql;Integrated Security=True");

            // DML 

            UnosZaposlenika(dbContext);

            var servis = new PodatkovniServis(dbContext);

            servis.UnosNovogZaposlenika(new Zaposlenik
            {
                ImePrezime = "Iva Ivić",
                Email = "iva.ivic@algebra.hr",
                Telefon = "095444333222",
                Adresa = "Livadska 12",
                OdjelID = 2
            });

            // DQL 

            var upit = dbContext.Zaposleniks.FirstOrDefault();

            //var upit = from zaposlenik in dbContext.Zaposleniks
            //           where zaposlenik.ImePrezime.StartsWith("Pero")
            //           select zaposlenik;

            var zaposlenik = servis.DohvatiZaposlenika("Pero");
            zaposlenik.OdjelID = 3;

            servis.AzuriranjeZaposlenika(zaposlenik);

            servis.AzuriranjeZaposlenika(2, "+385 42 111 222", "Kolodvorska 145");

            servis.ObrisiZaposlenika(2);

            Console.ReadKey();
        }

        private static void UnosZaposlenika(LinqSqlDataContext dbContext)
        {
            var zaposlenik = new Zaposlenik
            {
                ImePrezime = "Pero Perić",
                Email = "pero.peric@algebra.hr",
                Telefon = "09811122233",
                Adresa = "Vrtna bb",
                OdjelID = 1
            };

            dbContext.Zaposleniks.InsertOnSubmit(zaposlenik);

            dbContext.SubmitChanges();
        }
    }
}
