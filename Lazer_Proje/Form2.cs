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
using static LazerOlcum.Ini;
using System.Reflection;



namespace Lazer_Proje
{


    public partial class Form2 : Form
    {




        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            IniFile IniFile = new IniFile("D:\\Settings.ini");

            ipTxt.Text = IniFile.IniReadValue("IPAdresleri", "IP1");
            ipTxt1.Text = IniFile.IniReadValue("IPAdresleri", "IP2");
            ipTxt2.Text = IniFile.IniReadValue("IPAdresleri", "IP3");
            ipTxt3.Text = IniFile.IniReadValue("IPAdresleri", "IP4");
            kanalTxt.Text = IniFile.IniReadValue("KanalIsimleri", "Kanal-1");
            kanalTxt1.Text = IniFile.IniReadValue("KanalIsimleri", "Kanal-2");
            kanalTxt2.Text = IniFile.IniReadValue("KanalIsimleri", "Kanal-3");
            kanalTxt3.Text = IniFile.IniReadValue("KanalIsimleri", "Kanal-4");
            hizTxt.Text = IniFile.IniReadValue("ZamanAyarlari", "Periyot");


        }

        private void Button1_Click(object sender, EventArgs e)
        {
          

            IniFile IniFile = new IniFile("D:\\Settings.ini");


            IniFile.IniWriteValue("IPAdresleri", "IP1", ipTxt.Text);
            IniFile.IniWriteValue("IPAdresleri", "IP2", ipTxt1.Text);
            IniFile.IniWriteValue("IPAdresleri", "IP3", ipTxt2.Text);
            IniFile.IniWriteValue("IPAdresleri", "IP4", ipTxt3.Text);
            IniFile.IniWriteValue("KanalIsimleri", "Kanal-1", kanalTxt.Text);
            IniFile.IniWriteValue("KanalIsimleri", "Kanal-2", kanalTxt1.Text);
            IniFile.IniWriteValue("KanalIsimleri", "Kanal-3", kanalTxt2.Text);
            IniFile.IniWriteValue("KanalIsimleri", "Kanal-4", kanalTxt3.Text);
            IniFile.IniWriteValue("ZamanAyarlari", "Periyot", hizTxt.Text);


            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

    public class IniFile
    {
        public string path { get; private set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string INIPath)
        {
            path = INIPath;
        }
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }

/*class INIFile
{
    private string filePath;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section,
    string key,
    string val,
    string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section,
    string key,
    string def,
    StringBuilder retVal,
    int size,
    string filePath);

    public INIFile(string filePath)
    {
        this.filePath = filePath;
    }

    public void Write(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
    }

    public string Read(string section, string key)
    {
        StringBuilder SB = new StringBuilder(255);
        int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
        return SB.ToString();
    }

    public string FilePath
    {
        get { return this.filePath; }
        set { this.filePath = value; }
    }
}
*/


