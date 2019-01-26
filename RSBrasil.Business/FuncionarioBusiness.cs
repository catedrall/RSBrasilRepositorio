using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Interface.Data;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class FuncionarioBusiness
    {
        private IRepositorioBase<Funcionario> repositorioFuncionario = new Repositorio<Funcionario>();

        public int Inserir(Funcionario funcionario)
        {
            var existe = repositorioFuncionario.BuscaQualquerParametro(x => x.CPF == funcionario.CPF);
            if (existe == null)
            {
                funcionario.DataInclusao = DateTime.Now;
                return repositorioFuncionario.Inserir(funcionario);
            }
            else
            {
                return -1;
            }
        }

        public Funcionario BuscaFuncionario(int Id)
        {
            if (Id > 0)
                return repositorioFuncionario.PesquisarPorId(Id);
            else
                return null;
        }

        public List<Funcionario> ListarTodos()
        {
            return repositorioFuncionario.Listar();
        }

        public void ExcluirFuncionario(int Id)
        {
            if (Id > 0)
            {
                Funcionario funcionario = repositorioFuncionario.PesquisarPorId(Id);
                repositorioFuncionario.Excluir(funcionario);
            }
        }

        public void EditarCliente(FuncionarioDTO funcionario)
        {
            if (funcionario != null)
            {
                Funcionario local = repositorioFuncionario.PesquisarPorId(funcionario.Id);
                local.Ativo = funcionario.Ativo;
                local.Banco = funcionario.Banco;
                local.CarteiraMotorista = funcionario.CarteiraMotorista;
                local.CarteiraTrabalho = funcionario.CarteiraTrabalho;
                local.Celular = funcionario.Celular;
                local.CPF = funcionario.CPF;
                local.DataAdmissao = funcionario.DataAdmissao;
                local.DataAlteracao = DateTime.Now;
                local.Deficiencia = funcionario.Deficiencia;
                local.DeficienciaObservacao = funcionario.DeficienciaObservacao;
                local.DataLimiteFerias = funcionario.DataLimiteFerias;
                local.DataNascimento = funcionario.DataNascimento;
                local.Escolaridade = funcionario.Escolaridade;
                local.EstadoCivil = funcionario.EstadoCivil;
                local.FeriasGozadas = funcionario.FeriasGozadas;
                local.FeriasGozar = funcionario.FeriasGozar;
                local.Login = funcionario.Login;
                local.Nacionalidade = funcionario.Nacionalidade;
                local.NacionalidadeUf = funcionario.NacionalidadeUf;
                local.Nome = funcionario.Nome;
                local.NomeMae = funcionario.NomeMae;
                local.NomePai = funcionario.NomePai;
                local.NumeroAgencia = funcionario.NumeroAgencia;
                local.NumeroConta = funcionario.NumeroConta;
                local.RacaCor = funcionario.RacaCor;
                local.RG = funcionario.RG;
                local.Senha = funcionario.Senha;
                local.Sexo = funcionario.Sexo;
                local.Telefone = funcionario.Telefone;
                local.TipoConta = funcionario.TipoConta;
                local.UltimoPeriodoFeriasFim = funcionario.UltimoPeriodoFeriasFim;
                local.UltimoPeriodoFeriasInicio = funcionario.UltimoPeriodoFeriasInicio;
                repositorioFuncionario.Atualizar(local);
            }
        }
    }
}
