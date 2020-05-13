using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Todos os campos são de preenchimento obrigatorio
 * Ano de edição deverá ser numérico e positivo
*/

namespace pequenoCRUD
{
    class LivroBLL
    {
        public static void conecta()
        {
            LivroDAL.conecta();
        }

        public static void desconecta()
        {
            LivroDAL.desconecta();
        }

        public static void validaCodigo(Livro umlivro, char op)
        {
            Erro.setErro(false);
            if (umlivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (op == 'c')
                LivroDAL.consultaUmLivro(umlivro);
            else
                LivroDAL.excluiUmLivro(umlivro);
        }

        public static void validaDados(Livro umlivro, char op)
        {
            Erro.setErro(false);
            if (umlivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (umlivro.getTitulo().Equals(""))
            {
                Erro.setMsg("O título é de preenchimento obrigatório!");
                return;
            }
            if (umlivro.getAutor().Equals(""))
            {
                Erro.setMsg("O autor é de preenchimento obrigatório!");
                return;
            }
            if (umlivro.getEditora().Equals(""))
            {
                Erro.setMsg("A Editora é de preenchimento obrigatório!");
                return;
            }
            if (umlivro.getAno().Equals(""))
            {
                Erro.setMsg("O ano é de preenchimento obrigatório!");
                return;
            }


            try
            {
                int.Parse(umlivro.getAno());
            }
            catch (Exception)
            {
                Erro.setMsg("O valor do ano deve ser numérico!");
                return;
            }


            if (int.Parse(umlivro.getAno()) <= 0)
            {
                Erro.setMsg("O valor do Ano deve ser numérico e positivo!");
                return;
            }
            if (op == 'i')
                LivroDAL.inseriUmLivro(umlivro);
            else
                LivroDAL.atualizaUmLivro(umlivro);

        }

    }
}

