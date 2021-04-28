using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodosExtension
    {
        public static string InformarNovedad(this CartucheraLlenaException e)
        {
            return e.Message;
        }
    }
}
