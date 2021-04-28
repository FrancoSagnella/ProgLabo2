﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Agregar usings necesarios
using Entidades;
using System.Data.SqlClient;
using System.IO;

namespace WindowsForms.SP
{
    //Agregar manejo de excepciones en TODOS los lugares críticos!!!
    public partial class SegundoParcial : Form
    {
        private Lapiz lapiz;
        private Goma goma;
        private Sacapunta sacapunta;

        private Cartuchera<Utiles> c_utiles;
        private Cartuchera<Lapiz> c_lapices;
        private Cartuchera<Goma> c_gomas;

        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;

        public SegundoParcial()
        {
            InitializeComponent();

            this.dt = new DataTable("utiles");
            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Cambiar por su apellido y nombre
        private void SegundoParcial_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Sagnella Franco Ezequiel");
            this.Text = "Sagnella Franco Ezequiel";
        }

        //Crear, en un class library, la siguiente jerarquía de clases:
        //Utiles-> marca:string y precio:double (públicos); PreciosCuidados:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)
        //Lapiz-> color:ConsoleColor(público); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        //Goma-> soloLapiz:bool(público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        //Sacapunta-> deMetal:bool(público); 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            //Crear una instancia de cada clase e inicializar los atributos del form lapiz, goma y sacapunta. 
            this.lapiz = new Lapiz(ConsoleColor.Green, ETipoTrazo.Grueso, "Sylvapen", 25.50);
            this.goma = new Goma(true, "Pelican", 30);
            this.sacapunta = new Sacapunta(true, 55.90, "Afiladitos");

            MessageBox.Show(this.lapiz.ToString());
            MessageBox.Show(this.goma.ToString());
            MessageBox.Show(this.sacapunta.ToString());
        }

        //Crear, en class library, la clase Cartuchera<T> -> restringir para que sólo lo pueda usar Utiles 
        //o clases que deriven de Utiles.
        //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
        //Propiedades:
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos:
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operadores:
        //(+) Será el encargado de agregar elementos a la cartuchera, 
        //siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            
            this.c_lapices = new Cartuchera<Lapiz>(3);
            this.c_gomas = new Cartuchera<Goma>(3);
            this.c_utiles = new Cartuchera<Utiles>(2);

