namespace PersonelGorevTkp.Module.Controllers
{
    partial class IslemeAlindi
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
            this.GorevAlindi = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // GorevAlindi
            // 
            this.GorevAlindi.Caption = "İşleme Alındı";
            this.GorevAlindi.ConfirmationMessage = "Seçil olan görevi almak istediğinize emin misiniz?";
            this.GorevAlindi.Id = "GorevAlindi";
            this.GorevAlindi.ImageName = "Hyperlink";
            this.GorevAlindi.ToolTip = null;
            this.GorevAlindi.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.GorevAlindi_Execute);
            // 
            // IslemeAlindi
            // 
            this.Actions.Add(this.GorevAlindi);
            this.TargetViewId = "GorevOlustur_ListView_BanaAtananGörevler";

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction GorevAlindi;
    }
}
