using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using static LazerOlcum.Ini;
using System.IO;





namespace Lazer_Proje
{
    public partial class Form1 : Form
    {
        
        
        public Form1()

        {
            InitializeComponent();
        }

        //Tanımlar
        
        string TimeOutMs;
        StringBuilder sb = new StringBuilder();
        TcpClient tcpSocket;
        SqlConnection baglanti;
        Ping pinger = new Ping();
        PingReply PingReply;
        string DBIP = "192.168.0.111";
        SqlCommand command1 = new SqlCommand();
        string x;
        string y;
        string t;
        string z;
        string a;
        string b;
        string c;
        string d;
        int Periyot;
        IniFile IniFile = new IniFile("D:\\Settings.ini");
        string ipadr;
        string ipadr1;
        string ipadr2;
        string ipadr3;
        string kanal;
        string kanal1;
        string kanal2;
        string kanal3;




        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'lazerHatalariDataSet.Hatalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.hatalarTableAdapter.Fill(this.lazerHatalariDataSet.Hatalar);



            TimeOutMs = IniFile.IniReadValue("ZamanAyarlari", "Periyot");

            try
            {
                timer1.Interval = Convert.ToInt32(IniFile.IniReadValue("ZamanAyarlari", "Periyot"));

                ipadr = IniFile.IniReadValue("IPAdresleri", "IP1");
                ipadr1 = IniFile.IniReadValue("IPAdresleri", "IP2");
                ipadr2 = IniFile.IniReadValue("IPAdresleri", "IP3");
                ipadr3 = IniFile.IniReadValue("IPAdresleri", "IP4");

                kanal = IniFile.IniReadValue("KanalIsimleri", "Kanal-1");
                kanal1 = IniFile.IniReadValue("KanalIsimleri", "Kanal-2");
                kanal2 = IniFile.IniReadValue("KanalIsimleri", "Kanal-3");
                kanal3 = IniFile.IniReadValue("KanalIsimleri", "Kanal-4");

            }
            catch (Exception hataTuru)
            {
                HataLbl.Text = "E356 Ini Dosyası Okunamadı" + hataTuru;
            }

            baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
            vt_baglanti_ac();


            //dataGridView1.DataSource = "null";



        }


        public void HataKaydet(string kanal, DateTime tarihSaat,  string x, string y, double hedefCap)
        {


            
            try
            {
                command1.Parameters.Clear();
                command1.Connection = baglanti;
                
                command1.Parameters.AddWithValue("@tarihSaat", "tarihSaat");
                command1.Parameters.AddWithValue("@kanal", "kanal");
                command1.Parameters.AddWithValue("@x", "x");
                command1.Parameters.AddWithValue("@y", "y");
                command1.Parameters.AddWithValue("@hedefCap", "hedefCap");
               
               
                command1.CommandText = "insert into Hatalar (kanal, tarihSaat, x, y,hedefCap)  VALUES(@kanal, @tarihSaat, @x, @y, @hedefCap)";
                command1.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }









        }

        public void Son10Hata()
        {
            
             
                SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
                baglanti.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP (10) * from Hatalar where kanal='" + kanal + "'   ORDER BY  tarihSaat DESC;", baglanti);
                baglanti.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            catch (Exception)
            {
                UyariLbl.Text = "veri tabanına ulaşılamıyor";
            }



        }
        public void Son10Hata1()
        {
            
               SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
                baglanti.Open();
            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter("Select TOP (10) * from Hatalar where kanal='" + kanal1 + "'   ORDER BY  tarihSaat DESC;", baglanti);
                baglanti.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            catch (Exception)
            {
                UyariLbl1.Text = "veri tabanına ulaşılamıyor";
            }

        }

