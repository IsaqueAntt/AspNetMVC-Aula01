using AspNetMVC_Aula01.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC_Aula01.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        public ActionResult EfetuarLogin(Usuario usuario)
        {
            using (Conexao conexao = new Conexao())
            {
                string strLogin = "SELECT * FROM usuarios " +
                    "WHERE userName = @userName and" +
                    "userPass = @userPass;";

                using (var comando = new MySqlCommand(strLogin, conexao.conn)) 
                {
                    comando.Parameters.AddWithValue("@userName", usuario.UserName);
                    comando.Parameters.AddWithValue("@userPass", usuario.UserPass);

                    MySqlDataReader dr = comando.ExecuteReader();
                    dr.Read();
                    if (!dr.HasRows)
                    {
                        return RedirectToAction("Menu");
                    }
                    else
                    {
                        ViewBag.ErroLogin = true;
                        return RedirectToAction("Index");
                    }
                }
            }
        }
    }
}