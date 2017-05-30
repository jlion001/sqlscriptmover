using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;

/// <summary>
/// https://sqlscriptmove.codeplex.com/
/// </summary>
namespace sqlScriptMoveCS
{
    internal static class ExportScript
    {

        public static void ScriptTables(
             Database database,
             string scriptDirectory,
             Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptTables(database, scriptDirectory, scripter, false, "");
        }

       public static void ScriptTables(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string tableDirectory = Path.Combine(scriptDirectory, "tables");
            System.IO.Directory.CreateDirectory(tableDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            TableCollection allTables = database.Tables;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allTableObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int tableIndex = 0;

            ScriptMove.WriteToLog("Scripting tables...");
            foreach (Table oneTable in database.Tables)
            {
                if (!oneTable.IsSystemObject)
                    if (matchOnNameContains==false || (matchOnNameContains==true && oneTable.Name.ToUpper().Contains(textToMatchOnNameContains)))
                    {
                        List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneTableObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                        SqlSmoObject[] objectArray = { oneTable };
                        int depCount = CountTableDependancies(scripter, objectArray);
                        if (depCount > 0)
                            ScriptMove.WriteToLog(string.Format("table {0} has {1} dependancies", oneTable.Name, depCount));

                        oneTableObject.Add(oneTable.Urn);
                        allTableObjects.Add(oneTable.Urn);

                        string fileName = string.Format("{0}.{1}.{2}.sql",
                                    string.Format("0000{0}", tableIndex).Right(4),
                                    oneTable.Schema,
                                    oneTable.Name);

                        string fullFileName = Path.Combine(tableDirectory, fileName);

                        try
                        {
                            WriteScriptToFile(fullFileName, oneTable.Urn, ref scripter);
                        } catch (Exception ex)
                        {
                            ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneTable.Name,ex.Message));
                        }

                        tableIndex++;
                    }
            }
            ScriptMove.WriteToLog(String.Format("{0} tables scripted. Elapsed seconds: {1}", tableIndex,blockStart.Elapsed.TotalSeconds));
        }

        public static void ScriptViews(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptViews(database, scriptDirectory, scripter, false, "");
        }

