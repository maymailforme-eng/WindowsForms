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

namespace Clock
{
    public partial class FontDialog : Form
    {

        Form parent;
        public FontDialog(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;

        }

        void LoadFonts()
        {
            AllocConsole();
            MessageBox.Show($"{Directory.GetParent(Application.StartupPath)?.Parent?.FullName}\\Fonts" );
            Console.WriteLine(Application.ExecutablePath);
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Traverse(Directory.GetCurrentDirectory());
            //LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory(), "*.otf");


        }

        void LoadFonts(string path, string extention)
        {
            string[] files = Directory.GetFiles(path, extention);
            for (int i = 0; i < files.Length; ++i)
            {
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





        private void FontDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.parent.Location.X - this.Width / 3, this.parent.Location.Y + 120);
            LoadFonts();
        }
    }
}
