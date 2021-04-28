using Entidades.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class Extensora
    {
        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id)
        {
            //PARA HACERLO DIRECTAMENTE SOBRE LA BASE DE DATOS:
            //Parametros que necesito
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();

            bool retorno = true;
            try
            { 
                //Configuro el comando (Como se recibe por string, el string con el comando, y la conexion)
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE FROM frutas WHERE id=@id";
                comando.Connection = cn;

                //Agrego el parametro de id, directamente con el valor que le quiero asignar
                comando.Parameters.AddWithValue("@id", id);

                //Abro la conexion
                cn.Open();

                //Ejecuto el comando para eliminar, si devuelve cero no afecto a ninguna fila, entonces
                //Devuelvo false, porque no se elimino nada
                if(comando.ExecuteNonQuery() == 0)
                {
                    retorno = false;
                }

                //Cierro conexion
                cn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error con la base de datos");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return retorno;

 //**************************************************************************************************************//
 //**************************************************************************************************************//


            //PARA HACERLO CON DATAADAPTER Y DATATABLE:
            /*
            bool ret = true;
            try
            {
                //Creo el data adapter y el data table y cnfiguro la conexin
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.Conexion);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("frutas");

                //Configuro el data table
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("peso", typeof(double));
                dt.Columns.Add("precio", typeof(double));

                dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };

                dt.Columns["id"].AutoIncrement = true;
                dt.Columns["id"].AutoIncrementSeed = 1;
                dt.Columns["id"].AutoIncrementStep = 1;

                //configuro el data adapter
                da.DeleteCommand = new SqlCommand("DELETE FROM frutas WHERE id=@id", cn);
                da.SelectCommand = new SqlCommand("SELECT * FROM frutas", cn);

                da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                //Cargo la tabla de la base en mi data table
                da.Fill(dt);

                DataRow fila = null;

                foreach(DataRow item in dt.Rows)
                {
                    if(int.Parse(item["id"].ToString()) == id)
                    {
                        fila = item;
                        break;
                    }
                }

                if (fila != null)
                {
                    fila.Delete();
                    da.Update(dt);
                }
                else
                {
                    ret = false;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Error con la base de datos");
            }
            return ret;
            */
        }
    }
}
