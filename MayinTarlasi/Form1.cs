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
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace MayinTarlasi
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //--------------------------------------------------------/Global Variables/---------------------------------------------------------
        field[,] GameMatrix = new field[10, 10];
        List<(int, int)> MineCoordinates = new List<(int, int)>();
        int min;
        int sec;
        int clearField = 0;
        int mineCount = 0;
        Bitmap MineImage = MayinTarlasi.Properties.Resources.mine;
        Bitmap FlagImage = MayinTarlasi.Properties.Resources.flag;

        //--------------------------------------------------------/Methods/---------------------------------------------------------
        #region Methods
        /// <summary>
        /// Scans the surrounding fields of the selected region 
        /// </summary>
        /// <param name="RelatedButton"></param>
        public void ScanFields(Button RelatedButton)
        {
            List<field> neighborsList = new List<field>();

            field selectedField = RelatedButton.Tag as field;
            int xDownBorder = selectedField.x - 1;
            int xUpBorder = selectedField.x + 1;

            int yDownBorder = selectedField.y - 1;
            int yUpBorder = selectedField.y + 1;

            int count = 0;
            for (int y = yDownBorder; y <= yUpBorder; y++)
            {

                for (int x = xDownBorder; x <= xUpBorder; x++)
                {
                    // x 'in ve y'nin -1 ve 10 koşulları matrix sınırından çıktığı için baştan elemine ediliyor.
                    if (x != -1 && x != 10 && y != -1 && y != 10 && GameMatrix[x, y].IsItBomb)
                    {
                        count++;
                        selectedField.button.Text = count.ToString();
                    }
                }
            }
        }
        
        /// <summary>
        /// Puts the given photo in the given x-y coordinates at the zoom settings
        /// </summary>
        /// <param name="tempX"></param>
        /// <param name="tempY"></param>
        /// <param name="Image"></param>
        public void changeButtonImage(int tempX , int tempY , Bitmap Image)
        {
            Bitmap zoomedImage = new Bitmap(50, 50);
            using (Graphics graphics = Graphics.FromImage(zoomedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(Image, 0, 0, 50, 50);
            }
            GameMatrix[tempX, tempY].button.BackgroundImage = zoomedImage;
        }

        /// <summary>
        /// Shows the location of the mines after the game is over 
        /// </summary> 
        public void ShowMines()
        {
            for (int i = 0; i < MineCoordinates.Count; i++)
            {
                (int tempX, int tempY) = MineCoordinates[i];
                changeButtonImage(tempX, tempY, MineImage);
            }
        }

        /// <summary>
        /// Creating Game Panel and seting mines
        /// </summary>
        /// <param name="mineCount"></param>
        public void StartGame(int mineCount)
        {
            // Creating Buttons and field Objects
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    //Creating Fields
                    field _field = new field();
                    _field.x = x;
                    _field.y = y;

                    //Creating Buttons
                    Button btn = new Button();
                    pnl_buttonPanel.Controls.Add(btn);
                    btn.Size = new Size(50, 50);
                    btn.Location = new Point(50 * x, 50 * y);
                    btn.Tag = _field;
                    _field.button = btn;
                    btn.MouseDown += new MouseEventHandler(button_MouseClick);
                    
                    
                    //btn.Text = x.ToString() + " " + y.ToString();
                    // Creating GameMatrix
                    GameMatrix[x, y] = _field;
                }
            }

            // Add mines to fields
            Random rnd = new Random();
            for (int i = 0; i < mineCount; i++)
            {
                int tempX = rnd.Next(0, 10);
                int tempY = rnd.Next(0, 10);
                (int, int) tempTuple = (tempX, tempY);

                if (!MineCoordinates.Contains(tempTuple))
                {
                    MineCoordinates.Add(tempTuple);
                    GameMatrix[tempX, tempY].IsItBomb = true;
                    GameMatrix[tempX, tempY].button.BackColor = Color.Black;
                }
                else
                {
                    i--;
                }
            }
        }
        /// <summary>
        /// Clear variables and inputs for new game
        /// </summary>
        public void newGameSettings()
        {
            gbInputPanel.Enabled = true;
            pnl_buttonPanel.Controls.Clear();
            MineCoordinates.Clear();
            gbTimeWarning.Visible = false;
            timer1.Stop();
        
            min = 0;
            sec = 0;
        }

        #endregion
        

        //---------------------------------------------------------/Button Eventes/---------------------------------------------------------
        #region Button Events
        

        /// <summary>
        /// Get MineCount and Start Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            newGameSettings();
            gbInputPanel.Enabled = false;
            if (int.TryParse(tb_MineCount.Text, out int mineCount) && int.Parse(tb_MineCount.Text) < 101)
            {
                if (numericUpDownMin.Value < 0 || numericUpDownSecond.Value < 0 )
                {
                    MessageBox.Show("Lütfen Oynayacağınız Süreyi Dakika ve Saniye Cinsinden Giriniz !!!");
                    gbInputPanel.Enabled = true;
                }
                else if (numericUpDownMin.Value == 0 && numericUpDownSecond.Value < 30)
                {
                    MessageBox.Show("Lütfen Oynayacağınız Süreyi Minumum 30 Saniye Giriniz !!!");
                    gbInputPanel.Enabled=true;
                }
                else
                {
                    min = Convert.ToInt32(numericUpDownMin.Value);
                    sec = Convert.ToInt32(numericUpDownSecond.Value);
                    mineCount = int.Parse(tb_MineCount.Text);
                    lblMineCount.Text = mineCount.ToString();

                    timer1.Start();
                    StartGame(mineCount);
                    gbTimeWarning.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Mayın Sayısına, 0'dan 100'e Kadar Herhangi Bir Sayısal Değer Girin!!!");
                gbInputPanel.Enabled = true;
            }
        }

        /// <summary>
        /// Actions of mouse right click and left click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Fare ile sol tıklama eventi
            {
                Button btn = sender as Button;
                field _field = btn.Tag as field;
                // İlk koşul bombya oturma koşulu
                if (_field.IsItBomb)
                {
                    timer1.Stop();
                    MessageBox.Show("BOOM\nKaybettiniz. Mayın bilgileri 10 saniye ekranınıza yansıtılacak");
                    ShowMines();
                    Thread.Sleep(10000);
                    if (MessageBox.Show("Yeniden  Oynamak istermisiniz ?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        newGameSettings();
                    else
                        Application.Exit();
                }
                //İkinci koşul temiz alana denk gelme koşulu
                else if (btn.BackColor != Color.Green && !_field.IsClicked)
                {
                    _field.IsClicked = true;
                    btn.BackgroundImage = null;
                    btn.BackColor = Color.Green;
                    ScanFields(btn);
                    clearField++;
                    mineCount = int.Parse(lblMineCount.Text);
                    if((100 - (mineCount + clearField) == 0))
                    {
                        timer1.Stop();
                        if (MessageBox.Show("Tebrikler Tüm Temiz Alanları Tespit Ettiniz ve Kazandınız !!!\nYeniden  Oynamak istermisiniz ?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            newGameSettings();
                        else
                            Application.Exit();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right) // Fare ile sağ tıklama eventi
            {
                Button clickedButton = sender as Button;
                field _field = clickedButton.Tag as field;

                if (!_field.IsClicked)
                {
                    // Arka planı bayrak resmi ile güncelle
                    changeButtonImage(_field.x, _field.y, FlagImage);
                }

                _field.IsClicked = true;

                // Mayın Tespit Edildiğinde MineCount azaltılır.
                if (_field.IsItBomb)
                {
                    lblMineCount.Text = (int.Parse(lblMineCount.Text) - 1).ToString();
                    if (lblMineCount.Text == "0")
                    {
                        timer1.Stop();
                        if (MessageBox.Show("Tebrikler Tüm Mayınları Tespit Ettiniz Kazandınız !!!\nYeniden  Oynamak istermisiniz ?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            newGameSettings();
                        
                        else
                            Application.Exit();
                    }
                }
            }
        }
        
        /// <summary>
        /// Time control and updating of the counter every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec / 60 > 0)
            {
                int temp = sec / 60;
                min = min + temp;
                sec = sec % 60;
            }
            if (sec == 0 && min == 0)
            {   
                timer1.Stop();
                lbl_Sec.Text = sec.ToString();
                lbl_Min.Text = min.ToString();
                MessageBox.Show("Süre Bitti\nKaybettiniz. Mayın bilgileri 10 saniye ekranınıza yansıtılacak");
                ShowMines();
                Thread.Sleep(10000);
                if (MessageBox.Show("Yeniden  Oynamak istermisiniz ?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    newGameSettings();
                else
                    Application.Exit();

            }
            if (sec ==0 && min > 0)
            {
                min--;
                sec = sec+60;
            }
            lbl_Sec.Text = sec.ToString();
            lbl_Min.Text = min.ToString();
            sec -= 1;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mayın Tarlası oyununa hoş geldiniz.\n" +
                            "Girilecek Mayın sayısı 0'dan 100'e kadar olmalıdır.\n" +
                            "Girdiğiniz mayın sayısı kadar mayın haritada rastgele bir şekilde oluşur.\n" +
                            "Oynamak istediğiniz süre 30 saniyeden büyük olamlıdır\n\n" +
                            "2 adet kazanma ve kay betme koşulu bulunmaktadır ; \n" +
                            "     -Farenizin sol tıklaması ile alanları açabilirsiniz.Eğer açtığınız alan mayınlı değil ise yeşile döner ve çevresinde kaç adet mayın olduğu bilgisini size geri verir.\n" +
                            "Tüm temiz alanları açar iseniz birinci kazanma koşulunu sağlamış olursunuz.Eğer mayınlı alana sol tıklama yaparsanız mayın patlar ve kaybedersiniz.\n" +
                            "     -Farenizin sağ tıklaması ile alana bayrak ekliyebilirsiniz. Eğer eklemiş olduğunuz bayrak mayınlı bölgeye denk gelir ise Kalan mayın sayısı 1 azaltılır.\n" +
                            "bu şekilde tüm mayınları bulursanız ikinci kazanma koşulunu sağlamış olursunuz.\n" +
                            "Girmiş olduğunuz süre boyunca kazanma koşullarını sağlayamassınız otomatik olarak kaybedersiniz. \n\n" +
                            "ÖNEMLİ NOT: OYUN ALANINDA HER BUTONA SADECE BİR KERE TIKLAYABİLİRSİNİZ.BOL ŞANS :)");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        #endregion
        //---------------------------------------------------------//---------------------------------------------------------

    }

    /// <summary>
    /// Creating field class for keeping mine information
    /// </summary>
    public class field
    {
        public int x { get; set; }

        public int y { get; set; }

        public bool IsItBomb { get; set; }

        public Button button { get; set; }

        public bool IsClicked { get; set; }
    }
}

