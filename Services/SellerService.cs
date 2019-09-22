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
        public async Task<List<Seller>> FindAllAsync()
        {
            // Acessa a fonte de dados da tabela de vendedores e converte para uma lista
            return await _context.Seller.ToListAsync();
        }
        // Metodo para inserir no banco de dados um novo vendedor
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);// Inserindo o objeto obj no banco de dados.
            _context.SaveChangesAsync();// Salvando e confirmando a alteração no banco de dados
        }
        
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task  RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found!!!");
            }

            try
            {
                _context.Update(obj);// Atualizando no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }


    }
}
