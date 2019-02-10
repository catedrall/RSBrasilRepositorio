using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RSBRasil.Model.Entidades;
using System.Net.Http;
using Newtonsoft.Json;
using RSBrasil.Model.Enuns;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RSBrasil.WebCore.Controllers
{
    public class FuncionarioController : Controller
    {

        private IConfiguration _configuration;

        public FuncionarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Funcionario> funcionarios = GetFuncionariosAsync();
            return View();
        }

        public ActionResult Novo()
        {
            var enumSexo = from ESexo e in Enum.GetValues(typeof(ESexo))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.SexoList = new SelectList(enumSexo, "ID", "Name");

            var enumEstadoCivil = from EEstadoCivil e in Enum.GetValues(typeof(EEstadoCivil))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.EstadoCivilList = new SelectList(enumEstadoCivil, "ID", "Name");

            return View();
        }

        public List<Funcionario> GetFuncionariosAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarFuncionarios"];
                var response = client.GetStringAsync(url);
                var funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(response.Result);
                return funcionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}