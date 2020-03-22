using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace PersonelGorevTkp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("KasaTanim")]
    [ListViewFilter("Tüm Liste", "")]
    [ListViewFilter("Aktif Kasalar", "[Durum]==True", true)]
    [ListViewFilter("Pasif Kasalar", "[Durum]==False")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Kasalar : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        
        public Kasalar(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string aciklama;
        bool durum;
        string kasaTanim;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aciklama
        {
            get => aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref aciklama, value);
        }
        
        public bool Durum
        {
            get => durum;
            set => SetPropertyValue(nameof(Durum), ref durum, value);
        }

        [Association("Kasalar-SirketMasrafOdeme")]
        public XPCollection<SirketMasraflari> SirketMasrafOdeme
        {
            get
            {
                return GetCollection<SirketMasraflari>(nameof(SirketMasrafOdeme));
            }
        }          

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KasaTanim
        {
            get => kasaTanim;
            set => SetPropertyValue(nameof(KasaTanim), ref kasaTanim, value);
        }

        public double Odeme
        {
            get
            {
                double temp = 0;
                temp += SirketMasrafOdeme.Where(x => x.Hareket == EnumObjects.KasaHareketType.MasrafOdeme).Sum(x => x.Tutar);
                temp += BankaIslemleri.Sum(x => x.Odeme);
                return temp;
            }
        }

        public double Tahsilat
        {
            get
            { 
                double temp1 = 0;
                temp1 += BankaIslemleri.Sum(y => y.Tahsilat);
                return temp1;
            }
        }

        public double Bakiye
        {
            get
            {
                return Tahsilat - Odeme;
            }
        }

        [Association("Kasalar-BankaIslemleri")]
        public XPCollection<BankaIslemler> BankaIslemleri
        {
            get
            {
                return GetCollection<BankaIslemler>(nameof(BankaIslemleri));
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
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "KasalarServerPrefix");
                Kod = string.Format("KS{0:D7}", deger); //0000001
            }
            base.OnSaving();
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}