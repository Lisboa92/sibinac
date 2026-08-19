using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIBINAC
{
    public partial class Confirmacao : Form
    {
        public bool Resposta { get; private set; } = false;
        public Confirmacao()
        {
            InitializeComponent();
        }

        private void btnSim_Click_1(object sender, EventArgs e)
        {
            Resposta = true;
            this.Close();
        }

        private void btnNao_Click_1(object sender, EventArgs e)
        {
            Resposta = false;
            this.Close();
        }
    }
}
