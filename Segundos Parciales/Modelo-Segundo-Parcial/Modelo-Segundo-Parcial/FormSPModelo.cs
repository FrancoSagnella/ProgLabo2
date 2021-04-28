using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//usings que tengo que agregar para bases de datos y archivos
using System.Data.SqlClient;
using System.IO;
using Entidades;

namespace Modelo_Segundo_Parcial
{
    public partial class FormSPModelo : Form
    {
        private Lapiz lapiz;
        private Goma goma;
        private Sacapunta sacapunta;

        private Cartuchera<Utiles> c_utiles;
        private Cartuchera<Lapiz> c_lapices;
        private Cartuchera<Goma> c_gomas;

        //Atributos que tengo que tener para conectarme a una base de datos
        //y mostrar la info en el form
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;



        public FormSPModelo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void FormSPModelo_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Sagnella Franco");
            this.Text = "Sagnella Franco";
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
        private void button1_Click(object sender, EventArgs e)
        {
            //Crear una instancia de cada clase e inicializar los atributos del form lapiz, goma y sacapunta. 
            this.lapiz = new Lapiz(ConsoleColor.Green, Lapiz.ETipoTrazo.Grueso, "Sylvapen", 25.50);
            this.goma = new Goma(true, "Pelican", 30);
            this.sacapunta = new Sacapunta(true, 55.90, "Afiladitos");

            MessageBox.Show(lapiz.ToString());
            MessageBox.Show(goma.ToString());
            MessageBox.Show(sacapunta.ToString());
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.c_utiles = new Cartuchera<Utiles>(2);
            this.c_lapices = new Cartuchera<Lapiz>(3);
            this.c_gomas = new Cartuchera<Goma>(3);

            this.c_lapices += new Lapiz(ConsoleColor.Red, Lapiz.ETipoTrazo.Medio, "Faber-Castell", 25);
            this.c_lapices += new Lapiz(ConsoleColor.Blue, Lapiz.ETipoTrazo.Fino, "Paper Mate", 30);
            this.c_lapices += this.lapiz;

            this.c_gomas += this.goma;
            this.c_gomas += new Goma(false, "Dos banderas", 25);

            this.c_utiles += this.lapiz;
            this.c_utiles += this.goma;

            MessageBox.Show(this.c_lapices.ToString());
            MessageBox.Show(this.c_gomas.ToString());
            MessageBox.Show(this.c_utiles.ToString());
        }
        //Agregar un elemento a la cartuchera de útiles, al superar la cantidad máxima, 
        //lanzará un CartucheraLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void button3_Click(object sender, EventArgs e)
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.c_gomas.EventoPrecio += new DelegadoPrecio(this.c_goma_EventoPrecio);

            try
            {
                this.c_gomas += new Goma(false, "Faber-Castell", 85);
            }
            catch (CartucheraLlenaException ex)
            {

                MessageBox.Show(ex.InformarNovedad());
            }

