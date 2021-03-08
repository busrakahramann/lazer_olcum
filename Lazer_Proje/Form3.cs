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
using System.IO;
using static LazerOlcum.Ini;
using System.Net.NetworkInformation;

namespace Lazer_Proje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string kanal;
        IniFile IniFile = new IniFile("D:\\Settings.ini");

        private void Form3_Load(object sender, EventArgs e)
        {
            kanal = IniFile.IniReadValue("KanalIsimleri", "Kanal-1");
            
                // TODO: Bu kod satırı 'lazerHatalariDataSet.Hatalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
                this.hatalarTableAdapter.Fill(this.lazerHatalariDataSet.Hatalar);
                SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hatalar where kanal='" + kanal + "' ORDER BY tarihSaat", baglanti);
                baglanti.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            

            /* SqlCommand cmdveri = new SqlCommand("Select * from  Hatalar ORDER BY tarihSaat", baglanti);
             SqlDataReader dr = cmdveri.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dataGridView1.DataSource = dt;*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           

            SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hatalar where kanal='" + kanal + "' and tarihSaat between '" + dateTimePicker1.Value.ToString()+"' AND '" + dateTimePicker2.Value.ToString()+"' order by tarihSaat", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Hatalar");
            dataGridView1.DataSource = ds.Tables["Hatalar"];

            

            /*
             dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";

            //string t1 = dateTimePicker1.Value.ToString("yyyy-dd-MM HH:mm:ss");
            // string t2 = dateTimePicker2.Value.ToString("yyyy-dd-MM HH:mm:ss");

            string t1 = dateTimePicker1.Value.ToString();
             string t2 = dateTimePicker2.Value.ToString();
             SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
              baglanti.Open();

             SqlCommand sc = new SqlCommand("Select * from Hatalar where  tarihSaat >= @t1 AND tarihSaat <= @t2", baglanti);
            //SqlCommand sc = new SqlCommand("Select * from Hatalar where tarihSaat>'07.03.2019'", baglanti);

             sc.Parameters.Add("@t1", SqlDbType.DateTime).Value = dateTimePicker1.Value.Date;
              sc.Parameters.Add("@t2", SqlDbType.DateTime).Value = dateTimePicker2.Value.Date;


              DataTable dt = new DataTable();
              dt.Load(sc.ExecuteReader(CommandBehavior.CloseConnection));
              dataGridView1.DataSource = dt;*/

            baglanti.Close();
            }
        }
    }

