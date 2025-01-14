using CardapioMVC.Models;
using CardapioMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CardapioMVC.Controllers
{
    public class PratoController : Controller
    {

        private readonly IPratoRepository _pratoRepository;

        public PratoController(IPratoRepository pratoRepository)
        {
            _pratoRepository = pratoRepository;
        }

        public IActionResult Index()
        {
            List<Prato> pratos = _pratoRepository.GetAllPratos();

            return View(pratos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Prato prato = _pratoRepository.GetPrato(id);
            return View(prato);
        }



        public IActionResult Delete(int id)
        {
            Prato prato = _pratoRepository.GetPrato(id);

            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }



        //[HttpPost]
        //public IActionResult Post(Prato prato)
        //{
        //    _pratoRepository.AddPrato(prato);
        //    return RedirectToAction("Index");
        //}



        [HttpPost]
        public IActionResult Post(Prato prato)
        {
            try
            {
                _pratoRepository.AddPrato(prato);
                TempData["MensagemSucesso"] = "Prato cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o prato. Erro: {ex.Message}";
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(Prato prato)
        {
            try
            {
                _pratoRepository.UpdatePrato(prato);
                TempData["MensagemSucesso"] = "Prato atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o prato. Erro: {ex.Message}";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmDelete(int id)
        {
            _pratoRepository.DeletePrato(id);
            return RedirectToAction("Index");
        }

    }
}
