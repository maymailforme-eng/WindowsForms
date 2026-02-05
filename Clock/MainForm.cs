using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Clock
{
    public partial class MainForm : Form
    {

        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;

        FontDialog fontDialog;
        Font FontMain;

        public MainForm()
        {
            InitializeComponent();

            tsmiShowControls.Checked = true;
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new FontDialog(this);


            this.Load += MainForm_Load;

            
        }




        //обработчик события Load (Start Unity)
        private void MainForm_Load(object sender, EventArgs e)
        {
            //получаем ширину окна
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            //устанавливаем положение окна
            this.Location = new Point(workingArea.Width - this.Width, 0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            if (checkBoxShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            }

            if (checkBoxShowWeekday.Checked)
            {
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            }

            notifyIcon.Text = labelTime.Text;
        }


        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekday.Visible = visible;
            buttonHideControls.Visible = visible;
            this.ShowInTaskbar = visible;

            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
        }

        //обработчик кнопки buttonHideContols
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            tsmiShowControls.Checked = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            tsmiShowControls.Checked = true;
        }

        //обработчик Topmost
        private void tsmiTopmost_CheckedChanged(object sender, EventArgs e)
        {
            //this.TopMost = tsmiTopmost.Checked;

            this.TopMost = (sender as ToolStripMenuItem).Checked;
        }


        //обработчик tsmiShowControls
        private void tsmiShowControls_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility(tsmiShowControls.Checked);
        }


        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowDate.Checked = (sender as CheckBox).Checked;
        }

        private void checkBoxShowWeekday_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowWeekday.Checked = (sender as CheckBox).Checked;
        }

        private void tsmiShowDate_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxShowDate.Checked = (sender as ToolStripMenuItem).Checked;
        }

        private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxShowWeekday.Checked = (sender as ToolStripMenuItem).Checked;
        }

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            DialogResult result = backgroundDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                labelTime.BackColor = backgroundDialog.Color;
            }
        }

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            if (foregroundDialog.ShowDialog() == DialogResult.OK)
            {
                labelTime.ForeColor = foregroundDialog.Color;
            }
        }

        
        //клик по Font 
        private void tsmiFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                FontMain = fontDialog.Font_Dialog;
                labelTime.Font = FontMain;
            }
        }

        private void tsmiAutorun_CheckedChanged(object sender, EventArgs e)
        {
            string key_name = "Clock_PV_522";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (tsmiAutorun.Checked) rk.SetValue(key_name, Application.ExecutablePath);
            else rk.DeleteValue(key_name, false);
            rk.Dispose();
        }
    }
}
