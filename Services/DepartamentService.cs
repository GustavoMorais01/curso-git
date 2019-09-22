using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;// Habilita os Tasks
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartamentService
    {
        private readonly SalesWebMvcContext _context;

        // Metodo de Injeção de dependencia
        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        // Criando o serviço de departamento com o metodo de retornar os mesmos departamentos ordendados.

        // Função assincrona, retornando um task de list departament e dentro dela faz uma outra chamada
        // assincrona com a palavra await
        public async Task<List<Departament>> FindAllAsync()
        {
            // Retorma lista ordenada por nome.
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync(); 
        }


    }
}
