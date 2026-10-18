using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZooApp.Models;
using ZooApp.Repositories;

namespace ZooApp.Controllers
{
    public class AnimaisController : Controller
    {
        private AnimalRepository repo;

        // Recebe o repositório
        public AnimaisController(AnimalRepository repo)
        {
            this.repo = repo;
        }

        // Lista de opções do dropdown de dieta
        private void CarregarDietas()
        {
            List<string> dietas = new List<string>();
            dietas.Add("Carnívoro");
            dietas.Add("Herbívoro");
            dietas.Add("Onívoro");
            ViewBag.Dietas = new SelectList(dietas);
        }

        // Regras de negócio que não cabem nos atributos do Model
        private void ValidarRegras(Animal animal)
        {
            if (animal.DataChegada.Date > DateTime.Today)
            {
                ModelState.AddModelError("DataChegada", "A data de chegada não pode ser no futuro.");
            }

            if (repo.ExisteNome(animal.Nome, animal.Id))
            {
                ModelState.AddModelError("Nome", "Já existe um animal com esse nome.");
            }
        }

        // Lista os animais e pesquisa por nome
        public IActionResult Listar(string? busca)
        {
            ViewBag.Busca = busca;
            List<Animal> lista = repo.Listar(busca);
            return View(lista);
        }

        // Mostra um animal
        public IActionResult Detalhes(int id)
        {
            Animal? animal = repo.Obter(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // Abre o formulário de cadastro
        public IActionResult Cadastrar()
        {
            CarregarDietas();
            return View(new Animal());
        }

        // Salva o novo animal
        [HttpPost]
        public IActionResult Cadastrar(Animal animal)
        {
            ValidarRegras(animal);
            if (!ModelState.IsValid)
            {
                CarregarDietas();
                return View(animal);
            }
            repo.Adicionar(animal);
            TempData["Msg"] = "Animal cadastrado com sucesso.";
            return RedirectToAction("Listar");
        }

        // Abre o formulário de edição
        public IActionResult Editar(int id)
        {
            Animal? animal = repo.Obter(id);
            if (animal == null)
            {
                return NotFound();
            }
            CarregarDietas();
            return View(animal);
        }

        // Salva a edição
        [HttpPost]
        public IActionResult Editar(Animal animal)
        {
            ValidarRegras(animal);
            if (!ModelState.IsValid)
            {
                CarregarDietas();
                return View(animal);
            }
            repo.Atualizar(animal);
            TempData["Msg"] = "Animal atualizado com sucesso.";
            return RedirectToAction("Listar");
        }

        // Exclui o animal
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            repo.Remover(id);
            TempData["Msg"] = "Animal removido.";
            return RedirectToAction("Listar");
        }
    }
}
