using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace pequenoCRUD
{
    class LivroDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BDLivros.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }
            
        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmLivro(Livro umlivro)
        {
            String aux = "insert into TabLivro(codigo,titulo,autor,editora,ano) values ('" + umlivro.getCodigo() + "','" + umlivro.getTitulo() + "','" + umlivro.getAutor() + "','" + umlivro.getEditora() + "','" + umlivro.getAno() + "')";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void excluiUmLivro(Livro umlivro)
        {
            String aux = "delete from TabLivro where codigo ='" + umlivro.getCodigo() + "'";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }
        public static void atualizaUmLivro(Livro umlivro)
        {
            String aux = "update TabLivro set titulo='" + umlivro.getTitulo() + "', autor='" + umlivro.getAutor() +"', editora='" + umlivro.getEditora() + "', ano='" + umlivro.getAno() + "' where codigo ='" + umlivro.getCodigo() + "'";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void consultaUmLivro(Livro umlivro)
        {
            String aux = "select * from TabLivro where codigo ='" + umlivro.getCodigo() + "'";

            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                umlivro.setTitulo(result.GetString(1));
                umlivro.setAutor(result.GetString(2));
                umlivro.setEditora(result.GetString(3));
                umlivro.setAno(result.GetString(4));
            }
            else
                Erro.setMsg("Livro não cadastrado.");
        }


    }
}
