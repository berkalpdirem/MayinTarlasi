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



namespace MayinTarlasi
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        field[,] GameMatrix = new field[10, 10];
        List<(int, int)> MineCoordinates = new List<(int, int)>();
        int min;
        int sec;

        //--------------------------------------------------------
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
                    if (x != -1 && x != 10 && y != -1 && y != 10 && GameMatrix[x, y].IsItBomb)
                    {
                        count++;
                        selectedField.button.Text = count.ToString();
                    }

                }
            }
        }

        /// <summary>
        /// Shows the location of the mines after the game is over 
        /// </summary>
        public void ShowMines()
        {
            for (int i = 0; i < MineCoordinates.Count; i++)
            {
                (int tempX, int tempY) = MineCoordinates[i];
                GameMatrix[tempX, tempY].button.BackColor = Color.Red;
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
                    btn.Click += new EventHandler(button_Click);
                    btn.Tag = _field;
                    _field.button = btn;
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
        #endregion


        //---------------------------------------------------------
        #region Button Events
        /// <summary>
        /// GamePanel's buttons behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            field _field = btn.Tag as field;
            if (_field.IsItBomb)
            {
                MessageBox.Show("Boom");
                ShowMines();
            }
            else
            {
                btn.BackColor = Color.Green;
                ScanFields(btn);

            }

        }

        /// <summary>
        /// Get MineCount and Start Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            pnl_buttonPanel.Controls.Clear();
            MineCoordinates.Clear();
            gbTimeWarning.Visible = false;
            min = 0;
            sec = 0;
            if (int.TryParse(tb_MineCount.Text, out int mineCount) && int.Parse(tb_MineCount.Text) < 101)
            {
                if ((numericUpDownMin.Value < 0 && numericUpDownSecond.Value <= 1))
                {
                    MessageBox.Show("Lütfen Oynayacağınız Süreyi Dakika ve Saniye Cinsinden Giriniz !!!");
                }
                else
                {
                    min = Convert.ToInt32(numericUpDownMin.Value);
                    sec = Convert.ToInt32(numericUpDownSecond.Value);
                    mineCount = int.Parse(tb_MineCount.Text);
                    
                    timer1.Start();
                    StartGame(mineCount);
                    gbTimeWarning.Visible = true;

                }

            }
            else
            {
                MessageBox.Show("Lütfen Mayın Sayısına, 0'dan 100'e Kadar Herhangi Bir Sayısal Değer Girin!!!");
            }

        }

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
                MessageBox.Show("Süre Bitti !!!");
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


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
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
    }
}

