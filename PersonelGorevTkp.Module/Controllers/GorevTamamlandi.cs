﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using PersonelGorevTkp.Module.BusinessObjects;

namespace PersonelGorevTkp.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class GorevTamamlandi : ViewController
    {
        private IObjectSpace objectSpace;
        private IObjectSpace objectSpace2;
        public GorevTamamlandi()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void GorevTamamlandiController_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            objectSpace = Application.CreateObjectSpace();
            objectSpace2 = Application.CreateObjectSpace();


            GorevOlustur gorev = objectSpace.GetObjectByKey<GorevOlustur>(((GorevOlustur)e.CurrentObject).Oid);
            gorev.Durum = EnumObjects.ProjeDurumType.tamamlandi;
            gorev.BitirmeTarihi = DateTime.Now;
            


            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}
