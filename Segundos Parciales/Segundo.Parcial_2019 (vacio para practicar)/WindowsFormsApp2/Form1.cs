using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Entidades;
using Entidades.SP;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public Cajon<Manzana> c_manzanas;
        public Cajon<Banana> c_bananas;
        public Cajon<Durazno> c_duraznos;

        public Form1()
        {
            InitializeComponent();
        }

        //Crear la siguiente jerarquía de clases:
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Crear una instancia de cada clase e inicializar los atributos del form _manzana, _banana y _durazno. 
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("verde", 2, "rio negro");
            this._banana = new Banana("amarillo", 5, "ecuador");
            this._durazno = new Durazno("rojo", 2.5, 53);

            MessageBox.Show(this._manzana.ToString());
            MessageBox.Show(this._banana.ToString());
            MessageBox.Show(this._durazno.ToString());

        }

        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_manzanas = new Cajon<Manzana>(1.58, 3);
            this.c_bananas = new Cajon<Banana>(15.96, 4);
            this.c_duraznos = new Cajon<Durazno>(21.5, 1);

            this.c_manzanas += new Manzana("roja", 1, "neuquen");
            this.c_manzanas += this._manzana;
            this.c_manzanas += new Manzana("amarilla", 3, "san juan");

            this.c_bananas += new Banana("verde", 3, "brasil");
            this.c_bananas += this._banana;

            this.c_duraznos += this._durazno;

            MessageBox.Show(this.c_manzanas.ToString());
            MessageBox.Show(this.c_bananas.ToString());
            MessageBox.Show(this.c_duraznos.ToString());

        }

        //Crear las interfaces: 
        //ISerializar -> Xml(string):bool
        //IDeserializar -> Xml(string, out Fruta):bool
        //Implementar (implicitamente) ISerializar en Cajon y manzana
        //Implementar (explicitamente) IDeserializar en manzana
        //Los archivos .xml guardarlos en el escritorio del cliente
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;

            if (this._manzana.Xml("manzana.xml"))
            {
                MessageBox.Show("Manzana serializada OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

            if (((IDeserializar)this._manzana).Xml("manzana.xml", out aux))
            {
                MessageBox.Show("Manzana deserializada OK");
                MessageBox.Show(((Manzana)aux).ToString());
            }
            else
            {
                MessageBox.Show("NO Deserializado");
            }

            if (this.c_manzanas.Xml("manzanas.xml"))
            {
                MessageBox.Show("Cajon de Manzanas serializado OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //implementar estructura de manejo de excepciones
            try
            {
                this.c_duraznos += this._durazno;
            }
            catch (CajonLlenoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos y crearlo en la clase Manejadora (de instancia).
            Manejadora m = new Manejadora();
            this.c_bananas.EventoPrecio += new DelegadoPrecio(m.ImprimirTicket_EventoPrecio);

            try
            {
                this.c_bananas += new Banana("verde", 2, "argentina");
                this.c_bananas += new Banana("amarilla", 4, "ecuador");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Form1.ObtenerListadoFrutas());
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if (Form1.AgregarFrutas(this))
            {
                MessageBox.Show("Se agregaron las frutas a la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se agregaron las frutas a la Base de Datos");
            }
        }

        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //implementar manejo de excepciones
            try
            {
                if (this.c_manzanas.EliminarFruta(4))
                {
                    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
                }

                //implementar manejo de excepciones
                if (this.c_manzanas.EliminarFruta(1))
                {
                    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string ObtenerListadoFrutas()
        {
            /*
            //Para acceder Directamente a la base de datos
            //Declaro la lista a la que le cargo los datos
            List <Fruta> lista = new List<Fruta>();

            //Los tres atributos que necesito
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dr = comando.ExecuteReader();

            //Configuro el Command
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM frutas";
            comando.Connection = cn;

            //Abro conexion y cargo
            cn.Open();

            while (dr.Read())
            {
                //Aca tendria que ir cargando cada lectura en un item y añadir ese itema la lista
                //En este ejemplo justo no se puede, porque Fruta no se instancia, ni tiene los mismos atributos
                
                Fruta item = new Fruta();

                item.Nombre = dr["nombre"].ToString();

                lista.add(item);
                
            }

            //Al final cierro la conexion
            cn.Close();
            */
        
//**************************************************************************************************************/
 //**************************************************************************************************************//

            //Para acceder con data table y data adapter:

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
            da.SelectCommand = new SqlCommand("SELECT * FROM frutas", cn);

            //Cargo el data table con el contenido de la base de datos
            da.Fill(dt);


            //Muestro el contenido del data table
            StringBuilder sb = new StringBuilder();

            foreach(DataRow fila in dt.Rows)
            {
                sb.AppendFormat("{0} - ",fila["id"].ToString());
                sb.AppendFormat("{0} - ", fila["nombre"].ToString());
                sb.AppendFormat("{0} - ", fila["peso"].ToString());
                sb.AppendLine(fila["precio"].ToString());
            }
            return sb.ToString();
            
        }

        private static bool AgregarFrutas(Form1 frm)
        {
            /*
            bool retorno = true;
            // PARA AGREAGAR COSAS DIRECTAMENTE USANDO LA CONECCION DE SQL
            //Los tres atributos que necesito
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();
            try
            {
                //Configuro el Command
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO frutas (nombre, peso, precio) VALUES (@nombre, @peso, @precio)";
                comando.Connection = cn;

                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@peso", SqlDbType.Float);
                comando.Parameters.Add("@precio", SqlDbType.Float);
                //Abro la conexion
                cn.Open();

                //Configuro los parametros con los valores que voy a añadir
                comando.Parameters["@nombre"].Value = frm._banana.Nombre;
                comando.Parameters["@peso"].Value = frm._banana.Peso;
                comando.Parameters["@precio"].Value = 20;

                //Cargo los datos
                comando.ExecuteNonQuery();

                //Configuro los parametros con los valores que voy a añadir
                comando.Parameters["@nombre"].Value = frm._manzana.Nombre;
                comando.Parameters["@peso"].Value = frm._manzana.Peso;
                comando.Parameters["@precio"].Value = 30;

                //Cargo los datos
                comando.ExecuteNonQuery();

                //Configuro los parametros con los valores que voy a añadir
                comando.Parameters["@nombre"].Value = frm._durazno.Nombre;
                comando.Parameters["@peso"].Value = frm._durazno.Peso;
                comando.Parameters["@precio"].Value = 40;

                //Cargo los datos
                comando.ExecuteNonQuery();

                //Cierro conexion
                cn.Close();
            }
            catch(Exception ex)
            {
                retorno = false;
            }
            finally
            {
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return retorno;
            */



//**************************************************************************************************************//
//**************************************************************************************************************//


            //PARA AGREGAR COSAS USANDO UN DATA ADAPTER Y UN DATA TABLE
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
                da.InsertCommand = new SqlCommand("INSERT INTO frutas (nombre, peso, precio) VALUES (@nombre, @peso, @precio)", cn);

                da.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                da.InsertCommand.Parameters.Add("@peso", SqlDbType.Float, 10, "peso");
                da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 50, "precio");

                //Creo nuevas filas y voy agregando las frutas
                DataRow fila = dt.NewRow();

                fila["nombre"] = frm._banana.Nombre;
                fila["peso"] = frm._banana.Peso;
                fila["precio"] = 20;
                dt.Rows.Add(fila);

                fila = dt.NewRow();

                fila["nombre"] = frm._durazno.Nombre;
                fila["peso"] = frm._durazno.Peso;
                fila["precio"] = 10;
                dt.Rows.Add(fila);

                fila = dt.NewRow();

                fila["nombre"] = frm._manzana.Nombre;
                fila["peso"] = frm._manzana.Peso;
                fila["precio"] = 41;
                dt.Rows.Add(fila);

                //Sincronizo con la base de datos
                da.Update(dt);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
            
        }
    }
}
