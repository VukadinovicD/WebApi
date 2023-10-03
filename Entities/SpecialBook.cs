using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApiTask1.Entities;

public class SpecialBook : Book, IInventory
{
    public string SpecialEditionDetails { get; set;}

    public SpecialBook(string name, string specialEditionDetails) : base(name)
    {
        SpecialEditionDetails = specialEditionDetails;
    }

    public override string GetBookDetails()
    {   
        return SpecialEditionDetails;
    }

    public int CalculateInventoryValue()
    {
        return base.CalculateInventoryValue() + 100;
    }
}
