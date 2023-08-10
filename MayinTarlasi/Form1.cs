using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<field> fieldList = new List<field>();
        List<mine> mineList = new List<mine>();

        public class field
        {
            public int x { get; set; }

            public int y { get; set; }

            public bool IsItBomb { get; set; }

            public Button button { get; set; }
        }
        
        public class mine
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (true)
            {
                MessageBox.Show("Patladı");
            }
            else
            {
                MessageBox.Show("Temiz");
            }
            
        }

        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            pnl_buttonPanel.Controls.Clear();
            fieldList.Clear();

            //defult olarak 5 ayın var
            int mineCount = 5;
            if (tb_MineCount.Text == string.Empty)
            {
                mineCount = 5;
                
            }
            else
            {
                mineCount = int.Parse(tb_MineCount.Text);
            }
            
            
            
            //Mine Count kadar mine oluşturukuyor
            for (int i = 0; i < mineCount; i++)
            {
                mine _mine = new mine();
                mineList.Add(_mine);
            }

            // Creating Buttons and field Objects
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    field _field = new field();
                    _field.x = x;
                    _field.y = y;

                    Button btn = new Button();

                    pnl_buttonPanel.Controls.Add(btn);
                    btn.Size = new Size(20, 20);
                    btn.Location = new Point(20 * x, 20 * y);
                    btn.Click += new EventHandler(button_Click);
                    _field.button = btn;

                    fieldList.Add(_field);
                }
            }

            Random rnd = new Random();
            List<int> templist = new List<int>();
            for (int i = 0; i < mineCount; i++)
            {
                int temp = rnd.Next(0, 100);
                if (!templist.Contains(temp))
                {
                    templist.Add(temp);
                    fieldList[temp].button.BackColor = Color.Red;
                }
                else
                {
                    i--;
                }

            }
            
            
        }
    }
}
