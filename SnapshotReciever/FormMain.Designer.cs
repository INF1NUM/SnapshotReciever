namespace SnapshotReciever
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.treeViewDevices = new System.Windows.Forms.TreeView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.toolStripDevices = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripImage = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonGetSnapshot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveImage = new System.Windows.Forms.ToolStripButton();
            this.labelDeviceInfo = new System.Windows.Forms.Label();
            this.pictureBoxSnapshot = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStarus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.toolStripDevices.SuspendLayout();
            this.toolStripImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnapshot)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewDevices
            // 
            this.treeViewDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewDevices.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewDevices.FullRowSelect = true;
            this.treeViewDevices.HideSelection = false;
            this.treeViewDevices.LabelEdit = true;
            this.treeViewDevices.Location = new System.Drawing.Point(0, 0);
            this.treeViewDevices.Name = "treeViewDevices";
            this.treeViewDevices.Size = new System.Drawing.Size(211, 532);
            this.treeViewDevices.TabIndex = 0;
            this.treeViewDevices.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewDevices_AfterLabelEdit);
            this.treeViewDevices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDevices_AfterSelect);
            this.treeViewDevices.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDevices_NodeMouseDoubleClick);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.Location = new System.Drawing.Point(12, 12);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.toolStripDevices);
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewDevices);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.toolStripImage);
            this.splitContainerMain.Panel2.Controls.Add(this.labelDeviceInfo);
            this.splitContainerMain.Panel2.Controls.Add(this.pictureBoxSnapshot);
            this.splitContainerMain.Size = new System.Drawing.Size(950, 565);
            this.splitContainerMain.SplitterDistance = 213;
            this.splitContainerMain.TabIndex = 1;
            // 
            // toolStripDevices
            // 
            this.toolStripDevices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripDevices.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddDevice,
            this.toolStripButtonRemoveDevice,
            this.toolStripButtonEditDevice,
            this.toolStripSeparator1,
            this.toolStripButtonUp,
            this.toolStripButtonDown});
            this.toolStripDevices.Location = new System.Drawing.Point(0, 532);
            this.toolStripDevices.Name = "toolStripDevices";
            this.toolStripDevices.Size = new System.Drawing.Size(211, 31);
            this.toolStripDevices.TabIndex = 1;
            this.toolStripDevices.Text = "toolStrip1";
            // 
            // toolStripButtonAddDevice
            // 
            this.toolStripButtonAddDevice.AutoSize = false;
            this.toolStripButtonAddDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddDevice.Image = global::SnapshotReciever.Properties.Resources.add24p;
            this.toolStripButtonAddDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddDevice.Name = "toolStripButtonAddDevice";
            this.toolStripButtonAddDevice.Size = new System.Drawing.Size(30, 28);
            this.toolStripButtonAddDevice.Text = "Добавить";
            this.toolStripButtonAddDevice.ToolTipText = "Добавить устройство";
            this.toolStripButtonAddDevice.Click += new System.EventHandler(this.toolStripButtonAddDevice_Click);
            // 
            // toolStripButtonRemoveDevice
            // 
            this.toolStripButtonRemoveDevice.AutoSize = false;
            this.toolStripButtonRemoveDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveDevice.Image = global::SnapshotReciever.Properties.Resources.remove24pred;
            this.toolStripButtonRemoveDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRemoveDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveDevice.Name = "toolStripButtonRemoveDevice";
            this.toolStripButtonRemoveDevice.Size = new System.Drawing.Size(30, 28);
            this.toolStripButtonRemoveDevice.Text = "Удалить";
            this.toolStripButtonRemoveDevice.ToolTipText = "Удалить выбранное устройство или канал";
            this.toolStripButtonRemoveDevice.Click += new System.EventHandler(this.toolStripButtonRemoveDevice_Click);
            // 
            // toolStripButtonEditDevice
            // 
            this.toolStripButtonEditDevice.AutoSize = false;
            this.toolStripButtonEditDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditDevice.Image = global::SnapshotReciever.Properties.Resources.edit24p;
            this.toolStripButtonEditDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEditDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditDevice.Name = "toolStripButtonEditDevice";
            this.toolStripButtonEditDevice.Size = new System.Drawing.Size(30, 28);
            this.toolStripButtonEditDevice.Text = "Изменить";
            this.toolStripButtonEditDevice.ToolTipText = "Редактировать устройство";
            this.toolStripButtonEditDevice.Click += new System.EventHandler(this.toolStripButtonEditDevice_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonUp
            // 
            this.toolStripButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUp.Image = global::SnapshotReciever.Properties.Resources.up24p;
            this.toolStripButtonUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUp.Name = "toolStripButtonUp";
            this.toolStripButtonUp.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonUp.Text = "Поднять вверх";
            this.toolStripButtonUp.ToolTipText = "Поднять вверх";
            this.toolStripButtonUp.Click += new System.EventHandler(this.toolStripButtonUp_Click);
            // 
            // toolStripButtonDown
            // 
            this.toolStripButtonDown.AutoSize = false;
            this.toolStripButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDown.Image = global::SnapshotReciever.Properties.Resources.down24p;
            this.toolStripButtonDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDown.Name = "toolStripButtonDown";
            this.toolStripButtonDown.Size = new System.Drawing.Size(30, 28);
            this.toolStripButtonDown.Text = "Опустить вниз";
            this.toolStripButtonDown.ToolTipText = "Опустить вниз";
            this.toolStripButtonDown.Click += new System.EventHandler(this.toolStripButtonDown_Click);
            // 
            // toolStripImage
            // 
            this.toolStripImage.AutoSize = false;
            this.toolStripImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripImage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonGetSnapshot,
            this.toolStripSeparator2,
            this.toolStripButtonSaveImage});
            this.toolStripImage.Location = new System.Drawing.Point(0, 532);
            this.toolStripImage.Name = "toolStripImage";
            this.toolStripImage.Size = new System.Drawing.Size(731, 31);
            this.toolStripImage.TabIndex = 5;
            this.toolStripImage.Text = "toolStrip1";
            // 
            // toolStripButtonGetSnapshot
            // 
            this.toolStripButtonGetSnapshot.AutoSize = false;
            this.toolStripButtonGetSnapshot.Image = global::SnapshotReciever.Properties.Resources.photo24p;
            this.toolStripButtonGetSnapshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonGetSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGetSnapshot.Name = "toolStripButtonGetSnapshot";
            this.toolStripButtonGetSnapshot.Size = new System.Drawing.Size(140, 28);
            this.toolStripButtonGetSnapshot.Text = "Получить снимок";
            this.toolStripButtonGetSnapshot.Click += new System.EventHandler(this.toolStripButtonGetSnapshot_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonSaveImage
            // 
            this.toolStripButtonSaveImage.AutoSize = false;
            this.toolStripButtonSaveImage.Image = global::SnapshotReciever.Properties.Resources.save24p;
            this.toolStripButtonSaveImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveImage.Name = "toolStripButtonSaveImage";
            this.toolStripButtonSaveImage.Size = new System.Drawing.Size(140, 28);
            this.toolStripButtonSaveImage.Text = "Сохранить снимок";
            this.toolStripButtonSaveImage.Click += new System.EventHandler(this.toolStripButtonSaveImage_Click);
            // 
            // labelDeviceInfo
            // 
            this.labelDeviceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeviceInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeviceInfo.Location = new System.Drawing.Point(3, 3);
            this.labelDeviceInfo.Name = "labelDeviceInfo";
            this.labelDeviceInfo.Size = new System.Drawing.Size(725, 24);
            this.labelDeviceInfo.TabIndex = 3;
            this.labelDeviceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSnapshot
            // 
            this.pictureBoxSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSnapshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSnapshot.Location = new System.Drawing.Point(0, 30);
            this.pictureBoxSnapshot.Name = "pictureBoxSnapshot";
            this.pictureBoxSnapshot.Size = new System.Drawing.Size(731, 502);
            this.pictureBoxSnapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSnapshot.TabIndex = 0;
            this.pictureBoxSnapshot.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStarus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 580);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStarus
            // 
            this.toolStripStatusLabelStarus.Name = "toolStripStatusLabelStarus";
            this.toolStripStatusLabelStarus.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelStarus.Text = "Готово";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 602);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnapshotReciever";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.toolStripDevices.ResumeLayout(false);
            this.toolStripDevices.PerformLayout();
            this.toolStripImage.ResumeLayout(false);
            this.toolStripImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnapshot)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewDevices;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.PictureBox pictureBoxSnapshot;
        private System.Windows.Forms.ToolStrip toolStripDevices;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddDevice;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveDevice;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditDevice;
        private System.Windows.Forms.Label labelDeviceInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonDown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStarus;
        private System.Windows.Forms.ToolStrip toolStripImage;
        private System.Windows.Forms.ToolStripButton toolStripButtonGetSnapshot;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

