﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15_TrabalhoModelo_2022_23.Livros
{
    public class Livro
    {
        public int Nlivro { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public DateTime Data_Aquisicao { get; set; }
        public Decimal Preco { get; set; }
        public string Capa { get; set; }
        public bool Estado { get; set; }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Livros(nome,ano,data_aquisicao,preco,capa,estado) VALUES 
                            (@nome,@ano,@data_aquisicao,@preco,@capa,1)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Aquisicao.Date
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco
                },
                new SqlParameter()
                {
                    ParameterName="@capa",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Capa
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Livros";
            return bd.DevolveSQL(sql);
        }

        public DataTable Procurar(int nlivro,BaseDados bd)
        {
            string sql = "SELECT * FROM Livros WHERE nlivro=" + nlivro;
            DataTable temp= bd.DevolveSQL(sql);

            if(temp!=null && temp.Rows.Count>0)
            {
                this.Nlivro = int.Parse(temp.Rows[0]["nlivro"].ToString());
                this.Nome = temp.Rows[0]["nome"].ToString();
                this.Ano = int.Parse(temp.Rows[0]["ano"].ToString());
                this.Data_Aquisicao = DateTime.Parse(temp.Rows[0]["data_aquisicao"].ToString());
                this.Preco = Decimal.Parse(temp.Rows[0]["preco"].ToString());
                this.Capa = temp.Rows[0]["capa"].ToString();
                this.Estado = bool.Parse(temp.Rows[0]["estado"].ToString());
            }

            return temp;
        }

        public static void ApagarLivro(int nlivro, BaseDados bd)
        {
            string sql = "DELETE FROM Livros WHERE nlivro=" + nlivro;
            bd.ExecutaSQL(sql);
        }
    }
}