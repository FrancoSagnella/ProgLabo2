using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EntidadesBD
{
    public class AccesoDatos
    {
        #region Atributos

        private SqlConnection conexion;
        private SqlCommand comando;

        #endregion

        #region Constructor
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
        }

        #endregion

        #region Métodos

        #region Getters
        public List<Persona> ObtenerListaPersonas()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion; 
                
                comando.CommandText = "SELECT * FROM Personas ORDER BY apellido, nombre";

                this.conexion.Open();
               
                SqlDataReader oDr = comando.ExecuteReader();

                while (oDr.Read())
                {
                    lista.Add(new Persona(oDr.GetInt32(0), oDr["apellido"].ToString(), oDr.GetString(1), oDr.GetInt32(3)));
                }

                oDr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        public DataTable ObtenerTablaPersonas()
        {
            DataTable tabla = new DataTable("Personas");

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;
                
                this.comando.CommandText = "SELECT * FROM Personas ORDER BY apellido DESC, nombre";

                this.conexion.Open();
                
                SqlDataReader oDr = this.comando.ExecuteReader();

                tabla.Load(oDr);

                oDr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return tabla;
        }

        public Persona ObtenerPersonaPorID(int id)
        {
            Persona p = null;

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", id);

                this.comando.CommandText = "SELECT * FROM Personas WHERE id = @id";

                this.conexion.Open();

                SqlDataReader oDr = this.comando.ExecuteReader();

                if (oDr.Read())
                {
                    p = new Persona(oDr.GetInt32(0), oDr.GetString(1), oDr.GetString(2), oDr.GetInt32(3));
                }

                oDr.Close();
            }

            catch (Exception e)
            {
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return p;
        }

        #endregion

        #region Insertar Persona
        public bool InsertarPersona(Persona p)
        {
            bool todoOk = false;

            string sql = "INSERT INTO Personas (nombre, apellido, edad) ";
            sql += "VALUES (@nombre, @apellido, @edad)";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@nombre", p.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", p.Apellido);
                this.comando.Parameters.AddWithValue("@edad", p.Edad);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        #endregion

        #region Modificar Persona
        public bool ModificarPersona(Persona p)
        {
            bool todoOk = false;

            string sql = "UPDATE Personas SET nombre = @nombre, apellido = @apellido, ";
            sql += "edad = @edad WHERE id = @id";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", p.ID);
                this.comando.Parameters.AddWithValue("@nombre", p.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", p.Apellido);
                this.comando.Parameters.AddWithValue("@edad", p.Edad);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        #endregion

        #region Eliminar Persona
        public bool EliminarPersona(Persona p)
        {
            bool todoOk = false;

            string sql = "DELETE FROM Personas WHERE id = @id";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", p.ID);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        #endregion

        #endregion

    }
}