            MessageBox.Show(this.c_gomas.ToString());
        }
        private void c_goma_EventoPrecio(double e)
        {
            bool todoOK = Ticketadora.ImprimirTicket(e); //Reemplazar por la llamada al método de clase ImprimirTicket

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
        private void buttonLog_Click(object sender, EventArgs e)
        {
            //Configuro la ventana del OpenFileDialog, para buscar el ticket
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

            //Abro el OpenFileDialog de forma modal, para recibir una respuesta
            DialogResult rta = this.openFileDialog1.ShowDialog();//Reemplazar por la llamada al método correspondiente del OpenFileDialog

            //Con la respuesta hago lo que corresponda
            if(rta == DialogResult.OK)
            {
                //Si la respuesta es OK, cargo el archivo que elegi en el visor
                //Primeto gurado en un string el path que seleccione del filedialog,
                //que queda guardado en la propiedad FileName
                string path = this.openFileDialog1.FileName;
                //Despues, con ese path cargo el contenido que tiene (Con la clase File, metodo ReadAllText, le tengo que 
                //pasar el path del archivo que elegi en el FileDialog)
                //en el visor
                this.textBox1.Text = File.ReadAllText(path);
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
        private void button5_Click(object sender, EventArgs e)
        {
            //Creo un lapiz auxiliar para deserializar
            Lapiz aux;

            try
            {
                if (this.lapiz.Xml())
                {
                    MessageBox.Show("Serializado");
                }
                else
                {
                    MessageBox.Show("No Serializado");
                }

                if (((IDeserializa)this.lapiz).Xml(out aux))
                {
                    MessageBox.Show("Deserializado");
                    MessageBox.Show(aux.ToString());
                }
                else
                {
                    MessageBox.Show("No Deserializado");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Obtener de la base de datos (sp_lab_II_utiles) el listado de útiles:
        //Tabla - utiles { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void button6_Click(object sender, EventArgs e)
        {
            //Configuro DataTable, DataAdapter (Y lo conecto a la base de datos) y la grilla
            this.ConfigurarDataTable();
            this.ConfigurarGrilla();
            this.ConfigurarDataAdapter();

            //Agrego en el data adapter las filas que tiene configuradas el data table
            //el fill va a llamar al select de la base de datos, y lo va a cargar en el DataTable
            this.da.Fill(this.dt);
            //Hago que el grid muestre las columnas del data table
            this.dataGridView1.DataSource = this.dt;
        }

        private void ConfigurarDataTable()
        {
            //Creo el DataTable y lo configuro
            this.dt = new DataTable("utiles");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("marca", typeof(string));
            this.dt.Columns.Add("precio", typeof(float));
            this.dt.Columns.Add("tipo", typeof(string));

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }
        private void ConfigurarGrilla()
        {
            //Configuro el data grid viewer
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
        }
        private void ConfigurarDataAdapter()
        {
            //Configurar el SqlConnection
            //voy a profpedades, configuracion y la agrego
            //le pego esta cadena 
            //Data Source=localhost\SQLEXPRESS;Initial Catalog=sp_lab_II_utiles;Integrated Security=True
            this.cn = new SqlConnection(Properties.Settings.Default.Conexion);

            //Configurar el SqlDataAdapter (y su selectCommand) 
            //Instancio el data adapter
            this.da = new SqlDataAdapter();
            //Instancio los comandos
            this.da.SelectCommand = new SqlCommand("SELECT id, marca, precio, tipo FROM utiles", cn);
            this.da.InsertCommand = new SqlCommand("INSERT INTO utiles (marca, precio, tipo) VALUES (@marca, @precio, @tipo)", cn);
            this.da.UpdateCommand = new SqlCommand("UPDATE utiles SET marca=@marca, precio=@precio, tipo=@tipo WHERE id=@id", cn);
            this.da.DeleteCommand = new SqlCommand("DELETE FROM utiles WHERE id=@id", cn);

            //Creo los parametros para que se reemplazen
            //Le tengo que opner nombre del parametro, tipo de SqlDbtype, tamaño y el nombre de la columna que corresponde
            this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
            this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

            this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
            this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
            this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

            this.da.DeleteCommand.Parameters.Add("id", SqlDbType.Int, 10, "id");
        }


        //Agregar en el dataTable los útiles del formulario (lapiz, goma y sacapunta).
        private void button7_Click(object sender, EventArgs e)
        {
            //Agrego los utiles al DataTable
            //Para eso creo un obejto fila con una nueva fila del Data Table
            //Esto lo voy a tener que hacer con cada coso que agregue
            //Despues tengo que agregar esa fila al DataTable, con Rows.Add
            //Las filas quedan con el estado added
            DataRow fila = this.dt.NewRow();

            fila["marca"] = this.lapiz.marca;
            fila["precio"] = this.lapiz.precio;
            fila["tipo"] = this.lapiz.GetType().ToString();
            this.dt.Rows.Add(fila);

            fila = this.dt.NewRow();

            fila["marca"] = this.goma.marca;
            fila["precio"] = this.goma.precio;
            fila["tipo"] = this.goma.GetType().ToString();
            this.dt.Rows.Add(fila);

            fila = this.dt.NewRow();

            fila["marca"] = this.sacapunta.marca;
            fila["precio"] = this.sacapunta.precio;
            fila["tipo"] = this.sacapunta.GetType().ToString();
            this.dt.Rows.Add(fila);
        }
        //Eliminar del dataTable el primer registro
        private void button8_Click(object sender, EventArgs e)
        {
            //Para eliminar tambien creo un data Row, pero le paso en indice de la fila a borrar
            DataRow fila = this.dt.Rows[0];

            //Esto cambia el estado de la fila a que se va a eliminar
            //Es un borrado logico
            fila.Delete();
        }
        //Modificar del dataTable el último registro, cambiarlo por: marca:barrilito; precio:72
        private void button9_Click(object sender, EventArgs e)
        {
            //Tengo que modificar el ultimo, entonces le paso como indice count de filas -1
            DataRow fila = this.dt.Rows[this.dt.Rows.Count - 1];

            //Le cambio los valores en las columnas que correspondan
            fila["marca"] = "barrilito";
            fila["precio"] = 72;
        }
        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void button10_Click(object sender, EventArgs e)
        {
            //Para sincronizar se usa this.da.Update(Le paso el Data Table que modifique)
            //Esto va a aplicar updates, inserts y deletes donde se necesite para subir el data table a la base de datos
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
