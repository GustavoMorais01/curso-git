using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found!!!");
            }

            try
            {
                _context.Update(obj);// Atualizando no banco de dados
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }


    }
}
