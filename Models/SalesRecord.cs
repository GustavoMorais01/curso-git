using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        // Tem que importar: using SalesWebMvc.Models.Enums;
        public SaleStatus Status { get; set; }

        // Associação Com a classe Seller 1 vendedor(Seller), para muitas vendas(SalesRecord)
        public Seller Seller { get; set; }

        // Construtor Vazio necessario na aplicação
        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
