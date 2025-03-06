using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class PartnersService
    {
        public static List<Partner> GetPartners()
        {
            using (var context = new DemoContext())
            {
                var result = context.Partners
                    .Include(p => p.PartnersProducts)
                    .ToList();
                return result;
            }
        }

        public static List<PartnersProduct> GetSalesHistory(int partnerId)
        {
            using (var context = new DemoContext())
            {
                var result = context.PartnersProducts
                    .Where(p=> p.IdPartner ==  partnerId)
                    .Include(p => p.ArticleProductNavigation)
                    .OrderBy(id => id.IdPartnersProducts)
                    .ToList();
                return result;
            }
        }

        public static List<Partner> GetPartnersNames()
        {
            using (var context = new DemoContext())
            {
                var result = context.Partners.ToList();
                return result;
            }
        }
        public static List<PartnersProduct> FilterForPartnerName(int partnerId)
        {
            using (var context = new DemoContext())
            {
                var result = context.PartnersProducts
                    .Include(p => p.IdPartnerNavigation)
                    .Include(p => p.ArticleProductNavigation)
                    .Where(p => p.IdPartner == partnerId)
                    .OrderBy(p => p.IdPartnersProducts)
                    .ToList();
                return result;
            }
        }

        public bool ExistingEmail(string email)
        {
            using (var context = new DemoContext())
            {
                var existingEmail = context.Partners.FirstOrDefault(e => e.EmailPartner == email);
                if (existingEmail != null) { return false; }
                return true;
            }
        }

        public static bool AddPartner(Partner partner)
        {
            try
            {
                using (var context = new DemoContext())
                {
                    context.Partners.Add(partner);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EditPartner(int idPartner, string typePartner, string name, string surnameDirector, string nameDirector,
            string patronymicDirector, string email, string phone, int indexAddress, string localityAddress,
            string cityAddress, string streetAddress, string homeAddress, string inn, int rating)
        {
            try
            {
                using (var context = new DemoContext())
                {
                    var partner = context.Partners.FirstOrDefault(p => p.IdPartner == idPartner);
                    if (partner == null) { return false; }

                    partner.TypePartner = typePartner;
                    partner.NamePartner = name;
                    partner.DirectorSurname = surnameDirector;
                    partner.DirectorName = nameDirector;
                    partner.DirectorPatronymic = patronymicDirector;
                    partner.EmailPartner = email;
                    partner.PhomeNumber = phone;
                    partner.AddressIndex = indexAddress;
                    partner.AddressLocality = localityAddress;
                    partner.AddressCity = cityAddress;
                    partner.AddressStreet = streetAddress;
                    partner.AddressHome = homeAddress;
                    partner.InnPartner = inn;
                    partner.RatingPartner = rating;

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
