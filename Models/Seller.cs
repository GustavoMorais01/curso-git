using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        // Fazendo Composição(01 associação com a classe Departament)
        public Departament Departament { get; set; }

        public int DepartamentId { get; set; }

        // Associação 1 para muitos
        // Fazendo um composição(Enumeração) com a classe SalesRecord e Instanciando uma nova lista
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        // Metodo que adiciona um venda na classe SalesRecord
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        // Metodo que remove uma venda na classe SalesRecord
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // Pegar os dados das vendas usando o linq
        public double TotalSales(DateTime initial, DateTime final)
        {

            // Usando a lista do Sales para filtrar essa lista de vendas contendo um nova lista no 
            // intervalo de datas passado como parametro

            // Expressaõ lambda onde todo objeto sr tal que sr.Date >= initial && sr.Date <= final.
            // Onde manda calcular a soma do sr que leva em sr.amount(Soma das vendas)
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
