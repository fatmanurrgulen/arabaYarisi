using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buton_Yarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Button click olaylarına ilgili olay işleyicileri ekleniyor
            button_yaris_1.Click += Button_yaris_1_Click;
            button_yaris_2.Click += Button_yaris_2_Click;
            button_yaris_3.Click += Button_yaris_3_Click;
        }

        /*
         * C# ARABA YARIŞI OYUNU
         */

        // Yarışçı seçildiğinde seçilen yarışçı numarasını label'a yazdırır
        private void Button_yaris_1_Click(object sender, EventArgs e)
        {
            label1.Text = "1 Numara";
        }

        private void Button_yaris_2_Click(object sender, EventArgs e)
        {
            label1.Text = "2 Numara";
        }

        private void Button_yaris_3_Click(object sender, EventArgs e)
        {
            label1.Text = "3 Numara";
        }

        // Rastgele sayı üretmek için kullanılacak Random sınıfı örneği oluşturuluyor
        Random rnd = new Random();

        // Yarışçıların başlangıç noktalarını saklamak için değişkenler tanımlanıyor
        int btn1x, btn1y, btn2x, btn2y, btn3x, btn3y;

        // mesajver sınıfından bir örnek oluşturuluyor
        mesajver mesaj = new mesajver();

        // Yarışçıları başlangıç noktalarına götürmek için kullanılan metot
        private void eskikonum()
        {
            // Yarışçıların başlangıç konumlarına ayarlanıyor
            button_yaris_1.Location = new Point(btn1x, btn1y);
            button_yaris_2.Location = new Point(btn2x, btn2y);
            button_yaris_3.Location = new Point(btn3x, btn3y);

            // Butonların ve label'ın etkinlikleri (Enabled) açılıyor
            button1.Enabled = true;
            button_yaris_1.Enabled = true;
            button_yaris_2.Enabled = true;
            button_yaris_3.Enabled = true;

            // Label metni temizleniyor
            label1.Text = "";
        }

        // Timer tick olayı gerçekleştiğinde çalışacak olan metot
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Her yarışçı için bir sonraki konumu belirlemek için rasgele sayılar oluşturuluyor
            int konum1 = rnd.Next(2, 10);
            int konum2 = rnd.Next(2, 10);
            int konum3 = rnd.Next(2, 10);

            // Yarışçılardan herhangi biri bitiş çizgisini geçtiyse (yarış bitti)
            if (button_yaris_1.Right > label_bitis.Left || button_yaris_2.Right > label_bitis.Left || button_yaris_3.Right > label_bitis.Left)
            {
                // Yarışçı 1 diğerlerinden öndeyse
                if (button_yaris_1.Right > button_yaris_2.Right && button_yaris_1.Right > button_yaris_3.Right)
                {
                    // Doğru tahmin yapılırsa
                    if (label1.Text == "1 Numara")
                    {
                        timer1.Stop();
                        mesaj.mesajgetir("Tebrikler doğru tahmin.");
                        eskikonum();
                    }
                    else
                    {
                        // Yanlış tahmin yapılırsa
                        timer1.Stop();
                        mesaj.mesajgetir("Seçtiğiniz araba gelmedi. Kazanan 1 Numara.");
                        eskikonum();
                    }
                }
                // Yarışçı 2 diğerlerinden öndeyse
                else if (button_yaris_2.Right > button_yaris_1.Right && button_yaris_2.Right > button_yaris_3.Right)
                {
                    // Doğru tahmin yapılırsa
                    if (label1.Text == "2 Numara")
                    {
                        timer1.Stop();
                        mesaj.mesajgetir("Tebrikler doğru tahmin.");
                        eskikonum();
                    }
                    else
                    {
                        // Yanlış tahmin yapılırsa
                        timer1.Stop();
                        mesaj.mesajgetir("Seçtiğiniz araba gelmedi. Kazanan 2 Numara.");
                        eskikonum();
                    }
                }
                // Yarışçı 3 diğerlerinden öndeyse
                else if (button_yaris_3.Right > button_yaris_1.Right && button_yaris_3.Right > button_yaris_2.Right)
                {
                    // Doğru tahmin yapılırsa
                    if (label1.Text == "3 Numara")
                    {
                        timer1.Stop();
                        mesaj.mesajgetir("Tebrikler doğru tahmin.");
                        eskikonum();
                    }
                    else
                    {
                        // Yanlış tahmin yapılırsa
                        timer1.Stop();
                        mesaj.mesajgetir("Seçtiğiniz araba gelmedi. Kazanan 3 Numara.");
                        eskikonum();
                    }
                }
                else
                {
                    // Yarışı kimse kazanmadıysa (yarış berabere)
                    timer1.Stop();
                    eskikonum();
                }
            }
            else
            {
                // Yarış hala bitmediyse, yarışçıları sağa doğru rasgele sayılarla ilerlet
                button_yaris_1.Location = new Point(button_yaris_1.Location.X + konum1, button_yaris_1.Location.Y);
                button_yaris_2.Location = new Point(button_yaris_2.Location.X + konum2, button_yaris_2.Location.Y);
                button_yaris_3.Location = new Point(button_yaris_3.Location.X + konum3, button_yaris_3.Location.Y);
            }
        }

        // Başlat butonuna tıklandığında çalışacak olan metot
        private void button1_Click(object sender, EventArgs e)
        {
            // Yarışçıların başlangıç konumları saklanıyor
            btn1x = button_yaris_1.Location.X;
            btn1y = button_yaris_1.Location.Y;
            btn2x = button_yaris_2.Location.X;
            btn2y = button_yaris_2.Location.Y;
            btn3x = button_yaris_3.Location.X;
            btn3y = button_yaris_3.Location.Y;

            // Araba seçilmediyse
            if (label1.Text == "" || label1.Text == "Araba seçiniz.")
            {
                label1.Text = "Araba seçiniz.";
            }
            else
            {
                // Araba seçildiyse, seçimleri kapat ve yarışı başlat
                button_yaris_1.Enabled = false;
                button_yaris_2.Enabled = false;
                button_yaris_3.Enabled = false;
                button1.Enabled = false;
                timer1.Start();
            }
        }
    }
}
