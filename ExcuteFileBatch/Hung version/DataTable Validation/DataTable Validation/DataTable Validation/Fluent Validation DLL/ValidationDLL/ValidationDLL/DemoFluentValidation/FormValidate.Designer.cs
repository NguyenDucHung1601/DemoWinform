
namespace DemoFluentValidation {
    partial class FormValidate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.ErrorMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoCuoiNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiTieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.Caption = "Error Message";
            this.ErrorMessage.FieldName = "ErrorMessage";
            this.ErrorMessage.Name = "ErrorMessage";
            // 
            // SoCuoiNam
            // 
            this.SoCuoiNam.Caption = "SoCuoiNam";
            this.SoCuoiNam.FieldName = "SoCuoiNam";
            this.SoCuoiNam.Name = "SoCuoiNam";
            this.SoCuoiNam.Visible = true;
            this.SoCuoiNam.VisibleIndex = 3;
            // 
            // gridControlData
            // 
            this.gridControlData.Location = new System.Drawing.Point(0, -2);
            this.gridControlData.MainView = this.gridData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(618, 454);
            this.gridControlData.TabIndex = 0;
            this.gridControlData.ToolTipController = this.toolTipController1;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridData});
            // 
            // gridData
            // 
            this.gridData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STT,
            this.ChiTieu,
            this.MaSo,
            this.SoCuoiNam,
            this.ErrorMessage});
            gridFormatRule1.Column = this.ErrorMessage;
            gridFormatRule1.ColumnApplyTo = this.SoCuoiNam;
            gridFormatRule1.Name = "FormatErrorIcon";
            formatConditionIconSet1.CategoryName = "Symbols";
            formatConditionIconSetIcon1.PredefinedName = "Symbols23_3.png";
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "Symbols23_3.png";
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Symbols23_3.png";
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "Symbols3Circled";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule1.Rule = formatConditionRuleIconSet1;
            gridFormatRule2.Column = this.ErrorMessage;
            gridFormatRule2.ColumnApplyTo = this.SoCuoiNam;
            gridFormatRule2.Name = "FormatErrorColor";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual;
            formatConditionRuleValue1.PredefinedName = "Red Fill, Red Text";
            formatConditionRuleValue1.Value1 = 0;
            formatConditionRuleValue1.Value2 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue1;
            this.gridData.FormatRules.Add(gridFormatRule1);
            this.gridData.FormatRules.Add(gridFormatRule2);
            this.gridData.GridControl = this.gridControlData;
            this.gridData.Name = "gridData";
            this.gridData.OptionsMenu.ShowConditionalFormattingItem = true;
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            // 
            // ChiTieu
            // 
            this.ChiTieu.Caption = "ChiTieu";
            this.ChiTieu.FieldName = "ChiTieu";
            this.ChiTieu.Name = "ChiTieu";
            this.ChiTieu.Visible = true;
            this.ChiTieu.VisibleIndex = 1;
            // 
            // MaSo
            // 
            this.MaSo.Caption = "MaSo";
            this.MaSo.FieldName = "MaSo";
            this.MaSo.Name = "MaSo";
            this.MaSo.Visible = true;
            this.MaSo.VisibleIndex = 2;
            // 
            // toolTipController1
            // 
            this.toolTipController1.InitialDelay = 1;
            this.toolTipController1.Rounded = true;
            this.toolTipController1.RoundRadius = 5;
            this.toolTipController1.ShowBeak = true;
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // FormValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.gridControlData);
            this.Name = "FormValidate";
            this.Text = "FormValidate";
            this.Load += new System.EventHandler(this.FormValidate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridData;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn ChiTieu;
        private DevExpress.XtraGrid.Columns.GridColumn MaSo;
        private DevExpress.XtraGrid.Columns.GridColumn SoCuoiNam;
        private DevExpress.XtraGrid.Columns.GridColumn ErrorMessage;
    }
}

