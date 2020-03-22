using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace PersonelGorevTkp.Module.BusinessObjects
{
    public class BankaIslemler : XPObject
    {
        public BankaIslemler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Kasalar kasaID;
        BankaSubeleri subeID;
        Bankalar bankaID;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }


        public Bankalar BankaID
        {
            get => bankaID;
            set => SetPropertyValue(nameof(BankaID), ref bankaID, value);
        }
                
        public BankaSubeleri SubeID
        {
            get => subeID;
            set => SetPropertyValue(nameof(SubeID), ref subeID, value);
        }
        
        public double Odeme
        {
            get => MaasHareket.Where(x => x.Hareket == EnumObjects.KasaHareketType.MaasOdeme).Sum(x => x.Tutar)+
               BankaIslemleri.Where(x => x.Hareket == EnumObjects.KasaHareketType.BankaOdeme).Sum(x => x.Tutar);
        }


        public double Tahsilat
        {
            get => MusteriTahsilat.Sum(x => x.Tutar) +
                BankaIslemleri.Where(x => x.Hareket == EnumObjects.KasaHareketType.Tahsilat).Sum(x => x.Tutar);
        }


        public double Bakiye
        {
            get => Tahsilat - Odeme;
        }

        [Association("BankaIslemler-BankaIslemleri")]
        public XPCollection<BankaHareket> BankaIslemleri
        {
            get
            {
                return GetCollection<BankaHareket>(nameof(BankaIslemleri));
            }
        }


        [Association("Kasalar-BankaIslemleri")]
        public Kasalar KasaID
        {
            get => kasaID;
            set => SetPropertyValue(nameof(KasaID), ref kasaID, value);
        }

        [Association("BankaIslemler-MusteriTahsilat")]
        public XPCollection<Musteriler> MusteriTahsilat
        {
            get
            {
                return GetCollection<Musteriler>(nameof(MusteriTahsilat));
            }
        }

        [Association("BankaIslemler-MaasHareket")]
        public XPCollection<PersonelMaasHareket> MaasHareket
        {
            get
            {
                return GetCollection<PersonelMaasHareket>(nameof(MaasHareket));
            }
        }
        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.  //Kaldırılmış Olabilir
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                && Session.IsNewObject(this) //Yeni obje gelirse
                && string.IsNullOrEmpty(Kod) //Boş Değer Geldiğinde 
                )
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "BankaIslemlerServerPrefix");
                Kod = string.Format("BNKISLEM{0:D7}", deger); //0000001
            }
            base.OnSaving();
        }
        public override string ToString()
        {
            if (bankaID != null && bankaID.BankaAdi != null)
                return this.bankaID.BankaAdi;
            else
                return null;

        }

    
    }
}