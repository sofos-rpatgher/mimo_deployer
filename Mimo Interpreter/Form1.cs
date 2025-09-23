using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Guna.UI2.WinForms;

namespace Mimo_Interpreter
{
    public partial class Form1 : Form
    {
        private bool maximised = false;
        private string usernameStr = "";
        private string passwordStr = "";
        private string clientStr = "";
        // private bool isResizing = false;
        // private Point lastMousePosition;

        Interpreter interpreter;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.AutoScroll = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Style = ProgressBarStyle.Continuous;

            set_Header();

            runBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            Listener listener = new Listener("http://+:8000/", console);
        }

        private void set_Header()
        {
            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 25;
            topBar.BackColor = Color.FromArgb(8, 98, 36);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 75;
            header.BackColor = Color.FromArgb(8, 98, 36);
            this.Controls.Add(header);
            this.Controls.Add(topBar);

            // Event to move the window
            topBar.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) MoveWindow();
            };

            // Center Container
            Panel containerHeader = new Panel
            {
                Size = new Size(this.ClientSize.Width, header.ClientSize.Height),
                Anchor = AnchorStyles.Top,
                Left = (this.ClientSize.Width - 300) / 2,
                Top = 0
            };
            header.Controls.Add(containerHeader);

            // PictureBox Logo
            PictureBox logo = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(150, 150),
                Location = new Point((containerHeader.ClientSize.Width / 4) - 150, -50)
            };
            // logo.Image = Image.FromFile("Assets/mimo_logo_2.png");
            containerHeader.Controls.Add(logo);
        }

        private void BtnMaximise_Click(object sender, EventArgs e)
        {
            if (maximised)
            {
                this.WindowState = FormWindowState.Normal;
                maximised = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                maximised = true;
            }
        }

        private void MoveWindow()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Allow moving the window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileSelect = new OpenFileDialog();
            fileSelect.Filter = "(*.exe) |*.exe";

            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileSelect.FileName;
            }
        }

        private void password_TextChanged_1(object sender, EventArgs e)
        {
            usernameStr = username.Text;
        }

        private void username_TextChanged_1(object sender, EventArgs e)
        {
            passwordStr = password.Text;
        }

        private void client_TextChanged_1(object sender, EventArgs e)
        {
            clientStr = client.Text;
        }

        private void browseBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileSelect = new OpenFileDialog();
            fileSelect.Filter = "Mimo program (*.mimo) |*.mimo";

            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = fileSelect.FileName;
                runBtn.Enabled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void runBtn_Click_1(object sender, EventArgs e)
        {
            string filePath = pathBox.Text;
            interpreter = new Interpreter(console, textBox1, usernameStr, passwordStr, clientStr);
            interpreter.interpret(filePath, progressBar1);
            logsButton.Enabled = true;
        }

        private void logsButton_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Logs", $"B_{interpreter.mimo_program.batch_id}");

            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Directory does not exist: " + path);
            }
        }
    }
}
