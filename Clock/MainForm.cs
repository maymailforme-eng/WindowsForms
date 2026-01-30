using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }




        //обработчик события Load (Start Unity)
        private void MainForm_Load(object sender, EventArgs e)
        {
            //получаем ширину окна
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            //устанавливаем положение окна
            this.Location = new Point(workingArea.Width - this.Width, 0);

            tsmiShowControls.Checked = true;
            tsmiBGC_1.Checked = true;
            tsmiFGC_1.Checked = true;
        }




        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            if (checkBoxShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
                tsmiShowDate.Checked = true;
            }
            else 
            {
                tsmiShowDate.Checked = false;
            }

            if (checkBoxShowWeekday.Checked)
            {
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
                tsmiShowWeekday.Checked = true;
            }
            else 
            {
                tsmiShowWeekday.Checked = false;
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
            SetVisibility(false);
            tsmiShowControls.Checked = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            SetVisibility(true);
        }


        //обработчик события нажатия на tsmiShowDate
        private void tsmiShowDate_Click(object sender, EventArgs e)
        {
            checkBoxShowDate.Checked = tsmiShowDate.Checked ? true : false;
        }

        //обработчик события нажатия на отображения дня недели
        private void tsmiShowWeekday_Click(object sender, EventArgs e)
        {
            checkBoxShowWeekday.Checked = tsmiShowWeekday.Checked ? true : false;
        }

        //обработчик показать\скрыть котролсы
        private void tsmiShowControls_Click(object sender, EventArgs e)
        {
            SetVisibility(tsmiShowControls.Checked ? true : false);

        }

        //обработчик - выход
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //обработка tsmiTopmost
        private void tsmiTopmost_Click(object sender, EventArgs e)
        {
            this.TopMost = tsmiTopmost.Checked ? true : false;
        }

        //system try - двойной щулчок по иконке
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Activate();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //ЦВЕТА
        //

        //усановить цвет фона 1
        private void tsmiBGC_1_Click(object sender, EventArgs e)
        {
            //снимаем выделения остальных цветов
            tsmiBGC_2.Checked = false;
            labelTime.BackColor = SystemColors.Highlight;

        }

        //усановить цвет фона 2
        private void tsmiBGC_2_Click(object sender, EventArgs e)
        {
            tsmiBGC_1.Checked = false;
            labelTime.BackColor = SystemColors.Info;
        }


        //усановить цвет шрифта 1
        private void tsmiFGC_1_Click(object sender, EventArgs e)
        {
            tsmiFGC_2.Checked = false;
            labelTime.ForeColor = SystemColors.ControlText;
        }


        //усановить цвет шрифта 2
        private void tsmiFGC_2_Click(object sender, EventArgs e)
        {
            tsmiFGC_1.Checked = false;
            labelTime.ForeColor = ColorTranslator.FromHtml("DarkRed");
        }
    }
}
