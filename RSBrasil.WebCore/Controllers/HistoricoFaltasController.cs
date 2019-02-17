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
    public class HistoricoFaltasController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoFaltasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Novo()
        {
            Task<List<Cliente>> clientes = Testar();

            ViewBag.IdCliente = new SelectList
                (
                    GetClienteAsync(),
                    "Id",
                    "NomeFantasia"
                );
            return View();
        }

        public List<Cliente> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(response.Result);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Funcionario> GetFuncionarioAsync()
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

        public async Task<List<Cliente>> Testar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}