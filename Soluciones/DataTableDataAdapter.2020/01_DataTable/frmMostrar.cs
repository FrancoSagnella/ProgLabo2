using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02_DataAdapter
{
    public partial class frmMostrar : Form
    {
        public frmMostrar(DataTable tabla)
        {
            InitializeComponent();

            foreach (DataRow item in tabla.Rows)
            {
                this.dgvVisor.Rows.Add(item.RowState.ToString());
            }
        }
    }
}
