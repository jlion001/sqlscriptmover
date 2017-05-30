using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

/// <summary>
/// https://sqlscriptmove.codeplex.com/
/// </summary>
namespace sqlScriptMoveCS
{
    internal class ScriptMove
    {
        private StringBuilder _printStatements = new StringBuilder();
        private static string _logPath = string.Empty;

        private string _serverName = string.Empty;
        private string _databaseName = string.Empty;
        private string _userId = string.Empty;
        private string _password = string.Empty;
        private bool _useIntegratedAuthentication = false;

        private bool _matchOnNameContains = false;
        private string _textToMatchOnNameContains = string.Empty;

        private bool _includeTables = true;
        private bool _includeViews = true;
        private bool _includeFunctions = true;
        private bool _includeProcedures = true;
        private bool _includeTriggers = true;
        private bool _includeDDLTriggers = true;

        public string ServerName
        {
            set { _serverName = value; }
        }

        public string DatabaseName
        {
            set { _databaseName = value; }
        }

        public string UserId
        {
            set { _userId = value; }
        }

        public string Password
        {
            set { _password = value; }
        }

        public bool UseIntegratedAuthentication
        {
            set { _useIntegratedAuthentication = value; }
        }

        public bool IncludeTables
        {
            set { _includeTables = value; }
        }
        public bool IncludeViews
        {
            set { _includeViews = value; }
        }
        public bool IncludeFunctions
        {
            set { _includeFunctions = value; }
        }
        public bool IncludeProcedures
        {
            set { _includeProcedures = value; }
        }
        public bool IncludeTriggers
        {
            set { _includeTriggers = value; }
        }
        public bool IncludeDDLTriggers
        {
            set { _includeDDLTriggers = value; }
        }

        public bool MatchOnNameContains
        {
            set { _matchOnNameContains = value; }
        }

        public string TextToMatchOnNameContains
        {
            set { _textToMatchOnNameContains = value.ToUpper(); }
        }

        public ScriptMove()
        {

        }

        public void Execute(
            string scriptPath)
        {
            ScriptToFile(
                scriptPath);
        }

        private void LogPrintStatements(
            object sender,
            SqlInfoMessageEventArgs e)
        {
            _printStatements.AppendLine(e.Message);
        }

        private void ScriptToFile(
            string scriptDirectory)
        {
            Stopwatch totalTime = new Stopwatch();
            totalTime.Start();

            string nowDir = string.Format("{0}_{1}_{2}_{3}_{4}",
                DateTime.Now.Year,
                string.Format("00{0}", DateTime.Now.Month).Right(2),
                string.Format("00{0}", DateTime.Now.Day).Right(2),
                string.Format("00{0}", DateTime.Now.Hour).Right(2),
                string.Format("00{0}", DateTime.Now.Minute).Right(2));

            string instanceScriptPath = Path.Combine(scriptDirectory, nowDir);
            Directory.CreateDirectory(instanceScriptPath);

            _logPath = Path.Combine(instanceScriptPath, "log.txt");

            Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(_serverName);
            if (_useIntegratedAuthentication)
            {
                server.ConnectionContext.LoginSecure = true;
            }
            else
            {
                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = _userId;
                server.ConnectionContext.Password = _password;
            }
                    
            Microsoft.SqlServer.Management.Smo.Database database = server.Databases[_databaseName];

            /* define scripting options */
            ScriptingOptions options = new ScriptingOptions();
            options.AllowSystemObjects = false;
            options.AllowSystemObjects = false;
            options.IncludeDatabaseContext = false;
            options.IncludeIfNotExists = false;
            options.ClusteredIndexes = true;
            options.Default = true;
            options.DriAll = true;
            options.Indexes = true;
            options.NonClusteredIndexes = true;         
            options.IncludeHeaders = true;
            options.ToFileOnly = true;
            options.AppendToFile = true;
            options.AnsiPadding = false;

            // Set scripter options to ensure only schema is scripted
            options.ScriptSchema = true;
            options.ScriptData = false;

            //Exclude GOs after every line
            options.NoCommandTerminator = false;

            Microsoft.SqlServer.Management.Smo.Scripter scripter = new Microsoft.SqlServer.Management.Smo.Scripter();
            scripter.Options = options;
            scripter.Server = server;

            if (_includeTables)
                ExportScript.ScriptTables(database, instanceScriptPath, scripter,_matchOnNameContains,_textToMatchOnNameContains);

            if (_includeViews)
                ExportScript.ScriptViews(database, instanceScriptPath, scripter, _matchOnNameContains, _textToMatchOnNameContains);

            if (_includeFunctions)
                ExportScript.ScriptFunctions(database, instanceScriptPath, scripter, _matchOnNameContains, _textToMatchOnNameContains);

            if (_includeProcedures)
                ExportScript.ScriptProcedures(database, instanceScriptPath, scripter, _matchOnNameContains, _textToMatchOnNameContains);

            if (_includeTriggers)
                ExportScript.ScriptTableTriggers(database, instanceScriptPath, scripter, _matchOnNameContains, _textToMatchOnNameContains);

            if (_includeDDLTriggers)
                ExportScript.ScriptDatabaseTriggers(database, instanceScriptPath, scripter, _matchOnNameContains, _textToMatchOnNameContains);

            WriteToLog(String.Format("Scripting completed. Elapsed seconds: {0}", totalTime.Elapsed.TotalSeconds));
        }

        private void ScriptFromFile(
            string scriptPath)
        {

        }

        public static void WriteToLog(string message)
        {
            try
            {
                if (_logPath.Trim().Length>0)
                {
                    using (StreamWriter sw = new StreamWriter(_logPath, true))
                    {
                        sw.WriteLine(message);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(string.Format("*** Error while writing to log: {0}", ex.Message));
            }
        }
    }
}
