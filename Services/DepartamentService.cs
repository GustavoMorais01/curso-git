using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        // Criando o serviço de departamento com o metodo de retornar os mesmos depsrtamentos ordendados.
        public List<Departament> FindAll()
        {
            // Retorma lista ordenada por nome.
            return _context.Departament.OrderBy(x => x.Name).ToList(); 
        }


    }
}
