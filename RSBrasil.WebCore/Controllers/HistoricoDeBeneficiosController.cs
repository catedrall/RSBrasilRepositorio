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
    public class HistoricoDeBeneficiosController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoDeBeneficiosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Novo()
        {
            Task<List<HistoricoBeneficios>> beneficios = Testar();

            ViewBag.IdCliente = new SelectList
                (
                    GetClienteAsync(),
                    "Id",
                    "NomeFantasia"
                );

            ViewBag.IdBeneficios = new SelectList
                (
                    GetClienteAsync(),
                    "Id",
                    "Nome"
                );

            return View();
        }

        public List<HistoricoBeneficios> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var beneficios = JsonConvert.DeserializeObject<List<HistoricoBeneficios>>(response.Result);
                return beneficios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HistoricoBeneficios> GetFuncionarioAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarFuncionarios"];
                var response = client.GetStringAsync(url);
                var historicoBeneficios = JsonConvert.DeserializeObject<List<HistoricoBeneficios>>(response.Result);
                return historicoBeneficios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HistoricoBeneficios>> Testar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                List<HistoricoBeneficios> beneficios = JsonConvert.DeserializeObject<List<HistoricoBeneficios>>(content);
                return beneficios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}