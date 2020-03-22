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
    public class Fisler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Fisler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Musteriler musteriID;
        double birimFiyat;
        Projelers projeID;
        FisHareketType turu;
        double genelToplam;
        double ındirimTutar;
        double ındirimOran;
        DateTime tarih;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [ImmediatePostData]
        [Association("Musteriler-AlisSatisIslemleri")]        
        public Musteriler MusteriID
        {
            get => musteriID;
            set => SetPropertyValue(nameof(MusteriID), ref musteriID, value);
        }

        public DateTime Tarih
        {
            get => tarih;
            set => SetPropertyValue(nameof(Tarih), ref tarih, value);
        }

        public FisHareketType Turu
        {
            get => turu;
            set => SetPropertyValue(nameof(Turu), ref turu, value);
        }

        public Projelers ProjeID
        {
            get => projeID;
            set
            {
                if (SetPropertyValue(nameof(ProjeID), ref projeID, value))
                { 
                    BirimFiyat = ProjeID.ProjeFiyat;
                }
            }
        }
        
        public double BirimFiyat
        {
            get => birimFiyat;
            set => SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value);
        }

        public double IndirimOran
        {
            get => ındirimOran;
            set
            {
                if(SetPropertyValue(nameof(IndirimOran), ref ındirimOran, value))
                {
                    HesaplaToplam();
                }

            }
        }

        public double IndirimTutar
        {
            get
            {
                if (!IsLoading && !IsSaving)
                    HesaplamaIndirimToplam(false);
                return ındirimTutar;
            }
            set => SetPropertyValue(nameof(IndirimTutar), ref ındirimTutar, value);
        }
                
        public double GenelToplam
        {
            get
            {
                if (!IsLoading && !IsSaving)
                    HesaplaGenelToplam(false);
                return genelToplam;
            }
            set => SetPropertyValue(nameof(GenelToplam), ref genelToplam, value);
        }

        public void HesaplaToplam()
        {
            IndirimTutar = (BirimFiyat / 100) * IndirimOran;
            GenelToplam = BirimFiyat - IndirimTutar;
        }
        
        public void HesaplamaIndirimToplam(bool disposing) //////////
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (ındirimTutar != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                double? eskiIndirimToplam = ındirimTutar;

                if (disposing)
                    OnChanged(nameof(IndirimTutar), eskiIndirimToplam, ındirimTutar);
            }
        }
               
        public void HesaplaGenelToplam(bool disposing)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (genelToplam != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                double? eskiGenelToplam = genelToplam;

                if (disposing)
                    OnChanged(nameof(GenelToplam), eskiGenelToplam, genelToplam);
            }
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