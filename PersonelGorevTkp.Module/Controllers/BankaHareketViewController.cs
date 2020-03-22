using System;
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
    public partial class BankaHareketViewController : ViewController
    {
        public BankaHareketViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes += Controller_CollectCreatableItemTypes;
                controller.CollectDescendantTypes += Controller_CollectDescendantTypes;
                if (controller.Active)
                {
                    controller.UpdateNewObjectAction();
                }
            }
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes += Controller_CollectCreatableItemTypes;
                controller.CollectDescendantTypes += Controller_CollectDescendantTypes;
            }
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        public void CustomizeList(ICollection<Type> types)
        {
            List<Type> _list = new List<Type>();
            foreach (Type item in types)
            {
                if (item == typeof(BankaHareket))
                {
                    _list.Add(item);
                }
            }
            foreach (Type item in _list)
            {
                types.Remove(item);
            }
        }

        private void Controller_CollectCreatableItemTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
        private void Controller_CollectDescendantTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
    }
}
