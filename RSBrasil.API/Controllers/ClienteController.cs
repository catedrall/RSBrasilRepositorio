using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSBrasil.Model.Entidades;
using RSBrasil.Shared.ValueObjects;
using RSBrasil.Business;
using RSBrasil.Model.DTOs;
using Microsoft.AspNetCore.Http;

namespace RSBrasil.API.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("NovoCliente")]
        public IActionResult NovoCliente([FromBody] ClienteDTO cliente)
        {
            cliente.Validate();
            if (cliente.Invalid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, cliente.Notifications);
            }
            else
            {   
                try
                {
                    Email email = new Email(cliente.Email);
                    Cliente novoCliente = new Cliente(cliente.CNPJ, 
                                                      cliente.Contato, 
                                                      email, 
                                                      cliente.NomeFantasia, 
                                                      cliente.RazaoSocial, 
                                                      cliente.Telefone,
                                                      cliente.IdContrato);

                    ClienteBusiness negocio = new ClienteBusiness();
                    Cliente result = negocio.Inserir(novoCliente);

                    if(result != null)
                    {
                        EnderecoBusiness negocioEndereco = new EnderecoBusiness();

                        Enderecos endCliente = new Enderecos(cliente.Cep);
                        endCliente.Bairro = cliente.Bairro;
                        endCliente.Cidade = cliente.Cidade;
                        endCliente.Complemento = cliente.Complemento;
                        endCliente.Idclientefuncionario = result.Id;
                        endCliente.Logradouro = cliente.Logradouro;
                        endCliente.Numero = cliente.Numero;
                        endCliente.Pais = "Brasil";

                        Enderecos end = negocioEndereco.Inserir(endCliente);

                        if (end != null)
                            return StatusCode(StatusCodes.Status200OK, "Cliente criado com sucesso!");
                        else
                            return BadRequest("Erro inesperado!");
                    }                        
                    else
                        return BadRequest("Cliente já cadastrado!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro inesperado!");
                }
            }
        }

        [HttpGet, Route("BuscaCliente/{Id}")]
        public JsonResult BuscaCliente(int Id)
        {
            try
            {
                ClienteBusiness negocio = new ClienteBusiness();
                var result = new JsonResult(negocio.BuscaCliente(Id));
                if (result.Value != null)
                {
                    result.StatusCode = 200;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Cliente não localizado"));
                }                
            }
            catch (Exception)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }

        [HttpGet, Route("ListarClientes")]
        public JsonResult ListarClientes()
        {
            try
            {
                ClienteBusiness negocio = new ClienteBusiness();
                List<Cliente> lista = new List<Cliente>();
                lista = negocio.ListarTodos();
                var result = new JsonResult(lista);
                if (result != null)
                {
                    result.StatusCode = 200;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Clientes não localizados"));
                }
            }
            catch (Exception)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }

        [HttpPost, Route("ExcluirClientes")]
        public IActionResult ExcluirClientes([FromBody] ClienteDTO cliente)
        {
            try
            {
                cliente.Validate();
                if (cliente.Invalid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, cliente.Notifications);
                }
                else
                {
                    try
                    {                        
                        ClienteBusiness negocio = new ClienteBusiness();
                        negocio.ExcluirCliente(cliente.Id);
                        return StatusCode(StatusCodes.Status200OK, "Cliente excluido com sucesso!");
                    }
                    catch (Exception)
                    {
                        return BadRequest("Erro inesperado!");
                    }
                }
            }
            catch (Exception)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }

        [HttpPut, Route("EditarCliente")]
        public IActionResult EditarCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                cliente.Validate();
                if (cliente.Invalid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, cliente.Notifications);
                }
                else
                {
                    try
                    {
                        ClienteBusiness negocio = new ClienteBusiness();
                        negocio.EditarCliente(cliente);
                        return StatusCode(StatusCodes.Status200OK, "Cliente alterado com sucesso!");
                    }
                    catch (Exception)
                    {
                        return BadRequest("Erro inesperado!");
                    }
                }
            }
            catch (Exception)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }
    }
}