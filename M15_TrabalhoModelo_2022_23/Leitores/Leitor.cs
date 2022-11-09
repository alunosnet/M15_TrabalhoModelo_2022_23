using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
namespace M15_TrabalhoModelo_2022_23.Leitores
{
    public class Leitor
    {

        public int Nleitor { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento  { get; set; }
        public byte[] Fotografia { get; set; }
        public bool Estado { get; set; }
        public Leitor()
        { }
        public Leitor(int nleitor, string nome, DateTime dataNascimento, byte[] fotografia, bool estado)
        {
            Nleitor = nleitor;
            Nome = nome;
            DataNascimento = dataNascimento;
            Fotografia = fotografia;
            Estado = estado;
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Leitores(nome,data_nasc,fotografia,estado) VALUES 
                        (@nome,@data_nasc,@fotografia,1)";
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
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataNascimento
                },
                new SqlParameter()
                {
                    ParameterName="@fotografia",
                    SqlDbType=System.Data.SqlDbType.VarBinary,
                    Value=this.Fotografia
                },

            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * From Leitores";
            return bd.DevolveSQL(sql);
        }

        public void ProcurarPorNrLeitor(BaseDados bd,int nleitor)
        {
            string sql = "SELECT * FROM Leitores WHERE NLeitor=" + nleitor;
            DataTable dados = bd.DevolveSQL(sql);
            if(dados!=null && dados.Rows.Count>0)
            {
                this.Nleitor = int.Parse(dados.Rows[0]["nleitor"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.DataNascimento = DateTime.Parse(dados.Rows[0]["data_nasc"].ToString());
                this.Fotografia = (byte[])dados.Rows[0]["fotografia"];
                this.Estado = bool.Parse(dados.Rows[0]["estado"].ToString());
            }
        }

        internal static void Apagar(BaseDados bd, int nleitor_escolhido)
        {
            string sql = "DELETE FROM Leitores WHERE NLeitor=" + nleitor_escolhido;
            bd.ExecutaSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE Leitores SET nome=@nome,data_nasc=@data_nasc ";
            if (this.Fotografia != null)
                sql += ",fotografia=@fotografia";
            sql += " WHERE nleitor=@nleitor";
                        
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
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataNascimento
                },
                
                new SqlParameter()
                {
                    ParameterName="@nleitor",
                    SqlDbType=SqlDbType.Int,
                    Value=this.Nleitor
                }
            };
            if (this.Fotografia != null)
                parametros.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@fotografia",
                        SqlDbType = System.Data.SqlDbType.VarBinary,
                        Value = this.Fotografia
                    }
                );
            bd.ExecutaSQL(sql, parametros);
        }
    }
}
