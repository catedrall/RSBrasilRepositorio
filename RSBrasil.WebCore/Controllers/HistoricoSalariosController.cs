using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSBrasil.Model.Entidades;
using System.Net.Http;
using Newtonsoft.Json;
using RSBRasil.Model.Entidades;

namespace RSBrasil.WebCore.Controllers
{
    public class HistoricoSalariosController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoSalariosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Novo()
        {
            Task<List<HistoricoSalarios>> clientes = Testar();

            ViewBag.IdCliente = new SelectList
                (
                    GetClienteAsync(),
                    "Id",
                    "NomeFantasia"
                );
            return View();
        }

        public List<HistoricoSalarios> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var historico = JsonConvert.DeserializeObject<List<HistoricoSalarios>>(response.Result);
                return historico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HistoricoSalarios> GetFuncionarioAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarFuncionarios"];
                var response = client.GetStringAsync(url);
                var historico = JsonConvert.DeserializeObject<List<HistoricoSalarios>>(response.Result);
                return historico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HistoricoSalarios>> Testar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                List<HistoricoSalarios> historico = JsonConvert.DeserializeObject<List<HistoricoSalarios>>(content);
                return historico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}