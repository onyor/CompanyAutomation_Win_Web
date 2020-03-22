using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using PersonelGorevTkp.Module.EnumObjects;
using System;
using System.Linq;

namespace PersonelGorevTkp.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PersonelMaasHareket : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public PersonelMaasHareket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            Hareket = EnumObjects.KasaHareketType.MaasOdeme;
            Tarih = DateTime.Now;
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string  Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        string aciklama;
        BankaIslemler bankaIslemID;
        DateTime tarih;
        KasaHareketType hareket;
        double tutar;
        string kod;
        Personel personelID;

        public Personel PersonelID
        {
            get => personelID;

            set
            {
                if (SetPropertyValue(nameof(PersonelID), ref personelID, value))
                {
                    if (Tutar == 0 && Session.IsNewObject(this))
                        Tutar = PersonelID.Tutar;
                }
            }
        }

        public double Tutar
        {
            get => tutar;
            set => SetPropertyValue(nameof(Tutar), ref tutar, value);
        }

        public KasaHareketType Hareket
        {
            get => hareket;
            set => SetPropertyValue(nameof(Hareket), ref hareket, value);
        }


        public DateTime Tarih
        {
            get => tarih;
            set => SetPropertyValue(nameof(Tarih), ref tarih, value);
        }

        [Association("BankaIslemler-MaasHareket")]
        public BankaIslemler BankaIslemID
        {
            get => bankaIslemID;
            set => SetPropertyValue(nameof(BankaIslemID), ref bankaIslemID, value);
        }
               
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aciklama
        {
            get => aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref aciklama, value);
        }

        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                && Session.IsNewObject(this) //Yeni obje gelirse
                && string.IsNullOrEmpty(Kod) //Boş Değer Geldiğinde 
                )
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "PersonelMaasHareketServerPrefix");
                Kod = string.Format("PM{0:D7}", deger); //0000001
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