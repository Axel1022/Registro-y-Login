using Microsoft.AspNetCore.Mvc;
using REGISTROLOGIN.Data;
using REGISTROLOGIN.Models;
using System.Data;
using System.Data.SqlClient;


namespace REGISTROLOGIN.Controllers
{
    public class CuentaController : Controller
    {
        private readonly DbContext? _context;
        public CuentaController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Registrar()
        {
            return View("Registrar");
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_context.Valor))
                    {
                        using (SqlCommand cmd = new("sp_Registrar", con))
                        {
                            //?Paranetros que necesita el storeprocedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuarioModel.Nombre;
                            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = usuarioModel.Correo;
                            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = usuarioModel.Edad;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuarioModel.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = usuarioModel.Clave;

                            //? Abir conexion y ejecutar
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception)
            {
                return View("Registrar");
            }
            ViewData["Error"] = "Error de credenciales";
            return View("Registrar");
        }
    }
}
