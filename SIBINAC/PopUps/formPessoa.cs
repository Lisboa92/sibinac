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
    public partial class formPessoa : Form
    {

        public formPessoa()
        {
            InitializeComponent();
        }

        private void btnSairPessoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnvPDecada_Click(object sender, EventArgs e)
        {
            // CORRIGIDO: Usando o nome exato da sua classe 'popIntrIdentificacao'
            popIntrIdentificacao pop = new popIntrIdentificacao();

            // Abre o formulário passando o formPessoa atual como Owner
            pop.ShowDialog(this);

            // Fecha o formPessoa atual após o pop-up ser encerrado
            this.Close();
        }
    }

}
