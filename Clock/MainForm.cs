using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {

        private string _nameAutoran = "Clock";
        private string _registr = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";

        //переменные для положения мыши
        private Point _mouseOffset;
        private bool _moving = false;

        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;

        private Font _сustomFont;
        PrivateFontCollection _fontCollection;

        public MainForm()
        {
            InitializeComponent();

            tsmiShowControls.Checked = true;
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();

            //установка кастомного шрифта

            // нужно создать коллекцию шрифтов, что бы хагрузить в нее не системный шрифт
            _fontCollection = new PrivateFontCollection();

            // Загружаем шрифт из файла (лежит рядом с программой)
            _fontCollection.AddFontFile("Forgotbi.ttf");

            //устанавлваем шрифт во все нужные окна
            labelTime.Font = new Font(_fontCollection.Families[0], 36f);
            checkBoxShowDate.Font = new Font(_fontCollection.Families[0], 20f);
            checkBoxShowWeekday.Font = new Font(_fontCollection.Families[0], 20f);
            buttonHideControls.Font = new Font(_fontCollection.Families[0], 20f);
            contextMenuStrip.Font = new Font(_fontCollection.Families[0], 12f);

            //синхранизируем отметку режима AutoRun по реестру
            CheckAutorunStatus();

            //this.Load += MainForm_Load;


        }







        ///приватные методы ...................................................................................
        ///
        // для проверки статуса автозапуска при загрузке формы
        private void CheckAutorunStatus()
        {
            try
            {
                object value = Registry.GetValue(_registr, _nameAutoran, null);
                tsmiAutorun.Checked = (value != null && value.ToString() == Application.ExecutablePath);
            }
            catch
            {
                tsmiAutorun.Checked = false;
            }
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //обработчик автозапуска
        private void tsmiAutorun_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            //если галка отмечена - ВКЛЮЧАЕМ автозапуск
            if (item.Checked)
            {
                //записываем в регистр автозапуска ссылку на нашу прошрамму
                Registry.SetValue(_registr, _nameAutoran, Application.ExecutablePath);
                MessageBox.Show("Автозапуск включен!");
            }
            //инаяе ОТКЛЮЧАЕМ
            else
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        key?.DeleteValue(_nameAutoran, false);
                    }
                    MessageBox.Show("Автозапуск выключен!");
                }
                catch
                {
                    MessageBox.Show("Не удалось отключить автозапуск");
                }
            }
        }

        //нажатие мышью на labelTime
        private void labelTime_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && tsmiShowControls.Checked == false)
            {
                _moving = true;
                _mouseOffset = new Point(e.X, e.Y);

                //e.X - Координата X курсора мыши относительно элемента (labelTime)
                //e.Y - Координата Y курсора мыши относительно элемента

                //изменяем курсор
                if (sender is Control control) control.Cursor = Cursors.SizeAll;
            }


        }

        //перемещение зажатой мыши
        private void labelTime_MouseMove(object sender, MouseEventArgs e)
        {
            if (_moving)
            {
                Point currentPos = PointToScreen(e.Location);
                this.Location = new Point(currentPos.X - _mouseOffset.X,
                                          currentPos.Y - _mouseOffset.Y);
            }
        }

        //отжатие мыши
        private void labelTime_MouseUp(object sender, MouseEventArgs e)
        {
            _moving = false;

            if (sender is Control control)
                control.Cursor = Cursors.Default;
        }
    }
}
