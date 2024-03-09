using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using SistemaCheques.Models;
using SistemaCheques.Models.Datos;



namespace SistemaCheques.Controllers
{
    public class ProveedoresMatenedorController : Controller
    {
        ProveedoresDatos proveedores_datos = new ProveedoresDatos();

        // Mostrara el listado de concepto de pago
        public IActionResult Listar()
        {
            var Lista = proveedores_datos.Listar();
            // Devolvera la vista
            return View(Lista);
        }

        // Metodo para devolver a la vista
        public IActionResult Guardar()
        {
            return View();
        }

        // Para recibir los datos
        [HttpPost]
        public IActionResult Guardar(ProveedoresModel Proveedores)
        {
            // Metodo para guardar en la DB

            if (!ModelState.IsValid)
                return View();

           var respuesta = proveedores_datos.Guardar(Proveedores);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View("Listar");
        }

        // Para editar
        public IActionResult Editar(int idProveedor)
        {
            var proveedor = proveedores_datos.Obtener(idProveedor);
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Editar(ProveedoresModel Proveedores)
        {
            // Metodo para guardar en la DB

            if (!ModelState.IsValid)
                return View();

            var respuesta = proveedores_datos.Editar(Proveedores);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }

        // Para Eliminar
        public IActionResult Eliminar(int idProveedor)
        {
            var proveedor = proveedores_datos.Obtener(idProveedor);
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Eliminar(ProveedoresModel Proveedores)
        {


            var respuesta = proveedores_datos.Eliminar(Proveedores.idProveedor);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }



    }
}
