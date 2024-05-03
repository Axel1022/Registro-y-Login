using Microsoft.AspNetCore.Mvc;
using REGISTROLOGIN.Data;
using REGISTROLOGIN.Models;
using System.Data;
using System.Data.SqlClient;


namespace REGISTROLOGIN.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbContext? _context;
        public LoginController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_context.Valor))
                    {
                        using (SqlCommand cmd = new("sp_login", con))
                        {
                            //?Paranetros que necesita el storeprocedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = loginModel.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = loginModel.Clave;

                            //? Abir conexion y ejecutar
                            con.Open();
                            SqlDataReader readerData = cmd.ExecuteReader();
                            if (readerData.Read())
                            {
                                Response.Cookies.Append("user", $"Bienvenido {loginModel.Usuario}");
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["Error"] = "Error de credenciales";
                            }
                            con.Close();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("Login");
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
