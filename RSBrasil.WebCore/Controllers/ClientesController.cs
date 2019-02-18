using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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
            var enumEstados = from EEstados e in Enum.GetValues(typeof(EEstados))
                              select new
                              {
                                  ID = (int)e,
                                  Name = e.ToString()
                              };
            ViewBag.EstadosList = new SelectList(enumEstados, "ID", "Name");

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

        //public Cliente Inserir(Form)
    }
}