            try
            {
                this.c_lapices += new Lapiz(ConsoleColor.Red, ETipoTrazo.Medio, "Faber-Castell", 25);
                this.c_lapices += new Lapiz(ConsoleColor.Blue, ETipoTrazo.Fino, "Paper Mate", 30);
                this.c_lapices += this.lapiz;

                this.c_gomas += this.goma;
                this.c_gomas += new Goma(false, "Dos banderas", 25);

                this.c_utiles += this.lapiz;
                this.c_utiles += this.goma;

                MessageBox.Show(this.c_lapices.ToString());
                MessageBox.Show(this.c_gomas.ToString());
                MessageBox.Show(this.c_utiles.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Agregar un elemento a la cartuchera de útiles, al superar la cantidad máxima, 
        //lanzará un CartucheraLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_utiles += this.lapiz;
            }
            catch (CartucheraLlenaException ex)
            {
                //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
                //que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Si el precio total de la cartuchera supera los 85 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cartuchera. 
        //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total de la cartuchera (en un nuevo renglón). 
        //Se deben acumular los mensajes. 
        //El archivo se guardará con el nombre 'tickets.log' en la carpeta 'Mis documentos' del cliente.
        //El manejador de eventos (c_gomas_EventoPrecio) invocará al método (de clase) 
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano 
        //indicando si se pudo escribir o no.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            try
            {
                //Asociar manejador de eventos (c_gomas_EventoPrecio) aquí  
                this.c_gomas.EventoPrecio += new DelegadoPrecio(this.c_gomas_EventoPrecio);

            
                this.c_gomas += new Goma(false, "Faber-Castell", 31);
            }
            catch(CartucheraLlenaException ex)
            {
                MessageBox.Show(ex.InformarNovedad());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void c_gomas_EventoPrecio(object sender, EventArgs e)
        {
            //Reemplazar por la llamada al método de clase ImprimirTicket
            bool todoOK = Ticketadora.ImprimirTicket((double)sender);

            if (todoOK)
            {
                MessageBox.Show("Ticket impreso correctamente!!!");
            }
            else
            {
                MessageBox.Show("No se pudo imprimir el ticket!!!");
            }
        }

        //Configurar el OpenFileDialog, para poder seleccionar el log de tickets
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            //titulo -> 'Abrir archivo de tickets'
            this.openFileDialog1.Title = "Abrir archivos de tickets";
            //directorio por defecto -> Mis documentos
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //tipo de archivo (filtro) -> .log
            this.openFileDialog1.Filter = "Log |*.log";
            //extensión por defecto -> .log
            this.openFileDialog1.DefaultExt = "log";
            //nombre de archivo (defecto) -> tickets
            this.openFileDialog1.FileName = "tickets";

            DialogResult rta = this.openFileDialog1.ShowDialog();//Reemplazar por la llamada al método correspondiente del OpenFileDialog

            if (rta == DialogResult.OK)
            {
                //leer el archivo seleccionado por el cliente y mostrarlo en txtVisorTickets
                string path = this.openFileDialog1.FileName;
                this.txtVisorTickets.Text = File.ReadAllText(path);
            }
        }

        //Crear las interfaces (en class library): 
        //#.-ISerializa -> Xml() : bool
        //              -> Path{ get; } : string
        //#.-IDeserializa -> Xml(out Lapiz) : bool
        //Implementar (implícitamente) ISerializa lápiz
        //Implementar (explícitamente) IDeserializa en lápiz
        //El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.lapiz.xml
        //Ejemplo: Alumno Juan Pérez -> perez.juan.lapiz.xml
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Lapiz aux = null;

            try
            {
                if (this.lapiz.Xml())
                {
                    MessageBox.Show("Lápiz serializado OK");
                }
                else
                {
                    MessageBox.Show("Lápiz NO serializado");
                }

                if (((IDeserializa)this.lapiz).Xml(out aux))
                {
                    MessageBox.Show("Lápiz deserializado OK");
                    MessageBox.Show(aux.ToString());
                }
                else
                {
                    MessageBox.Show("Lápiz NO deserializado");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Obtener de la base de datos (sp_lab_II_utiles) el listado de útiles:
        //Tabla - utiles { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            try
            {
                //Configurar el SqlConnection
                this.cn = new SqlConnection(Properties.Settings.Default.Conexion);

                //Configurar el SqlDataAdapter (y su selectCommand)                        
                this.da = new SqlDataAdapter();
                this.da.SelectCommand = new SqlCommand("SELECT id, marca, precio, tipo FROM utiles", cn);

                this.da.Fill(this.dt);
                this.dataGridView1.DataSource = this.dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Agregar en el dataTable los útiles del formulario (lapiz, goma y sacapunta).
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            try
            {
                //Configurar el insertCommand del SqlDataAdapter y sus parámetros
                this.da.InsertCommand = new SqlCommand("INSERT INTO utiles (marca, precio, tipo) VALUES (@marca, @precio, @tipo)", cn);

                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

                //Agregar los utiles del formulario al dataTable (crear filas)

                DataRow fila = dt.NewRow();

                fila["marca"] = this.lapiz.marca;
                fila["precio"] = this.lapiz.precio;
                fila["tipo"] = this.lapiz.GetType().ToString();

                this.dt.Rows.Add(fila);

                fila = dt.NewRow();

                fila["marca"] = this.goma.marca;
                fila["precio"] = this.goma.precio;
                fila["tipo"] = this.goma.GetType().ToString();

                this.dt.Rows.Add(fila);

                fila = dt.NewRow();

                fila["marca"] = this.sacapunta.marca;
                fila["precio"] = this.sacapunta.precio;
                fila["tipo"] = this.sacapunta.GetType().ToString();

                this.dt.Rows.Add(fila);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Eliminar del dataTable el primer registro
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            try
            {
                //Configurar el deleteCommand del SqlDataAdapter y sus parámetros
                this.da.DeleteCommand = new SqlCommand("DELETE FROM utiles WHERE id=@id", cn);

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                //Borrar el primer registro del dataTable (borrado físico NO)
                DataRow fila = this.dt.Rows[0];
                fila.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Modificar del dataTable el último registro, cambiarlo por: marca:barrilito; precio:72
        private void btnPunto9_Click(object sender, EventArgs e)
        {
            try
            {
                //Configurar el updateCommand del SqlDataAdapter y sus parámetros
                this.da.UpdateCommand = new SqlCommand("UPDATE utiles SET marca=@marca, precio=@precio, tipo=@tipo WHERE id=@id", cn);

                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                //Modificar el último registro del dataTable
                int i = this.dt.Rows.Count - 1;
                DataRow fila = this.dt.Rows[i];

                fila["marca"] = "barrilito";
                fila["precio"] = 72;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void btnPunto10_Click(object sender, EventArgs e)
        {
            try
            {
                //Sincronizar el SqlDataAdapter con la BD
                this.da.Update(this.dt);
                MessageBox.Show("Datos sincronizados!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha sincronizado!!!\n" + ex.Message);
            }
        }
    }
}
