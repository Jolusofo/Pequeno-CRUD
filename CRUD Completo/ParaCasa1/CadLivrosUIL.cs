using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pequenoCRUD
{
    public partial class CadLivrosUIL : Form
    {
        Livro umlivro = new Livro();
        public CadLivrosUIL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            umlivro.setCodigo(textBox1.Text);
            umlivro.setTitulo(textBox2.Text);
            umlivro.setAutor(textBox3.Text);
            umlivro.setEditora(textBox4.Text);
            umlivro.setAno(textBox5.Text);

            LivroBLL.validaDados(umlivro,'i');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void CadLivrosUIL_Load(object sender, EventArgs e)
        {
            LivroBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            umlivro.setCodigo(textBox1.Text);

            LivroBLL.validaCodigo(umlivro,'c');
            
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                textBox1.Text = umlivro.getCodigo();
                textBox2.Text = umlivro.getTitulo();
                textBox3.Text = umlivro.getAutor();
                textBox4.Text = umlivro.getEditora();
                textBox5.Text = umlivro.getAno();
            }
        }

        private void CadLivrosUIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivroBLL.desconecta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            umlivro.setCodigo(textBox1.Text);

            LivroBLL.validaCodigo(umlivro,'e');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Livro Excluído!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            umlivro.setCodigo(textBox1.Text);
            umlivro.setTitulo(textBox2.Text);
            umlivro.setAutor(textBox3.Text);
            umlivro.setEditora(textBox4.Text);
            umlivro.setAno(textBox5.Text);

            LivroBLL.validaDados(umlivro,'a');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");
        }
    }
}
