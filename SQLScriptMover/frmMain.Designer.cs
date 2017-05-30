namespace sqlScriptMoveCS
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtScriptDir = new System.Windows.Forms.TextBox();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSetScriptDir = new System.Windows.Forms.Button();
            this.chkUseIntegratedAuthentication = new System.Windows.Forms.CheckBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.appToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkFilterOnNameContaining = new System.Windows.Forms.CheckBox();
            this.txtNameContains = new System.Windows.Forms.TextBox();
            this.chkIncludeTables = new System.Windows.Forms.CheckBox();
            this.chkIncludeViews = new System.Windows.Forms.CheckBox();
            this.chkIncludeFunctions = new System.Windows.Forms.CheckBox();
            this.chkIncludeProcedures = new System.Windows.Forms.CheckBox();
            this.chkIncludeTriggers = new System.Windows.Forms.CheckBox();
            this.chkIncludeDDLTriggers = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(87, 13);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(157, 20);
            this.txtServer.TabIndex = 1;
            this.appToolTip.SetToolTip(this.txtServer, "Name of sql server");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Schema Script Directory:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(359, 10);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(143, 20);
            this.txtDatabase.TabIndex = 2;
            this.appToolTip.SetToolTip(this.txtDatabase, "Name of database");
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(86, 57);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 4;
            this.appToolTip.SetToolTip(this.txtUser, "User name (if not integrated authentication)");
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(359, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            this.appToolTip.SetToolTip(this.txtPassword, "Password (if not integrated authentication)");
            // 
            // txtScriptDir
            // 
            this.txtScriptDir.Location = new System.Drawing.Point(43, 207);
            this.txtScriptDir.Name = "txtScriptDir";
            this.txtScriptDir.Size = new System.Drawing.Size(458, 20);
            this.txtScriptDir.TabIndex = 9;
            this.appToolTip.SetToolTip(this.txtScriptDir, "Directory where exported schema should be saved");
            // 
            // cmdExecute
            // 
            this.cmdExecute.Location = new System.Drawing.Point(426, 248);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(75, 23);
            this.cmdExecute.TabIndex = 12;
            this.cmdExecute.Text = "&Execute";
            this.appToolTip.SetToolTip(this.cmdExecute, "Execute schema export");
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(333, 248);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "E&xit";
            this.appToolTip.SetToolTip(this.cmdClose, "Close application");
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSetScriptDir
            // 
            this.cmdSetScriptDir.Location = new System.Drawing.Point(15, 207);
            this.cmdSetScriptDir.Name = "cmdSetScriptDir";
            this.cmdSetScriptDir.Size = new System.Drawing.Size(22, 23);
            this.cmdSetScriptDir.TabIndex = 8;
            this.cmdSetScriptDir.Text = "...";
            this.appToolTip.SetToolTip(this.cmdSetScriptDir, "Browse for export directory");
            this.cmdSetScriptDir.UseVisualStyleBackColor = true;
            this.cmdSetScriptDir.Click += new System.EventHandler(this.cmdSetScriptDir_Click);
            // 
            // chkUseIntegratedAuthentication
            // 
            this.chkUseIntegratedAuthentication.AutoSize = true;
            this.chkUseIntegratedAuthentication.Location = new System.Drawing.Point(87, 34);
            this.chkUseIntegratedAuthentication.Name = "chkUseIntegratedAuthentication";
            this.chkUseIntegratedAuthentication.Size = new System.Drawing.Size(167, 17);
            this.chkUseIntegratedAuthentication.TabIndex = 3;
            this.chkUseIntegratedAuthentication.Text = "Use Integrated Authentication";
            this.appToolTip.SetToolTip(this.chkUseIntegratedAuthentication, "Use integrated authentication (rather than username/password) ?");
            this.chkUseIntegratedAuthentication.UseVisualStyleBackColor = true;
            // 
            // chkFilterOnNameContaining
            // 
            this.chkFilterOnNameContaining.AutoSize = true;
            this.chkFilterOnNameContaining.Location = new System.Drawing.Point(19, 95);
            this.chkFilterOnNameContaining.Name = "chkFilterOnNameContaining";
            this.chkFilterOnNameContaining.Size = new System.Drawing.Size(224, 17);
            this.chkFilterOnNameContaining.TabIndex = 17;
            this.chkFilterOnNameContaining.Text = "Include only objects with this text in name:";
            this.appToolTip.SetToolTip(this.chkFilterOnNameContaining, "Filter on object name");
            this.chkFilterOnNameContaining.UseVisualStyleBackColor = true;
            // 
            // txtNameContains
            // 
            this.txtNameContains.Location = new System.Drawing.Point(253, 93);
            this.txtNameContains.Name = "txtNameContains";
            this.txtNameContains.PasswordChar = '*';
            this.txtNameContains.Size = new System.Drawing.Size(100, 20);
            this.txtNameContains.TabIndex = 18;
            this.appToolTip.SetToolTip(this.txtNameContains, "If filtering on object name, include only objects with this text in name");
            // 
            // chkIncludeTables
            // 
            this.chkIncludeTables.AutoSize = true;
            this.chkIncludeTables.Checked = true;
            this.chkIncludeTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeTables.Location = new System.Drawing.Point(19, 160);
            this.chkIncludeTables.Name = "chkIncludeTables";
            this.chkIncludeTables.Size = new System.Drawing.Size(58, 17);
            this.chkIncludeTables.TabIndex = 19;
            this.chkIncludeTables.Text = "Tables";
            this.appToolTip.SetToolTip(this.chkIncludeTables, "Include tables when exporting scripts");
            this.chkIncludeTables.UseVisualStyleBackColor = true;
            // 
            // chkIncludeViews
            // 
            this.chkIncludeViews.AutoSize = true;
            this.chkIncludeViews.Checked = true;
            this.chkIncludeViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeViews.Location = new System.Drawing.Point(86, 160);
            this.chkIncludeViews.Name = "chkIncludeViews";
            this.chkIncludeViews.Size = new System.Drawing.Size(54, 17);
            this.chkIncludeViews.TabIndex = 20;
            this.chkIncludeViews.Text = "Views";
            this.appToolTip.SetToolTip(this.chkIncludeViews, "Include views when exporting scripts");
            this.chkIncludeViews.UseVisualStyleBackColor = true;
            // 
            // chkIncludeFunctions
            // 
            this.chkIncludeFunctions.AutoSize = true;
            this.chkIncludeFunctions.Checked = true;
            this.chkIncludeFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeFunctions.Location = new System.Drawing.Point(146, 160);
            this.chkIncludeFunctions.Name = "chkIncludeFunctions";
            this.chkIncludeFunctions.Size = new System.Drawing.Size(72, 17);
            this.chkIncludeFunctions.TabIndex = 21;
            this.chkIncludeFunctions.Text = "Functions";
            this.appToolTip.SetToolTip(this.chkIncludeFunctions, "Include functions when exporting scripts");
            this.chkIncludeFunctions.UseVisualStyleBackColor = true;
            // 
            // chkIncludeProcedures
            // 
            this.chkIncludeProcedures.AutoSize = true;
            this.chkIncludeProcedures.Checked = true;
            this.chkIncludeProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeProcedures.Location = new System.Drawing.Point(228, 160);
            this.chkIncludeProcedures.Name = "chkIncludeProcedures";
            this.chkIncludeProcedures.Size = new System.Drawing.Size(80, 17);
            this.chkIncludeProcedures.TabIndex = 22;
            this.chkIncludeProcedures.Text = "Procedures";
            this.appToolTip.SetToolTip(this.chkIncludeProcedures, "Include procedures when exporting scripts");
            this.chkIncludeProcedures.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTriggers
            // 
            this.chkIncludeTriggers.AutoSize = true;
            this.chkIncludeTriggers.Checked = true;
            this.chkIncludeTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeTriggers.Location = new System.Drawing.Point(314, 160);
            this.chkIncludeTriggers.Name = "chkIncludeTriggers";
            this.chkIncludeTriggers.Size = new System.Drawing.Size(64, 17);
            this.chkIncludeTriggers.TabIndex = 23;
            this.chkIncludeTriggers.Text = "Triggers";
            this.appToolTip.SetToolTip(this.chkIncludeTriggers, "Include triggers when exporting scripts");
            this.chkIncludeTriggers.UseVisualStyleBackColor = true;
            // 
            // chkIncludeDDLTriggers
            // 
            this.chkIncludeDDLTriggers.AutoSize = true;
            this.chkIncludeDDLTriggers.Checked = true;
            this.chkIncludeDDLTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeDDLTriggers.Location = new System.Drawing.Point(384, 160);
            this.chkIncludeDDLTriggers.Name = "chkIncludeDDLTriggers";
            this.chkIncludeDDLTriggers.Size = new System.Drawing.Size(89, 17);
            this.chkIncludeDDLTriggers.TabIndex = 24;
            this.chkIncludeDDLTriggers.Text = "DDL Triggers";
            this.appToolTip.SetToolTip(this.chkIncludeDDLTriggers, "Include ddl triggers when exporting scripts");
            this.chkIncludeDDLTriggers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Include these object types when scripting:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 286);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIncludeDDLTriggers);
            this.Controls.Add(this.chkIncludeTriggers);
            this.Controls.Add(this.chkIncludeProcedures);
            this.Controls.Add(this.chkIncludeFunctions);
            this.Controls.Add(this.chkIncludeViews);
            this.Controls.Add(this.chkIncludeTables);
            this.Controls.Add(this.txtNameContains);
            this.Controls.Add(this.chkFilterOnNameContaining);
            this.Controls.Add(this.chkUseIntegratedAuthentication);
            this.Controls.Add(this.cmdSetScriptDir);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.txtScriptDir);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Script Mover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtScriptDir;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSetScriptDir;
        private System.Windows.Forms.CheckBox chkUseIntegratedAuthentication;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ToolTip appToolTip;
        private System.Windows.Forms.CheckBox chkFilterOnNameContaining;
        private System.Windows.Forms.TextBox txtNameContains;
        private System.Windows.Forms.CheckBox chkIncludeTables;
        private System.Windows.Forms.CheckBox chkIncludeViews;
        private System.Windows.Forms.CheckBox chkIncludeFunctions;
        private System.Windows.Forms.CheckBox chkIncludeProcedures;
        private System.Windows.Forms.CheckBox chkIncludeTriggers;
        private System.Windows.Forms.CheckBox chkIncludeDDLTriggers;
        private System.Windows.Forms.Label label5;
    }
}

