using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSBrasil.Model.DTOs;
using Microsoft.AspNetCore.Http;
using RSBrasil.Business;
using RSBRasil.Model.Entidades;

namespace RSBrasil.API.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("NovoFuncionario")]
        public IActionResult NovoFuncionario([FromBody] FuncionarioDTO funcionario)
        {
            funcionario.Validate();
            if (funcionario.Invalid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, funcionario.Notifications);
            }
            else
            {
                try
                {
                    Funcionario novoFuncionario = new Funcionario(
                        funcionario.CarteiraMotorista,
                        funcionario.CarteiraTrabalho,
                        funcionario.Celular,
                        funcionario.CPF,
                        funcionario.Login,
                        funcionario.Nome,
                        funcionario.RG,
                        funcionario.Senha,
                        funcionario.Telefone,
                        funcionario.DataNascimento,
                        funcionario.IdCargo,
                        funcionario.IdEndereco,
                        funcionario.IdFuncionario,
                        funcionario.IdPerfilAcesso);
                    FuncionarioBusiness negocio = new FuncionarioBusiness();
                    int result = negocio.Inserir(novoFuncionario);
                    if (result > 0)
                        return StatusCode(StatusCodes.Status200OK, "Cliente criado com sucesso!");
                    else
                        return BadRequest("Cliente já cadastrado!");
                }
                catch (Exception)
                {
                    return BadRequest("Erro inesperado!");
                }
            }
        }

        [HttpGet, Route("BuscaFuncionario/{Id}")]
        public JsonResult BuscaFuncionario(int Id)
        {
            try
            {
                FuncionarioBusiness negocio = new FuncionarioBusiness();
                var result = new JsonResult(negocio.BuscaFuncionario(Id));
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

        [HttpGet, Route("ListarFuncionarios")]
        public JsonResult ListarFuncionarios()
        {
            try
            {
                FuncionarioBusiness negocio = new FuncionarioBusiness();
                List<Funcionario> lista = new List<Funcionario>();
                lista = negocio.ListarTodos();
                var result = new JsonResult(lista);
                if (result != null)
                {
                    result.StatusCode = 200;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Funcionarios não localizados"));
                }
            }
            catch (Exception)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }

        [HttpPost, Route("ExcluirFuncionarios")]
        public IActionResult ExcluirFuncionarios([FromBody] FuncionarioDTO cliente)
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
                        FuncionarioBusiness negocio = new FuncionarioBusiness();
                        negocio.ExcluirFuncionario(cliente.Id);
                        return StatusCode(StatusCodes.Status200OK, "Funcionario excluido com sucesso!");
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

        [HttpPut, Route("EditarFuncionario")]
        public IActionResult EditarFuncionario([FromBody] FuncionarioDTO funcionario)
        {
            try
            {
                funcionario.Validate();
                if (funcionario.Invalid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, funcionario.Notifications);
                }
                else
                {
                    try
                    {
                        FuncionarioBusiness negocio = new FuncionarioBusiness();
                        negocio.EditarCliente(funcionario);
                        return StatusCode(StatusCodes.Status200OK, "Funcionario alterado com sucesso!");
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