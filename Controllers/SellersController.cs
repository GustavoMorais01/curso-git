using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services; // Biblioteca para importar da classe SellerService
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Declarando dependencia para o SellerService
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;


        // Construtor para injetar dependencia
        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        // Esse Index() vai ter que chamar a operação FindAll() da classe SellerService.
        public IActionResult Index()
        {
            // Implementando o SellerService para chamar o FindAll()
            var list = _sellerService.FindAll(); // Retorna lista de Seller

            return View(list);

            // O que esta acontecendo nesse metodo:
            // Chamou o controlador Index()
            // O controlador acessou o model, pegou os dados na lista.
            // Encaminhanhou os dados para a View(list)
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        // Criando a ação de Post botão create

        [HttpPost] // Anotation para o programa que a ação é post e não get
        [ValidateAntiForgeryToken] //Anotation para prevenir que a aplicação sofra ataques CSRF, Protege contra hack
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) // Int opcional que é o id
        {
            if (id == null)
            {
                return NotFound(); // Instancia uma resposta basica
            }

            var obj = _sellerService.FindById(id.Value); // Busca do banco de dados

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));// Depois que remove o vendedor volta pra tela do index
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Instancia uma resposta basica
            }

            var obj = _sellerService.FindById(id.Value); // Busca do banco de dados

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) // Abre a tela para editar o vendedor Seller
        {
            if (id == null)
            {
                return NotFound();
            }

            // Testar se o id existe no banco de dados.
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            // Se todos os teste acima passar, vai abrir a tela de edição
            // Carregando os departamentos para povoar a caixinha de seleção
            List<Departament> departaments = _departamentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }

    }
}