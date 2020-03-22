using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using PersonelGorevTkp.Module.BusinessObjects;
using System;
using System.Linq;

namespace PersonelGorevTkp.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ToplantiOlustur : ViewController
    {
        public ToplantiOlustur()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

#pragma warning disable CRR0042 // Unused parameter
#pragma warning disable CRR0026 // Unused member
        private void ActionToplantiOlustur_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
#pragma warning restore CRR0042 // Unused parameter
        {
#pragma warning disable CRR0044 // Unused local variable
            Projelers projelers = (Projelers)View.CurrentObject;
#pragma warning restore CRR0044 // Unused local variable

            IObjectSpace space = View.ObjectSpace.CreateNestedObjectSpace();

            Toplanti toplanti = space.CreateObject<Toplanti>();

            e.View = Application.CreateDetailView(space, toplanti);
        }
#pragma warning restore CRR0026 // Unused member

#pragma warning disable IDE1006 // Naming Styles
        private void actionToplantiOlustur_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {

        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
