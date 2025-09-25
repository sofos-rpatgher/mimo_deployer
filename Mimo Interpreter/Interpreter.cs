using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Drawing;
using SAPFEWSELib;
using System.Collections.Generic;
using System.ComponentModel.Design;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Newtonsoft.Json.Linq;


namespace Mimo_Interpreter
{
    internal class Interpreter
    {
        public MimoProgram mimo_program;
        private RichTextBox console;
        private string sapshcutPath;
        LogHelper logSuccess;
        LogHelper logError;

        object SapGuiAuto = null;
        object connection = null;
        object app = null;
        object session = null;

        int connectionNumber = 0;
        int sessionNumber = 0;

        private string username = "";
        private string password = "";
        private string client = "";

        public Interpreter(RichTextBox console, string sapshcutPath, string username, string password, string client)
        {
            this.console = console;
            this.sapshcutPath = sapshcutPath;
            this.username = username;
            this.password = password;
            this.client = client;
        }

        static dynamic InvokeMethod(object obj, string methodName, object[] methodParams = null)
        {
            return obj.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, methodParams);
        }

        static dynamic GetProperty(object obj, string propertyName, object[] propertyParams = null)
        {
            return obj.GetType().InvokeMember(propertyName, BindingFlags.GetProperty, null, obj, propertyParams);
        }

