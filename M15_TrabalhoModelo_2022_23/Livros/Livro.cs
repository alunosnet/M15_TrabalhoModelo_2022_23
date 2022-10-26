using System;
using System.Collections.Generic;
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
    }
}
