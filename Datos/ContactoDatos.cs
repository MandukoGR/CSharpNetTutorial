using CRUDCORE.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using(var conexion = new MySqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),

                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new MySqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("U_IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("U_Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("U_Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("U_Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("U_IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("U_Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("U_Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("U_Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("U_IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

    }
}
