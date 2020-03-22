using DevExpress.Data.Async;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DevExpress.XtraEditors;

namespace PersonelGorevTkp.Module.Win.Controllers
{
    public class WebLinkController : ViewController<DetailView>
    {/*
        StringPropertyEditor webSitEditor;

        public WebLinkController()
        {
            TargetObjectType = typeof(Command);
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            webSitEditor = View.FindItem("Website") as StringPropertyEditor;

            if(webSitEditor?.Control != null)
            {
                webSitEditor.Control.Font = new System.Drawing.Font(webSitEditor.Control.Font, System.Drawing.FontStyle.Underline);
                webSitEditor.Control.ForeColor = System.Drawing.Color.Blue;
                webSitEditor.Control.DoubleClick += Control_DoubleClick;
            }
        }

        protected override void OnDeactivated()
        {
            if (webSitEditor?.Control != null)
            {
                webSitEditor.Control.DoubleClick -= Control_DoubleClick;
            }
            base.OnDeactivated();
        }


        private void Control_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            System.Diagnostics.Process.Start(edit.Text);
        }*/

    }
}
