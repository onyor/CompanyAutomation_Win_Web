using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
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
    public class Musteriler : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        BankaIslemler bankaID;

        Projelers projeTanim;
        string email;
        string kod;
        string temsilci;
        double tutar;

        public Musteriler(Session session)
            : base(session)
        {
        }

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                && Session.IsNewObject(this)
                && string.IsNullOrEmpty(Kod))
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "MusterilerPrefix");
                Kod = string.Format("MS{0:D8}", deger);
            }

            base.OnSaving();
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("Musteriler-AlisSatisIslemleri")]
        public XPCollection<Fisler> AlisSatisIslemleri
        {
            get
            {
                return GetCollection<Fisler>(nameof(AlisSatisIslemleri));
            }
        }

        [Association("BankaIslemler-MusteriTahsilat")]
        public BankaIslemler BankaID
        {
            get => bankaID;
            set => SetPropertyValue(nameof(BankaID), ref bankaID, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [DisplayName("Proje Adı")]
        public Projelers ProjeTanim
        {
            get => projeTanim;
            set => SetPropertyValue(nameof(Projelers), ref projeTanim, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Temsilci
        {
            get => temsilci;
            set => SetPropertyValue(nameof(Temsilci), ref temsilci, value);
        }

        public double Tutar
        {
            get
            {
                double temp = 0;
                temp += AlisSatisIslemleri.Where(x => x.Turu == EnumObjects.FisHareketType.Satis).Sum(x => x.GenelToplam);
                return temp;
            }
            set => SetPropertyValue(nameof(Tutar), ref tutar, value);
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