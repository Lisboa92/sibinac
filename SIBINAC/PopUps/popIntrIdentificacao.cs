using SIBINAC.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIBINAC.PopUps
{
    public partial class popIntrIdentificacao : Form
    {
        public popIntrIdentificacao()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            formPessoa fp = new formPessoa();
            fp.Show();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // 1. Verifica se o campo não está vazio
            if (string.IsNullOrWhiteSpace(txtIntrNumReg.Text))
            {
                MessageBox.Show("Por favor, insira o número de registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tenta procurar pela instância existente na memória
            formPDecadactilar formPrincipal = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is formPDecadactilar)
                {
                    formPrincipal = (formPDecadactilar)f;
                    break;
                }
            }

            // 3. SE ENCONTROU: Injeta o dado na tela que já está aberta
            if (formPrincipal != null)
            {
                formPrincipal.InjetarNumeroRegistroNoFormDados(txtIntrNumReg.Text);
                formPrincipal.BringToFront(); // Traz a tela para a frente
            }
            // 4. SE NÃO ENCONTROU: Cria uma nova instância da Estação de Trabalho e injeta o dado nela
            else
            {
                // Cria a estação de trabalho principal do zero
                formPrincipal = new formPDecadactilar();

                // Injeta o número de registro nela antes de exibir
                formPrincipal.InjetarNumeroRegistroNoFormDados(txtIntrNumReg.Text);

                // Exibe a estação principal para o especialista trabalhar
                formPrincipal.Show();
            }

            // 5. Fecha o pop-up atual de forma limpa
            this.Close();
        }
    }
}
