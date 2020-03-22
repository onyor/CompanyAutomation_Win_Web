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
using PersonelGorevTkp.Module.EnumObjects;

namespace PersonelGorevTkp.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PersonelIzin : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public PersonelIzin(Session session)
            : base(session)
        {            
        }
        public override void AfterConstruction()
        {
            XPQuery<Personel> query = Session.Query<Personel>();
            Personel personel = (from d in query where d.Kullanici.Oid == (Guid)(SecuritySystem.CurrentUserId) select d).LastOrDefault();
            PersonelID = personel;

            Hareket = EnumObjects.PersonelIzınHareketType.NULL;
            baslangicTarihi = DateTime.Now;
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        DateTime bitisTarihi;
        DateTime baslangicTarihi;
        string aciklama;
        PersonelIzınHareketType hareket;
        Personel personelID;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        public Personel PersonelID
        {
            get => personelID;
            set => SetPropertyValue(nameof(PersonelID), ref personelID, value);
        }

        public PersonelIzınHareketType Hareket
        {
            get => hareket;
            set => SetPropertyValue(nameof(Hareket), ref hareket, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aciklama
        {
            get => aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref aciklama, value);
        }

        public DateTime BaslangicTarihi
        {
            get => baslangicTarihi;
            set => SetPropertyValue(nameof(BaslangicTarihi), ref baslangicTarihi, value);
        }

        
        public DateTime BitisTarihi
        {
            get => bitisTarihi;
            set => SetPropertyValue(nameof(BitisTarihi), ref bitisTarihi, value);
        }

        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                && Session.IsNewObject(this) //Yeni obje gelirse
                && string.IsNullOrEmpty(Kod) //Boş Değer Geldiğinde 
                )
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "PersonelIzinServerPrefix");
                Kod = string.Format("PIZ{0:D7}", deger); //0000001
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