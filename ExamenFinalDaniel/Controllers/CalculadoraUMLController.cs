using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ExamenFinalDaniel.Models;   

namespace ExamenFinalDaniel.Controllers
{
    public class CalculadoraUMLController : Controller
    {
        
        private static List<string> historial = new List<string>();

        public ActionResult Index()
        {
            ViewBag.Historial = historial;
            return View(new CalculadoraUML());
        }

        [HttpPost]
        public ActionResult Index(CalculadoraUML calc, string operacion)
        {
            double resultado = 0;

            try
            {
                switch (operacion)
                {
                    case "Sumar":
                        resultado = calc.Sumar();
                        break;
                    case "Restar":
                        resultado = calc.Restar();
                        break;
                    case "Multiplicar":
                        resultado = calc.Multiplicar();
                        break;
                    case "Dividir":
                        resultado = calc.Dividir();
                        break;
                }

                string registro = $"{DateTime.Now:HH:mm:ss} -> {calc.Numero1} {operacion} {calc.Numero2} = {resultado}";
                historial.Add(registro);

                ViewBag.Resultado = resultado;
            }
            catch (DivideByZeroException ex)
            {
                ViewBag.Error = ex.Message;
            }

            ViewBag.Historial = historial;
            return View(calc);
        }

        public ActionResult LimpiarTodo()
        {
            historial.Clear();
            return RedirectToAction("Index");
        }

        public FileResult ExportarCSV()
        {
            var csv = new StringBuilder();
            csv.AppendLine("Historial");

            foreach (var item in historial)
            {
                csv.AppendLine(item);
            }

            byte[] buffer = Encoding.UTF8.GetBytes(csv.ToString());

            return File(buffer, "text/csv", "historial.csv");
        }
    }
}