        public static void ScriptViews(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string viewDirectory = Path.Combine(scriptDirectory, "views");
            System.IO.Directory.CreateDirectory(viewDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            ViewCollection allViews = database.Views;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allViewObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int viewIndex = 0;

            ScriptMove.WriteToLog("Scripting views...");
            foreach (View oneView in allViews)
            {
                if (!oneView.IsSystemObject)
                    if (matchOnNameContains == false || (matchOnNameContains == true && oneView.Name.ToUpper().Contains(textToMatchOnNameContains)))
                    {
                        SqlSmoObject[] objectArray = { oneView };

                        int depCount = CountObjectDependancies(scripter, objectArray);
                        if (depCount > 0)
                            ScriptMove.WriteToLog(string.Format("view {0} has {1} dependancies",oneView.Name, depCount));

                        List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneViewObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                        oneViewObject.Add(oneView.Urn);
                        allViewObjects.Add(oneView.Urn);

                        string fileName = string.Format("{0}.{1}.{2}.sql",
                                    string.Format("0000{0}", viewIndex).Right(4),
                                    oneView.Schema,
                                    oneView.Name);

                        string fullFileName = Path.Combine(viewDirectory, fileName);

                        try
                        {
                            WriteScriptToFile(fullFileName, oneView.Urn, ref scripter);
                        }
                        catch (Exception ex)
                        {
                            ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneView.Name,ex.Message));
                        }

                        viewIndex++;
                    }
            }
            ScriptMove.WriteToLog(String.Format("{0} views scripted. Elapsed seconds: {1}", viewIndex, blockStart.Elapsed.TotalSeconds));

        }

        public static void ScriptFunctions(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptFunctions(database, scriptDirectory, scripter, false, "");
        }

        public static void ScriptFunctions(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string functionDirectory = Path.Combine(scriptDirectory, "functions");
            System.IO.Directory.CreateDirectory(functionDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            UserDefinedFunctionCollection allFunctions = database.UserDefinedFunctions;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allFunctionObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int functionIndex = 0;

            ScriptMove.WriteToLog("Scripting functions...");
            foreach (UserDefinedFunction oneFunction in allFunctions)
            {
                if (!oneFunction.IsSystemObject)
                    if (matchOnNameContains == false || (matchOnNameContains == true && oneFunction.Name.ToUpper().Contains(textToMatchOnNameContains)))
                    {
                        SqlSmoObject[] objectArray = { oneFunction };
                        int depCount = CountObjectDependancies(scripter, objectArray);
                        if (depCount > 0)
                            ScriptMove.WriteToLog(string.Format("function {0} has {1} dependancies", oneFunction.Name, depCount));

                        List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneFunctionObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                        oneFunctionObject.Add(oneFunction.Urn);
                        allFunctionObjects.Add(oneFunction.Urn);

                        string fileName = string.Format("{0}.{1}.{2}.sql",
                                    string.Format("0000{0}", functionIndex).Right(4),
                                    oneFunction.Schema,
                                    oneFunction.Name);

                        string fullFileName = Path.Combine(functionDirectory, fileName);

                        try
                        {
                            WriteScriptToFile(fullFileName,oneFunction.Urn, ref scripter);
                        }
                        catch (Exception ex)
                        {
                            ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneFunction.Name,ex.Message));
                        }

                        functionIndex++;
                    }
            }
            ScriptMove.WriteToLog(String.Format("{0} functions scripted. Elapsed seconds: {1}", functionIndex, blockStart.Elapsed.TotalSeconds));

        }

        public static void ScriptProcedures(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptProcedures(database, scriptDirectory, scripter, false, "");
        }

        public static void ScriptProcedures(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string procsDirectory = Path.Combine(scriptDirectory, "procs");
            System.IO.Directory.CreateDirectory(procsDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            StoredProcedureCollection allProcs = database.StoredProcedures;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allProcObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int procIndex = 0;

            ScriptMove.WriteToLog("Scripting procs...");
            foreach (StoredProcedure oneProc in allProcs)
            {
                if (!oneProc.IsSystemObject)
                    if (matchOnNameContains == false || (matchOnNameContains == true && oneProc.Name.ToUpper().Contains(textToMatchOnNameContains)))
                    {
                        SqlSmoObject[] objectArray = { oneProc };
                        int depCount = CountObjectDependancies(scripter, objectArray);
                        if (depCount > 0)
                            ScriptMove.WriteToLog(string.Format("procedure {0} has {1} dependancies", oneProc.Name, depCount));

                        List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneProcObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                        oneProcObject.Add(oneProc.Urn);
                        allProcObjects.Add(oneProc.Urn);

                        string fileName = string.Format("{0}.{1}.{2}.sql",
                                    string.Format("0000{0}", procIndex).Right(4),
                                    oneProc.Schema,
                                    oneProc.Name);

                        string fullFileName = Path.Combine(procsDirectory, fileName);

                        try
                        {
                            WriteScriptToFile(fullFileName, oneProc.Urn, ref scripter);
                        }
                        catch (Exception ex)
                        {
                            ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneProc.Name,ex.Message));
                        }

                        procIndex++;
                    }
            }
            ScriptMove.WriteToLog(String.Format("{0} procs scripted. Elapsed seconds: {1}", procIndex,blockStart.Elapsed.TotalSeconds));

        }

        public static void ScriptTableTriggers(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptTableTriggers(database, scriptDirectory, scripter, false, "");
        }

        public static void ScriptTableTriggers(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string triggerDirectory = Path.Combine(scriptDirectory, "triggers");
            System.IO.Directory.CreateDirectory(triggerDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            TableCollection allTables = database.Tables;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allTriggerObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int triggerIndex = 0;

            ScriptMove.WriteToLog("Scripting triggers...");
            foreach (Table oneTable in allTables)
            {
                if (!oneTable.IsSystemObject)
                    if (matchOnNameContains == false || (matchOnNameContains == true && oneTable.Name.ToUpper().Contains(textToMatchOnNameContains)))
                        if (oneTable.Triggers.Count>0)
                            foreach(Trigger oneTrigger in oneTable.Triggers)
                                if(!oneTrigger.IsSystemObject)
                                {
                                    List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneTriggerObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                                    oneTriggerObject.Add(oneTrigger.Urn);

                                    string fileName = string.Format("{0}.{1}.{2}.sql",
                                                string.Format("0000{0}", triggerIndex).Right(4),
                                                oneTable.Schema,
                                                oneTrigger.Name);

                                    string fullFileName = Path.Combine(triggerDirectory, fileName);

                                    try
                                    {
                                        WriteScriptToFile(fullFileName, oneTrigger.Urn, ref scripter);
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneTable.Name,ex.Message));
                                    }

                                    triggerIndex++;
                                }
            }
            ScriptMove.WriteToLog(String.Format("{0} table triggers scripted. Elapsed seconds: {1}", triggerIndex,blockStart.Elapsed.TotalSeconds));

        }

        public static void ScriptDatabaseTriggers(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter)
        {
            ScriptDatabaseTriggers(database, scriptDirectory, scripter, false, "");
        }

        public static void ScriptDatabaseTriggers(
            Database database,
            string scriptDirectory,
            Microsoft.SqlServer.Management.Smo.Scripter scripter,
            bool matchOnNameContains,
            string textToMatchOnNameContains)
        {
            string triggerDirectory = Path.Combine(scriptDirectory, "ddltriggers");
            System.IO.Directory.CreateDirectory(triggerDirectory);

            Stopwatch blockStart = new Stopwatch();
            blockStart.Start();

            DatabaseDdlTriggerCollection allTriggers = database.Triggers;
            List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> allTriggerObjects = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

            int triggerIndex = 0;

            ScriptMove.WriteToLog("Scripting DDL triggers...");
            foreach (DatabaseDdlTrigger oneTrigger in allTriggers)
            {
                if (!oneTrigger.IsSystemObject)
                    if (matchOnNameContains == false || (matchOnNameContains == true && oneTrigger.Name.ToUpper().Contains(textToMatchOnNameContains)))
                        {
                        List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn> oneTriggerObject = new List<Microsoft.SqlServer.Management.Sdk.Sfc.Urn>();

                        oneTriggerObject.Add(oneTrigger.Urn);

                        string fileName = string.Format("{0}.{1}.{2}.sql",
                                    string.Format("0000{0}", triggerIndex).Right(4),
                                    "dbo",
                                    oneTrigger.Name);

                        string fullFileName = Path.Combine(triggerDirectory, fileName);

                        try
                        {
                            WriteScriptToFile(fullFileName, oneTrigger.Urn, ref scripter);
                        }
                        catch (Exception ex)
                        {
                            ScriptMove.WriteToLog(String.Format("    Unable to script {0} due to error {1}", oneTrigger.Name,ex.Message));
                        }

                        triggerIndex++;
                    }
            }
            ScriptMove.WriteToLog(String.Format("{0} DDL triggers scripted. Elapsed seconds: {1}", triggerIndex, blockStart.Elapsed.TotalSeconds));

        }

        private static void WriteScriptToFile(string fullFileName, Microsoft.SqlServer.Management.Sdk.Sfc.Urn schemaObject, ref Scripter scripter)
        {
            StringBuilder script = new StringBuilder();

            // Add script to file content
            foreach (string scriptLine in scripter.EnumScript(new Urn[] { schemaObject }))
            {
                string line = scriptLine;
                if (!line.Contains("SET ANSI_NULLS ON")
                    && !line.Contains("SET ANSI_NULLS OFF")
                    && !line.Contains("SET QUOTED_IDENTIFIER ON")
                    && !line.Contains("SET QUOTED_IDENTIFIER OFF")
                    )
                    script.AppendLine(line);
            }

            using (StreamWriter sw = new StreamWriter(fullFileName, false))
            {
                sw.Write(script.ToString());
            }
        }

        private static int CountObjectDependancies(Scripter scripter, SqlSmoObject[] objectArray)
        {
            int retVal = 0;

            DependencyWalker dependencyWalker = new DependencyWalker(scripter.Server);
            DependencyTree dependencyTree = dependencyWalker.DiscoverDependencies(objectArray, true);
            DependencyCollection dependencyCollection =dependencyWalker.WalkDependencies(dependencyTree);

            foreach (DependencyCollectionNode oneDep in dependencyCollection)
            {
                if (oneDep.Urn.Type.Equals("View")
                    || oneDep.Urn.Type.Equals("UserDefinedFunction")
                    || oneDep.Urn.Type.Equals("StoredProcedure")
                    )
                    retVal++;
            }
            

            return retVal;
        }

        private static int CountTableDependancies(Scripter scripter, SqlSmoObject[] objectArray)
        {
            int retVal = 0;

            DependencyWalker dependencyWalker = new DependencyWalker(scripter.Server);
            DependencyTree dependencyTree = dependencyWalker.DiscoverDependencies(objectArray, true);
            DependencyCollection dependencyCollection = dependencyWalker.WalkDependencies(dependencyTree);

            foreach (DependencyCollectionNode oneDep in dependencyCollection)
            {
                if (oneDep.Urn.Type.Equals("Table"))
                    retVal++;
            }


            return retVal;
        }
    }
}
