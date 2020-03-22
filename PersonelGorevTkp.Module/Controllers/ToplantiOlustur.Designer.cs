namespace PersonelGorevTkp.Module.Controllers
{
    partial class ToplantiOlustur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.actionToplantiOlustur = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // actionToplantiOlustur
            // 
            this.actionToplantiOlustur.AcceptButtonCaption = null;
            this.actionToplantiOlustur.CancelButtonCaption = null;
            this.actionToplantiOlustur.Caption = "Toplantı";
            this.actionToplantiOlustur.ConfirmationMessage = null;
            this.actionToplantiOlustur.Id = "actionToplantiOlustur";
            this.actionToplantiOlustur.ImageName = "BO_Scheduler";
            this.actionToplantiOlustur.ToolTip = null;
            this.actionToplantiOlustur.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.actionToplantiOlustur_Execute);
            // 
            // ToplantiOlustur
            // 
            this.Actions.Add(this.actionToplantiOlustur);
            this.TargetObjectType = typeof(PersonelGorevTkp.Module.BusinessObjects.Projelers);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction actionToplantiOlustur;
    }
}
