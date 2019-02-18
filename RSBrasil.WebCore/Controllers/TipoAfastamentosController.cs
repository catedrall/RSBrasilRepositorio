using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class TipoAfastamentosController : Controller
    {

        private IConfiguration _configuration;

        public TipoAfastamentosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<TipoAfastamentos> tipoDeAfastamentos = GetClienteAsync();
            return View(tipoDeAfastamentos);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
                
        public List<TipoAfastamentos> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var tipoDeAfastamentos = JsonConvert.DeserializeObject<List<TipoAfastamentos>>(response.Result);
                return tipoDeAfastamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}