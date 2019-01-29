using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RSBrasil.Web.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public string CriarMenu()
        {
            StringBuilder menu = new StringBuilder();
            
            var telas = new List<string>();

            foreach(string tela in telas)
            {
                menu.AppendLine(MenuPrincipal(Convert.ToInt32(telas)));
            }

                return menu.ToString();
        }

        private string MenuPrincipal(int id)
        {
            StringBuilder menu = new StringBuilder();

            //apagar a lista
            var telas = new List<string>();

            menu.AppendLine("< li class='dropdown'>");
            menu.AppendLine("        <a href = '#' class='dropdown -toggle links' data -toggle='dropdown'> ");
            menu.AppendLine("            <span class='glyphicon glyphicon-user'></span>");
            menu.AppendFormat("            {0}", "nome do menu").AppendLine();
            menu.AppendLine("            <span class='caret'></span>");
            menu.AppendLine("        </a>");
            menu.AppendLine("<ul class='dropdown-menu' role ='menu'> ");

            foreach (var nome in telas)
            {
                menu.AppendLine(LayoutLogin(nome));
            }

            menu.AppendLine("    </ul>");
            menu.AppendLine("</li>");

            return menu.ToString();
        }
        
        private string LayoutLogin(string nomeMenu)
        {

            string layout = @"
                                <li>
                                <a href='#' class='links'>
                                    <span class='glyphicon glyphicon-list' ></span>
                                    {NOME_MENU}
                                </a>
                            </li>
                            ";
            layout = layout.Replace("{NOME_MENU}", nomeMenu);

            return layout;
        }
    }
}