using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace english_words
{
    public partial class Form1 : Form
    {
        
        public string aciklama;
        public string key;
        public int dogruSayisi = 0;
        Dictionary<string, string> kelimeler = new Dictionary<string, string>();

        public int sayi;

        public Form1()
        {
            InitializeComponent();
            label2.Text = "doğru sayısı : " + dogruSayisi;
            listBox1.Text = "Bilmediğim kelimeler";
            
            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FormApp\\kelimeler.txt";
            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            
            bool bittiMi = false;
            string kelime;
            string anlami;

            while (!bittiMi)
            {

                kelime = sr.ReadLine().ToLower();
                if (kelime == "bitti")
                {
                    bittiMi = true;
                    break;
                }

                anlami = sr.ReadLine().ToLower();
                kelimeler.Add(kelime, anlami);

            }

            sr.Close();
            Console.WriteLine("ilk kelimeyi yolla");
            kelimeyiDegistir();
        }

        private void output()
        {
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Bilmediklerim.txt";
            StreamWriter sw = new StreamWriter(outputFilePath);
            foreach (var item in listBox1.Items)
            {
                sw.WriteLine(item);
            }

            sw.Close();
        }

        private bool IsEnded
        {
            get
            {
                if (kelimeler.Count == 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        private void kelimeyiDegistir()
        {
            Random rnd = new Random();

            if(!IsEnded)
            {

                int rastgeleSayi = rnd.Next(0, kelimeler.Count);
                label1.Text = kelimeler.ElementAt(rastgeleSayi).Key;
                aciklama = kelimeler.ElementAt(rastgeleSayi).Value;
                key = kelimeler.ElementAt(rastgeleSayi).Key;
                sayi = rastgeleSayi;
                kelimeler.Remove(kelimeler.ElementAt(sayi).Key);
            }

            else
            {
                string text = "Kelimeler Tükendi!";
                MessageBox.Show(text);
                label1.Text = "";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e )
        {
            if (!IsEnded)
            {
           
                if (richTextBox2.Text.ToLower() == aciklama)
                {
                    dogruSayisi++;
                    label2.Text = "doğru sayısı : " + dogruSayisi;
                    richTextBox2.Text = "";
                    kelimeyiDegistir();
        
                }   
            }
        }

        private void listeyeEkle()
        {
            listBox1.Items.Add(aciklama + "  :  " + key);
            label3.Text = "bilmediğim kelimelerin sayısı : " + Convert.ToInt32(listBox1.Items.Count);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (!IsEnded)
            {
                listeyeEkle();
                kelimeyiDegistir();
            }

            else
            {
                string text = "Kelimeler Tükendi!";
                label1.Text = "";
                MessageBox.Show(text);
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            output();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }


    }
}
