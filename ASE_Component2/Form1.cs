using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Component2
{
    /// <summary>
    /// The main class of the program that inherits form the Form class.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creating a "factory" object of the class "ShapeFactory". 
        /// Here our needed variables are declared.
        /// </summary>        
        /// <param name="intX">It is the, current point - common for all the shapes</param>
        /// <param name="intY">It is the, current point - common for all the shapes</param>
        /// <param name="rightX">Used for third x coordinate for triangle</param>
        /// <param name="rightY">Used for third y coordinate for triangle</param>
        /// <param name="leftX">Used for second x coordinate for triangle</param>
        /// <param name="leftY">Used for second y coordinate for triangle</param>
        /// <param name="shapeWidth">Used for recatangle</param>
        /// <param name="shapeHeight">Used for Rectnangle</param>
        /// <param name="shapeRadius">Used for circle</param>

        ShapeFactory factory = new ShapeFactory();
        int intX = 0;        //Start Position X for all shape
        int intY = 0;        //Start Position Y for all shape
        int leftX = 0;        //Changed from midX
        int leftY = 0;        //Changed from midY
        int rightX = 0;     //Changed from finalX
        int rightY = 0;     //Changed from finalY
        int uptoX = 0;     // Added to distinguish end point of DrawTo line
        int uptoY = 0;     // Added to distinguish end point of DrawTo line
        int shapeWidth = 0;
        int shapeHeight = 0;
        int shapeRadius = 0;  //Added to distinguished radius 
        /// <summary>
        /// fillColor is an object created of the class Color.
        /// "gObj" is an object of Graphics class.
        /// </summary>
        /// <param name="penSize">Variable for width of the pen(border of shapes)</param>
        /// <param name="penColor">Variable to define the color of the pen. Assigned specific numbers to specific colors</param>
        /// <param name="fillOk">variable to fill the shape or not.</param>
        /// <param name="lineNo">Identifies the line array.Needed for executing the one command at a time.</param>
        Color fillColor = new Color();
        int penSize = 2;
        int penColor = 1;         //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
        int fillOk = 1;        //fillOk  1 = true, 2 = false

        int lineNo = 0;
        Graphics gObj;

        string[] myMethodArr;

        // Loads immediately after the form is opened.
        private void Form1_Load(object sender, EventArgs e)
        {
            gObj = Canvas.CreateGraphics(); //initialized
            LoadCommandList();              // Display command with syntax
            ResetAll();
        }

        #region Component 1 - button objects
        /// <summary>
        /// Method to list the commands to be dispalyed in txt_Cmd_List
        /// </summary>
        private void LoadCommandList()
        {
            string CmdList = "Basic drawing commands (all commands are case insensitive)";
            CmdList = CmdList + Environment.NewLine + "MoveTo <x>, <y>";
            CmdList = CmdList + Environment.NewLine + "DrawTo <x> <y>";
            CmdList = CmdList + Environment.NewLine + "Clear";
            CmdList = CmdList + Environment.NewLine + "Reset";
            CmdList = CmdList + Environment.NewLine + "";
            CmdList = CmdList + Environment.NewLine + "Draw basic shapes:";
            CmdList = CmdList + Environment.NewLine + "Rectangle  <width>, <height>";
            CmdList = CmdList + Environment.NewLine + "Circle <radius>";
            CmdList = CmdList + Environment.NewLine + "Triangle LeftX, LeftY, rightX, RightY";
            CmdList = CmdList + Environment.NewLine + "";
            CmdList = CmdList + Environment.NewLine + "Colours and fills";
            CmdList = CmdList + Environment.NewLine + "Pen  <colour>, <size>  e.g. pen red (Select either black or red or blue, or green or yellow ";
            CmdList = CmdList + Environment.NewLine + "FillShape <on/off>";
            CmdList = CmdList + Environment.NewLine + "FillColor <colour> e.g. pen red (Select either red or blue, or green or yellow";

            txt_Cmd_List.Text = CmdList;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
        }

        //------------------

        /// <summary>
        /// Click event for the button btn_Run.
        /// To execute command one line at a time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Run_Click(object sender, EventArgs e)
        {
            RunCommand(false);  //RunAllComands = false
        }
        /// <summary>
        ///  Click event for the button btn_Execute.
        ///  Executes the entire code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Execute_Click(object sender, EventArgs e)
        {
            //execute command from the first line
            if (lineNo > 0)
            {
                lineNo = 0;
                btn_Run.Text = "Run";
            }
            RunCommand(true);
            //reset line number to initial position
            // lineNo = 0;
        }
        /// <summary>
        /// Click event for the Clear canvas button.
        /// clears the canvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearCanvase_Click(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }
        /// <summary>
        /// Click event for the Clear button.
        /// clears the comman box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Command.Text = "";
            txt_CurrentCommand.Text = "";
        }
        /// <summary>
        /// Clcik event to for the button btn_LoadFile.
        /// Loads a txt file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TXT(*.TXT) | *.txt";

            if (of.ShowDialog() == DialogResult.OK)
            {
                string s = File.ReadAllText(of.FileName);
                txt_Command.Text = s;
            }
        }
        /// <summary>
        /// Click event to for the button btn_SaveFile.
        /// Saves the commands in txt file.
        /// </summary>
        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "TXT(*.TXT) | *.txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sf.FileName, txt_Command.Text);
            }
        }
        #endregion

        //------------------

        /// <summary>
        /// Method to run the command entered.
        /// Reads and Executes the command written in the command box either one line at a time or the whole code..
        /// It identifies the command and executes it.
        /// </summary>
        /// <param name="RunAllCommand">Boolean to run the command one line ata time or the entire code.</param>
        /// <param name="lines">array of strings to that holds the line of code</param>
        /// <param name="runCmd">Array that holds the command and oparameter of each line.</param>
        /// <param name="numLines">Reads the length of the array lines</param>
        /// <param name="numParams">Reads the lenght of the array runCmd</param>
        private void RunCommand(bool RunAllCommand)
        {
            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int numLines = lines.Length;

            //Check whether all command had been executed
            if (!RunAllCommand && lineNo == 0)
            {
                btn_Run.Text = "Next";
            }

            for (int i = lineNo; i < numLines; i++)
            {
                string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int numParams = runCmd.Length;

                if (runCmd[0].ToUpper().Trim() == "MOVETO") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "DRAWTO") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "CLEAR") { Canvas.Refresh(); }
                else if (runCmd[0].ToUpper().Trim() == "RESET") { ResetAll(); }
                else if (runCmd[0].ToUpper().Trim() == "CIRCLE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "RECTANGLE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "TRIANGLE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "PEN") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "FILLSHAPE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "FILLCOLOR") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "INCREASE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "DECREASE") { if (!CommandExecuted(lines[i], i)) { break; }; }
                else if (runCmd[0].ToUpper().Trim() == "STARTMETHOD")         //Added for component 2
                {
                    bool methodNotEnded = true;
                    while (methodNotEnded)
                    {
                        i++;
                        runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (runCmd[0].ToUpper().Trim() == "ENDMETHOD") { break; }
                    }
                    lineNo = i;
                }
                else if (runCmd[0].ToUpper().Trim() == "CALLMETHOD")         //Added for component 2
                {
                    int CallFromLine = i;
                    //ExeMethodCalled(chkCmdLine, i);
                }
                else
                {
                    DisplayError("Command", lines[i], i);
                    break;
                }

                //exit after completing this command
                if (!RunAllCommand) { lineNo = DisplayRunline(i, lines[i]); break; } //*

            }
            if (lineNo >= numLines)
            {
                lineNo = 0;
                btn_Run.Text = "Run";
                txt_CurrentCommand.Text = "";
            }
        }

        #region Component 1 - simple methods and methods to draw Shape 
        /// <summary>
        /// displays the line the line the command is at.
        /// </summary>
        /// <param name="i">Identifies the index of the array line(line number)</param>
        /// <param name="str">Displays the object of the array(line command)</param>
        /// <returns>Returns the line number of the command</returns>
        private int DisplayRunline(int i, string str)
        {
            txt_CurrentCommand.Text = "Line " + (i + 1).ToString() + ":   " + str;
            return i + 1;
        }

        /// <summary>
        /// method to display error messages.
        /// </summary>
        /// <param name="errFrom">To identify if it was a command or parameter error.</param>
        /// <param name="str">Displays the object of the array "lines"</param>
        /// <param name="i">Displays line number</param>
        private void DisplayError(string errFrom, string str, int i)
        {
            //For Command Error - list[0] is LineNo
            string title, msg;

            if (errFrom == "Command")
            {
                title = "Command Error";
                msg = "The following line has a command error. Please go through the command list and correct the error ";
            }
            else
            {
                title = "Parameter Error";
                msg = "The following line has a Parameter error. Please go through the command list. Check for the number of the parameter, comma(,) or space and correct the error";
            }
            msg = msg + Environment.NewLine + Environment.NewLine + "Line " + (i + 1).ToString() + ":  " + str;
            MessageBox.Show(msg, title);

            txt_CurrentCommand.Text = "Line " + (i + 1).ToString() + ":   " + str;

        }

        /// <summary>
        /// Method to reset everything.
        /// </summary>
        private void ResetAll()
        {
            intX = 0;
            intY = 0;
            leftX = 0;
            leftY = 0;
            rightX = 0;
            rightY = 0;
            shapeWidth = 0;
            shapeHeight = 0;
            shapeRadius = 0;

            penColor = 1;
            penSize = 2;
            fillColor = Color.Green;
            fillOk = 1;
            lineNo = 0;

            lbl_CurrentPosition.Text = "Current Position (" + intX.ToString() + ", " + intY.ToString() + ")";
            txt_CurrentCommand.Text = "";
        }

        /// <summary>
        /// Method to draw circle. Called from circle class
        /// </summary>
        private void DrawCircle()
        {
            Shape s;
            s = factory.getShape("circle");
            s.set(fillColor, intX, intY, shapeRadius, penSize, penColor, fillOk);
            s.draw(gObj);
        }
        /// <summary>
        /// Method to draw rectangle. Called from rectangle class
        /// </summary>
        private void DrawRectangle()
        {
            Shape s;
            s = factory.getShape("rectangle");
            s.set(fillColor, intX, intY, shapeWidth, shapeHeight, penSize, penColor, fillOk);
            s.draw(gObj);
        }
        /// <summary>
        /// Method to draw triangle. Called from Triangle class
        /// </summary>
        private void DrawTriangle()
        {
            Shape s;
            s = factory.getShape("triangle");
            //changes made in leftX, leftY, rightX, rightY
            s.set(fillColor, intX, intY, leftX, leftY, rightX, rightY, penSize, penColor, fillOk);
            s.draw(gObj);
        }
        /// <summary>
        /// Method to draw line. Called from Line class
        /// </summary>
        private void DrawLine()
        {
            Shape s;
            s = factory.getShape("line");
            s.set(fillColor, intX, intY, uptoX, uptoY, penSize, penColor);
            s.draw(gObj);
        }
        #endregion


        #region Component 2

        //the following method is added to adjust the command to be called from within the myMethod.
        private bool CommandExecuted(string cmdLine, int lineNumb)
        {
            string[] runCmd = cmdLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numParams = runCmd.Length;
            int i = lineNumb;
            //bool isSuccess = true;
            if (runCmd[0].ToUpper().Trim() == "MOVETO")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                intX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                intY = Convert.ToInt32(runCmd[2].Trim());

                lbl_CurrentPosition.Text = "Current Position (" + runCmd[1] + " " + runCmd[2] + ")";
            }
            else if (runCmd[0].ToUpper().Trim() == "DRAWTO")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                uptoX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                uptoY = Convert.ToInt32(runCmd[2]);
                DrawLine();
            }
            else if (runCmd[0].ToUpper().Trim() == "CIRCLE")
            {
                //Check for numbers of parameter
                if (numParams != 2) { DisplayError("Parameter", cmdLine, i); return false; }

                shapeRadius = Convert.ToInt32(runCmd[1].Trim());
                DrawCircle();
            }
            else if (runCmd[0].ToUpper().Trim() == "RECTANGLE")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                shapeWidth = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                shapeHeight = Convert.ToInt32(runCmd[2].Trim());
                DrawRectangle();
            }
            else if (runCmd[0].ToUpper().Trim() == "TRIANGLE")
            {
                //Check for numbers of parameter
                if (numParams != 5) { DisplayError("Parameter", cmdLine, i); return false; }

                leftX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));          //Change from leftX
                leftY = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                rightX = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                rightY = Convert.ToInt32(runCmd[4].Trim());
                DrawTriangle();
            }
            else if (runCmd[0].ToUpper().Trim() == "PEN")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                penSize = Convert.ToInt32(runCmd[2].Trim());

                //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
                if (runCmd[1].ToUpper().Trim() == "BLUE") { penColor = 2; }
                else if (runCmd[1].ToUpper().Trim() == "GREEN") { penColor = 3; }
                else if (runCmd[1].ToUpper().Trim() == "RED") { penColor = 4; }
                else if (runCmd[1].ToUpper().Trim() == "YELLOW") { penColor = 5; }
                else { penColor = 1; }
            }
            else if (runCmd[0].ToUpper().Trim() == "FILLSHAPE")
            {
                //Check for numbers of parameter
                if (numParams != 2) { DisplayError("Parameter", cmdLine, i); return false; }

                //fillOk  1 = true, 2 = false
                if (runCmd[1].ToUpper().Trim() == "ON") { fillOk = 1; }
                else { fillOk = 2; }
            }
            else if (runCmd[0].ToUpper().Trim() == "FILLCOLOR")
            {
                //Check for numbers of parameter
                if (numParams != 2) { DisplayError("Parameter", cmdLine, i); return false; }

                if (runCmd[1].ToUpper().Trim() == "RED") { fillColor = Color.Red; }
                else if (runCmd[1].ToUpper().Trim() == "BLUE") { fillColor = Color.Blue; }
                else if (runCmd[1].ToUpper().Trim() == "GREEN") { fillColor = Color.Green; }
                else if (runCmd[1].ToUpper().Trim() == "YELLOW") { fillColor = Color.Yellow; }
                else { fillColor = Color.Gainsboro; }
            }
            else if (runCmd[0].ToUpper().Trim() == "INCREASE") { ChangeShapeSize(cmdLine, i); }
            else if (runCmd[0].ToUpper().Trim() == "DECREASE") { ChangeShapeSize(cmdLine, i); }
            else if (runCmd[0].ToUpper().Trim() == "ADD")
            {
                //ADD Radius Radius NumbToAdd  -> Result is Updated Radius
                //You Can Add Radius, Width,  Height, LeftX, LeftY, RightX, RightY, and (intX and intY which are the start position)
                //ADD varName Number ->

                //Check for numbers of parameter
                // if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }
                // CalcNewShapeSize(cmdLine, i);
            }
            else if (runCmd[0].ToUpper().Trim() == "DIVIDE")
            {
                //Divide radius NumOfRing DecreaseRadius
            }
            else if (runCmd[0].ToUpper().Trim() == "MINUS")
            {
            }
            else if (runCmd[0].ToUpper().Trim() == "MULTIPLY")
            {
            }
            else if (runCmd[0].ToUpper().Trim() == "new")
            {
            }
            else if (runCmd[0].ToUpper().Trim() == "new")
            {
            }
            else if (runCmd[0].ToUpper().Trim() == "new")
            {
            }
            else if (runCmd[0].ToUpper().Trim() == "new")
            {
            }
            else
            {
                DisplayError("Command", cmdLine, i);
                //break;
            }
            return true;
        }

        private void ChangeShapeSize(string cmdLine, int lineNum)
        {
            string[] runCmd = cmdLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numParams = runCmd.Length;
            int i = lineNum;

            string vAction = runCmd[0].ToUpper().Trim();
            string vName = runCmd[1].ToUpper().Trim();

            //Increase Circle Radius

            if (vName == "CIRCLE")
            {
                ////need to add error check
                ////Check for numbers of parameter
                //if (numParams != 2) { DisplayError("Parameter", cmdLine, i); return false; }

                int iNum = Convert.ToInt32(runCmd[2].Trim());
                if (vAction == "INCREASE") { shapeRadius += iNum; }
                else if (vAction == "DECREASE") { shapeRadius -= iNum; }
                else { /*display error*/}
                DrawCircle();
            }
            else if (vName == "RECTANGLE")
            {
                //Rectangle  <width>, <height>
                // INCREASE rectangle 24, 24
                //                uptoX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));

                int iWdth = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                int iHght = Convert.ToInt32(runCmd[3].Trim());

                if (vAction == "INCREASE")
                {
                    shapeWidth += iWdth;
                    shapeHeight += iHght;
                }
                else if (vAction == "DECREASE")
                {
                    shapeWidth -= iWdth;
                    shapeHeight -= iHght;
                }
                else { /*display error*/}
                DrawRectangle();
            }
            else if (vName == "TRIANGLE")
            {
                //Triangle LeftX, LeftY, RightX, RightY
                // INCREASE Triangle LeftX, LeftY, RightX, RightY

                int xLeft = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                int yLeft = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                int xRight = Convert.ToInt32(runCmd[4].Substring(0, runCmd[4].IndexOf(",")));
                int yRight = Convert.ToInt32(runCmd[5].Trim());


                if (vAction == "INCREASE")
                {
                    leftX += xLeft;
                    leftY += yLeft;
                    rightX += xRight;
                    rightY += yRight;
                }
                else if (vAction == "DECREASE")
                {
                    leftX += xLeft;
                    leftY += yLeft;
                    rightX += xRight;
                    rightY += yRight;
                }
                else { /*display error*/}
                DrawTriangle();
            }
            else if (vName == "DRAWTO")
            {
                //DrawTo <uptoX> <upToY>
                //Increase DrawTo uptoX upToY

                int xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                int yUpto = Convert.ToInt32(runCmd[3].Trim());

                if (vAction == "INCREASE")
                {
                    uptoX += xUpto;
                    uptoY += yUpto;
                }
                else if (vAction == "DECREASE")
                {
                    uptoX -= xUpto;
                    uptoY -= yUpto;
                }
                else { /*display error*/}
                DrawLine();
            }
            else if (vName == "MOVETO")
            {
                //DrawTo <uptoX> <upToY>
                //Increase DrawTo uptoX upToY

                int xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                int yUpto = Convert.ToInt32(runCmd[3].Trim());

                if (vAction == "INCREASE")
                {
                    intX += xUpto;
                    intY += yUpto;
                }
                else if (vAction == "DECREASE")
                {
                    intX -= xUpto;
                    intY -= yUpto;
                }
                else { /*display error*/}
                lbl_CurrentPosition.Text = "Current Position (" + intX + " " + intY + ")";
            }
        }

        private void ExeMethodCalled(string[] lines, int CalledFromLineNo)
        {
            //string chkCmdLine = txt_Command.Text;
            //string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int numLines = lines.Length;
            int i = CalledFromLineNo;
            //
            string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numParams = runCmd.Length;
            if (runCmd[0].ToUpper().Trim() != "CALLMETHOD") { /*state error*/ return; }
            string methodName = runCmd[1].ToUpper().Trim();

            //Increase Circle Radius

            //if (vName == "CIRCLE")
            //{
            //    ////need to add error check
            //    ////Check for numbers of parameter
            //    //if (numParams != 2) { DisplayError("Parameter", cmdLine, i); return false; }

            //    int iNum = Convert.ToInt32(runCmd[2].Trim());
            //    if (vAction == "INCREASE") { shapeRadius += iNum; }
            //    else if (vAction == "DECREASE") { shapeRadius -= iNum; }
            //    else { /*display error*/}
            //    DrawCircle();

        }




        //private void CalcNewShapeSize(string cmdLine, int lineNum)
        //{
        //    //ADD Radius Radius NumbToAdd  -> Result is Updated Radius
        //    //You Can Add Radius, Width,  Height, LeftX, LeftY, RightX, RightY, and (intX and intY which are the start position)
        //    //ADD varName Number ->

        //    string[] runCmd = cmdLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //    int numParams = runCmd.Length;
        //    int i = lineNum;

        //    string vAction = runCmd[0].ToUpper().Trim();
        //    string vName = runCmd[1].Substring(0, runCmd[1].IndexOf(","));
        //    int iNum = Convert.ToInt32(runCmd[4].Trim());

        //    if (vName == "RADIUS")  { if (vAction == "ADD") { shapeRadius += iNum; }}
        //    if (vName == "RADIUS")  { if (vAction == "MINUS") { shapeRadius -=  iNum; }}
        //    if (vName == "WIDTH")  { if (vAction == "ADD") { shapeWidth += iNum; }}
        //    if (vName == "WIDTH")  { if (vAction == "MINUS") { shapeWidth -=  iNum; }}
        //    if (vName == "HEIGHT")  { if (vAction == "ADD") { shapeHeight += iNum; }}
        //    if (vName == "HEIGHT")  { if (vAction == "MINUS") { shapeHeight -=  iNum; }}

        //    if (vName == "UPTOX")  { if (vAction == "ADD") { uptoX += iNum; }}
        //    if (vName == "UPTOX")  { if (vAction == "MINUS") { uptoX -=  iNum; }}
        //    if (vName == "UPTOY")  { if (vAction == "ADD") { uptoY += iNum; }}
        //    if (vName == "UPTOY")  { if (vAction == "MINUS") { uptoY -=  iNum; }}

        //    if (vName == "STARTX")  { if (vAction == "ADD") { intX += iNum; }}
        //    if (vName == "STARTX")  { if (vAction == "MINUS") { intX -=  iNum; }}
        //    if (vName == "STARTY")  { if (vAction == "ADD") { intY += iNum; }}
        //    if (vName == "STARTY")  { if (vAction == "MINUS") { intY -=  iNum; }}

        //    if (vName == "LEFTX")  { if (vAction == "ADD") { leftX += iNum; }}
        //    if (vName == "LEFTX")  { if (vAction == "MINUS") { leftX -=  iNum; }}
        //    if (vName == "LEFTY")  { if (vAction == "ADD") { leftY += iNum; }}
        //    if (vName == "LEFTY")  { if (vAction == "MINUS") { leftY -=  iNum; }}

        //    if (vName == "RIGHTX")  { if (vAction == "ADD") { rightX += iNum; }}
        //    if (vName == "RIGHTX")  { if (vAction == "MINUS") { rightX -=  iNum; }}
        //    if (vName == "RIGHTY")  { if (vAction == "ADD") { rightY += iNum; }}
        //    if (vName == "RIGHTY")  { if (vAction == "MINUS") { rightY -=  iNum; }}


        //}


        //




        private int makeMyMethod(string[] lines, int lineNo)
        {
            int i = lineNo;
            int numLines = lines.Length;
            if (lines[lineNo].ToUpper().Trim() != "METHOD") { return i; }    //return if the first line is not the Start of the method.


            //if (runCmd[0].ToUpper().Trim() == "MOVETO")
            //{
            //    //Check for numbers of parameter
            //    if (numParams != 3) { DisplayError("Parameter", lines[i], i); break; }

            //    intX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
            //    intY = Convert.ToInt32(runCmd[2].Trim());

            //    lbl_CurrentPosition.Text = "Current Position (" + runCmd[1] + " " + runCmd[2] + ")";
            //}
            return i;
        }


        private void CallMyMethod()
        {

        }



    }
    #endregion
}
