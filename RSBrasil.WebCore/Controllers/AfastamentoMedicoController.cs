using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class AfastamentoMedicoController : Controller
    {

        private IConfiguration _configuration;

        public AfastamentoMedicoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            //List<AfastamentoMedico> afastamento = GetClienteAsync();
            //return View(afastamento);
            return View();
        }

        public ActionResult Novo()
        {
            ViewBag.IdFuncionario = new SelectList
                (
                    GetFuncionarioAsync(),
                    "Id",
                    "Nome"
                );

            return View();
        }

        public ActionResult Edit()
        {
            return View();
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

        public List<AfastamentoMedico> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var afastamento = JsonConvert.DeserializeObject<List<AfastamentoMedico>>(response.Result);
                return afastamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}