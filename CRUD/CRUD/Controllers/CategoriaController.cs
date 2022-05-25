using Microsoft.AspNetCore.Mvc;
using CRUD.Datos;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos _categoriaDatos = new CategoriaDatos();
        public IActionResult Listar()
        {
            // LISTA DE PRODUCTOS
            var lista = _categoriaDatos.Listar();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            // SOLO DEVUELVE LA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(CategoriaModel categoria)
        {
            // RECIBE UN OBJETO PARA GUARDARLO
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var resp = _categoriaDatos.Insertar(categoria);
                if (resp)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
        }
        public IActionResult Editar(int idCategoria)
        {
            // SOLO DEVUELVE LA VISTA
            var categoria = _categoriaDatos.Obtener(idCategoria);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModel categoria)
        {
            // RECIBE UN OBJETO PARA EDITARLO
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var resp = _categoriaDatos.Actualizar(categoria);
                if (resp)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
        }
        public IActionResult Eliminar(int idCategoria)
        {
            // SOLO DEVUELVE LA VISTA
            var categoria = _categoriaDatos.Obtener(idCategoria);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaModel categoria)
        {
            // RECIBE UN OBJETO PARA Eliminarlo
            var resp = _categoriaDatos.Delete(categoria.nIdCategori);
            if (resp)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
