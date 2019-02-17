using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class TipoDeAfastamentosController : Controller
    {

        private IConfiguration _configuration;

        public TipoDeAfastamentosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<TipoDeAfastamentos> tipoDeAfastamentos = GetClienteAsync();
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
                
        public List<TipoDeAfastamentos> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var tipoDeAfastamentos = JsonConvert.DeserializeObject<List<TipoDeAfastamentos>>(response.Result);
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