namespace TkChatbot_APIClient
{
    partial class APIClientSettings : TkChatBotPlugin_Base.BotPluginTemplate
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EndpointTable = new System.Windows.Forms.TableLayoutPanel();
            this.EndpointList = new System.Windows.Forms.ComboBox();
            this.Endpoint_Add = new System.Windows.Forms.Button();
            this.Endpoint_Remove = new System.Windows.Forms.Button();
            this.EndPointActionsGroup = new System.Windows.Forms.GroupBox();
            this.EndpointActionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EndpointActionsListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.endpointActionList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.EndpointAction_Add = new System.Windows.Forms.Button();
            this.EndpointAction_Remove = new System.Windows.Forms.Button();
            this.EndpointEditor = new System.Windows.Forms.MultisplitContainer();
            this.EE_URL_Group = new System.Windows.Forms.GroupBox();
            this.EE_URL = new System.Windows.Forms.TextBox();
            this.EE_Description_Group = new System.Windows.Forms.GroupBox();
            this.EE_Description = new System.Windows.Forms.TextBox();
            this.EE_Headers_Group = new System.Windows.Forms.GroupBox();
            this.EE_Headers = new System.Windows.Forms.TextBox();
            this.EE_Data_Group = new System.Windows.Forms.GroupBox();
            this.EE_Data = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.EE_Do_Revert = new System.Windows.Forms.Button();
            this.EE_Do_Update = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.EndpointTable.SuspendLayout();
            this.EndPointActionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndpointActionsSplitContainer)).BeginInit();
            this.EndpointActionsSplitContainer.Panel1.SuspendLayout();
            this.EndpointActionsSplitContainer.Panel2.SuspendLayout();
            this.EndpointActionsSplitContainer.SuspendLayout();
            this.EndpointActionsListTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndpointEditor)).BeginInit();
            this.EndpointEditor.SuspendLayout();
            this.EE_URL_Group.SuspendLayout();
            this.EE_Description_Group.SuspendLayout();
            this.EE_Headers_Group.SuspendLayout();
            this.EE_Data_Group.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EndPointActionsGroup, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 360);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EndpointTable);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endpoints";
            // 
            // EndpointTable
            // 
            this.EndpointTable.ColumnCount = 3;
            this.EndpointTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EndpointTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.EndpointTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.EndpointTable.Controls.Add(this.EndpointList, 0, 0);
            this.EndpointTable.Controls.Add(this.Endpoint_Add, 1, 0);
            this.EndpointTable.Controls.Add(this.Endpoint_Remove, 2, 0);
            this.EndpointTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointTable.Location = new System.Drawing.Point(3, 16);
            this.EndpointTable.Name = "EndpointTable";
            this.EndpointTable.RowCount = 1;
            this.EndpointTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EndpointTable.Size = new System.Drawing.Size(348, 26);
            this.EndpointTable.TabIndex = 0;
            // 
            // EndpointList
            // 
            this.EndpointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EndpointList.DropDownWidth = 300;
            this.EndpointList.FormattingEnabled = true;
            this.EndpointList.Location = new System.Drawing.Point(3, 3);
            this.EndpointList.Name = "EndpointList";
            this.EndpointList.Size = new System.Drawing.Size(235, 21);
            this.EndpointList.TabIndex = 0;
            this.EndpointList.SelectedIndexChanged += new System.EventHandler(this.EndpointList_SelectedIndexChanged);
            // 
            // Endpoint_Add
            // 
            this.Endpoint_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Endpoint_Add.Location = new System.Drawing.Point(244, 3);
            this.Endpoint_Add.Name = "Endpoint_Add";
            this.Endpoint_Add.Size = new System.Drawing.Size(38, 20);
            this.Endpoint_Add.TabIndex = 1;
            this.Endpoint_Add.Text = "Add";
            this.Endpoint_Add.UseVisualStyleBackColor = true;
            this.Endpoint_Add.Click += new System.EventHandler(this.Endpoint_Add_Click);
            // 
            // Endpoint_Remove
            // 
            this.Endpoint_Remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Endpoint_Remove.Location = new System.Drawing.Point(288, 3);
            this.Endpoint_Remove.Name = "Endpoint_Remove";
            this.Endpoint_Remove.Size = new System.Drawing.Size(57, 20);
            this.Endpoint_Remove.TabIndex = 2;
            this.Endpoint_Remove.Text = "Remove";
            this.Endpoint_Remove.UseVisualStyleBackColor = true;
            this.Endpoint_Remove.Click += new System.EventHandler(this.Endpoint_Remove_Click);
            // 
            // EndPointActionsGroup
            // 
            this.EndPointActionsGroup.Controls.Add(this.EndpointActionsSplitContainer);
            this.EndPointActionsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndPointActionsGroup.Location = new System.Drawing.Point(3, 54);
            this.EndPointActionsGroup.Name = "EndPointActionsGroup";
            this.EndPointActionsGroup.Size = new System.Drawing.Size(354, 303);
            this.EndPointActionsGroup.TabIndex = 3;
            this.EndPointActionsGroup.TabStop = false;
            this.EndPointActionsGroup.Text = "Endpoint Actions";
            // 
            // EndpointActionsSplitContainer
            // 
            this.EndpointActionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointActionsSplitContainer.Location = new System.Drawing.Point(3, 16);
            this.EndpointActionsSplitContainer.Name = "EndpointActionsSplitContainer";
            // 
            // EndpointActionsSplitContainer.Panel1
            // 
            this.EndpointActionsSplitContainer.Panel1.Controls.Add(this.EndpointActionsListTableLayoutPanel);
            // 
            // EndpointActionsSplitContainer.Panel2
            // 
            this.EndpointActionsSplitContainer.Panel2.Controls.Add(this.EndpointEditor);
            this.EndpointActionsSplitContainer.Size = new System.Drawing.Size(348, 284);
            this.EndpointActionsSplitContainer.SplitterDistance = 116;
            this.EndpointActionsSplitContainer.TabIndex = 1;
            // 
            // EndpointActionsListTableLayoutPanel
            // 
            this.EndpointActionsListTableLayoutPanel.ColumnCount = 1;
            this.EndpointActionsListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EndpointActionsListTableLayoutPanel.Controls.Add(this.endpointActionList, 0, 0);
            this.EndpointActionsListTableLayoutPanel.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.EndpointActionsListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointActionsListTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.EndpointActionsListTableLayoutPanel.Name = "EndpointActionsListTableLayoutPanel";
            this.EndpointActionsListTableLayoutPanel.RowCount = 2;
            this.EndpointActionsListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EndpointActionsListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.EndpointActionsListTableLayoutPanel.Size = new System.Drawing.Size(116, 284);
            this.EndpointActionsListTableLayoutPanel.TabIndex = 0;
            // 
            // endpointActionList
            // 
            this.endpointActionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endpointActionList.FormattingEnabled = true;
            this.endpointActionList.Location = new System.Drawing.Point(3, 3);
            this.endpointActionList.Name = "endpointActionList";
            this.endpointActionList.Size = new System.Drawing.Size(110, 244);
            this.endpointActionList.TabIndex = 3;
            this.endpointActionList.SelectedIndexChanged += new System.EventHandler(this.endpointActionList_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.22807F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.77193F));
            this.tableLayoutPanel5.Controls.Add(this.EndpointAction_Add, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.EndpointAction_Remove, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 253);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(108, 28);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // EndpointAction_Add
            // 
            this.EndpointAction_Add.Location = new System.Drawing.Point(3, 3);
            this.EndpointAction_Add.Name = "EndpointAction_Add";
            this.EndpointAction_Add.Size = new System.Drawing.Size(38, 23);
            this.EndpointAction_Add.TabIndex = 0;
            this.EndpointAction_Add.Text = "Add";
            this.EndpointAction_Add.UseVisualStyleBackColor = true;
            this.EndpointAction_Add.Click += new System.EventHandler(this.EndpointAction_Add_Click);
            // 
            // EndpointAction_Remove
            // 
            this.EndpointAction_Remove.Location = new System.Drawing.Point(47, 3);
            this.EndpointAction_Remove.Name = "EndpointAction_Remove";
            this.EndpointAction_Remove.Size = new System.Drawing.Size(58, 23);
            this.EndpointAction_Remove.TabIndex = 1;
            this.EndpointAction_Remove.Text = "Remove";
            this.EndpointAction_Remove.UseVisualStyleBackColor = true;
            this.EndpointAction_Remove.Click += new System.EventHandler(this.EndpointAction_Remove_Click);
            // 
            // EndpointEditor
            // 
            this.EndpointEditor.AutoScroll = true;
            this.EndpointEditor.AutoScrollMinSize = new System.Drawing.Size(30, 30);
            this.EndpointEditor.Controls.Add(this.EE_URL_Group);
            this.EndpointEditor.Controls.Add(this.EE_Description_Group);
            this.EndpointEditor.Controls.Add(this.EE_Headers_Group);
            this.EndpointEditor.Controls.Add(this.EE_Data_Group);
            this.EndpointEditor.Controls.Add(this.tableLayoutPanel4);
            this.EndpointEditor.Cursor = System.Windows.Forms.Cursors.Default;
            this.EndpointEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointEditor.Expansion = 600;
            this.EndpointEditor.Location = new System.Drawing.Point(0, 0);
            this.EndpointEditor.MarkupColor = System.Drawing.SystemColors.Control;
            this.EndpointEditor.Name = "EndpointEditor";
            this.EndpointEditor.SingleColumnOrRow = true;
            this.EndpointEditor.Size = new System.Drawing.Size(228, 284);
            this.EndpointEditor.TabIndex = 4;
            // 
            // EE_URL_Group
            // 
            this.EE_URL_Group.Controls.Add(this.EE_URL);
            this.EE_URL_Group.Location = new System.Drawing.Point(3, 3);
            this.EE_URL_Group.MaximumSize = new System.Drawing.Size(0, 40);
            this.EE_URL_Group.MinimumSize = new System.Drawing.Size(50, 40);
            this.EE_URL_Group.Name = "EE_URL_Group";
            this.EE_URL_Group.Size = new System.Drawing.Size(222, 40);
            this.EndpointEditor.SetSizeDynamic(this.EE_URL_Group, false);
            this.EE_URL_Group.TabIndex = 1;
            this.EE_URL_Group.TabStop = false;
            this.EE_URL_Group.Text = "URL";
            // 
            // EE_URL
            // 
            this.EE_URL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_URL.Location = new System.Drawing.Point(3, 16);
            this.EE_URL.Name = "EE_URL";
            this.EE_URL.Size = new System.Drawing.Size(216, 20);
            this.EE_URL.TabIndex = 0;
            // 
            // EE_Description_Group
            // 
            this.EE_Description_Group.Controls.Add(this.EE_Description);
            this.EE_Description_Group.Location = new System.Drawing.Point(3, 49);
            this.EE_Description_Group.MaximumSize = new System.Drawing.Size(32767, 32767);
            this.EE_Description_Group.MinimumSize = new System.Drawing.Size(50, 40);
            this.EE_Description_Group.Name = "EE_Description_Group";
            this.EE_Description_Group.Size = new System.Drawing.Size(222, 40);
            this.EE_Description_Group.TabIndex = 2;
            this.EE_Description_Group.TabStop = false;
            this.EE_Description_Group.Text = "Description";
            // 
            // EE_Description
            // 
            this.EE_Description.AcceptsReturn = true;
            this.EE_Description.AcceptsTab = true;
            this.EE_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_Description.Location = new System.Drawing.Point(3, 16);
            this.EE_Description.Multiline = true;
            this.EE_Description.Name = "EE_Description";
            this.EE_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EE_Description.Size = new System.Drawing.Size(216, 21);
            this.EE_Description.TabIndex = 0;
            // 
            // EE_Headers_Group
            // 
            this.EE_Headers_Group.Controls.Add(this.EE_Headers);
            this.EE_Headers_Group.Location = new System.Drawing.Point(3, 95);
            this.EE_Headers_Group.MaximumSize = new System.Drawing.Size(32767, 32767);
            this.EE_Headers_Group.MinimumSize = new System.Drawing.Size(50, 60);
            this.EE_Headers_Group.Name = "EE_Headers_Group";
            this.EE_Headers_Group.Size = new System.Drawing.Size(222, 60);
            this.EE_Headers_Group.TabIndex = 3;
            this.EE_Headers_Group.TabStop = false;
            this.EE_Headers_Group.Text = "Headers";
            // 
            // EE_Headers
            // 
            this.EE_Headers.AcceptsReturn = true;
            this.EE_Headers.AcceptsTab = true;
            this.EE_Headers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_Headers.Location = new System.Drawing.Point(3, 16);
            this.EE_Headers.Multiline = true;
            this.EE_Headers.Name = "EE_Headers";
            this.EE_Headers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EE_Headers.Size = new System.Drawing.Size(216, 41);
            this.EE_Headers.TabIndex = 0;
            this.EE_Headers.WordWrap = false;
            // 
            // EE_Data_Group
            // 
            this.EE_Data_Group.Controls.Add(this.EE_Data);
            this.EE_Data_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointEditor.SetIsFillControl(this.EE_Data_Group, true);
            this.EE_Data_Group.Location = new System.Drawing.Point(3, 161);
            this.EE_Data_Group.MaximumSize = new System.Drawing.Size(32767, 32767);
            this.EE_Data_Group.MinimumSize = new System.Drawing.Size(50, 60);
            this.EE_Data_Group.Name = "EE_Data_Group";
            this.EE_Data_Group.Size = new System.Drawing.Size(222, 84);
            this.EE_Data_Group.TabIndex = 4;
            this.EE_Data_Group.TabStop = false;
            this.EE_Data_Group.Text = "Data";
            // 
            // EE_Data
            // 
            this.EE_Data.AcceptsReturn = true;
            this.EE_Data.AcceptsTab = true;
            this.EE_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_Data.HideSelection = false;
            this.EE_Data.Location = new System.Drawing.Point(3, 16);
            this.EE_Data.Multiline = true;
            this.EE_Data.Name = "EE_Data";
            this.EE_Data.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EE_Data.Size = new System.Drawing.Size(216, 65);
            this.EE_Data.TabIndex = 0;
            this.EE_Data.WordWrap = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel4.Controls.Add(this.EE_Do_Revert, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.EE_Do_Update, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 251);
            this.tableLayoutPanel4.MaximumSize = new System.Drawing.Size(32767, 32767);
            this.tableLayoutPanel4.MinimumSize = new System.Drawing.Size(50, 20);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(222, 30);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // EE_Do_Revert
            // 
            this.EE_Do_Revert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_Do_Revert.Location = new System.Drawing.Point(71, 3);
            this.EE_Do_Revert.Name = "EE_Do_Revert";
            this.EE_Do_Revert.Size = new System.Drawing.Size(74, 24);
            this.EE_Do_Revert.TabIndex = 0;
            this.EE_Do_Revert.Text = "Revert";
            this.EE_Do_Revert.UseVisualStyleBackColor = true;
            this.EE_Do_Revert.Click += new System.EventHandler(this.EE_Do_Revert_Click);
            // 
            // EE_Do_Update
            // 
            this.EE_Do_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EE_Do_Update.Location = new System.Drawing.Point(151, 3);
            this.EE_Do_Update.Name = "EE_Do_Update";
            this.EE_Do_Update.Size = new System.Drawing.Size(68, 24);
            this.EE_Do_Update.TabIndex = 1;
            this.EE_Do_Update.Text = "Update";
            this.EE_Do_Update.UseVisualStyleBackColor = true;
            this.EE_Do_Update.Click += new System.EventHandler(this.EE_Do_Update_Click);
            // 
            // APIClientSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "APIClientSettings";
            this.TabName = "API";
            this.Text = "Web API client";
            this.Load += new System.EventHandler(this.APIClientSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.EndpointTable.ResumeLayout(false);
            this.EndPointActionsGroup.ResumeLayout(false);
            this.EndpointActionsSplitContainer.Panel1.ResumeLayout(false);
            this.EndpointActionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EndpointActionsSplitContainer)).EndInit();
            this.EndpointActionsSplitContainer.ResumeLayout(false);
            this.EndpointActionsListTableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EndpointEditor)).EndInit();
            this.EndpointEditor.ResumeLayout(false);
            this.EE_URL_Group.ResumeLayout(false);
            this.EE_URL_Group.PerformLayout();
            this.EE_Description_Group.ResumeLayout(false);
            this.EE_Description_Group.PerformLayout();
            this.EE_Headers_Group.ResumeLayout(false);
            this.EE_Headers_Group.PerformLayout();
            this.EE_Data_Group.ResumeLayout(false);
            this.EE_Data_Group.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel EndpointTable;
        private System.Windows.Forms.ComboBox EndpointList;
        private System.Windows.Forms.Button Endpoint_Add;
        private System.Windows.Forms.Button Endpoint_Remove;
        private System.Windows.Forms.GroupBox EndPointActionsGroup;
        private System.Windows.Forms.ListBox endpointActionList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox EE_URL_Group;
        private System.Windows.Forms.TextBox EE_URL;
        private System.Windows.Forms.GroupBox EE_Headers_Group;
        private System.Windows.Forms.TextBox EE_Headers;
        private System.Windows.Forms.GroupBox EE_Description_Group;
        private System.Windows.Forms.TextBox EE_Description;
        private System.Windows.Forms.GroupBox EE_Data_Group;
        private System.Windows.Forms.TextBox EE_Data;
        private System.Windows.Forms.MultisplitContainer EndpointEditor;
        private System.Windows.Forms.Button EE_Do_Revert;
        private System.Windows.Forms.Button EE_Do_Update;
        private System.Windows.Forms.SplitContainer EndpointActionsSplitContainer;
        private System.Windows.Forms.TableLayoutPanel EndpointActionsListTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button EndpointAction_Add;
        private System.Windows.Forms.Button EndpointAction_Remove;
    }
}

