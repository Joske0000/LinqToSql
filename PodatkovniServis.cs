using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql
{
    internal class PodatkovniServis
    {
        private readonly LinqSqlDataContext _dataContext;

        public PodatkovniServis(LinqSqlDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void UnosNovogZaposlenika(Zaposlenik zaposlenik)
        {
            _dataContext.Zaposleniks.InsertOnSubmit(zaposlenik);
            _dataContext.SubmitChanges();
        }

        public void UnosNovogZaposlenika(string imePrezime, string email, string telefon, string adresa, int odjelId)
        {
            var zaposlenik = new Zaposlenik
            {
                ImePrezime = imePrezime,
                Email = email,
                Telefon = telefon,
                Adresa = adresa,
                OdjelID = odjelId
            };

            _dataContext.Zaposleniks.InsertOnSubmit(zaposlenik);
            _dataContext.SubmitChanges();
        }

        public void AzuriranjeZaposlenika(Zaposlenik zaposlenik)
        {
            _dataContext.SubmitChanges();
        }

        public void AzuriranjeZaposlenika(int id, string telefon, string adresa)
        {
            var zaposlenik = DohvatiZaposlenika(id);
            if (zaposlenik != null)
            {
                zaposlenik.Telefon = telefon;
                zaposlenik.Adresa = adresa;

                _dataContext.SubmitChanges();
            }
        }

        public Zaposlenik DohvatiZaposlenika(int id)
        {
            return _dataContext.Zaposleniks.SingleOrDefault(_ => _.ID == id);
        }

        public Zaposlenik DohvatiZaposlenika(string imePrezime)
        {
            return _dataContext.Zaposleniks.Where(_ => _.ImePrezime.Contains(imePrezime))
                .FirstOrDefault();
        }

        public void ObrisiZaposlenika(int id)
        {
            var zaposlenik = DohvatiZaposlenika(id);

            _dataContext.Zaposleniks.DeleteOnSubmit(zaposlenik);
            _dataContext.SubmitChanges();
        }
    }
}
