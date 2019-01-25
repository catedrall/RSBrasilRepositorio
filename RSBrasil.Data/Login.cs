using MySql.Data.MySqlClient;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data
{
    public class Login
    {
        public Funcionario VerificaLogin(string usuario, string senha)
        {

            var funcionario = new Funcionario();
            var dbCon = DBConnection.Instance();

            try
            {
                if (dbCon.IsConnect())
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select ");
                    query.AppendLine("    f.NomeFuncionario, ");
                    query.AppendLine("    f.idPerfilAcesso ");
                    query.AppendLine("from ");
                    query.AppendLine("    funcionario f ");
                    query.AppendLine("where ");
                    query.AppendLine("    f.ativo = 1 ");
                    query.AppendFormat("    and f.login = '{0}' ", usuario).AppendLine();
                    query.AppendFormat("    and f.senha = '{0}' ", senha).AppendLine();

                    var cmd = new MySqlCommand(query.ToString(), dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //funcionario.NomeFuncionario = reader.GetString(0);
                        funcionario.IdPerfilAcesso = reader.GetInt32(1);
                    }
                    dbCon.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return funcionario;
        }

        public List<Telas> GetTelasPerfilAcesso(int idPerfil)
        {

            var telas = new List<Telas>();
            var dbCon = DBConnection.Instance();

            try
            {
                if (dbCon.IsConnect())
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select ");
                    query.AppendLine("    t.IdTelas ");
                    query.AppendLine("from ");
                    query.AppendLine("    telas t ");
                    query.AppendLine("    join perfilAcesso pa on t.idtelas - pa.idtela ");
                    query.AppendLine("where ");
                    query.AppendFormat("    t.idtelas = {0}", idPerfil).AppendLine();

                    var cmd = new MySqlCommand(query.ToString(), dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        telas.Add(new Telas
                        {
                            IdTelas = reader.GetInt32(0)
                        });
                    }
                    dbCon.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return telas;
        }
    }
}
