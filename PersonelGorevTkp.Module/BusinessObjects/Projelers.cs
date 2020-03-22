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
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Projelers : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Projelers(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        GorevOlustur gorevID;
        double projeFiyat;
        string aciklama;
        string projeTanim;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjeTanim
        {
            get => projeTanim;
            set => SetPropertyValue(nameof(ProjeTanim), ref projeTanim, value);
        }

        [XafDisplayName("Projenin Satış Fiyatı")]
        public double ProjeFiyat
        {
            get => projeFiyat;
            set => SetPropertyValue(nameof(ProjeFiyat), ref projeFiyat, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aciklama
        {
            get => aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref aciklama, value);
        }

        [ModelDefault("AllowEdit", "False")]
        public List<GorevOlustur> Gorevler
        {
            get
            {
                XPQuery<GorevOlustur> xpQuery = Session.Query<GorevOlustur>();
                List<GorevOlustur> görevler = (from d in xpQuery select d).ToList();
                return görevler;

            }
        }

        [Association("GorevOlustur-GorevList")]
        public XPCollection<GorevOlustur> GorevList
        {
            get
            {
                return GetCollection<GorevOlustur>(nameof(GorevList));
            }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public GorevOlustur GorevID
        {
            get => gorevID;
            set => SetPropertyValue(nameof(GorevID), ref gorevID, value);
        }
        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "ProjelersServerPrefix");
                Kod = string.Format("PJ{0:D7}", deger); //0000001
            }
            base.OnSaving();
        }

        public override string ToString()
        {
            return this.projeTanim;
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