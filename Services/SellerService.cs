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

    }
}
