using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            // Instanciando um lista do controller departament
            List<Departament> list = new List<Departament>();

            // Adicionando novos Departments, colocando ID e Name
            list.Add(new Departament { Id = 1, Name = "Eletronics" });
            list.Add(new Departament { Id = 2, Name = "Fashion" });

            // Enviando a minha list no metodo View()
            return View(list);
        }
    }
}