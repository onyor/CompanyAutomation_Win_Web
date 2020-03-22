using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelGorevTkp.Module.EnumObjects
{
    public enum ProjeDurumType
    {
        [XafDisplayName("Atandı")]
        atandi,
        [XafDisplayName("Atanmadı")]
        atanmadi,
        [XafDisplayName("İşleme Alındı")]
        islemeAlindi,
        [XafDisplayName("Tamamlandı")]
        tamamlandi
    }
}
