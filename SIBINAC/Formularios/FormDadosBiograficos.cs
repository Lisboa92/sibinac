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
    public partial class FormDadosBiograficos : Form
    {
        public FormDadosBiograficos()
        {
            InitializeComponent();
            // Associa o evento Load do formulário para carregar as nacionalidades
            this.Load += FormDadosBiograficos_Load;
        }

        public void AtualizarNumeroRegistro(string numeroRegistro)
        {
            // Atribui o valor recebido ao TextBox correspondente
            txtNumReg.Text = numeroRegistro;
        }

        private void FormDadosBiograficos_Load(object sender, EventArgs e)
        {
            PreencherNacionalidades();
        }

        private void PreencherNacionalidades()
        {
            // Lista abrangente de nacionalidades em português (ordenada alfabeticamente)
            List<string> nacionalidades = new List<string>
            {
                "Afegã", "Albanesa", "Alemã", "Andorrana", "Angolana", "Antiguana", "Saudita", "Argelina", "Argentina", "Armênia",
                "Australiana", "Austríaca", "Azerbaijana", "Bahamense", "Bahreinita", "Bangladexense", "Barbadense", "Belga", "Belizense", "Beninense",
                "Bielorrussa", "Birmanesa", "Boliviana", "Bósnia", "Botsuana", "Brasileira", "Bruneiana", "Búlgara", "Burquinense", "Burundiana",
                "Butanesa", "Cabo-verdiana", "Camaronesa", "Cambojana", "Canadense", "Catarina", "Cazaque", "Centro-africana", "Chadiana", "Chilena",
                "Chinesa", "Cipriota", "Colombiana", "Comoriana", "Congolesa", "Cossovar", "Costa-riquenha", "Croata", "Cubana", "Dinamarquesa",
                "Djibutiana", "Dominiquense", "Egípcia", "Salvadorenha", "Emiratense", "Equatoriana", "Eritreia", "Eslovaca", "Eslovena", "Espanhola",
                "Estadunidense", "Estônia", "Eswatínia", "Etíope", "Fidjiana", "Filipina", "Finlandesa", "Francesa", "Gabonesa", "Gambiana",
                "Ganesa", "Georgiana", "Granadina", "Grega", "Guatemalteca", "Guianense", "Guineense", "Guineense-bissauense", "Equato-guineense", "Haitiana",
                "Hondurenha", "Húngara", "Iemenita", "Iaquistanesa", "Indiana", "Indonésia", "Iraniana", "Iraquiana", "Irlandesa", "Islandesa",
                "Israelense", "Italiana", "Jamaicana", "Japonesa", "Jordaniana", "Kiribatiana", "Kuwaitiana", "Laosiana", "Lesota", "Letã",
                "Libanesa", "Liberiana", "Líbia", "Liechtensteinense", "Lituana", "Luxemburguesa", "Macedônia", "Madagandense", "Malásia", "Malauiana",
                "Maldivana", "Malinesa", "Maltesa", "Marroquina", "Marshallina", "Mauriciana", "Mauritana", "Mexicana", "Micronésia", "Moçambicana",
                "Moldava", "Monacoense", "Mongol", "Montenegrina", "Namíbia", "Nauruana", "Neozelandesa", "Nepalesa", "Nicaraguense", "Nigeriana",
                "Nigerina", "Norte-coreana", "Norueguesa", "Omanense", "Neerlandesa", "Palauana", "Palestina", "Panamenha", "Papuásia", "Paquistanesa",
                "Paraguaia", "Peruana", "Polonesa", "Portorriquenha", "Portuguesa", "Queniana", "Quirguiz", "Britânica", "Romena", "Ruandesa",
                "Russa", "Salomônica", "Samoana", "San-marinense", "Santa-lucense", "São-cristovense", "São-tomense", "São-vicentina", "Senegalesa", "Serra-leonesa",
                "Sérvia", "Seychelense", "Singapurense", "Síria", "Somali", "Sri-lanquesa", "Sudanesa", "Sul-sudanesa", "Sul-coreana", "Sueca",
                "Suíça", "Surinamesa", "Tailandesa", "Taiwanesa", "Tajique", "Tanzaniana", "Tcheca", "Timorense", "Togolesa", "Tonganesa",
                "Trinitária", "Tunisiana", "Turcomana", "Turca", "Tuvaluana", "Ucraniana", "Ugandense", "Uruguaia", "Uzbeque", "Vanuatense",
                "Vaticana", "Venezuelana", "Vietnamita", "Zambiana", "Zimbabuana"
            };

            // Define a lista como fonte de dados da ComboBox
            cboxNacionalidade.DataSource = nacionalidades;

            // Opcional: Deixar a ComboBox sem nenhuma seleção inicial
            cboxNacionalidade.SelectedIndex = -1;
        }
    }
}