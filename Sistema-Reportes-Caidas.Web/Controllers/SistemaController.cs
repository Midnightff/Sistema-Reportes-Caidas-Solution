using Microsoft.AspNetCore.Mvc;
using Sistema_Reportes_Caidas.Infrastructure.Context;
using Sistema_Reportes_Caidas.Domain.Entities;


namespace Sistema_Reportes_Caidas.Web.Controllers
{
    public class SistemaController : Controller
    {
        private readonly AppDbContext _db;
        public SistemaController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var sistemas = _db.Sistemas.ToList();
            return View(sistemas);
        }

        [HttpPost]
        public IActionResult Store(Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Sistemas.Add(sistema);
                    _db.SaveChanges();

                    TempData["SuccessMessage"] = "El sistema se agrego correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
         
                    TempData["ErrorMessage"] = "Ocurrio un error al agregar el sistema: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            TempData["ErrorMessage"] = "Los datos del formulario no son validos.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Update(Sistema sistema)
        {
            if (ModelState.IsValid && sistema.Id > 0)
            {
                try
                {
                    _db.Sistemas.Update(sistema);
                    _db.SaveChanges();
                    TempData["SuccessMessage"] = "El sistema se actualizo correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Ocurrio un error al actualizar el sistema: " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Datos no validos.";
            }
            TempData["ErrorMessage"] = "Los datos del formulario no son validos.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var sistema = _db.Sistemas.Find(id);
                if (sistema == null)
                {
                    TempData["ErrorMessage"] = "El sistema no fue encontrado.";
                    return RedirectToAction("Index");
                }
                _db.Sistemas.Remove(sistema);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "El sistema se elimino correctamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al eliminar el sistema: " + ex.Message;
            }
            return RedirectToAction("Index");
        }


    }
}
