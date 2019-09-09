using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.Enums
{

    // Classe é uma enumeração, colocar enum no lugar de class
    public enum SaleStatus : int
    {
        Pending = 0,
        Billed = 1,
        Canceled = 2

    }
}
