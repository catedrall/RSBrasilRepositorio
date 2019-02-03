using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RSBRasil.Model.Entidades;
using System.Net.Http;
using Newtonsoft.Json;

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