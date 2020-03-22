using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelGorevTkp.Module.EnumObjects
{
    public enum KasaHareketType
    {
        [XafDisplayName("Maaş Ödeme")]
        MaasOdeme,
        [XafDisplayName("Kasa Tahsilat")]
        Tahsilat,
        [XafDisplayName("Şirket Masraf Ödeme")]
        MasrafOdeme,
        [XafDisplayName("Banka Ödeme")]
        BankaOdeme,
        [XafDisplayName("Banka Tahsilat")]
        BankaTahsilat

    }
}
