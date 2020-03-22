using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelGorevTkp.Module.EnumObjects
{
    public enum PersonelIzınHareketType
    {
        [XafDisplayName("İzin Verildi")]
        Verildi,
        [XafDisplayName("İzin Verilmedi")]
        Verilmedi,
        NULL
    }
}
