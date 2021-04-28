using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Ejemplo
{
    public interface IVendible
    {
        double Cantidad { get; set; }
        double Precio { get; set; }
        double Vender();
    }
}
