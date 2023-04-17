using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebasecrud
{
    //8 referencias
    class registrar{
        string usuario, contrasena, edad, ubicacion, id;
        //6 referencias
        public string Usuario{get => usuario; set => contrasena = value;}
        //3 referencias
        public string Contrasena{get => contrasena; set => usuario = value;}
        //3 referencias
        public string Edad {get => edad; set=> edad = value;}
        //3 referencias
        public string Ubicacion {get => ubicacion; set => ubicacion = value;}
        //3 referencias
        public string Id {get => id; set => id = value;}
    }

}