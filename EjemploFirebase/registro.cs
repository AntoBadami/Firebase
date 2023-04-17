//falta el inicio 



namespace firebasecrud
{

    public partial class registro : Form{

        IFirebaseConfig config = new FirebaseConfig{
            AuthSecret = "kHsT70sE7Q9hPkWFHxYGghrnUodOf9AG6B1W",
            BasePath = "http://formulageneral-Sb180.firebaseio.com/"
        };

        IFirebaseClient client;

        public registro(){
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private void Registrar_Click(object sender, EventArgs e){
            int ver = verificar_usuario(txtusuario.Text);

            if (ver == 1)
            {
                MessageBox.Show("usuario existes");
            }else{
                Guid g = Guid.NewGuid();
                string uuid = g.ToString();
                var registrarse = new registrar{
                    Usuario = txtusuario.Text,
                    Contrasena = txtcontrasena.Text,
                    Ubicacion = txtubicacion.Text,
                    Edad = txtedad.Text,
                    Id = uuid
                };
                FirebaseResponse = client.Set("usuarios/"+ uuid, registrarse);
                MessageBox.Show("usuario registrado");
            }
        }

        private int verificar_usuario(string _usuario){
            int bandera = 0;

            FirebaseResponse _response = client.Get("usuarios/");
            Dictionary<string, registrar> resultado = _response.ResultAs<Dictionary<string, registrar>>();

            if(resultado == null){

            }else{
                foreach (var item in resultado)
                {
                    string usuario = item.Value.Usuario;
                    if(_usuario == usuario && bandera == 0){
                        bandera = 1;
                    }
                }
            }
            return bandera;
        }


    }

}
