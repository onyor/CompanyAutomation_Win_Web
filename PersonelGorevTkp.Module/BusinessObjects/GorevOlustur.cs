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
using DevExpress.ExpressApp.SystemModule;
namespace PersonelGorevTkp.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ListViewFilter("Tüm Liste", "", true)]
    //[ListViewFilter("Atanmış Görevler", "[Durum]=='atandi'", false)]
    //[ListViewFilter("Atanmamış", "[Durum]=='atanmadi'", false)]
    //[ListViewFilter("İşleme Alınan Görevler", "[Durum]=='islemeAlindi'", false)]
    //[ListViewFilter("Tamamlanan Görevler", "[Durum]=='tamamlandi'", false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class GorevOlustur : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public GorevOlustur(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            XPQuery<Personel> query = Session.Query<Personel>();
            Personel personel = (from d in query where d.Kullanici.Oid == (Guid)(SecuritySystem.CurrentUserId) select d).LastOrDefault();
            Olusturan = personel;
            OlusturmaTarihi = DateTime.Now;

            //Durum = durum;
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        FileData dosyaYukle;
        ProjeDurumType durum;
        Personel alan;
        Personel olusturan;
        Projelers projeID;
        DateTime bitirmeTarihi;
        DateTime planlananBitirmeTarihi;
        DateTime olusturmaTarihi;
        string gorevTanim;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [Association("GorevOlustur-GorevList")]
        public Projelers ProjeID
        {
            get => projeID;
            set => SetPropertyValue(nameof(ProjeID), ref projeID, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GorevTanim
        {
            get => gorevTanim;
            set => SetPropertyValue(nameof(GorevTanim), ref gorevTanim, value);
        }

        public Personel Olusturan
        {
            get => olusturan;
            set => SetPropertyValue(nameof(Olusturan), ref olusturan, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public FileData DosyaYukle
        {
            get => dosyaYukle;
            set => SetPropertyValue(nameof(DosyaYukle), ref dosyaYukle, value);
        }

        public Personel Alan
        {
            get => alan;
            set => SetPropertyValue(nameof(Alan), ref alan, value);
        }

        public DateTime OlusturmaTarihi
        {
            get => olusturmaTarihi;
            set => SetPropertyValue(nameof(OlusturmaTarihi), ref olusturmaTarihi, value);
        }

        public DateTime PlanlananBitirmeTarihi
        {
            get => planlananBitirmeTarihi;
            set => SetPropertyValue(nameof(PlanlananBitirmeTarihi), ref planlananBitirmeTarihi, value);
        }

        public DateTime BitirmeTarihi
        {
            get => bitirmeTarihi;
            set => SetPropertyValue(nameof(BitirmeTarihi), ref bitirmeTarihi, value);
        }
                
        public ProjeDurumType Durum
        {
            get => durum;
            set => SetPropertyValue(nameof(Durum), ref durum, value);
        }

        protected override void OnSaving()  //Kaydetme İşlemi Yaparken Hazır Değer Döndürecek.
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "gorevOlusturServerPrefix");
                Kod = string.Format("GO{0:D7}", deger); //0000001                
            }

            //if (Alan != null)
            //{
            //    Durum = ProjeDurumType.atandi;
            //}
            //else
            //    Durum = ProjeDurumType.atanmadi;

            if (Alan == null)
                Durum = EnumObjects.ProjeDurumType.atanmadi;

            base.OnSaving();
        }

        public override string ToString()
        {
            return this.gorevTanim;
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