using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RSBrasil.Web.Controllers
{
    public class ClientesController : Controller
    {

        private IConfiguration _configuration;

        public ClientesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> clientes = GetClienteAsync();
            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Edit()
        {
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
    }
}