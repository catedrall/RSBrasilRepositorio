using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class TipoDocumentosController : Controller
    {

        private IConfiguration _configuration;

        public TipoDocumentosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<TipoDocumentos> tipoDocumentos = GetClienteAsync();
            return View(tipoDocumentos);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
                
        public List<TipoDocumentos> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var tipoDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentos>>(response.Result);
                return tipoDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}