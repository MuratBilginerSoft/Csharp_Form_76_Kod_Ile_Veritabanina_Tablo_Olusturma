using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kod_İle_Veritabanına_Tablo_Oluşturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int sayı = int.Parse(textBox2.Text);

            int y1=-23;

            groupBox2.Visible = true;

            TextBox[] txtbox1=new TextBox[sayı];
            TextBox[] txtbox2 = new TextBox[sayı];
            TextBox[] txtbox3 = new TextBox[sayı];

            for (int i = 0; i < sayı; i++)
            {

                TextBox txt1 = new TextBox();
                TextBox txt2 = new TextBox();
                TextBox txt3 = new TextBox();

                txt1.Size = new Size(130, 20);
                txt2.Size = new Size(130, 20);
                txt3.Size = new Size(130, 20);

                y1=y1+26;
                txt1.Location = new Point(3,y1);
                txt2.Location = new Point(137,y1);
                txt3.Location = new Point(270, y1);

                txtbox1[i] = txt1;
                txtbox2[i] = txt2;
                txtbox3[i] = txt3;


                panel1.Controls.Add(txt1);
                panel1.Controls.Add(txt2);
                panel1.Controls.Add(txt3);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tabloadı = textBox1.Text;
            try
            {
                OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
                bağlantı.Open();
                string sorgu = "Create Table " + tabloadı;
                OleDbCommand komut = new OleDbCommand(sorgu, bağlantı);
                komut.ExecuteNonQuery();
                bağlantı.Dispose();
                bağlantı.Close();

                MessageBox.Show("Başarılı bir şekilde eklendi.");
            }
            catch (Exception)
            {

                MessageBox.Show("Bir hata oluştu.");
            }
        }
    }
}
