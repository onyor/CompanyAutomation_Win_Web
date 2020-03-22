namespace PersonelGorevTkp.Module.Controllers
{
    partial class GorevIptal
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
            this.actionGorevIptal = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionGorevIptal
            // 
            this.actionGorevIptal.Caption = "Görev İptal";
            this.actionGorevIptal.ConfirmationMessage = "Görevi İptal Etmek istediğinize emin misiniz?";
            this.actionGorevIptal.Id = "actionGorevIptal";
            this.actionGorevIptal.ImageName = "Actions_DeleteCircled";
            this.actionGorevIptal.ToolTip = null;
            this.actionGorevIptal.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionGorevIptal_Execute);
            // 
            // GorevIptal
            // 
            this.Actions.Add(this.actionGorevIptal);
            this.TargetViewId = "GorevOlustur_ListView_BanaAtananGörevler";

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionGorevIptal;
    }
}