        static dynamic SetProperty(object obj, string propertyName, object[] propertyParams = null)
        {
            return obj.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, obj, propertyParams);
        }

        public void printMessage(string message = "", string type = "", int aNL = 1, int bNL = 0, bool writeLog = true)
        {
            // Verificar si se necesita invocar al hilo de la UI
            if (console.InvokeRequired)
            {
                console.Invoke(new Action(() => printMessage(message, type, aNL, bNL, writeLog)));
                return;
            }

            // Operaciones de formato y escritura en el control console
            for (int i = 0; i < aNL; i++)
            {
                console.AppendText(Environment.NewLine);
            }

            if (type == "Error")
            {
                console.SelectionColor = Color.Red;
                console.AppendText(Environment.NewLine + message);
                console.SelectionColor = Color.Black;
                if (writeLog)
                    logError.WriteLog(message, "ERROR");
            }
            else if (type == "Warning")
            {
                console.SelectionColor = Color.Yellow;
                console.AppendText(message);
                console.SelectionColor = Color.Black;
                if (writeLog)
                    logSuccess.WriteLog(message, "WARNING");
            }
            else if (type == "Success")
            {
                console.SelectionColor = Color.Green;
                console.AppendText(message);
                console.SelectionColor = Color.Black;
                if (writeLog)
                    logSuccess.WriteLog(message, "SUCCESS");
            }
            else
            {
                console.SelectionColor = Color.Black;
                console.AppendText(message);
                if (writeLog)
                    logSuccess.WriteLog(message, "INFO");
            }

            for (int i = 0; i < bNL; i++)
            {
                console.AppendText(Environment.NewLine);
            }
        }

        public void decodeJson(string mimoFilePath)
        {
            printMessage("Reading Mimo Program...", writeLog: false);
            if (!File.Exists(mimoFilePath))
            {
                printMessage("[ERROR]: File does not exists.", "Error", writeLog: false);
                return;
            }
            try
            {
                string programText = File.ReadAllText(mimoFilePath);
                mimo_program = JsonConvert.DeserializeObject<MimoProgram>(programText);
            }
            catch (Exception ex)
            {
                printMessage("[EXCEPTION]: " + ex.Message, "Error", writeLog: false);
                return;
            }
        }

        private void initiateSAPGUI()
        {
            try
            {
                printMessage("Initiating SAP GUI... ");
                // TODO: Make this path dynamic so that it can be adjusted when the path is different
                // string sapshcutPath = @"C:\Program Files\SAP\FrontEnd\SAPGUI\sapshcut.exe";
                

                string connectionName = "S4D";

                printMessage($"Signing in with user: {username}");
                string arguments = $"-system={connectionName} -client={client} -user={username} -pw={password} -language=ES";

                Process.Start(new ProcessStartInfo
                {
                    FileName = sapshcutPath,
                    Arguments = arguments,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                printMessage("[EXCEPTION]: " + ex.Message, "Error");
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    SapGuiAuto = Interaction.GetObject("SAPGUI");
                    app = InvokeMethod(SapGuiAuto, "GetScriptingEngine");
                    Thread.Sleep(5000);
                    break;
                }
                catch
                {
                    Thread.Sleep(1000);
                    printMessage(".");
                }
            }

            if (SapGuiAuto == null)
            {
                printMessage("Could not found the SAP GUI instance.", "Error");
                return;
            }

            try
            {
                SetProperty(app, "HistoryEnabled", new object[1] { false });
                connection = GetProperty(app, "Children", new object[1] { connectionNumber });
                if (GetProperty(connection, "DisabledByServer") == true) { return; }
                session = GetProperty(connection, "Children", new object[1] { sessionNumber });
                object info = GetProperty(session, "Info");
                if (GetProperty(info, "IsLowSpeedConnection") == true) { return; }
            }
            catch (Exception ex)
            {
                printMessage("Could not found the connections to SAP GUI: " + ex, "Error");
            }
        }

        private void textInRow(Object session, string tableId, string valueToWrite, int column_id)
        {
            GuiTableControl tableObj = null;
            try
            {
                tableObj = InvokeMethod(session, "findById", new object[] { tableId });
                if (tableObj == null) throw new Exception($"No se encontró la tabla: {tableId}");
            }
            catch
            {
                printMessage($"[ERROR]: Table not found: {tableId}", "Error");
                return;
            }

            int rowCount = (int)tableObj.RowCount;
            int vRowCount = (int)tableObj.VisibleRowCount;

            int diff = 0;
            for (int i = 0; i < rowCount; i++)
            {
                GuiTableRow row;
                try
                {
                    row = tableObj.GetAbsoluteRow(i);
                }
                catch
                {
                    diff++;
                    continue;
                }
                try
                {
                    string value = tableObj.GetCell(i - diff, column_id).Text;
                    printMessage($"Value: {value}");
                    if (value == "")
                    {
                        printMessage($"Value To Write: {valueToWrite}");
                        tableObj.GetCell(i - diff, column_id).Text = valueToWrite;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    printMessage($"[EXCEPTION] getting Cell({i - diff}, {column_id}) " + ex, "Error");
                }
            }

        }

        private void getAbsoluteRow(Object session, string tableId, string valueToSearch)
        {
            GuiTableControl tableObj = null;
            try
            {
                tableObj = InvokeMethod(session, "findById", new object[] { tableId });
                if (tableObj == null) throw new Exception($"No se encontró la tabla: {tableId}");
            }
            catch
            {
                printMessage($"[ERROR]: Table not found: {tableId}", "Error");
                return;
            }

            int rowCount = (int)tableObj.RowCount;
            int vRowCount = (int)tableObj.VisibleRowCount;

            int diff = 0;
            for (int i = 0; i < rowCount; i++)
            {
                GuiTableRow row;
                try
                {
                    row = tableObj.GetAbsoluteRow(i);
                }
                catch
                {
                    diff++;
                    continue;
                }
                var columnsCount = row.Count;
                for (int j = 0; j < columnsCount; j++)
                {
                    string value = "";
                    try
                    {
                        value = tableObj.GetCell(i - diff, j).Text;
                    }
                    catch
                    {
                        continue;
                    }
                    if (value == valueToSearch)
                    {
                        row.Selected = true;
                    }
                }
            }

        }

        private bool runActivity(string action_id, string type_code, string value, string command_id, string table_id = "", string row_value = "", string column_id = "")
        {
            try
            {
                object control = null;
                switch (action_id.ToLower())
                {
                    case "#autoselectedtext":
                        int column = int.Parse(column_id);
                        textInRow(session, table_id, value, column);
                        break;
                    case "#selectrow":
                        getAbsoluteRow(session, table_id, row_value);
                        break;
                    case "text":
                        control = InvokeMethod(session, "findById", new object[] { command_id });
                        if (control != null)
                        {
                            SetProperty(control, "text", new object[] { value });
                        }
                        else
                        {
                            printMessage($"[ERROR]: Control not found: {command_id}", "Error");
                        }
                        break;

                    case "sendvkey":
                        if (int.TryParse(value, out int key))
                        {
                            object target = session;

                            if (!string.IsNullOrEmpty(command_id))
                            {
                                target = InvokeMethod(session, "findById", new object[] { command_id });
                            }
                            InvokeMethod(target, "SendVKey", new object[] { key });
                        }
                        else
                        {
                            printMessage($"[ERROR]: Invalid sendVKey value: {value}", "Error");
                        }
                        break;

                    case "press":
                        control = InvokeMethod(session, "findById", new object[] { command_id });
                        if (control != null)
                        {
                            InvokeMethod(control, "press", null);
                        }
                        else
                        {
                            printMessage($"[ERROR]: Control not found: {command_id}", "Error");
                        }
                        break;

                    case "selected":
                        control = InvokeMethod(session, "findById", new object[] { command_id });
                        if (control != null)
                        {
                            if (bool.TryParse(value, out bool selected))
                            {
                                SetProperty(control, "selected", new object[] { selected });
                            }
                            else
                            {
                                printMessage($"[ERROR]: Invalid selected value: {value}", "Error");
                            }
                        }
                        else
                        {
                            printMessage($"[ERROR]: Control not found: {command_id}", "Error");
                        }
                        break;

                    case "select":
                        control = InvokeMethod(session, "findById", new object[] { command_id });
                        if (control != null)
                        {
                            InvokeMethod(control, "select", null);
                        }
                        else
                        {
                            printMessage($"[ERROR]: Control not found: {command_id}", "Error");
                        }
                        break;


                    case "selectrow":
                        control = InvokeMethod(session, "findById", new object[] { command_id });
                        if (control != null)
                        {
                            object row = InvokeMethod(control, "getAbsoluteRow", new object[] { row_value });
                            if (row != null)
                            {
                                SetProperty(row, "selected", new object[] { value });
                            }
                            else
                            {
                                printMessage($"[ERROR]: Row not found in the table: {command_id}", "Error");
                                throw new Exception($"[ERROR]: Row not found in the table: {command_id}");
                            }
                        }
                        else
                        {
                            printMessage($"[ERROR]: Control not found: {command_id}", "Error");
                            throw new Exception($"[ERROR]: Control not found: {command_id}");
                        }
                        break;

                    default:
                        printMessage($"[WARN]: Unknown action: {action_id}", "Warning");
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                printMessage($"Activity: sesion.findById(\"{command_id}\").{action_id}", "Error");
                printMessage($"[EXCEPTION] procesing " + ex, "Error");
                return false;
            }
        }

        public bool runIntent(Intent intent, string instance_iid)
        {
            int intent_count = 0;
            try
            {
                foreach (Activity activity in intent.code)
                {
                    bool result = runActivity(activity.action_id, activity.type_code, activity.value, activity.command_id, activity.table_id, activity.row_value, activity.column_id);
                    if (!result)
                    {
                        return false;
                    }
                    intent_count++;
                }
                return true;
            }
            catch (COMException comEx)
            {
                printMessage($"[ERROR COM]: {comEx.Message}", "Error");
                int rollback_count = 0;
                foreach (Activity activity in intent.rollback)
                {
                    if (rollback_count == intent_count)
                    {
                        break;
                    }
                    runActivity(activity.action_id, activity.type_code, activity.value, activity.command_id);
                    rollback_count++;
                }
                logError.WriteLog($"Instance: {instance_iid}", "ERROR");
                return false;
            }
            catch (Exception ex)
            {
                logError.WriteLog($"Instance: {instance_iid}", "ERROR");
                printMessage($"[EXCEPTION] procesing " + ex, "Error");
                return false;
            }
        }

        public void interpret( )
        {
     
            logSuccess = new LogHelper(mimo_program.batch_iid, Path.Combine(Application.StartupPath, "Logs", $"B_{mimo_program.batch_id}"), "INFO");
            logError = new LogHelper(mimo_program.batch_iid, Path.Combine(Application.StartupPath, "Logs", $"B_{mimo_program.batch_id}"), "ERROR");
            initiateSAPGUI();


 
            if (mimo_program == null || session == null)
            {
                return;
            }

            printMessage($"Running Batch {mimo_program.batch_id}");

            if (mimo_program.blocks == null)
            {
                printMessage("[ERROR]: No blocks in this batch", "Error");
                return;
            }

            bool success = false;
            float progressSpan = 0;
            foreach (Block block in mimo_program.blocks)
            {
                printMessage($"Running Block {block.block_id}");
                int instructionsCount = block.instructions.Count;
                if (block.instructions == null)
                {
                    printMessage($"[ERROR]: No instructions in block: {block.block_id}", "Error");
                    return;
                }

                foreach (Instruction instruction in block.instructions)
                {
                    printMessage($"Running Instruction {instruction.instruction_id}");
                    int instancesCount = instruction.instances.Count;
                    if (instruction.instances == null)
                    {
                        printMessage($"[ERROR]: No instances in intruction: {instruction.instruction_id}", "Error");
                        return;
                    }

                    foreach (Instance instance in instruction.instances)
                    {
                        printMessage($"Running Instance {instance.instance_seq}");

                        if (instance.intents == null)
                        {
                            printMessage($"[ERROR]: No intents in instance: {instance.instance_seq}", "Error");
                            return;
                        }

                        int intentsCount = instance.intents.Count;
                        progressSpan = intentsCount * instancesCount * instructionsCount / 100;
                        foreach (Intent intent in instance.intents)
                        {
                            printMessage($"Running Intent {intent.intent_id}");
                            success = runIntent(intent, instance.instance_iid);
                            if (!success)
                            {
                                printMessage($"[ERROR]: error running intent {intent.intent_id}", "Error");
                                break;
                            }
                        }
                        if (!success)
                        {
                            break;
                        }
                        logSuccess.WriteLog($"Instance: {instance.instance_iid}", "SUCCESS");
                    }
                    if (!success)
                    {
                        break;
                    }
                }
                if (!success)
                {
                    break;
                }
            }

            printMessage("Mimo Program excecuted successfully", "Success", 2);
        }
    }
}
