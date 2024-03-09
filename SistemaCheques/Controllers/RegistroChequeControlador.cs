using Microsoft.AspNetCore.Mvc;
using SistemaCheques.Models;
using SistemaCheques.Models.Datos;

namespace SistemaCheques.Controllers
{
    public class RegistroChequeControlador : Controller
    {
        public IActionResult Listar()
        {
            RegistroChequeDatos registro_cheque = new RegistroChequeDatos();

            var Lista = registro_cheque.Listar();
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
        public IActionResult Guardar(RegistroChequeModel RegistroCheque)
        {
            // Metodo para guardar en la DB

            if (!ModelState.IsValid)
                return View();

            var respuesta = registro_cheque.Guardar(RegistroCheque);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }

        // Para editar
        public IActionResult Editar(int idRegistroCheque)
        {
            var registrocheque = registro_cheque.Obtener(idRegistroCheque);
            return View(registrocheque);
        }

        [HttpPost]
        public IActionResult Editar(ConceptoPagoModel ConceptoPago)
        {
            // Metodo para guardar en la DB

            if (!ModelState.IsValid)
                return View();

            var respuesta = registro_cheque.Editar(ConceptoPago);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }

        // Para Eliminar
        public IActionResult Eliminar(int idConceptoPago)
        {
            var conceptopago = registro_cheque.Obtener(idConceptoPago);
            return View(conceptopago);
        }

        [HttpPost]
        public IActionResult Eliminar(ConceptoPagoModel ConceptoPago)
        {


            var respuesta = registro_cheque.Eliminar(ConceptoPago.idConceptoPago);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }



    }
}

    }
}
