using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        // Metodo de Injeção de dependencia
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Implementando a operação Findall para retornar uma lista com todos os vendedores do banco de bados
        public List<Seller> FindAll()
        {
            // Acessa a fonte de dados da tabela de vendedores e converte para uma lista
            return _context.Seller.ToList();
        }
        // Metodo para inserir no banco de dados um novo vendedor
        public void Insert(Seller obj)
        {
            _context.Add(obj);// Inserindo o objeto obj no banco de dados.
            _context.SaveChanges();// Salvando e confirmando a alteração no banco de dados
        }

    }
}
