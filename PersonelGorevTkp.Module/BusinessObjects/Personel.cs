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
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace PersonelGorevTkp.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Personel : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Personel(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        
        double maas;
        PermissionPolicyUser kullanici;

        Pozisyon unvan;
        string email;
        string telefon;
        string adres;
        string soyad;
        string ad;
        string tc;
        string kod;



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Tc
        {
            get => tc;
            set => SetPropertyValue(nameof(Tc), ref tc, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Ad
        {
            get => ad;
            set => SetPropertyValue(nameof(Ad), ref ad, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyad
        {
            get => soyad;
            set => SetPropertyValue(nameof(Soyad), ref soyad, value);
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AdSoyad => ObjectFormatter.Format("{Ad} {Soyad}", this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);

        [XafDisplayName("Kullanıcı Adı")]
        public PermissionPolicyUser Kullanici
        {
            get => kullanici;
            set => SetPropertyValue(nameof(Kullanici), ref kullanici, value);
        }

        public Pozisyon Unvan
        {
            get => unvan;
            set => SetPropertyValue(nameof(Unvan), ref unvan, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adres
        {
            get => adres;
            set => SetPropertyValue(nameof(Adres), ref adres, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Telefon
        {
            get => telefon;
            set => SetPropertyValue(nameof(Telefon), ref telefon, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [XafDisplayName("Hesaba Yatan Para")]
        public double Tutar
        {
            get => maas;
            set => SetPropertyValue(nameof(Tutar), ref maas, value);
        }

        //[DataSourceProperty("HesapID.PersonelIban")]
        //[XafDisplayName("Hesap Numarası")]
        //public BankaHesaplari BankaID
        //{
        //    get => bankaID;
        //    set => SetPropertyValue(nameof(BankaID), ref bankaID, value);
        //}

        [Association("Personel-HesapListe")]
        public XPCollection<BankaHesaplari> HesapListe
        {
            get
            {
                return GetCollection<BankaHesaplari>(nameof(HesapListe));
            }
        }
        
        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "personelServerPrefix");
                Kod = string.Format("PR{0:D7}", deger); //0000001
            }
            base.OnSaving();
        }
        public override string ToString()
        {
            return this.AdSoyad;
        }
    }
}