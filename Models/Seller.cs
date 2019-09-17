using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models  // Aula 243 não foi feita. refazer depois com tempo para achar o erro
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2} ")]
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
