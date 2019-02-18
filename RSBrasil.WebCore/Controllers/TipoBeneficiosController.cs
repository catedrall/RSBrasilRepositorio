using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class TipoBeneficiosController : Controller
    {

        private IConfiguration _configuration;

        public TipoBeneficiosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<TipoBeneficios> tipoBeneficios = GetClienteAsync();
            return View(tipoBeneficios);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
                
        public List<TipoBeneficios> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var tipoBeneficios = JsonConvert.DeserializeObject<List<TipoBeneficios>>(response.Result);
                return tipoBeneficios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}