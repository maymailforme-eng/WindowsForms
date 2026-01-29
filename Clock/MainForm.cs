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
        }
    }
}
