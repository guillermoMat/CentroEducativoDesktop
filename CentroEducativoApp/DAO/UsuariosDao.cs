using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEducativoApp.DAO
{
    public class UsuariosDao
    {

        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string passw = "";
            string baseDatos = "login";

            string cadenaConexion = "Server=" + servidor + ";Database=" + baseDatos + ";Uid=" + usuario + ";Pwd=" + passw + ";";
            MySqlConnection miConexion = new MySqlConnection(cadenaConexion);
            miConexion.Open();

            return miConexion;


            //string cadenaConexion = "Database=" + baseDatos + ";Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + passw +";";
        }


        


    }
}
