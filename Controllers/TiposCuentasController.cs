using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    { 

        private readonly string connectionString;

        public TiposCuentasController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public IActionResult Crear()
        {

            using (var connection = new SqlConnection(this.connectionString))
            {
                var query = connection.Query("SELECT * FROM TiposOperaciones").FirstOrDefault();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {

            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }

            return View();
        }

    }
}
