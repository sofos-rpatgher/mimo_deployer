namespace Mimo_Interpreter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            flowLayoutPanel7 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            username = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            password = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label4 = new Label();
            client = new TextBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            label5 = new Label();
            flowLayoutPanel9 = new FlowLayoutPanel();
            pathBox = new TextBox();
            browseBtn = new Button();
            flowLayoutPanel10 = new FlowLayoutPanel();
            label6 = new Label();
            flowLayoutPanel11 = new FlowLayoutPanel();
            textBox1 = new TextBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            console = new RichTextBox();
            flowLayoutPanel12 = new FlowLayoutPanel();
            logsButton = new Button();
            runBtn = new Button();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            flowLayoutPanel12.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel1.Controls.Add(progressBar1);
            flowLayoutPanel1.Controls.Add(console);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel12);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 118);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(582, 646);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(291, 20);
            label1.TabIndex = 1;
            label1.Text = "Type your credentials to enter SAP GUI:";
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel7.Location = new Point(3, 23);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(574, 131);
            flowLayoutPanel7.TabIndex = 5;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel4.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(379, 125);
            flowLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(username);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(223, 55);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 0;
            label2.Text = "User:";
            // 
            // username
            // 
            username.BorderStyle = BorderStyle.FixedSingle;
            username.Cursor = Cursors.IBeam;
            username.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(3, 23);
            username.Name = "username";
            username.Size = new Size(205, 26);
            username.TabIndex = 1;
            username.TextChanged += username_TextChanged_1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(password);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel3.Location = new Point(3, 64);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(223, 55);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 0;
            label3.Text = "Password:";
            // 
            // password
            // 
            password.BorderStyle = BorderStyle.FixedSingle;
            password.Cursor = Cursors.IBeam;
            password.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password.Location = new Point(3, 23);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(205, 26);
            password.TabIndex = 1;
            password.TextChanged += password_TextChanged_1;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel5.Location = new Point(388, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(170, 58);
            flowLayoutPanel5.TabIndex = 4;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(label4);
            flowLayoutPanel6.Controls.Add(client);
            flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel6.Location = new Point(3, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(68, 55);
            flowLayoutPanel6.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 0;
            label4.Text = "Client:";
            // 
            // client
            // 
            client.BorderStyle = BorderStyle.FixedSingle;
            client.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            client.Location = new Point(3, 23);
            client.Name = "client";
            client.Size = new Size(53, 26);
            client.TabIndex = 1;
            client.TextChanged += client_TextChanged_1;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel8.AutoSize = true;
            flowLayoutPanel8.Controls.Add(label5);
            flowLayoutPanel8.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel8.Controls.Add(flowLayoutPanel10);
            flowLayoutPanel8.Location = new Point(3, 160);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(574, 127);
            flowLayoutPanel8.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(302, 20);
            label5.TabIndex = 0;
            label5.Text = "Select the mimo program you want to run:";
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(pathBox);
            flowLayoutPanel9.Controls.Add(browseBtn);
            flowLayoutPanel9.Location = new Point(3, 23);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(541, 37);
            flowLayoutPanel9.TabIndex = 2;
            // 
            // pathBox
            // 
            pathBox.BorderStyle = BorderStyle.FixedSingle;
            pathBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pathBox.Location = new Point(3, 3);
            pathBox.Name = "pathBox";
            pathBox.ReadOnly = true;
            pathBox.Size = new Size(441, 26);
            pathBox.TabIndex = 1;
            // 
            // browseBtn
            // 
            browseBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            browseBtn.Location = new Point(450, 3);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(79, 26);
            browseBtn.TabIndex = 2;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click_1;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Controls.Add(label6);
            flowLayoutPanel10.Controls.Add(flowLayoutPanel11);
            flowLayoutPanel10.Location = new Point(3, 66);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(389, 58);
            flowLayoutPanel10.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(274, 20);
            label6.TabIndex = 1;
            label6.Text = "Select the absolute path of SAP GUI:";
            // 
            // flowLayoutPanel11
            // 
            flowLayoutPanel11.Controls.Add(textBox1);
            flowLayoutPanel11.Controls.Add(button1);
            flowLayoutPanel11.Location = new Point(3, 23);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            flowLayoutPanel11.Size = new Size(376, 32);
            flowLayoutPanel11.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(282, 26);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(291, 3);
            button1.Name = "button1";
            button1.Size = new Size(79, 26);
            button1.TabIndex = 2;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(3, 293);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(574, 23);
            progressBar1.TabIndex = 6;
            // 
            // console
            // 
            console.BorderStyle = BorderStyle.FixedSingle;
            console.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            console.Location = new Point(3, 322);
            console.Name = "console";
            console.ScrollBars = RichTextBoxScrollBars.Vertical;
            console.Size = new Size(574, 270);
            console.TabIndex = 7;
            console.Text = "";
            // 
            // flowLayoutPanel12
            // 
            flowLayoutPanel12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel12.AutoSize = true;
            flowLayoutPanel12.Controls.Add(logsButton);
            flowLayoutPanel12.Controls.Add(runBtn);
            flowLayoutPanel12.Location = new Point(368, 598);
            flowLayoutPanel12.Name = "flowLayoutPanel12";
            flowLayoutPanel12.Size = new Size(209, 36);
            flowLayoutPanel12.TabIndex = 1;
            // 
            // logsButton
            // 
            logsButton.Enabled = false;
            logsButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logsButton.Location = new Point(3, 3);
            logsButton.Name = "logsButton";
            logsButton.Size = new Size(122, 30);
            logsButton.TabIndex = 0;
            logsButton.Text = "Open log files";
            logsButton.UseVisualStyleBackColor = true;
            logsButton.Click += logsButton_Click_1;
            // 
            // runBtn
            // 
            runBtn.Enabled = false;
            runBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            runBtn.Location = new Point(131, 3);
            runBtn.Name = "runBtn";
            runBtn.Size = new Size(75, 30);
            runBtn.TabIndex = 1;
            runBtn.Text = "Run";
            runBtn.UseVisualStyleBackColor = true;
            runBtn.Click += runBtn_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 776);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Mimo Interpreter";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel10.PerformLayout();
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            flowLayoutPanel12.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private TextBox username;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private TextBox password;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label4;
        private TextBox client;
        private FlowLayoutPanel flowLayoutPanel7;
        private FlowLayoutPanel flowLayoutPanel8;
        private Label label5;
        private TextBox pathBox;
        private FlowLayoutPanel flowLayoutPanel9;
        private Button browseBtn;
        private FlowLayoutPanel flowLayoutPanel10;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel11;
        private TextBox textBox1;
        private Button button1;
        private ProgressBar progressBar1;
        private RichTextBox console;
        private FlowLayoutPanel flowLayoutPanel12;
        private Button logsButton;
        private Button runBtn;
    }
}
