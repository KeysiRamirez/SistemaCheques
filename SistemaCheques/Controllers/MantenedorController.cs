using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using SistemaCheques.Models;
using SistemaCheques.Models.Datos;


namespace SistemaCheques.Controllers
{
	public class MantenedorController : Controller
	{
		ConceptoPagoDatos concepto_pagos_datos = new ConceptoPagoDatos();	

		// Mostrara el listado de concepto de pago
		public IActionResult Listar()
		{
			var Lista = concepto_pagos_datos.Listar();
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
		public IActionResult Guardar(ConceptoPagoModel ConceptoPago)
        {
			// Metodo para guardar en la DB

			if (!ModelState.IsValid)
				return View();

			var respuesta = concepto_pagos_datos.Guardar(ConceptoPago);

			if (respuesta)
			
				return RedirectToAction("Listar");

			else
				return View ();
		}

		// Para editar
        public IActionResult Editar(int idConceptoPago)
        {
			var conceptopago = concepto_pagos_datos.Obtener(idConceptoPago);
            return View(conceptopago);
        }

        [HttpPost]
        public IActionResult Editar(ConceptoPagoModel ConceptoPago)
        {
            // Metodo para guardar en la DB

            if (!ModelState.IsValid)
                return View();

            var respuesta = concepto_pagos_datos.Editar(ConceptoPago);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }

        // Para Eliminar
        public IActionResult Eliminar(int idConceptoPago)
        {
            var conceptopago = concepto_pagos_datos.Obtener(idConceptoPago);
            return View(conceptopago);
        }

        [HttpPost]
        public IActionResult Eliminar(ConceptoPagoModel ConceptoPago)
        {
     

            var respuesta = concepto_pagos_datos.Eliminar(ConceptoPago.idConceptoPago);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }



    }
}