        public void Son10Hata2()
        {
            
           

                SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
                baglanti.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP (10) * from Hatalar where kanal='" + kanal2 + "'   ORDER BY  tarihSaat DESC;", baglanti);
                baglanti.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                UyariLbl2.Text = "veri tabanına ulaşılamıyor";
            }
            
        }

            public void Son10Hata3()
        {
            
            
                SqlConnection baglanti = new SqlConnection("Data Source=192.168.0.111;Initial Catalog=LazerHatalari;User ID=sa;Password=a123456*");
                baglanti.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP (10) * from Hatalar where kanal='" + kanal3 + "'   ORDER BY  tarihSaat DESC;", baglanti);
                baglanti.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception)
            {
                UyariLbl3.Text = "veri tabanına ulaşılamıyor";
            }
        }

        public void LazerOku(object ipadr, ref string x, ref string y)
        {
            try
            {

                Int32 port = 23;

                tcpSocket = new TcpClient(ipadr.ToString(), port);
                sb.Clear();
                Write(("E" + Convert.ToString("\n")));
                // oku
                System.Threading.Thread.Sleep(Convert.ToInt32(TimeOutMs));


                while ((tcpSocket.Available > 0))
                {

                    int input = tcpSocket.GetStream().ReadByte();
                    sb.Append(((char)(input)));

                }
               
                x = sb.ToString();
                sb.Clear();
                System.Threading.Thread.Sleep(Convert.ToInt32(TimeOutMs));
                Write(("D" + Convert.ToString("\n")));
                // oku
                System.Threading.Thread.Sleep(Convert.ToInt32(TimeOutMs));

                while ((tcpSocket.Available > 0))
                {

                    int input = tcpSocket.GetStream().ReadByte();
                    sb.Append(((char)(input)));

                }
                
                y = sb.ToString();
                tcpSocket.Close();


            }
            catch (Exception) { }



        }
        public void Write(string cmd)
        {
            if (!tcpSocket.Connected)
            {
                return;
            }

            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace((Convert.ToChar(0x0).ToString() + "xFF"), (Convert.ToChar(0x0).ToString() + "xFF") + (Convert.ToChar(0x0).ToString() + "xFF")));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }



        public void vt_baglanti_ac()
        {
            // Balant1n1n a�1k olup olmad11n1n kontrol�
            if ((baglanti.State != ConnectionState.Open))
            {
                try
                {
                    PingReply = pinger.Send(DBIP, Convert.ToInt32(TimeOutMs));
                    if (((PingReply.Status.ToString() == "TimedOut")
                                || (PingReply.Status.ToString() == "DestinationHostUnreachable")))
                    {
                        HataLbl.Text = "E352 Veri Tabanına Ulaşılamıyor -Ping";
                    }
                    else
                    {
                        try
                        {
                            baglanti.Open();
                        }
                        catch (Exception)
                        {
                            HataLbl.Text = "E352 Veri Taban1na Ulaşılamıyor";
                            return;
                        }

                    }

                }
                catch (Exception)
                {
                }

            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {



            //dataGridView1.Refresh();

            //dataGridView2.Refresh();




            Son10Hata();
            Son10Hata1();
            Son10Hata2();
            Son10Hata3();




            //vt_baglanti_ac();

            if ((HataLbl.Text != "E352 Veri Taban1na Ulaşılamıyor -Ping"))
             {
                 HataLbl.Text = "";
             }

             vt_baglanti_ac();
             if ((UyariLbl.Text == "Lazer ölçüm Hatas1"))
             {
                 UyariLbl.Text = "";
             }

             if ((UyariLbl.Text == "IP Adresine Ulaşılamıyor"))
             {
                 UyariLbl.Text = "";
             }

             if ((UyariLbl.Text == "IP Adresi Tanımlı Değil"))
             {
                 UyariLbl.Text = "";
             }
            command1.Parameters.Clear();
            command1.Connection = baglanti;
            command1.Parameters.AddWithValue("@tarihSaat", "tarihSaat");
            command1.Parameters.AddWithValue("@kanal", "kanal");
            command1.Parameters.AddWithValue("@x", "x");
            command1.Parameters.AddWithValue("@y", "y");
            command1.Parameters.AddWithValue("@hedefCap", "hedefCap");


            //ip
            try
            {
                if ((ipadr != ""))
                {
                    PingReply = pinger.Send(ipadr, Convert.ToInt32(TimeOutMs));
                    if (((PingReply.Status.ToString() == "TimedOut")
                                || (PingReply.Status.ToString() == "DestinationHostUnreachable")))
                    {
                        UyariLbl.Text = "IP Adresine Ulaşılamıyor";

                    }
                    else
                    {
                        

                        LazerOku(ipadr, ref x, ref y);
                        if (((x != "") && (y != "")))
                        {
                            x = x.Replace("E", "");
                            x = (x.Substring(0, 1) + ("," + x.Substring(1, 4)));
                            y = y.Replace("D", "");
                            y = (y.Substring(0, 1) + ("," + y.Substring(1, 4)));

                            xlbl.Text = ((Convert.ToDouble(x) + Convert.ToDouble(y)) / 2).ToString("F4");
                            ylbl.Text = Math.Abs(Convert.ToDouble(x) - Convert.ToDouble(y)).ToString("F4");
                            
                                if ((capTxt.Text != "" && maxTxt.Text != "" && minTxt.Text != "" && ovaliteTxt.Text != ""))
                                {



                                    if (Convert.ToDouble(xlbl.Text) > Convert.ToDouble(minTxt.Text) && Convert.ToDouble(xlbl.Text) < Convert.ToDouble(maxTxt.Text) && Convert.ToDouble(ylbl) > Convert.ToDouble(ovaliteTxt.Text))
                                    {


                                        panel2.Visible = false;
                                        panel3.Visible = true;



                                    }
                                    else
                                    {



                                        panel3.Visible = false;
                                        panel2.Visible = true;


                                        //HataKaydet(kanal, DateTime.Now, Convert.ToDouble(x) , Convert.ToDouble(y), Convert.ToDouble(capTxt.Text), Convert.ToDouble(hataTxt.Text));
                                        command1.Parameters.Clear();

                                        command1.Connection = baglanti;
                                        command1.CommandText = "insert into Hatalar(kanal, tarihSaat, x, y,hedefCap)  VALUES('" + kanal + "' ,'" + DateTime.Now + "' , '" + xlbl.Text + "' , '" + ylbl.Text + "','" + capTxt.Text + "')";
                                        command1.Parameters.AddWithValue("@tarihSaat", DateTime.Now);
                                        command1.Parameters.AddWithValue("@kanal", kanal);
                                        command1.Parameters.AddWithValue("@x", xlbl.Text);
                                        command1.Parameters.AddWithValue("@y", ylbl.Text);
                                        command1.Parameters.AddWithValue("@hedefCap", capTxt.Text);


                                        command1.ExecuteNonQuery();


                                    }
                                }
                          



                        }
                    }
                }
                else
                {
                    UyariLbl.Text = "IP Adresi Tanımlı Değil";
                }
               
            }

            catch (Exception)
            {
                HataLbl.Text = "E379 Line1-Emayesiz Lazer Okuma Hatası";
            }
            

            //ip1


            try
            {
                if ((ipadr1 != ""))
                {
                    PingReply = pinger.Send(ipadr1, Convert.ToInt32(TimeOutMs));
                    if (((PingReply.Status.ToString() == "TimedOut")
                                || (PingReply.Status.ToString() == "DestinationHostUnreachable")))
                    {
                        UyariLbl1.Text = "IP Adresine Ulaşılamıyor";

                    }
                    else
                    {
   
                        LazerOku(ipadr1, ref t, ref z);
                        if (((t != "") && (z != "")))
                        {
                            t = t.Replace("E", "");
                            t = (t.Substring(0, 1) + ("," + t.Substring(1, 4)));
                            z = z.Replace("D", "");
                            z = (z.Substring(0, 1) + ("," + z.Substring(1, 4)));

                            xlbl1.Text = ((Convert.ToDouble(t) + Convert.ToDouble(z)) / 2).ToString("F4");
                            ylbl1.Text = Math.Abs(Convert.ToDouble(t) - Convert.ToDouble(z)).ToString("F4");
                            if ((capTxt1.Text != "" && maxTxt1.Text != "" && minTxt1.Text != "" && ovaliteTxt1.Text != ""))
                            {



                                if (Convert.ToDouble(xlbl1.Text) > Convert.ToDouble(minTxt1.Text) && Convert.ToDouble(xlbl1.Text) < Convert.ToDouble(maxTxt1.Text) && Convert.ToDouble(ylbl1) > Convert.ToDouble(ovaliteTxt1.Text))
                                {


                                    panel4.Visible = false;
                                    panel7.Visible = true;



                                }
                                else
                                {



                                    panel7.Visible = false;
                                    panel4.Visible = true;


                                    //HataKaydet(kanal, DateTime.Now, Convert.ToDouble(x) , Convert.ToDouble(y), Convert.ToDouble(capTxt.Text), Convert.ToDouble(hataTxt.Text));
                                    command1.Parameters.Clear();

                                    command1.Connection = baglanti;
                                    command1.CommandText = "insert into Hatalar(kanal, tarihSaat, x, y,hedefCap)  VALUES('" + kanal1 + "' ,'" + DateTime.Now + "' , '" + xlbl1.Text + "' , '" + ylbl1.Text + "','" + capTxt1.Text + "')";
                                    command1.Parameters.AddWithValue("@tarihSaat", DateTime.Now);
                                    command1.Parameters.AddWithValue("@kanal", kanal1);
                                    command1.Parameters.AddWithValue("@x", xlbl1.Text);
                                    command1.Parameters.AddWithValue("@y", ylbl1.Text);
                                    command1.Parameters.AddWithValue("@hedefCap", capTxt1.Text);


                                    command1.ExecuteNonQuery();


                                }
                            }


                        }
                    }
                }
                else
                {
                    UyariLbl1.Text = "IP Adresi Tanımlı Değil";
                }
                
            }



            catch (Exception)
            {
                HataLbl1.Text = "E379 Line2-Emayesiz Lazer Okuma Hatası";
            }
            

            //ip2

            try
            {
                if ((ipadr2 != ""))
                {
                    PingReply = pinger.Send(ipadr2, Convert.ToInt32(TimeOutMs));
                    if (((PingReply.Status.ToString() == "TimedOut")
                                || (PingReply.Status.ToString() == "DestinationHostUnreachable")))
                    {
                        UyariLbl2.Text = "IP Adresine Ulaşılamıyor";

                    }
                    else
                    {

                        LazerOku(ipadr2, ref a, ref b);
                        if (((a != "") && (b != "")))
                        {
                            a = a.Replace("E", "");
                            a = (a.Substring(0, 1) + ("," + a.Substring(1, 4)));
                            b = b.Replace("D", "");
                            b = (b.Substring(0, 1) + ("," + b.Substring(1, 4)));

                            xlbl2.Text = ((Convert.ToDouble(a) + Convert.ToDouble(b)) / 2).ToString("F4");
                            ylbl2.Text = Math.Abs(Convert.ToDouble(a) - Convert.ToDouble(b)).ToString("F4");
                            if ((capTxt2.Text != "" && maxTxt2.Text != "" && minTxt2.Text != "" && ovaliteTxt2.Text != ""))
                            {



                                if (Convert.ToDouble(xlbl2.Text) > Convert.ToDouble(minTxt2.Text) && Convert.ToDouble(xlbl2.Text) < Convert.ToDouble(maxTxt2.Text) && Convert.ToDouble(ylbl2) > Convert.ToDouble(ovaliteTxt2.Text))
                                {


                                    panel5.Visible = false;
                                    panel8.Visible = true;



                                }
                                else
                                {



                                    panel8.Visible = false;
                                    panel5.Visible = true;


                                    //HataKaydet(kanal, DateTime.Now, Convert.ToDouble(x) , Convert.ToDouble(y), Convert.ToDouble(capTxt.Text), Convert.ToDouble(hataTxt.Text));
                                    command1.Parameters.Clear();

                                    command1.Connection = baglanti;
                                    command1.CommandText = "insert into Hatalar(kanal, tarihSaat, x, y,hedefCap)  VALUES('" + kanal2 + "' ,'" + DateTime.Now + "' , '" + xlbl2.Text + "' , '" + ylbl2.Text + "','" + capTxt2.Text + "')";
                                    command1.Parameters.AddWithValue("@tarihSaat", DateTime.Now);
                                    command1.Parameters.AddWithValue("@kanal", kanal2);
                                    command1.Parameters.AddWithValue("@x", xlbl2.Text);
                                    command1.Parameters.AddWithValue("@y", ylbl2.Text);
                                    command1.Parameters.AddWithValue("@hedefCap", capTxt2.Text);


                                    command1.ExecuteNonQuery();


                                }
                            }


                        }
                    }
                }
               
                else
                {
                    UyariLbl2.Text = "IP Adresi Tanımlı Değil";
                }
               
            }


            catch (Exception)
            {
                HataLbl2.Text = "E379 Line3-Emayesiz Lazer Okuma Hatası";
            }
           

            //ip3

            try
            {
                if ((ipadr3 != ""))
                {
                    PingReply = pinger.Send(ipadr3, Convert.ToInt32(TimeOutMs));
                    if (((PingReply.Status.ToString() == "TimedOut")
                                || (PingReply.Status.ToString() == "DestinationHostUnreachable")))
                    {
                        UyariLbl3.Text = "IP Adresine Ulaşılamıyor";

                    }
                    else
                    {
             


                        LazerOku(ipadr3, ref c, ref d);
                        if (((c != "") && (d != "")))
                        {
                            c = c.Replace("E", "");
                            c = (c.Substring(0, 1) + ("," + c.Substring(1, 4)));
                            d = d.Replace("D", "");
                            d = (d.Substring(0, 1) + ("," + d.Substring(1, 4)));

                            xlbl3.Text = ((Convert.ToDouble(c) + Convert.ToDouble(d)) / 2).ToString("F4");
                            ylbl3.Text = Math.Abs(Convert.ToDouble(c) - Convert.ToDouble(d)).ToString("F4");
                            if ((capTxt3.Text != "" && maxTxt3.Text != "" && minTxt3.Text != "" && ovaliteTxt3.Text != ""))
                            {



                                if (Convert.ToDouble(xlbl3.Text) > Convert.ToDouble(minTxt3.Text) && Convert.ToDouble(xlbl3.Text) < Convert.ToDouble(maxTxt3.Text) && Convert.ToDouble(ylbl3) > Convert.ToDouble(ovaliteTxt3.Text))
                                {


                                    panel6.Visible = false;
                                    panel9.Visible = true;



                                }
                                else
                                {



                                    panel9.Visible = false;
                                    panel6.Visible = true;


                                    //HataKaydet(kanal, DateTime.Now, Convert.ToDouble(x) , Convert.ToDouble(y), Convert.ToDouble(capTxt.Text), Convert.ToDouble(hataTxt.Text));
                                    command1.Parameters.Clear();

                                    command1.Connection = baglanti;
                                    command1.CommandText = "insert into Hatalar(kanal, tarihSaat, x, y,hedefCap)  VALUES('" + kanal3 + "' ,'" + DateTime.Now + "' , '" + xlbl3.Text + "' , '" + ylbl3.Text + "','" + capTxt3.Text + "')";
                                    command1.Parameters.AddWithValue("@tarihSaat", DateTime.Now);
                                    command1.Parameters.AddWithValue("@kanal", kanal3);
                                    command1.Parameters.AddWithValue("@x", xlbl3.Text);
                                    command1.Parameters.AddWithValue("@y", ylbl3.Text);
                                    command1.Parameters.AddWithValue("@hedefCap", capTxt3.Text);


                                    command1.ExecuteNonQuery();


                                }
                            }


                        }
                    }
                   
                }

                else
                {
                    UyariLbl3.Text = "IP Adresi Tanımlı Değil";
                }

            }


            catch (Exception)
            {
                HataLbl3.Text = "E379 Line4-Emayesiz Lazer Okuma Hatası";
            }
          














        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            frm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
        }

       

        private void Xlbl_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm1 = new Form3();
            frm1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm2 = new Form4();
            frm2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 frm3 = new Form5();
            frm3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 frm4 = new Form6();
            frm4.Show();
        }
    }



}