using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CapaEntidad;


namespace Capa_Acceso_Datos
{
    public class D_cat
    {
        SqlConnection conexion = new SqlConnection("server=LAPTOP-6R0HNJDA ; database=Agenda2 ; integrated security = true");

public List<E_cat> ListarContactos(string Buscar)
        {
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarContacto", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", Buscar);
            leerfilas = cmd.ExecuteReader();

            List<E_cat> Listar = new List<E_cat>();
            while (leerfilas.Read())
            {
                Listar.Add(new E_cat
                {
                    Idcontactos = leerfilas.GetInt32(0),
                    Nombre = leerfilas.GetString(1),
                    Apellido = leerfilas.GetString(2),
                    Celular = leerfilas.GetInt32(3),
                    Fecha_nacimiento = leerfilas.GetDateTime(4)


                });
            }
            conexion.Close();
            leerfilas.Close();
            return Listar;

        }

        public void InsertarCont(E_cat contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarContacto", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
            cmd.Parameters.AddWithValue("@Celular", contacto.Celular);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", contacto.Fecha_nacimiento);


            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarCont(E_cat contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_editarContacto", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDcontacto", contacto.Idcontactos);
            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
            cmd.Parameters.AddWithValue("@Celular", contacto.Celular);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", contacto.Fecha_nacimiento);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EliminarCont(E_cat contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_eliminarContacto", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDcontacto", contacto.Idcontactos);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

    }
}
