using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models;

public partial class Partner
{
    public int IdPartner { get; set; }

    public string TypePartner { get; set; } = null!;

    public string NamePartner { get; set; } = null!;

    public string DirectorSurname { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string DirectorPatronymic { get; set; } = null!;

    public string EmailPartner { get; set; } = null!;

    public string PhomeNumber { get; set; } = null!;

    public int AddressIndex { get; set; }

    public string AddressLocality { get; set; } = null!;

    public string AddressCity { get; set; } = null!;

    public string AddressStreet { get; set; } = null!;

    public string AddressHome { get; set; } = null!;

    public string InnPartner { get; set; } = null!;

    public int RatingPartner { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    // Добавление функции для подсчета скидки
    public int GetDiscount()
    {
        int totalProductsSold = PartnersProducts.Sum(p => p.CountProduct);

        if (totalProductsSold < 10000)
            return 0;
        if (totalProductsSold < 50000)
            return 5;
        if (totalProductsSold < 300000)
            return 10;
        return 15;
    }
}
