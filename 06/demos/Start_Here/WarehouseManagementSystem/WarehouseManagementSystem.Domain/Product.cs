using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain;

public class Product
{
    public string Color { get; set; }
    public double Price { get; set; }

    public IEnumerable<Item> LineItems { get; set; }

}
