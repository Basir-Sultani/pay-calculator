
namespace OO_programming
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
            this.label2 = new System.Windows.Forms.Label();
            this.hoursWorked = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LastName = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.Label();
            this.EmployeeId = new System.Windows.Forms.Label();
            this.Employees = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.paymentSummary = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hours Worked (hrs)";
            // 
            // hoursWorked
            // 
            this.hoursWorked.Location = new System.Drawing.Point(169, 476);
            this.hoursWorked.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hoursWorked.Name = "hoursWorked";
            this.hoursWorked.Size = new System.Drawing.Size(119, 22);
            this.hoursWorked.TabIndex = 3;
            this.hoursWorked.Text = "0";
            this.hoursWorked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hoursWorked.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 545);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LastName);
            this.groupBox1.Controls.Add(this.FirstName);
            this.groupBox1.Controls.Add(this.EmployeeId);
            this.groupBox1.Controls.Add(this.Employees);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hoursWorked);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(485, 642);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LastName.Location = new System.Drawing.Point(201, 30);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(72, 16);
            this.LastName.TabIndex = 7;
            this.LastName.Text = "Last Name";
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FirstName.Location = new System.Drawing.Point(123, 30);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(72, 16);
            this.FirstName.TabIndex = 6;
            this.FirstName.Text = "First Name";
            this.FirstName.Click += new System.EventHandler(this.label1_Click);
            // 
            // EmployeeId
            // 
            this.EmployeeId.AutoSize = true;
            this.EmployeeId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.EmployeeId.Location = new System.Drawing.Point(32, 30);
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.Size = new System.Drawing.Size(85, 16);
            this.EmployeeId.TabIndex = 5;
            this.EmployeeId.Text = "Employee ID";
            // 
            // Employees
            // 
            this.Employees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Employees.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employees.FormattingEnabled = true;
            this.Employees.ItemHeight = 20;
            this.Employees.Location = new System.Drawing.Point(29, 48);
            this.Employees.Margin = new System.Windows.Forms.Padding(5);
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(412, 364);
            this.Employees.TabIndex = 4;
            this.Employees.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.paymentSummary);
            this.groupBox2.Location = new System.Drawing.Point(493, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(484, 642);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Summary";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 549);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // paymentSummary
            // 
            this.paymentSummary.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentSummary.Location = new System.Drawing.Point(23, 43);
            this.paymentSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentSummary.Multiline = true;
            this.paymentSummary.Name = "paymentSummary";
            this.paymentSummary.ReadOnly = true;
            this.paymentSummary.Size = new System.Drawing.Size(421, 457);
            this.paymentSummary.TabIndex = 0;
            this.paymentSummary.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 640);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Weekly Payment Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoursWorked;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox paymentSummary;
        private System.Windows.Forms.ListBox Employees;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label EmployeeId;
        private System.Windows.Forms.Label LastName;
    }
}

