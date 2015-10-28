namespace WinFormsSample
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnSetMany = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MultilevelTextboxRedoButton = new System.Windows.Forms.Button();
            this.MultilevelTextboxUndoButton = new System.Windows.Forms.Button();
            this.MultilevelTextbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(62, 121);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(107, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Age:";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(62, 160);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(107, 22);
            this.txtAge.TabIndex = 3;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(9, 79);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(94, 79);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 23);
            this.btnRedo.TabIndex = 5;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnSetMany
            // 
            this.btnSetMany.Location = new System.Drawing.Point(188, 79);
            this.btnSetMany.Name = "btnSetMany";
            this.btnSetMany.Size = new System.Drawing.Size(157, 31);
            this.btnSetMany.TabIndex = 6;
            this.btnSetMany.Text = "Set Both Properties";
            this.btnSetMany.UseVisualStyleBackColor = true;
            this.btnSetMany.Click += new System.EventHandler(this.btnSetMany_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "Keep changing name and age in any order, \r\nUndo and Redo will keep track of the c" +
                "hanges";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 51);
            this.label4.TabIndex = 8;
            this.label4.Text = "\'Set both\' demonstrates \r\nrecording multiple actions\r\nin one transaction";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MultilevelTextboxRedoButton);
            this.groupBox1.Controls.Add(this.MultilevelTextboxUndoButton);
            this.groupBox1.Controls.Add(this.MultilevelTextbox);
            this.groupBox1.Location = new System.Drawing.Point(16, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multilevel undo textbox";
            // 
            // MultilevelTextboxRedoButton
            // 
            this.MultilevelTextboxRedoButton.Enabled = false;
            this.MultilevelTextboxRedoButton.Location = new System.Drawing.Point(89, 50);
            this.MultilevelTextboxRedoButton.Name = "MultilevelTextboxRedoButton";
            this.MultilevelTextboxRedoButton.Size = new System.Drawing.Size(75, 23);
            this.MultilevelTextboxRedoButton.TabIndex = 2;
            this.MultilevelTextboxRedoButton.Text = "Redo";
            this.MultilevelTextboxRedoButton.UseVisualStyleBackColor = true;
            this.MultilevelTextboxRedoButton.Click += new System.EventHandler(this.MultilevelTextboxRedoButton_Click);
            // 
            // MultilevelTextboxUndoButton
            // 
            this.MultilevelTextboxUndoButton.Enabled = false;
            this.MultilevelTextboxUndoButton.Location = new System.Drawing.Point(7, 50);
            this.MultilevelTextboxUndoButton.Name = "MultilevelTextboxUndoButton";
            this.MultilevelTextboxUndoButton.Size = new System.Drawing.Size(75, 23);
            this.MultilevelTextboxUndoButton.TabIndex = 1;
            this.MultilevelTextboxUndoButton.Text = "Undo";
            this.MultilevelTextboxUndoButton.UseVisualStyleBackColor = true;
            this.MultilevelTextboxUndoButton.Click += new System.EventHandler(this.MultilevelTextboxUndoButton_Click);
            // 
            // MultilevelTextbox
            // 
            this.MultilevelTextbox.Location = new System.Drawing.Point(6, 21);
            this.MultilevelTextbox.Name = "MultilevelTextbox";
            this.MultilevelTextbox.Size = new System.Drawing.Size(327, 22);
            this.MultilevelTextbox.TabIndex = 0;
            this.MultilevelTextbox.TextChanged += new System.EventHandler(this.MultilevelTextbox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnSetMany);
            this.groupBox2.Controls.Add(this.txtAge);
            this.groupBox2.Controls.Add(this.btnRedo);
            this.groupBox2.Controls.Add(this.btnUndo);
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 201);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Undoable form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnSetMany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button MultilevelTextboxRedoButton;
        private System.Windows.Forms.Button MultilevelTextboxUndoButton;
        private System.Windows.Forms.TextBox MultilevelTextbox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

