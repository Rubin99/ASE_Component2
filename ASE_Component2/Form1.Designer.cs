namespace ASE_Component2
{
    partial class Form1
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
            this.Canvas = new System.Windows.Forms.Panel();
            this.txt_Command = new System.Windows.Forms.TextBox();
            this.lbl_Display_Output = new System.Windows.Forms.Label();
            this.lbl_TitleCmd_List = new System.Windows.Forms.Label();
            this.lbl_Program = new System.Windows.Forms.Label();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.txt_Cmd_List = new System.Windows.Forms.TextBox();
            this.btn_ClearCanvase = new System.Windows.Forms.Button();
            this.lbl_CurrentPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CurrentCommand = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Canvas.Location = new System.Drawing.Point(697, 75);
            this.Canvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(665, 491);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // txt_Command
            // 
            this.txt_Command.Location = new System.Drawing.Point(7, 361);
            this.txt_Command.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Command.Multiline = true;
            this.txt_Command.Name = "txt_Command";
            this.txt_Command.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Command.Size = new System.Drawing.Size(676, 217);
            this.txt_Command.TabIndex = 1;
            // 
            // lbl_Display_Output
            // 
            this.lbl_Display_Output.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_Display_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Display_Output.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_Display_Output.Location = new System.Drawing.Point(693, 43);
            this.lbl_Display_Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Display_Output.Name = "lbl_Display_Output";
            this.lbl_Display_Output.Size = new System.Drawing.Size(655, 28);
            this.lbl_Display_Output.TabIndex = 3;
            this.lbl_Display_Output.Text = "Display Output (Shape)";
            this.lbl_Display_Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_TitleCmd_List
            // 
            this.lbl_TitleCmd_List.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_TitleCmd_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitleCmd_List.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_TitleCmd_List.Location = new System.Drawing.Point(3, 43);
            this.lbl_TitleCmd_List.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TitleCmd_List.Name = "lbl_TitleCmd_List";
            this.lbl_TitleCmd_List.Size = new System.Drawing.Size(679, 28);
            this.lbl_TitleCmd_List.TabIndex = 3;
            this.lbl_TitleCmd_List.Text = "Command List with Syntax";
            this.lbl_TitleCmd_List.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Program
            // 
            this.lbl_Program.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_Program.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Program.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_Program.Location = new System.Drawing.Point(7, 324);
            this.lbl_Program.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Program.Name = "lbl_Program";
            this.lbl_Program.Size = new System.Drawing.Size(675, 28);
            this.lbl_Program.TabIndex = 3;
            this.lbl_Program.Text = "Program";
            this.lbl_Program.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadFile.Location = new System.Drawing.Point(412, 624);
            this.btn_LoadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(133, 37);
            this.btn_LoadFile.TabIndex = 4;
            this.btn_LoadFile.Text = "Load File";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveFile.Location = new System.Drawing.Point(548, 624);
            this.btn_SaveFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(133, 37);
            this.btn_SaveFile.TabIndex = 4;
            this.btn_SaveFile.Text = "Save File";
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // btn_Execute
            // 
            this.btn_Execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Execute.Location = new System.Drawing.Point(140, 624);
            this.btn_Execute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(133, 37);
            this.btn_Execute.TabIndex = 4;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(276, 624);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(133, 37);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Run.Location = new System.Drawing.Point(4, 624);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(133, 37);
            this.btn_Run.TabIndex = 4;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // txt_Cmd_List
            // 
            this.txt_Cmd_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cmd_List.Location = new System.Drawing.Point(4, 75);
            this.txt_Cmd_List.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Cmd_List.Multiline = true;
            this.txt_Cmd_List.Name = "txt_Cmd_List";
            this.txt_Cmd_List.ReadOnly = true;
            this.txt_Cmd_List.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Cmd_List.Size = new System.Drawing.Size(684, 239);
            this.txt_Cmd_List.TabIndex = 5;
            // 
            // btn_ClearCanvase
            // 
            this.btn_ClearCanvase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearCanvase.Location = new System.Drawing.Point(1152, 624);
            this.btn_ClearCanvase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ClearCanvase.Name = "btn_ClearCanvase";
            this.btn_ClearCanvase.Size = new System.Drawing.Size(196, 37);
            this.btn_ClearCanvase.TabIndex = 4;
            this.btn_ClearCanvase.Text = "Clear Canvase";
            this.btn_ClearCanvase.UseVisualStyleBackColor = true;
            this.btn_ClearCanvase.Click += new System.EventHandler(this.btn_ClearCanvase_Click);
            // 
            // lbl_CurrentPosition
            // 
            this.lbl_CurrentPosition.AutoSize = true;
            this.lbl_CurrentPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CurrentPosition.Location = new System.Drawing.Point(751, 635);
            this.lbl_CurrentPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CurrentPosition.Name = "lbl_CurrentPosition";
            this.lbl_CurrentPosition.Size = new System.Drawing.Size(172, 20);
            this.lbl_CurrentPosition.TabIndex = 6;
            this.lbl_CurrentPosition.Text = "Current Position (X,Y)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Command Run";
            // 
            // txt_CurrentCommand
            // 
            this.txt_CurrentCommand.BackColor = System.Drawing.SystemColors.Control;
            this.txt_CurrentCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txt_CurrentCommand.Location = new System.Drawing.Point(140, 591);
            this.txt_CurrentCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_CurrentCommand.Name = "txt_CurrentCommand";
            this.txt_CurrentCommand.Size = new System.Drawing.Size(541, 26);
            this.txt_CurrentCommand.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1374, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLoadFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openLoadFileToolStripMenuItem
            // 
            this.openLoadFileToolStripMenuItem.Name = "openLoadFileToolStripMenuItem";
            this.openLoadFileToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openLoadFileToolStripMenuItem.Text = "Open/Load File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 671);
            this.Controls.Add(this.txt_CurrentCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_CurrentPosition);
            this.Controls.Add(this.txt_Cmd_List);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_ClearCanvase);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Execute);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.lbl_Program);
            this.Controls.Add(this.lbl_TitleCmd_List);
            this.Controls.Add(this.lbl_Display_Output);
            this.Controls.Add(this.txt_Command);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compomemt1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.TextBox txt_Command;
        private System.Windows.Forms.Label lbl_Display_Output;
        private System.Windows.Forms.Label lbl_TitleCmd_List;
        private System.Windows.Forms.Label lbl_Program;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.TextBox txt_Cmd_List;
        private System.Windows.Forms.Button btn_ClearCanvase;
        private System.Windows.Forms.Label lbl_CurrentPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CurrentCommand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLoadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

