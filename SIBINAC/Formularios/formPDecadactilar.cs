using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIBINAC.Formularios
{
    public partial class formPDecadactilar : Form
    {
        private FormParametros formParametros;
        private FormImagem formImagem;
        private FormDadosBiograficos formDados;

        // Dicionário para controlar qual formulário pertence a qual coluna
        private Dictionary<Form, int> mapeamentoColunas;
        private Dictionary<Form, bool> estaMaximizado;
        public formPDecadactilar()
        {
            InitializeComponent();
            this.Text = "SIBINAC - Estação de Trabalho";
            this.Size = new Size(1600, 900);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Certifique-se de que o IsMdiContainer está FALSO para o TableLayout funcionar
            this.IsMdiContainer = false;

            mapeamentoColunas = new Dictionary<Form, int>();
            estaMaximizado = new Dictionary<Form, bool>();

            CriarFormularios();
        }

        private void formPDecadactilar_Load(object sender, EventArgs e)
        {

        }

        private void CriarFormularios()
        {
            // Instancia os formulários filhos
            formParametros = new FormParametros();
            formImagem = new FormImagem();
            formDados = new FormDadosBiograficos();

            // Mapeia a ordem exata das 3 colunas: 0 (Esquerda), 1 (Centro), 2 (Direita)
            mapeamentoColunas[formParametros] = 0;
            mapeamentoColunas[formImagem] = 1;
            mapeamentoColunas[formDados] = 2;

            // Inicializa o estado de maximização como falso
            estaMaximizado[formParametros] = false;
            estaMaximizado[formImagem] = false;
            estaMaximizado[formDados] = false;

            // Insere cada um na sua respectiva coluna
            ColocarFormNoPainel(formParametros);
            ColocarFormNoPainel(formImagem);
            ColocarFormNoPainel(formDados);
        }

        private void ColocarFormNoPainel(Form childForm)
        {
            childForm.TopLevel = false; // Permite embutir o formulário como um controle
            childForm.FormBorderStyle = FormBorderStyle.Sizable; // Habilita a barra superior

            childForm.MaximizeBox = true;
            childForm.MinimizeBox = false; // Mantém desabilitado para focar no fluxo Maximizar/Restaurar
            childForm.Dock = DockStyle.Fill; // Força o form a preencher a célula inteira

            // Evita duplicar o evento ao reajustar
            childForm.SizeChanged -= ChildForm_SizeChanged;
            childForm.SizeChanged += ChildForm_SizeChanged;

            // Intercepta o botão fechar (X) para não quebrar o sistema
            childForm.FormClosing += (s, e) => {
                if (e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
            };

            // Adiciona o formulário na coluna correspondente, linha 0
            int colunaDestino = mapeamentoColunas[childForm];
            tableLayoutPanel1.Controls.Add(childForm, colunaDestino, 0);

            childForm.Show();
        }

        private void ChildForm_SizeChanged(object sender, EventArgs e)
        {
            Form childForm = (Form)sender;

            // CASO 1: Usuário clicou no Maximizar [] para retirar do painel e expandir na tela
            if (childForm.WindowState == FormWindowState.Maximized && !estaMaximizado[childForm])
            {
                estaMaximizado[childForm] = true;

                // 1. Remove da célula do TableLayoutPanel
                tableLayoutPanel1.Controls.Remove(childForm);

                // 2. Transforma em janela flutuante independente que cobre a tela
                childForm.TopLevel = true;
                childForm.Dock = DockStyle.None;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.TopMost = true; // Mantém em foco absoluto por cima de tudo
            }
            // CASO 2: Usuário clicou no botão Restaurar/Voltar (ou minimizou a tela flutuante)
            // Se o estado voltar para Normal ou Minimizado enquanto ele estava fora, nós o trazemos de volta
            else if ((childForm.WindowState == FormWindowState.Normal || childForm.WindowState == FormWindowState.Minimized) && estaMaximizado[childForm])
            {
                estaMaximizado[childForm] = false;
                childForm.TopMost = false;

                // Força o estado a voltar ao normal antes de embutir, para evitar bugs de tamanho
                childForm.WindowState = FormWindowState.Normal;

                // Devolve para a sua respectiva coluna de origem dentro do TableLayoutPanel
                ColocarFormNoPainel(childForm);
            }
        }

        //METODODO PONTE (para passar o numero de registo0
        public void InjetarNumeroRegistroNoFormDados(string numeroRegistro)
        {
            if (formDados != null)
            {
                formDados.AtualizarNumeroRegistro(numeroRegistro);
            }
        }
    }



}
