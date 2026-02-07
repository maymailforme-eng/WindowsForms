using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Text;
namespace Clock
{
    public partial class FontDialog : Form
    {

        Form parent;
        //переменная для хранения коллекции шрифтов
        PrivateFontCollection pfc;
        List<string> pathsFonts  = new List<string>();

        public Font Font_Dialog { get; private set; }
        public string FontFile { get; set; }
        public FontDialog(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;

            //this.Load += FontDialog_Load1;
        }

        //private void FontDialog_Load1(object sender, EventArgs e)
        //{
        //    pfc = new PrivateFontCollection();
        //    pfc.AddFontFile(FontFile); //выбираем по индексу 
        //    //при стирании pfc при ее локальном объявлении, получаем висячую ссылку
        //    labelExample.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);
        //}

        void LoadFonts()
        {
            AllocConsole();
            //MessageBox.Show($"{Directory.GetParent(Application.StartupPath)?.Parent?.FullName}\\Fonts" );
            Console.WriteLine(Application.ExecutablePath);
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Traverse(Directory.GetCurrentDirectory());
        }

        void LoadFonts(string path, string extention)
        {
            string[] files = Directory.GetFiles(path, extention);
            for (int i = 0; i < files.Length; ++i)
            {

                pathsFonts.Add(files[i]); //сохраняем абсолютный путь к шрифту
                files[i] = Path.GetFileName(files[i]);


            }
            comboBoxFonts.Items.AddRange(files);

        }

        void Traverse(string path)
        { 
            LoadFonts(path, "*.ttf");
            LoadFonts(path, "*.otf");
            string[] directories = Directory.GetDirectories(path);
            if (directories.Length == 0) return;
            for (int i = 0; i < directories.Length; ++i)
            {
                Traverse(directories[i]);
            }
        }

        [DllImport("kernel32.dll")]
        public static extern void AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern void FreeConsole();

        void ApplyFontExample(string filename)
        {
            // Освобождаем предыдущую коллекцию
            if (pfc != null)
            {
                pfc.Dispose();
            }

            //используем сохранненую переменную
            pfc = new PrivateFontCollection();
            //pfc.AddFontFile(comboBoxFonts.SelectedItem.ToString());
            pfc.AddFontFile(pathsFonts[comboBoxFonts.SelectedIndex]); //выбираем по индексу 


            //pfc.Families[0] - вернет ссылочный объект типа FontFamily, а не строку 
            //при стирании pfc при ее локальном объявлении, получаем висячую ссылку
            labelExample.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);

        }



        private void FontDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.parent.Location.X - this.Width / 3, this.parent.Location.Y + 120);
            //LoadFonts();
            ApplyFontExample(FontFile);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //PrivateFontCollection pfc = new PrivateFontCollection();
            // pfc.AddFontFile(comboBoxFonts.SelectedItem.ToString());
            this.Font_Dialog = labelExample.Font;
            this.FontFile = pathsFonts[comboBoxFonts.SelectedIndex];
        }

        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontExample(pathsFonts[comboBoxFonts.SelectedIndex]);


        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyFontExample(pathsFonts[comboBoxFonts.SelectedIndex]);
        }
    }
}
