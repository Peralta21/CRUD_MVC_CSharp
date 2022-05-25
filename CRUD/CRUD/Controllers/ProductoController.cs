using Microsoft.AspNetCore.Mvc;
using CRUD.Datos;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDatos _productoDatos = new ProductoDatos();
        public IActionResult Listar()
        {
            // LISTA DE PRODUCTOS
            var lista = _productoDatos.Listar(); 
            return View(lista);
        }
        public IActionResult Buscar(int idCategoria)
        {
            // LISTA DE PRODUCTOS
            var lista = _productoDatos.Listar();

            if (idCategoria != 0)
                lista = _productoDatos.Listar(idCategoria);

            return View(lista);
        }
        public IActionResult Guardar()
        {
            // SOLO DEVUELVE LA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ProductoModel producto)
        {
            // RECIBE UN OBJETO PARA GUARDARLO
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var resp = _productoDatos.Insertar(producto);
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
        public IActionResult Editar(int idProducto)
        {
            // SOLO DEVUELVE LA VISTA
            var producto = _productoDatos.Obtener(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(ProductoModel producto)
        {
            // RECIBE UN OBJETO PARA GUARDARLO
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var resp = _productoDatos.Actualizar(producto);
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
        public IActionResult Eliminar(int idProducto)
        {
            // SOLO DEVUELVE LA VISTA
            var producto = _productoDatos.Obtener(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoModel producto)
        {
            // RECIBE UN OBJETO PARA Eliminarlo
            var resp = _productoDatos.Delete(producto.nIdProduct);
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
