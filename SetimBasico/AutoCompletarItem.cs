using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetimBasico
{
    [Serializable]
    public class AutoCompletarItem
    {
        public string valor { get; set; }
        public string etiqueta { get; set; }
        public string desc { get; set; }
    }    
}
