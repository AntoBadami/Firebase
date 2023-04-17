//falta inicio

using System.ComponentModel;
using System.Data;
using System.Drawing;
// a partir de aqui sé que es asi, lo de arriba solo lo supuso pero ni idea

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebasecrud
{
    public partial class editar : Form{

        IFirebaseConfig config = new FirebaseConfig{
            AuthSecret = "kHsT70sE7Q9hPkWFHxYGghrnUodOf9AG6B1W",
            BasePath = "http://formulageneral-Sb180.firebaseio.com/"
        };
        IFirebaseClient client;

        public editar(){
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textcontrasena.Text) || string.IsNullOrEmpty(textedad.Text) || string.IsNullOrEmpty(textubicacion.Text)){
            MessageBox.Show("campos no pueden estar vacios");
            }else
            {
                var registrarse = new registrar{
                Usuario = mis_datos.usuario,
                Contrasena = txtcontrasena.Text,
                Ubicacion = txtubicacion.Text,
                Edad = txtedad.Text,
                Id = mis_datos.uuid
                };
                FirebaseResponse response = client.Set("usuarios/"+ mis_datos.uuid, registrarse);
                MessageBox.Show("usuario actualizado");
                }
        }
        
        private void button2_Click(object senter, EventArgs e){
            mis_datos ds = new mis_datos();
            ds.Show();
            this.Hide();
        }

    }

    

}