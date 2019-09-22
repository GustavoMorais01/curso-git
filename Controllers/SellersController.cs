using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<IActionResult> Index()
        {
            // Implementando o SellerService para chamar o FindAll()
            var list = await _sellerService.FindAllAsync(); // Retorna lista de Seller

            return View(list);

            // O que esta acontecendo nesse metodo:
            // Chamou o controlador Index()
            // O controlador acessou o model, pegou os dados na lista.
            // Encaminhanhou os dados para a View(list)
        }

        public async Task<IActionResult> CreateAsync()
        {
            var departaments = await _departamentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        // Criando a ação de Post botão create

        [HttpPost] // Anotation para o programa que a ação é post e não get
        [ValidateAntiForgeryToken] //Anotation para prevenir que a aplicação sofra ataques CSRF, Protege contra hack
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) // Int opcional que é o id
        {
            if (id == null)
            {
                // Retornando a pagina de erro
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value); // Busca do banco de dados

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));// Depois que remove o vendedor volta pra tela do index
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provived!" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value); // Busca do banco de dados

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) // Abre a tela para editar o vendedor Seller
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provived!" });
            }

            // Testar se o id existe no banco de dados.
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }

            // Se todos os teste acima passar, vai abrir a tela de edição
            // Carregando os departamentos para povoar a caixinha de seleção
            List<Departament> departaments = await _departamentService.FindAllAsync();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch!" });
            }

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}