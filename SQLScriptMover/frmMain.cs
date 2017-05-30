using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// https://sqlscriptmove.codeplex.com/
/// </summary>
namespace sqlScriptMoveCS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            try {
                ScriptMove move = new ScriptMove();
                move.ServerName = txtServer.Text;
                move.DatabaseName = txtDatabase.Text;
                move.UserId = txtUser.Text;
                move.Password = txtPassword.Text;
                move.UseIntegratedAuthentication = chkUseIntegratedAuthentication.Checked;

                move.MatchOnNameContains = chkFilterOnNameContaining.Checked;
                move.TextToMatchOnNameContains = txtNameContains.Text;

                move.IncludeTables = chkIncludeTables.Checked;
                move.IncludeViews = chkIncludeViews.Checked;
                move.IncludeProcedures = chkIncludeProcedures.Checked;
                move.IncludeTriggers = chkIncludeTriggers.Checked;
                move.IncludeDDLTriggers = chkIncludeDDLTriggers.Checked;
                move.IncludeFunctions = chkIncludeFunctions.Checked;

                move.Execute(
                        txtScriptDir.Text
                    );

                MessageBox.Show(this, "Script Export Complete.");
            } catch(Exception ex)
            {
                MessageBox.Show(this, string.Format("An exception occurred: {0}"), ex.Message);
            }
        }

        private void cmdSetScriptDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog db = new FolderBrowserDialog();
            if (db.ShowDialog()==DialogResult.OK)
            {
                txtScriptDir.Text = db.SelectedPath;                
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
