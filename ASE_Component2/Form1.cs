﻿using System;
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
        /// <param name="circleParamExist">Used for start method to check if circle has been used as a param or not</param>
        /// <param name="rectangleParamExist">Used for start method to check if rectangle has been used as a param or not</param>
        /// <param name="triangleParamExist">Used for start method to check if triangle has been used as a param or not</param>
        /// <param name="lineParamExist">Used for start method to check if line has been used as a param or not</param>

        ShapeFactory factory = new ShapeFactory();
        int intX = 0;        
        int intY = 0;        
        int leftX = 0;       
        int leftY = 0;       
        int rightX = 0;     
        int rightY = 0;     
        int uptoX = 0;     
        int uptoY = 0;     
        int shapeWidth = 0;
        int shapeHeight = 0;
        int shapeRadius = 0;   
        bool circleParamExist = false;     
        bool rectangleParamExist = false;  
        bool triangleParamExist = false;   
        bool lineParamExist = false;

        /// <summary>
        /// fillColor is an object created of the class Color.
        /// "gObj" is an object of Graphics class.
        /// </summary>
        /// <param name="penSize">Variable for width of the pen(border of shapes)</param>
        /// <param name="penColor">Variable to define the color of the pen. Assigned specific numbers to specific colors</param>
        /// <param name="fillOk">variable to fill the shape or not.</param>
        /// <param name="lineNo">Identifies the line array.Needed for executing the one command at a time.</param>
        /// <param name="RunAllCommand">Boolean to run the command one line at a time or the entire code.</param>
        /// <param name="mStart">Variable for Line Number where the method starts</param>
        /// <param name="mEnd">Variable for Line Number where the method ends</param>
        /// <param name="NumRepeat">Variable to be used in case of loop</param>
        /// <param name="arrCommand">Array to check Command Syntax  before the program is run</param>
        /// <param name="arrParams">Array to allows variables to be used in loop and as parameters to draw commands</param>
        Color fillColor = new Color();
        int penSize = 2;
        int penColor = 1;         //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
        int fillOk = 1;        //fillOk  1 = true, 2 = false

        int lineNo = 0;
        bool RunAllCommand = false;
        Graphics gObj;

        //string[] myMethodArr;
        int mStart, mEnd;         
        int NumRepeat = 0;     
        
        string[,] arrCommand = new string[21, 2] { { "Clear", "1" },
                                                                            { "Reset", "1" },
                                                                            { "MoveTo", "3" },
                                                                            { "DrawTo", "3" },
                                                                            { "Circle", "2" },
                                                                            { "Triangle", "5" },
                                                                            { "Rectangle", "3" },
                                                                            { "Pen", "3" },
                                                                            { "FillColor", "2" },
                                                                            { "FillShape", "2" },
                                                                            { "StartMethod", "2" },
                                                                            { "EndMethod", "1" },
                                                                            { "CallMethod", "2" },
                                                                            { "Loop", "4" },
                                                                            { "EndLoop", "1" },
                                                                            { "Increase", "2" },
                                                                            { "Decrease", "2" },
                                                                            { "NextPenColor", "1" },
                                                                            { "NextFillColor", "1" },
                                                                            { "IF", "4" },
                                                                            { "ENDIF", "1" },
        };

        string[] arrParams = { "intX", "intY", "leftX", "leftY", "rightX", "rightY", "uptoX", "uptoY", "Width", "Height",
                                            "Radius", "fillColor", "penColor", "penSize", "fillShape", "numRepeat" };

        // Loads immediately after the form is opened.
        private void Form1_Load(object sender, EventArgs e)
        {
            gObj = Canvas.CreateGraphics(); //initialized
            LoadCommandList("Command");              // Displays command with syntax
            ResetAll();
        }

        #region Component 1 - button objects
        /// <summary>
        ///  Method to list the commands to be dispalyed in txt_Cmd_List
        /// </summary>
       /// <param name="displayInTextBox">Tells the method which string variable is to be displayed in the text box.</param>

        private void LoadCommandList(string displayInTextBox)
        {
            string dispL = "";
            string dispTitle = "Command List with Syntax";

            if (displayInTextBox == "Command")
            {
                dispL = "BASIC COMMAND (all commands are case insensitive)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Clear                            (Clears the canvas)";
                dispL += Environment.NewLine + "Reset                           (reset all the variable to default value)";
                dispL += Environment.NewLine + "MoveTo <x>, <y>      (Moves the start position to this point)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Draw basic shapes:";
                dispL += Environment.NewLine + "DrawTo <x> <y>      (Draw line to this point from the Start Position)";
                dispL += Environment.NewLine + "Circle <radius>          (Draw Circle)";
                dispL += Environment.NewLine + "Rectangle  <width>, <height>          (Draw Rectangle)";
                dispL += Environment.NewLine + "Triangle <LeftX>, <LeftY>, <rightX>, <RightY>  (Draw Triangle with Start, Left & Right point)";
                dispL += Environment.NewLine + "Increase <Shape Name with Shape Parametes>  (Increases the size by the Number Enter)";
                dispL += Environment.NewLine + "Decrease <Shape Name with Shape Parametes>  (Decrease the size by the Number Enter)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Colours and fills";
                dispL += Environment.NewLine + "FillColor <colour> e.g. pen red  - Color-> Red, Blue, Green, Yellow";
                dispL += Environment.NewLine + "FillShape <on/off>       (fill the Shape with the Fill Color)";
                dispL += Environment.NewLine + "Pen  <colour>, <size>  (e.g. pen red 4 - Color-> Black, Red, Blue, Green, Yellow)";
                dispL += Environment.NewLine + "NextPenColor       (Changes the Pen Color )";
                dispL += Environment.NewLine + "NextFillColor        (Changes the Fill Color)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "StartMethod <MethodName><parameter1>, <parameter 2>, .......";
                dispL += Environment.NewLine + "EndMethod        (Every StartMethod must have EndMethod)";
                dispL += Environment.NewLine + " CallMethod <Method Name>        (Needed to call Method)";
                dispL += Environment.NewLine + "(StarMethod can have none, one or many parameters But parameter name must be one of the name listed in Parameter List)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Loop <start No>, <End No>, <Increment No>      (eg Loop 1, 5, 1)";
                dispL += Environment.NewLine + "EndLoop                     (Every Loop must have EndLoop)";
                dispL += Environment.NewLine + "(Loop command can be used with or without parameter. For the missing parameter, it will use the default value which are 1, 1, & 1. Loop can also be used inside the Method)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "IF <Parameter> <Comparision Symbol> <integer/Var>";
                dispL += Environment.NewLine + "Endif       (IF command must have EndIF)";
                dispL += Environment.NewLine + "(Parameter must be one of the name listed in Parameter List. ";
                dispL += Environment.NewLine + "Comparision symbols are =, ==, !=, >, <. Values of all parameters are integer.";
                dispL += Environment.NewLine + "Except for parameter fillColor and penColor is the name of the Color and for fillShape is <on/off> )";
                dispTitle = "Command List with Syntax";
            }
            else if (displayInTextBox == "Parameter")
            {
                dispL = "List of Parameter and/or Variable Name (all commands are case insensitive)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "intX, intY, leftX, leftY, rightX, rightY, uptoX, uptoY, Width, Height, Radius, penSize, fillColor, penColor, fillShape";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "intX, intY";
                dispL += Environment.NewLine + "(These are the initial or current or start position of the point in the canvas.";
                dispL += Environment.NewLine + "It is used with MoveTo command. e.g. MoveTo <intX>, <intY> and with Increase MoveTo <intX>, <intY>";
                dispL += Environment.NewLine + "These parameter name can be used in StartMethod or IF command )";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "leftX, leftY, rightX, rightY ";
                dispL += Environment.NewLine + "These are the parameter of triangle. Start point being the first corner. Left and Right being the second and third corner";
                dispL += Environment.NewLine + "These can be used as the parameter name in StartMethod and IF statement";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "uptoX, uptoY";
                dispL += Environment.NewLine + "These are the parameters used with DrawTo. It draw a line from start point upto this point";
                dispL += Environment.NewLine + "These can be used as the parameter name in StartMethod and IF statement";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Width, Height";
                dispL += Environment.NewLine + "These are the parameters used with Rectangle. Rectangle is drawn from the start point having these width and Height";
                dispL += Environment.NewLine + "These can be used as the parameter name in StartMethod and IF statement";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Radius";
                dispL += Environment.NewLine + "This parameter is used in drawing a circle having this radius . The center of the radius is at intX+radius, intY+radius from start point";
                dispL += Environment.NewLine + "These can be used as the parameter name in StartMethod and IF statement";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "fillColor, penColor, penSize, fillShape";
                dispL += Environment.NewLine + "These can be used as the parameter name in StartMethod and IF statement";
                dispL += Environment.NewLine + "___________________________________________________";
                dispTitle = "List of parameters";
            }
            else if (displayInTextBox == "Bulls Eye")
            {
                dispL = "Example Bull's Eye (Method & Loop Test)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Clear";
                dispL += Environment.NewLine + "reset";
                dispL += Environment.NewLine + "moveto 70, 20";
                dispL += Environment.NewLine + "pen red 10";
                dispL += Environment.NewLine + "fillshape on";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "StartMethod myCircle radius";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "Loop 1 4 1";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "If Radius > 50";
                dispL += Environment.NewLine + "decrease circle 50";
                dispL += Environment.NewLine + "increase moveto 50, 50";
                dispL += Environment.NewLine + "EndIF";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "nextPenColor";
                dispL += Environment.NewLine + "nextfillcolor";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "EndLoop";
                dispL += Environment.NewLine + "EndMethod";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "callMethod myCircle 225";

                dispTitle = "Example -> Bull's Eye";
            }
            else if (displayInTextBox == "Christmas Tree")
            {
                dispL = "Example Christmas Tree (Simple Test)";
                dispL += Environment.NewLine + "___________________________________________________";
                dispL += Environment.NewLine + "Clear";
                dispL += Environment.NewLine + "reset";
                dispL += Environment.NewLine + "fillcolor Green";
                dispL += Environment.NewLine + "pen Green 2";
                dispL += Environment.NewLine + "fillshape on";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "moveto 200, 10";
                dispL += Environment.NewLine + "triangle 150, 75, 250, 75";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "moveto 200, 50";
                dispL += Environment.NewLine + "increase triangle -25, 75, 25, 75";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "moveto 200, 100";
                dispL += Environment.NewLine + "increase triangle -25, 75, 25, 75";
                dispL += Environment.NewLine + "";
                dispL += Environment.NewLine + "fillcolor yellow";
                dispL += Environment.NewLine + "moveto 190, 225";
                dispL += Environment.NewLine + "Rectangle 20, 100";

                dispTitle = "Example Christmas Tree";
            }
            lbl_TitleCmd_List.Text = dispTitle;
            txt_Cmd_List.Text = dispL;
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
            RunAllCommand = false;  //Allow only one command to be executed at a time
            RunCommand();
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

            CheckCommandExist();   //Check all the Syntax of the command before executing
            RunAllCommand = true;
            RunCommand();
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
        //Added to check whether the commands are written with the Correct Syntax
        /// <summary>
        /// Click event for check code button.
        /// Checks the entire code and displays the errors if any.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChkCode_Click(object sender, EventArgs e)
        {

            if (txt_Command.Text.Trim().Length > 0)  //Command has been Typed
            {
                if (CheckCommandExist())
                {
                    string msg = "Syntax Checked and is found to be OK";
                    DisplayError("Command Check", msg, -1);
                }
            }
            else
            {
                string msg = "Please Enter Your Command Before Checking the Syntax";
                DisplayError("Command Check", msg, -1);
            }

        }
        /// <summary>
        /// Clcik event to for the button btn_LoadFile.
        /// Loads a txt file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// Open or Load the existing Text file in the text box
        /// </summary>
        private void LoadFile()
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
            SaveFile();
        }

        /// <summary>
        /// Save the Contents of text box into a new text file
        /// </summary>
        private void SaveFile()
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
        /// All the command runs through here. Also try catch is used.
        /// Includes code for method, loop and if.
        /// </summary>
        /// <param name="chkCmdLine">String variable to store code written in textbox.</param>
        /// <param name="lines">array of strings to that holds the line of code</param>
        /// <param name="runCmd">Array that holds the command and parameter of each line.</param>
        /// <param name="numLines">Reads the length of the array lines</param>
        /// <param name="numParams">Reads the lenght of the array runCmd</param>
        private void RunCommand()
        {
            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int numLines = lines.Length;

            //Check whether all command had been executed
            if (!RunAllCommand && lineNo == 0)
            {
                btn_Run.Text = "Next";
            }
            try
            {
                for (int i = lineNo; i < numLines; i++)
                {
                    string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    int numParams = runCmd.Length;

                    //The following code is updated to avoid the unnecessary duplication so that the same method can be from inside
                    //Method, loop and if conditions.
                    if (runCmd[0].ToUpper().Trim() == "STARTMETHOD")         
                    {
                        i = GetEndLineNo("ENDMETHOD", i);
                    }
                    else if (runCmd[0].ToUpper().Trim() == "CALLMETHOD")         
                    {
                        int CallFromLine = i;
                        ExeMethodCalled(lines, i);
                        i = CallFromLine;
                    }
                    else if (runCmd[0].ToUpper().Trim() == "LOOP")         
                    {
                        //This loop is being called from normal command line. It may also be called from Method
                        i = RunLoop(i, false);
                    }
                    else if (runCmd[0].ToUpper().Trim() == "IF")         
                    {
                        //This loop is being called from normal command line. It may also be called from Method
                        i = RunIF(i);
                    }
                    else
                    {
                        if (!CommandExecuted(lines[i], i))
                        {
                            break;
                        }
                    }

                    //exit after completing this command
                    if (!RunAllCommand) { lineNo = DisplayRunline(i, lines[i]); break; } //*
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Exception catch here - details  : " + ex.ToString());
            }
            finally
            {
                if (lineNo >= numLines)
                {
                    lineNo = 0;
                    btn_Run.Text = "Run";
                    txt_CurrentCommand.Text = "";
                }
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
            //Check whether Message needs to be Displayed in the Current command Text
            if (i + 1 == 0) { return 0; }
            txt_CurrentCommand.Text = "Line " + (i + 1).ToString() + ":   " + str;
            return i + 1;
        }

        /// <summary>
        /// method to display error messages.
        /// </summary>
        /// <param name="errFrom">To identify what type of error it was.</param>
        /// <param name="str">Displays the object of the array "lines"</param>
        /// <param name="i">Displays line number</param>
        private void DisplayError(string errFrom, string str, int i)
        {
            //For Command Error - list[0] is LineNo
            string title = errFrom, msg = "";

            if (errFrom == "Command")
            {
                title = "Command Error";
                if (i > 0)
                {
                    msg = "The following line has a command error. Please go through the command list and correct the error ";
                }
            }
            else if (errFrom == "Parameter")
            {
                title = "Parameter Error";
                if (i > 0)
                {
                    msg = "The following line has a Parameter error. Please go through the command list. Check for the number of the parameter, comma(,) or space and correct the error";
                }
            }
            //Check whether line Number Needs to be mentioned
            if (i + 1 == 0)
            {
                msg = msg + str;
            }
            else
            {
                msg = msg + Environment.NewLine + Environment.NewLine + "Line " + (i + 1).ToString() + ":  " + str;
            }
            MessageBox.Show(msg, title);
            if (i + 1 == 0) { return; }
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

            mStart = mEnd = NumRepeat = 0;
            circleParamExist = false;
            rectangleParamExist = false;
            triangleParamExist = false;
            lineParamExist = false;
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
        /// <summary>
        /// Method that executes various command or call other methods to complete the command
        /// This method is seperated from the run command as an independent method which can be called from RunCommand method, ExeMethodCall, RunLoop and RunIf to minimize the dupication of the code.
        /// </summary>
        /// <param name="cmdLine">passes the command line to be executed.</param>
        /// <param name="lineNumb">Identifies the line number of the command line.</param>
        /// <returns>Returns true value</returns>

        private bool CommandExecuted(string cmdLine, int lineNumb)
        {
            string[] runCmd = cmdLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numParams = runCmd.Length;
            int i = lineNumb;

            //Check whether the command syntax is correct i.e. command and required number of parament

            //bool isSuccess = true;
            if (runCmd[0].ToUpper().Trim() == "MOVETO")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                if (runCmd[1].Contains(","))
                {
                    intX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                }
                else { intX = Convert.ToInt32(runCmd[1]); }

                intY = Convert.ToInt32(runCmd[2].Trim());
                lbl_CurrentPosition.Text = "Current Position (" + runCmd[1] + " " + runCmd[2] + ")";
            }
            else if (runCmd[0].ToUpper().Trim() == "DRAWTO")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }

                if (runCmd[1].Contains(","))
                {
                    uptoX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                }
                else { uptoX = Convert.ToInt32(runCmd[1]); }
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

                if (runCmd[1].Contains(","))
                {
                    shapeWidth = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                }
                else { shapeWidth = Convert.ToInt32(runCmd[1]); }

                shapeHeight = Convert.ToInt32(runCmd[2].Trim());
                DrawRectangle();
            }
            else if (runCmd[0].ToUpper().Trim() == "TRIANGLE")
            {
                //Check for numbers of parameter
                if (numParams != 5) { DisplayError("Parameter", cmdLine, i); return false; }

                if (runCmd[1].Contains(","))
                {
                    leftX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                }
                else { leftX = Convert.ToInt32(runCmd[1]); }
                if (runCmd[2].Contains(","))
                {
                    leftY = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else { leftY = Convert.ToInt32(runCmd[2]); }
                if (runCmd[3].Contains(","))
                {
                    rightX = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                }
                else { rightX = Convert.ToInt32(runCmd[3]); }

                //leftX = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));          //Change from leftX
                //leftY = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                //rightX = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                rightY = Convert.ToInt32(runCmd[4].Trim());
                DrawTriangle();
            }
            else if (runCmd[0].ToUpper().Trim() == "PEN")
            {
                //Check for numbers of parameter
                if (numParams != 3) { DisplayError("Parameter", cmdLine, i); return false; }
                string penColr = runCmd[1].ToUpper().Trim();
                if (penColr.Contains(","))
                {
                    penColr = penColr.Substring(0, penColr.IndexOf(","));
                }
                PenColorToNum(penColr);
                penSize = Convert.ToInt32(runCmd[2].Trim());
            }
            else if (runCmd[0].ToUpper().Trim() == "NEXTPENCOLOR")
            {
                NextPenColor();
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

                //if (runCmd[1].ToUpper().Trim() == "RED") { fillColor = Color.Red; }
                //else if (runCmd[1].ToUpper().Trim() == "BLUE") { fillColor = Color.Blue; }
                //else if (runCmd[1].ToUpper().Trim() == "GREEN") { fillColor = Color.Green; }
                //else if (runCmd[1].ToUpper().Trim() == "YELLOW") { fillColor = Color.Yellow; }
                //else { fillColor = Color.Gainsboro; }
                FillColorToVar(runCmd[1]);
            }
            else if (runCmd[0].ToUpper().Trim() == "NEXTFILLCOLOR")
            {
                NextFillColor();
            }
            else if (runCmd[0].ToUpper().Trim() == "INCREASE") { ChangeShapeSize(cmdLine, i); }
            else if (runCmd[0].ToUpper().Trim() == "DECREASE") { ChangeShapeSize(cmdLine, i); }
            else if (runCmd[0].ToUpper().Trim() == "CLEAR") { Canvas.Refresh(); }
            else if (runCmd[0].ToUpper().Trim() == "RESET") { ResetAll(); }
            else
            {
                DisplayError("Command", cmdLine, i);
                //break;
            }

            return true;
        }

        /// <summary>
        /// check Command and Command Syntax i.e. whether it contains the right number of parameters
        /// </summary>
        /// <returns>If command or parameters does not match returns false which will tell the calling method to terminate the process else true.</returns>

        private bool CheckCommandExist()
        {
            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int numLines = lines.Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int numParams = runCmd.Length;
                bool cmdNotFound = true;
                for (int j = 0; j < arrCommand.GetLength(0); j++)
                {
                    if (runCmd[0].ToUpper().Trim() == arrCommand[j, 0].ToUpper().Trim())
                    {
                        if (runCmd[0].ToUpper().Trim() == "STARTMETHOD" || runCmd[0].ToUpper().Trim() == "CALLMETHOD")
                        {
                            CheckParameter(i);
                        }
                        else if (runCmd[0].ToUpper().Trim() == "INCREASE" || runCmd[0].ToUpper().Trim() == "DECREASE")
                        {
                            CheckIncrease(i);
                        }

                        //int check = Convert.ToInt32(arrCommand[j, 1]);
                        else if (Convert.ToInt32(arrCommand[j, 1]) != numParams) // for drawto, circle etc ....
                        {
                            DisplayError("Parameter", lines[i], i);
                            return false;
                        }
                        cmdNotFound = false;
                        break;
                    }
                }
                if (cmdNotFound)
                {
                    DisplayError("Command", lines[i], i);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check the parameter names and properties in StartMethod & CallMethod
        /// </summary>
        /// <param name="lineNumb">Holds the line number of the command</param>
        /// <returns>If command or parameters does not match returns false which will tell the calling method to terminate the process else true.</returns>
        
        private bool CheckParameter(int lineNumb)
        {
            string chkCmdLine = txt_Command.Text;
            //Create string[] lines as an array of lines from the command text box
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int numLines = lines.Length;                        //total numbers of lines in the command box

            //Check whether the passed on line number is the StartMethod or Call Method.
            string[] methodChk = lines[lineNumb].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            //Find the Index of the Method Exist. 
            string methodName = methodChk[1].ToUpper().Trim();
            if (!FindMethodName(lines, methodName)) { DisplayError("Command", lines[lineNumb], lineNumb); return false; }

            //Check whether the program has been called from StartMethod line or CallMethod line
            bool isCalledFromStart = true;
            int lineCalledMethod = 0;
            if (lineNumb != mStart) { lineCalledMethod = lineNumb; isCalledFromStart = false; }

            //Check parameter names for their validity in StartMethod
            methodChk = lines[mStart].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numOfParam = methodChk.Length;
            if (numOfParam > 2)           //Only 2 elements in array means it does not contain any parameters
            {
                for (int i = 2; i < numOfParam; i++)
                {
                    string paramChk = methodChk[i].ToUpper().Trim();
                    bool paramsNotFound = true;
                    if (paramChk.Contains(","))
                    {
                        paramChk = paramChk.Substring(0, paramChk.IndexOf(","));
                    }
                    for (int j = 0; j < arrParams.Length; j++)
                    {
                        if (paramChk == arrParams[j].ToUpper().Trim())
                        {
                            paramsNotFound = false;
                            break;
                        }
                    }
                    if (paramsNotFound)
                    {
                        DisplayError("Command", lines[mStart], i);
                        return false;
                    }
                }

            }

            //if the line number is not CallMethod then find the line No for the callMethods
            if (isCalledFromStart)
            {
                bool noCallMethod = true;
                for (int i = 0; i < lines.Length; i++)
                {
                    //check the Command line
                    methodChk = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (methodChk[0].ToUpper().Trim() == "CALLMETHOD" && methodChk[1].ToUpper().Trim() == methodName)
                    {
                        lineCalledMethod = i;
                        noCallMethod = false;
                        break;
                    }
                }
                if (noCallMethod)
                {
                    string msg = "Call Method " + methodName + " does Not exist";
                    DisplayError("Command", msg, -1); return false;
                }
            }

            //check the length of the elements in CallMethod 
            methodChk = lines[lineCalledMethod].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (numOfParam != methodChk.Length) { DisplayError("Parameter", lines[lineNumb], lineNumb); return false; }

            return true;
        }

        /// <summary>
        /// Checks whether the parameters names or properties is correct.
        /// </summary>
        /// <param name="lineNumb">Holds the line number of the command</param>
        /// <returns>If command or parameters does not match returns false which will tell the calling method to terminate the process else true.</returns>
        private bool CheckIncrease(int lineNumb)
        {
            string chkCmdLine = txt_Command.Text;
            //Create string[] lines as an array of lines from the command text box
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //Check Increase or Decrease
            string[] increaseChk = lines[lineNumb].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string vName = increaseChk[1].ToUpper().Trim();
            int numParam = 0;
            if (vName == "CIRCLE") { numParam = 3; }
            else if (vName == "RECTANGLE") { numParam = 4; }
            else if (vName == "TRIANGLE") { numParam = 6; }
            else if (vName == "DRAWTO") { numParam = 4; }
            else if (vName == "MOVETO") { numParam = 4; }

            if (numParam != increaseChk.Length)
            {
                DisplayError("Command", lines[lineNumb], lineNumb);
                return false;
            }
            return true;
        }

        /// <summary>
        /// this method changes the string variable into the color variable for fill shape
        /// </summary>
        /// <param name="colorName">Holds the string value of the name of the color</param>
        private void FillColorToVar(string colorName)
        {
            if (colorName.ToUpper().Trim() == "RED") { fillColor = Color.Red; }
            else if (colorName.ToUpper().Trim() == "BLUE") { fillColor = Color.Blue; }
            else if (colorName.ToUpper().Trim() == "GREEN") { fillColor = Color.Green; }
            else if (colorName.ToUpper().Trim() == "YELLOW") { fillColor = Color.Yellow; }
            else { fillColor = Color.Gainsboro; }
        }

        /// <summary>
        /// this method changes the string variable into the proper integer value to be passed on into the shape class for pen
        /// </summary>
        /// <param name="ColorName">Holds the string value of the name of the color</param>
        private void PenColorToNum(string ColorName)
        {
            //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
            if (ColorName.ToUpper().Trim() == "BLUE") { penColor = 2; }
            else if (ColorName.ToUpper().Trim() == "GREEN") { penColor = 3; }
            else if (ColorName.ToUpper().Trim() == "RED") { penColor = 4; }
            else if (ColorName.ToUpper().Trim() == "YELLOW") { penColor = 5; }
            else { penColor = 1; }
        }

        /// <summary>
        /// This method changes the current fill color to the next fill color
        /// </summary>
        /// <returns>Returns the fill color</returns>
        private Color NextFillColor()
        {
            if (fillColor == Color.Blue) { fillColor = Color.Green; }
            else if (fillColor == Color.Green) { fillColor = Color.Red; }
            else if (fillColor == Color.Red) { fillColor = Color.Yellow; }
            else if (fillColor == Color.Yellow) { fillColor = Color.Blue; }
            else { fillColor = Color.Red; }
            return fillColor;
        }

        /// <summary>
        /// This method changes the current pen color to the next pen color
        /// </summary>
        /// <returns>Returns the fill color</returns>
        private int NextPenColor()
        {
            if (penColor < 5) { penColor++; }
            else { penColor = 1; }

            return penColor;
        }

        /// <summary>
        /// This method changes the shape and size of the object by increasing or decreasing it.
        /// </summary>
        /// <param name="cmdLine">passes the command line to be executed.</param>
        /// <param name="lineNum">Identifies the line number of the command line.</param>
        private void ChangeShapeSize(string cmdLine, int lineNum)
        {
            string[] runCmd = cmdLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int numParams = runCmd.Length;
            int i = lineNum;

            string vAction = runCmd[0].ToUpper().Trim();
            string vName = runCmd[1].ToUpper().Trim();

            if (vName == "CIRCLE")
            {
                int iNum = Convert.ToInt32(runCmd[2].Trim());
                if (vAction == "INCREASE") { shapeRadius += iNum; }
                else if (vAction == "DECREASE") { shapeRadius -= iNum; }
                DrawCircle();
            }
            else if (vName == "RECTANGLE")
            {
                int iWdth;
                if (runCmd[2].Contains(","))
                {
                    iWdth = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else { iWdth = Convert.ToInt32(runCmd[2]); }

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
                DrawRectangle();
            }
            else if (vName == "TRIANGLE")
            {
                int xLeft;
                int yLeft;
                int xRight;
                int yRight;
                if (runCmd[2].Contains(","))
                {
                    xLeft = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else { xLeft = Convert.ToInt32(runCmd[2]); }
                if (runCmd[3].Contains(","))
                {
                    yLeft = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                }
                else { yLeft = Convert.ToInt32(runCmd[3]); }
                if (runCmd[4].Contains(","))
                {
                    xRight = Convert.ToInt32(runCmd[4].Substring(0, runCmd[4].IndexOf(",")));
                }
                else { xRight = Convert.ToInt32(runCmd[4]); }

                yRight = Convert.ToInt32(runCmd[5].Trim());

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
                DrawTriangle();
            }
            else if (vName == "DRAWTO")
            {
                int xUpto;
                if (runCmd[2].Contains(","))
                {
                    xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else { xUpto = Convert.ToInt32(runCmd[2]); }

                //int xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
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
                DrawLine();
            }
            else if (vName == "MOVETO")
            {
                int xUpto;
                if (runCmd[2].Contains(","))
                {
                    xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else { xUpto = Convert.ToInt32(runCmd[2]); }
                //int xUpto = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
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
                lbl_CurrentPosition.Text = "Current Position (" + intX + " " + intY + ")";
            }
        }

        /// <summary>
        /// This method executes the commands within the start method.
        /// </summary>
        /// <param name="lines">It is the array of lines from the command text box</param>
        /// <param name="CalledFromLineNo">line no from which the method was called.</param>
        private void ExeMethodCalled(string[] lines, int CalledFromLineNo)
        {
            
            int numLines = lines.Length;                        
            int i = CalledFromLineNo;                           

            //Check whether the passed on line number is the Call Method.
            string[] methodCall = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //if (methodCall[0].ToUpper().Trim() != "CALLMETHOD") { /*state error*/ return; }
            int numParams = methodCall.Length;

            //Find the Index of the Method called
            string methodName = methodCall[1].ToUpper().Trim();
            if (!FindMethodName(lines, methodName))
            {
                string msg = methodName + " does Not Exist";
                DisplayError("Command", msg, -1);
                return;
            }

            //Compare whether the number of parameter matches between the startMethod and Called Method
            string[] methodStart = lines[mStart].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (methodStart.Length != numParams) { DisplayError("Parameter", lines[i], i); return; }

            //update variables as per the parameter assighed.
            UpdateVarAsPerParams(methodStart, methodCall);


            for (int j = mStart + 1; j < mEnd; j++)
            {
                //private bool CommandExecuted(string cmdLine, int lineNumb)
                string[] runCmd = lines[j].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (runCmd[0].ToUpper().Trim() == "CIRCLE" && circleParamExist)
                {
                    DrawCircle();
                }
                else if (runCmd[0].ToUpper().Trim() == "RECTANGLE" & rectangleParamExist)
                {
                    DrawRectangle();
                }
                else if (runCmd[0].ToUpper().Trim() == "TRIANGLE" & triangleParamExist)
                {
                    DrawTriangle();
                }
                else if (runCmd[0].ToUpper().Trim() == "DRAWTO" & lineParamExist)
                {
                    DrawLine();
                }
                else if (runCmd[0].ToUpper().Trim() == "LOOP")
                {
                    j = RunLoop(j, true);
                }
                else if (runCmd[0].ToUpper().Trim() == "IF")
                {
                    j = RunIF(j);
                }
                else
                {
                    if (!CommandExecuted(lines[j], j))
                    {
                        break;
                    }
                }

            }

        }

        /// <summary>
        /// This method updates the parameters given in the StartMethods with parameter value given in the CallMethods
        /// </summary>
        /// <param name="methodStart">Array that holds the parameter list provided in the StartMethod</param>
        /// <param name="methodCall">Array the holds the parameter value provided in the CallMethod</param>
        private void UpdateVarAsPerParams(string[] methodStart, string[] methodCall)
        {
            //           List of Variable Names to be Used in the parameter:
            //           intX,intY,leftX,leftY, rightX, rightY, uptoX, uptoY, Width, Height, Radius
            //           fillColor, penColor, penSize, fillShape
            //           Number of time for loop to repeat:
            //           NumRepeat

            int numParams = methodCall.Length;
            if (methodStart.Length != numParams) 
            {
                string msg = "Numbers of element in StartMethod and Callmethod does not Match";
                DisplayError("Method Error", msg, -1); 
                return ;  
            }

            if (numParams == 2) { return; }              //This method does not have any parameter

            //Check if the parameter consist the component of shape
            circleParamExist = false;
            rectangleParamExist = false;
            triangleParamExist = false;
            lineParamExist = false;

            for (int i = 2; i < numParams; i++)
            {
                if (methodStart[i].ToUpper().Trim() == "INTX" || methodStart[i].ToUpper().Trim() == "INTX,")
                {
                    if (methodStart[i].Contains(","))
                    {
                        intX = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        intX = Convert.ToInt32(methodCall[i].Trim());
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "INTY" || methodStart[i].ToUpper().Trim() == "INTY,")
                {
                    if (methodStart[i].Contains(","))
                    {
                        intY = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        intY = Convert.ToInt32(methodCall[i].Trim());
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "LEFTX" || methodStart[i].ToUpper().Trim() == "LEFTX,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        leftX = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        leftX = Convert.ToInt32(methodCall[i].Trim());
                    }
                    triangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "LEFTY" || methodStart[i].ToUpper().Trim() == "LEFTY,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        leftY = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        leftY = Convert.ToInt32(methodCall[i].Trim());
                    }
                    triangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "RIGHTX" || methodStart[i].ToUpper().Trim() == "RIGHTX,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        rightX = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        rightX = Convert.ToInt32(methodCall[i].Trim());
                    }
                    triangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "RIGHTY" || methodStart[i].ToUpper().Trim() == "RIGHTY,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        rightY = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        rightY = Convert.ToInt32(methodCall[i].Trim());
                    }
                    triangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "UPTOX" || methodStart[i].ToUpper().Trim() == "UPTOX,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        uptoX = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        uptoX = Convert.ToInt32(methodCall[i].Trim());
                    }
                    lineParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "UPTOY" || methodStart[i].ToUpper().Trim() == "UPTOY,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        uptoY = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        uptoY = Convert.ToInt32(methodCall[i].Trim());
                    }
                    lineParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "WIDTH" || methodStart[i].ToUpper().Trim() == "WIDTH,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        shapeWidth = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        shapeWidth = Convert.ToInt32(methodCall[i].Trim());
                    }
                    rectangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "HEIGHT" || methodStart[i].ToUpper().Trim() == "HEIGHT,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        shapeHeight = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        shapeHeight = Convert.ToInt32(methodCall[i].Trim());
                    }
                    rectangleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "RADIUS" || methodStart[i].ToUpper().Trim() == "RADIUS,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        shapeRadius = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        shapeRadius = Convert.ToInt32(methodCall[i].Trim());
                    }
                    circleParamExist = true;
                }
                else if (methodStart[i].ToUpper().Trim() == "NUMREPEAT" || methodStart[i].ToUpper().Trim() == "NUMREPEAT,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        NumRepeat = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        NumRepeat = Convert.ToInt32(methodCall[i].Trim());
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "PENSIZE" || methodStart[i].ToUpper().Trim() == "PENSIZE,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        penSize = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        penSize = Convert.ToInt32(methodCall[i].Trim());
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "FILLCOLOR" || methodStart[i].ToUpper().Trim() == "FILLCOLOR,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        string colorName = methodCall[i].Substring(0, methodCall[i].IndexOf(","));
                        FillColorToVar(colorName);
                    }
                    else
                    {
                        string colorName = methodCall[i];
                        FillColorToVar(colorName);
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "PENCOLOR" || methodStart[i].ToUpper().Trim() == "PENCOLOR,")
                {
                    if (methodCall[i].Contains(","))
                    {
                        //PenColorToNum(runCmd[1].ToUpper().Trim());
                        // intX = Convert.ToInt32(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                        PenColorToNum(methodCall[i].Substring(0, methodCall[i].IndexOf(",")));
                    }
                    else
                    {
                        PenColorToNum(methodStart[i].ToUpper().Trim());
                        //intX = Convert.ToInt32(methodCall[i].Trim());
                    }
                }
                else if (methodStart[i].ToUpper().Trim() == "FILLSHAPE" || methodStart[i].ToUpper().Trim() == "FILLSHAPE,")
                {
                    string chkFillOk;         //fillOk  1 = true, 2 = false
                    if (methodCall[i].Contains(","))
                    {
                        chkFillOk = methodCall[i].Substring(0, methodCall[i].IndexOf(","));
                    }
                    else
                    {
                        chkFillOk = methodCall[i].Trim();
                    }

                    if (chkFillOk.ToUpper().Trim() == "ON" || chkFillOk.ToUpper().Trim() == "TRUE") { fillOk = 1; }
                    else { fillOk = 2; }
                }
            }

        }

        /// <summary>
        /// This method is called from CallMethod name. This method searches for the method names of the StartMethod
        /// and this method updates the start line of the StartMethod and the end line of the EndMethod.
        /// </summary>
        /// <param name="lines">Array that holds the line number of the CallMethod</param>
        /// <param name="methodName">String to hold the name of the method defined in StartMethod</param>
        /// <returns>Returns true when the StartMethod name is found.</returns>
        private bool FindMethodName(string[] lines, string methodName)
        {
            bool foundName = false;
            int numLines = lines.Length;
            mStart = mEnd = 0;
            for (int i = 0; i < numLines; i++)
            {
                string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (!foundName)
                {
                    if (runCmd.Length > 1)
                    {
                        if (runCmd[1].ToUpper().Trim() == methodName)
                        {
                            mStart = i;
                            foundName = true;
                        }
                    }
                }
                else
                {
                    if (runCmd[0].ToUpper().Trim() == "ENDMETHOD")
                    {
                        mEnd = i;
                        break;
                    }
                }

            }

            if (foundName && mEnd == 0)
            {
                string msg = "EndMethod Not Declared";
                DisplayError("Method Error", msg, -1); return false;
            }

            return foundName;
        }

        /// <summary>
        /// Method to run the loop.
        /// </summary>
        /// <param name="lineNum">Holds the start line number of the loop command</param>
        /// <param name="isFromMethod">It is true if this method is called form the StartMethod or false</param>
        /// <returns>Returns the end line of the loop</returns>
        private int RunLoop(int lineNum, bool isFromMethod)
        {
            //Loop startNum endNum increment
            //EndLoop
            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int endLine = GetEndLineNo("ENDLOOP", lineNum);
            //int numLines = lines.Length;

            string[] runCmd = lines[lineNum].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string check = runCmd[0].ToUpper().Trim();

            //Loop startNum endNum increment
            //int startLine = lineNum;
            int numParams = runCmd.Length;
            int startNum = 1;
            int endNum = 1;
            int incrNum = 1;
            if (numParams == 4 || numParams == 3)
            {
                if (runCmd[1].Contains(","))
                {
                    startNum = Convert.ToInt32(runCmd[1].Substring(0, runCmd[1].IndexOf(",")));
                }
                else
                {
                    startNum = Convert.ToInt32(runCmd[1].Trim());
                }
                if (runCmd[2].Contains(","))
                {
                    endNum = Convert.ToInt32(runCmd[2].Substring(0, runCmd[2].IndexOf(",")));
                }
                else
                {
                    endNum = Convert.ToInt32(runCmd[2].Trim());
                }
                if (numParams == 4)
                {
                    if (runCmd[3].Contains(","))
                    {
                        incrNum = Convert.ToInt32(runCmd[3].Substring(0, runCmd[3].IndexOf(",")));
                    }
                    else
                    {
                        incrNum = Convert.ToInt32(runCmd[3].Trim());
                    }
                }

            }

            //for (int i = startAt; i < numLines; i++)
            int i = lineNum + 1;
            while (true)
            {
                runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                check = runCmd[0].ToUpper().Trim();
                numParams = runCmd.Length;

                if (runCmd[0].ToUpper().Trim() == "ENDLOOP")        
                {
                    startNum += incrNum;
                    if (startNum > endNum) { break; }
                    i = lineNum + 1;
                    //Refresh the command line to be executed
                    runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                }

                if (runCmd[0].ToUpper().Trim() == "IF")       
                {
                    i = RunIF(i);
                }
                else if (isFromMethod)
                {

                    if (runCmd[0].ToUpper().Trim() == "CIRCLE" && circleParamExist && numParams == 1)
                    {
                        DrawCircle();
                    }
                    else if (runCmd[0].ToUpper().Trim() == "RECTANGLE" & rectangleParamExist && numParams == 1)
                    {
                        DrawRectangle();
                    }
                    else if (runCmd[0].ToUpper().Trim() == "TRIANGLE" & triangleParamExist && numParams == 1)
                    {
                        DrawTriangle();
                    }
                    else if (runCmd[0].ToUpper().Trim() == "DRAWTO" & lineParamExist && numParams == 1)
                    {
                        DrawLine();
                    }
                    else
                    {
                        if (!CommandExecuted(lines[i], i))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    CommandExecuted(lines[i], i);
                }
                i++;
            }
            return endLine + 1;
        }

        /// <summary>
        /// Method to run the IF statement
        /// </summary>
        /// <param name="lineNum">Holds the start line number of the IF statement</param>
        /// <returns>Returns the end line of the IF</returns>
        private int RunIF(int lineNum)
        {
            //return retLineNum
            //int retLineNum = 0;
            int returnValue = 0;    //returnValue =>  0 -> true, 1->false & 2->false

            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int endLine = GetEndLineNo("ENDIF", lineNum);
            if (endLine == 0)
            {
                string msg = "EndIf Not Declared";
                DisplayError("EndIf Error", msg, -1);
                return endLine;
            }
            string[] runCmd = lines[lineNum].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (runCmd.Length != 4)
            {
                string msg = "There should be only 4 words in If statement";
                DisplayError("Method Error", msg, -1);
                return endLine;
            }
            //IF params Compare Var (var may be numeric or other param)
            returnValue = IfCompare(runCmd);
            //Continue only if the return Value = 0 i.e. true
            if (returnValue == 0)
            {
                // Continue until endif is meet
                for (int i = lineNum + 1; i < endLine; i++)
                {
                    CommandExecuted(lines[i], i);
                }
            }
            return endLine;
        }

        /// <summary>
        /// This method compares the variables and parameters of the IF statement and returns true, false, or error.
        /// </summary>
        /// <param name="ifLine">holds the line of the If statemenr in aarray form</param>
        /// <returns>returns true, false or error based on the correcteness of the statement.</returns>
        private int IfCompare(string[] ifLine)
        {
            //return value 0 -> true, 1 -> false and 2-> error
            int returnValue = 0;
            bool paramExist = false;
            string paramIf = ifLine[1].ToUpper().Trim();
            if (paramIf.Contains(",")) { paramIf = paramIf.Substring(0, paramIf.IndexOf(",")); }

            //Check whether the if param exist
            for (int j = 0; j < arrParams.Length; j++)
            {
                if (paramIf == arrParams[j].ToUpper().Trim())
                {
                    paramExist = true;
                    break;
                }
            }
            if (!paramExist)
            {
                string msg = "parameter for IF statement does not Exist";
                DisplayError("Parameter", msg, -1);
                return 2;
            }

            //string[] cmpIf = { "=", "==" ">", "<", "!=" };
            //Check whether the proper Variable Comparision Symbol used
            string cmpIf = ifLine[2].Trim();
            if (cmpIf.Contains(",")) { cmpIf = cmpIf.Substring(0, cmpIf.IndexOf(",")); }
            if (cmpIf != "=" && cmpIf != "==" && cmpIf != ">" && cmpIf != "<" && cmpIf != "!=")
            {
                string msg = "IF statement does not contain proper Comparision Symbol";
                DisplayError("IF statement Error", msg, -1);
                return 2;
            }

            //Check whether the Var (var may be numeric or other param)
            int varNum;
            string varIf = ifLine[3].ToUpper().Trim();
            if (varIf.Contains(",")) { varIf = varIf.Substring(0, varIf.IndexOf(",")); }
            //isNumeric = int.TryParse(str, out i);
            bool isNumeric = int.TryParse(varIf, out varNum);

            //Compare the IF Statement
            //paramIf cmpIf varNum varIf
            if (paramIf.ToUpper().Trim() == "FILLCOLOR")
            {
                //string[] cmpIf = { "=", ">", "<", "!=" };
                string colfill = fillColor.ToString().ToUpper(); // example colfill = "COLOR[GREEN]"
                if (cmpIf == "=" || cmpIf == "==")
                {
                    //if (str.Contains("TOP") == true)
                    if (colfill.Contains(varIf)) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (!colfill.Contains(varIf)) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "PENCOLOR")
            {
                int colorNum = 1;
                if (varIf.ToUpper().Trim() == "BLUE") { colorNum = 2; }
                else if (varIf.ToUpper().Trim() == "GREEN") { colorNum = 3; }
                else if (varIf.ToUpper().Trim() == "RED") { colorNum = 4; }
                else if (varIf.ToUpper().Trim() == "YELLOW") { colorNum = 5; }
                else if (varIf.ToUpper().Trim() == "BLACK") { colorNum = 1; }

                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (penColor == colorNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (penColor != colorNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf.ToUpper().Trim() == "FILLSHAPE")
            {
                //int fillOk = 1;        //fillOk  1 = true, 2 = false
                int iffillShapeOk = 2;
                if (varIf.ToUpper().Trim() == "ON" || varIf.ToUpper().Trim() == "TRUE") { iffillShapeOk = 1; }

                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (fillOk == iffillShapeOk) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (fillOk != iffillShapeOk) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { return returnValue = 2; }
            }
            else if (paramIf == "INTX")
            {
                ///int intX = 0;        //Start Position X for all shape
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (intX == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (intX != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (intX > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (intX < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "INTY")
            {
                //int intY = 0;        //Start Position Y for all shape
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (intY == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (intY != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (intY > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (intY < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "LEFTX")
            {
                //int leftX = 0;        //Changed from midX
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (leftX == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (leftX != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (leftX > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (leftX < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "LEFTY")
            {
                //int leftY = 0;        //Changed from midY
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (leftY == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (leftY != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (leftY > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (leftY < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "RIGHTX")
            {
                //int rightX = 0;     //Changed from finalX
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (rightX == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (rightX != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (rightX > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (rightX < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "RIGHTY")
            {
                //int rightY = 0;     //Changed from finalY
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (rightY == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (rightY != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (rightY > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (rightY < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "UPTOX")
            {
                //int uptoX = 0;     // Added to distinguish end point of DrawTo line
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (uptoX == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (uptoX != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (uptoX > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (uptoX < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "UPTOY")
            {
                //int uptoY = 0;     // Added to distinguish end point of DrawTo line
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (uptoY == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (uptoY != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (uptoY > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (uptoY < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "WIDTH")
            {
                //int shapeWidth = 0;
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (shapeWidth == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (shapeWidth != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (shapeWidth > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (shapeWidth < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "HEIGHT")
            {
                //int shapeHeight = 0;
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (shapeHeight == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (shapeHeight != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (shapeHeight > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (shapeHeight < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "RADIUS")
            {
                //int shapeRadius = 0;  
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (shapeRadius == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (shapeRadius != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (shapeRadius > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (shapeRadius < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }
            else if (paramIf == "PENSIZE")
            {
                //int penSize = 2;
                if (cmpIf == "=" || cmpIf == "==")
                {
                    if (penSize == varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "!=")
                {
                    if (penSize != varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == ">")
                {
                    if (penSize > varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else if (cmpIf == "<")
                {
                    if (penSize < varNum) { returnValue = 0; }
                    else { returnValue = 1; }
                }
                else { returnValue = 2; }
            }

            if (returnValue == 2)
            {
                string msg = "IF statement does not contain proper Comparision Symbol";
                DisplayError("IF statement Error", msg, -1);
                return 2;
            }

            return returnValue;
        }

        /// <summary>
        /// This method provides the end line number of the end type defined by endtype such as EndMethod, EndLoop, EndIf. 
        /// </summary>
        /// <param name="endType">Holds the value of the end type</param>
        /// <param name="lineStartNo">Holds the value of the start line number of either StartType, eg: StartMethod, loop, if.</param>
        /// <returns>Returns the end Line number.</returns>
        private int GetEndLineNo(string endType, int lineStartNo)
        {
            string chkCmdLine = txt_Command.Text;
            string[] lines = chkCmdLine.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int totalLine = lines.Length;
            int i = lineStartNo;
            int endLineNo = 0;
            string[] runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //string chkEnd = "Chk";

            bool methodNotEnded = true;
            while (methodNotEnded)
            {
                i++;
                runCmd = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (runCmd[0].ToUpper().Trim() == endType) { endLineNo = i; break; }
                if (i == totalLine)
                {
                    string msg = endType + " Not Found";
                    DisplayError("Block End Error", msg, -1);
                    break;
                }
            }


            return endLineNo;
        }

        /// <summary>
        /// Click Method to load the file(in the menu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// Click Method to save the file(in the menu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Click Method to exit the app(in the menu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method to load the command list by clicking in "Command List with Syntax"  in txt_Command_List
        /// Within "Help"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandListWithSyntaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCommandList("Command");
        }

        /// <summary>
        /// Method to load the parameter list by clicking in "Parameter List" in txt_Command_List
        /// Within "Help"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parameterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCommandList("Parameter");
        }

        /// <summary>
        /// Method to help load a sample of code of bullseye.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bullsEyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCommandList("Bulls Eye");
        }

        /// <summary>
        /// Method to open a message box about the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string msg = "Graphical Programming Language Application (GPLA)";
            msg += Environment.NewLine + "_________________________________________________________";
            msg += Environment.NewLine + "";
            msg += Environment.NewLine + "The purpose of this program is to create a simple Learning Environment that helps new programmers learn simple programming concept using graphics.";
            msg += Environment.NewLine + "";
            msg += Environment.NewLine + "Programmer: Rubin Shrestha";
            msg += Environment.NewLine + "ID: C7202808";

            DisplayError("About", msg, -1);
        }

        /// <summary>
        /// ethod to help load a sample of code of Christmas Tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void christmasTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCommandList("Christmas Tree");
        }


    }
    #endregion
}
