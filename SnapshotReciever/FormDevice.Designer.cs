namespace SnapshotReciever
{
    partial class FormDevice
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevice));
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxCameraList = new System.Windows.Forms.GroupBox();
            this.panelCameras = new System.Windows.Forms.Panel();
            this.dataGridViewCameraList = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChanel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripCameras = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddCamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRemoveCamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRowUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRowDown = new System.Windows.Forms.ToolStripButton();
            this.groupBoxDeviceSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddDevice = new System.Windows.Forms.Button();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupBoxCameraList.SuspendLayout();
            this.panelCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraList)).BeginInit();
            this.toolStripCameras.SuspendLayout();
            this.groupBoxDeviceSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.Window;
            this.panelMain.Controls.Add(this.groupBoxCameraList);
            this.panelMain.Controls.Add(this.groupBoxDeviceSettings);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(556, 210);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxCameraList
            // 
            this.groupBoxCameraList.Controls.Add(this.panelCameras);
            this.groupBoxCameraList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxCameraList.Location = new System.Drawing.Point(257, 13);
            this.groupBoxCameraList.Name = "groupBoxCameraList";
            this.groupBoxCameraList.Size = new System.Drawing.Size(287, 183);
            this.groupBoxCameraList.TabIndex = 4;
            this.groupBoxCameraList.TabStop = false;
            this.groupBoxCameraList.Text = "Список камер";
            // 
            // panelCameras
            // 
            this.panelCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCameras.Controls.Add(this.dataGridViewCameraList);
            this.panelCameras.Controls.Add(this.toolStripCameras);
            this.panelCameras.Location = new System.Drawing.Point(6, 19);
            this.panelCameras.Name = "panelCameras";
            this.panelCameras.Size = new System.Drawing.Size(274, 158);
            this.panelCameras.TabIndex = 2;
            // 
            // dataGridViewCameraList
            // 
            this.dataGridViewCameraList.AllowUserToAddRows = false;
            this.dataGridViewCameraList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCameraList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCameraList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewCameraList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCameraList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnChanel});
            this.dataGridViewCameraList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCameraList.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewCameraList.MultiSelect = false;
            this.dataGridViewCameraList.Name = "dataGridViewCameraList";
            this.dataGridViewCameraList.RowHeadersVisible = false;
            this.dataGridViewCameraList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCameraList.Size = new System.Drawing.Size(274, 131);
            this.dataGridViewCameraList.TabIndex = 1;
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 142.132F;
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnChanel
            // 
            this.ColumnChanel.FillWeight = 57.86803F;
            this.ColumnChanel.HeaderText = "Канал";
            this.ColumnChanel.Name = "ColumnChanel";
            // 
            // toolStripCameras
            // 
            this.toolStripCameras.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripCameras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripSeparator1,
            this.toolStripButtonAddCamera,
            this.toolStripSeparator2,
            this.toolStripButtonRemoveCamera,
            this.toolStripSeparator3,
            this.toolStripButtonRowUp,
            this.toolStripButtonRowDown});
            this.toolStripCameras.Location = new System.Drawing.Point(0, 0);
            this.toolStripCameras.Name = "toolStripCameras";
            this.toolStripCameras.ShowItemToolTips = false;
            this.toolStripCameras.Size = new System.Drawing.Size(274, 27);
            this.toolStripCameras.TabIndex = 0;
            this.toolStripCameras.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.AutoSize = false;
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(65, 24);
            this.toolStripButtonSearch.Text = "Поиск";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonAddCamera
            // 
            this.toolStripButtonAddCamera.AutoSize = false;
            this.toolStripButtonAddCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddCamera.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddCamera.Image")));
            this.toolStripButtonAddCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddCamera.Name = "toolStripButtonAddCamera";
            this.toolStripButtonAddCamera.Size = new System.Drawing.Size(65, 24);
            this.toolStripButtonAddCamera.Text = "Добавить";
            this.toolStripButtonAddCamera.Click += new System.EventHandler(this.toolStripButtonAddCamera_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonRemoveCamera
            // 
            this.toolStripButtonRemoveCamera.AutoSize = false;
            this.toolStripButtonRemoveCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRemoveCamera.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveCamera.Image")));
            this.toolStripButtonRemoveCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveCamera.Name = "toolStripButtonRemoveCamera";
            this.toolStripButtonRemoveCamera.Size = new System.Drawing.Size(65, 24);
            this.toolStripButtonRemoveCamera.Text = "Удалить";
            this.toolStripButtonRemoveCamera.Click += new System.EventHandler(this.toolStripButtonRemoveCamera_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonRowUp
            // 
            this.toolStripButtonRowUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRowUp.Image = global::SnapshotReciever.Properties.Resources.up;
            this.toolStripButtonRowUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRowUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRowUp.Name = "toolStripButtonRowUp";
            this.toolStripButtonRowUp.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonRowUp.Text = "toolStripButton1";
            this.toolStripButtonRowUp.Click += new System.EventHandler(this.toolStripButtonRowUp_Click);
            // 
            // toolStripButtonRowDown
            // 
            this.toolStripButtonRowDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRowDown.Image = global::SnapshotReciever.Properties.Resources.down;
            this.toolStripButtonRowDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRowDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRowDown.Name = "toolStripButtonRowDown";
            this.toolStripButtonRowDown.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonRowDown.Text = "toolStripButton2";
            this.toolStripButtonRowDown.Click += new System.EventHandler(this.toolStripButtonRowDown_Click);
            // 
            // groupBoxDeviceSettings
            // 
            this.groupBoxDeviceSettings.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxDeviceSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDeviceSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDeviceSettings.Name = "groupBoxDeviceSettings";
            this.groupBoxDeviceSettings.Size = new System.Drawing.Size(238, 184);
            this.groupBoxDeviceSettings.TabIndex = 3;
            this.groupBoxDeviceSettings.TabStop = false;
            this.groupBoxDeviceSettings.Text = "Параметры устройства";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.80783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.19217F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAddress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUserName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxModel, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 139);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Логин";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Адрес";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(79, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 22);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAddress.Location = new System.Drawing.Point(79, 31);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(144, 22);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(79, 59);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(144, 22);
            this.textBoxUserName.TabIndex = 2;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(79, 87);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(144, 22);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.WordWrap = false;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelName
            // 
            this.labelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(70, 20);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Название";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(464, 222);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 24);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDevice.Location = new System.Drawing.Point(378, 222);
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Size = new System.Drawing.Size(80, 24);
            this.buttonAddDevice.TabIndex = 2;
            this.buttonAddDevice.Text = "Добавить";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(79, 115);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.ReadOnly = true;
            this.textBoxModel.Size = new System.Drawing.Size(144, 22);
            this.textBoxModel.TabIndex = 8;
            this.textBoxModel.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Модель";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(556, 258);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление устройства";
            this.Shown += new System.EventHandler(this.FormDevice_Shown);
            this.panelMain.ResumeLayout(false);
            this.groupBoxCameraList.ResumeLayout(false);
            this.panelCameras.ResumeLayout(false);
            this.panelCameras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraList)).EndInit();
            this.toolStripCameras.ResumeLayout(false);
            this.toolStripCameras.PerformLayout();
            this.groupBoxDeviceSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddDevice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewCameraList;
        private System.Windows.Forms.Panel panelCameras;
        private System.Windows.Forms.ToolStrip toolStripCameras;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddCamera;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveCamera;
        private System.Windows.Forms.GroupBox groupBoxCameraList;
        private System.Windows.Forms.GroupBox groupBoxDeviceSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChanel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRowUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonRowDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxModel;
    }
}