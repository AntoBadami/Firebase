//creo que solo falta un poco del inicio


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebasecrud
{
    public partial class mis_datos : Form{

        public static string uuid = Form1.uuid;
        public static string usuario;
        
        IFirebaseConfig config = new FirebaseConfig{
            AuthSecret = "kHsT70sE7Q9hPkWFHxYGghrnUodOf9AG6B1W",
            BasePath = "http://formulageneral-Sb180.firebaseio.com/"
        };
        IFirebaseClient client;

        //2 referencia
        public mis_datos(){
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse resp2 = client.Get("usuarios/"+ Form1.uuid);
            registrar resultado = resp2.ResultAs<registrar>();
            lbledad.Text = resultado.Edad;
            lblnombre.Text = resultado.Usuario;
            lblubicacion.Text = resultado.Ubicacion;
            usuario = resultado.Usuario;
        }

        //1 referencia 
        private void button1_Click(object sender, EventArgs e){
            editar ed = new editar();
            ed.Show();
            Hide();
        }
        //1 referencia
        private void button2_Click(object senter, EventArgs e){
            FirebaseResponse resp2 = client.Delete("usuarios/"+ Form1.uuid);
            MessageBox.Show("usuario fue eliminado");
            this.Close();
        }

    }

    

}