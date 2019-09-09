using System; // Biblioteca para usar o DateTime
using System.Collections.Generic; // Biblioteca usada para o ICollection<>
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departament 
    
        
    // ====>>>>> Escrevi Department errado. No endereço da WEB DIGITAR DEPARTAMENT  <<<========


    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Atributos que vai ser usado para fazer a composição(Associação) com a classe Seller 
        // e Instanciando uma nova List de Seller
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        
        // Necessita utilizar construtor vazio na aplicação
        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Metodo que adiciona vendedores
        public void AddSeller(Seller seller)
        {
         // Adicionando na lista do Icollerction Sellers, um novo seller que foi passado como paramentro.
            Sellers.Add(seller);
        }

        // Metodo para calcular o total de vendas nos intervalos de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            // Pega a lista Sellers(Vendedores) desse departamento e somar o total de vendas de cada
            // vendedor nesse intervalo de data

            // Pega cada vendedor da minha lista, chamando o totalsales do vendedor, naquele periodo
            // inicial e final, e faço a soma desse resultado para todos os vendedores do Departament
            // Meio dificil de entender, estudar depois
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}
