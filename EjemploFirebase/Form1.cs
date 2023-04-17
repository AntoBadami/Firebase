using System;


//falta unas lineas del inio
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebasecrud
{
    public partial class Form1 : Form{

        public static string uuid;
        
        IFirebaseConfig config = new FirebaseConfig{
            AuthSecret = "kHsT70sE7Q9hPkWFHxYGghrnUodOf9AG6B1W",
            BasePath = "http://formulageneral-Sb180.firebaseio.com/"
        };
        IFirebaseClient client;

        //1 referencia
        public Form1(){
            client = new FireSharp.FirebaseClient(config);
            InitializeComponent();
        }
    }

    //1 referencia
    private void button1_Click(object sender, EventArgs e){

        if(string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text)){
            MessageBox.Show("Por favor llenar los datos");
        }else{
            FirebaseResponse response = client.Get("usuarios/");
            Dictionary<string, registrar> resultado = response.ResultAs<Dictionary<string, registrar>>();
            foreach (var item in resultado)
            {
                string usuario = item.Value.Usuario;
                string pwd = item.Value.Contrasena;
                uuid = item.Value.Id;
                if (textBox1.Text == usuario){
                    if (textBox2.Text == pwd){

                        mis_datos ms = new mis_datos();
                        ms.Show();
                        this.Hide();
                    }

                }
            }
        }

    }



}

// falta el final, una funcion del button2 y no se si algo mas o solo eso
