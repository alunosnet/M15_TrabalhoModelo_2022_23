using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace M15_TrabalhoModelo_2022_23
{
    public class BaseDados
    {
        string ligaBD;
        SqlConnection sqlConnection;
        string NomeBD;
        string caminhoBD;
        /*construtor*/
        public BaseDados(string NomeBD)
        {
            ligaBD = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.NomeBD = NomeBD;
            string caminhoBD=Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            caminhoBD += "\\M15_TrabalhoModelo\\";
            this.caminhoBD = caminhoBD + NomeBD + ".mdf";
            if (System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }
            if(System.IO.File.Exists(this.caminhoBD) == false)
            {
                CriarBD();
            }
            //ligação BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(NomeBD);

        }
        /*destrutor*/
        ~BaseDados()
        {
            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch
            {
                //Pode ocorrer erros 
            }
        }
        private void CriarBD()
        {
            //ligar ao servidor BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            //criar a BD
            string sql = $"CREATE DATABASE {NomeBD} ON PRIMARY (NAME={NomeBD},FILENAME='{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(NomeBD);
            //criar as tabelas
            sql = @"create table leitores(
	                    nleitor int identity primary key,
	                    nome varchar(40) not null,
	                    data_nasc date,
	                    fotografia varbinary(max),
	                    estado bit
                    );
                    create table livros(
	                    nlivro int identity primary key,
	                    nome varchar(100),
	                    ano int,
	                    data_aquisicao date,
	                    preco decimal(4,2),
	                    capa varchar(300),
	                    estado bit
                    );
                    create table emprestimos(
	                    nemprestimo int identity primary key,
	                    nlivro int references livros(nlivro),
	                    nleitor int references leitores(nleitor),
	                    data_emprestimo date,
	                    data_devolve date,
	                    estado bit
                    );";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //fechar a ligação ao servidor BD
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        /// <summary>
        /// Vai executar um SQL que altera os dados (p.e:insert, delete ou update)
        /// </summary>
        public void ExecutaSQL(string sql,List<SqlParameter> parametros=null)
        {
            //TODO: Adicionar transações
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }
        /// <summary>
        /// Executa uma consulta e devolve os dados da bd
        /// </summary>
        /// <returns>Um datatable com o resultado da consulta</returns>
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            //TODO: adicionar transações
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            DataTable dados = new DataTable();

            SqlDataReader registos=comando.ExecuteReader();
            dados.Load(registos);

            registos.Close();
            comando.Dispose();
            registos = null;
            comando = null;

            return dados;
        }
        
    }
}
