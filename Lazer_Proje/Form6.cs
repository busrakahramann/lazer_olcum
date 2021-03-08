using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lazer_Proje
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        string kanal3;
        IniFile IniFile = new IniFile("D:\\Settings.ini");

        private void Form6_Load(object sender, EventArgs e)
        {
            kanal3 = IniFile.IniReadValue("KanalIsimleri", "Kanal-4");

            // TODO: Bu kod satırı 'lazerHatalariDataSet.Hatalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.hatalarTableAdapter.Fill(this.lazerHatalariDataSet.Hatalar);
            SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hatalar where kanal='" + kanal3 + "' ORDER BY tarihSaat", baglanti);
            baglanti.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hatalar where kanal='" + kanal3 + "' and tarihSaat between '" + dateTimePicker1.Value.ToString() + "' AND '" + dateTimePicker2.Value.ToString() + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Hatalar");
            dataGridView1.DataSource = ds.Tables["Hatalar"];
            baglanti.Close();
        }
    }
}
