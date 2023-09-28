using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }
        EntityProjeEntities db = new EntityProjeEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==textBox1.Text.ToLower()) {
                var sorgu = from x in db.admin where x.Kullanıcı == textBox1.Text && x.Sifre == textBox2.Text select x; // x bir değişkendir ve tablo içine ulaşmak için x i tabloya ait gösteriyoruz ve x. diyince tablo içindekilere ulaşabiliyoruz
                if (sorgu.Any())
                {
                    FrmAnaForm fr = new FrmAnaForm();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı giriş yapıldı.");
                }
            }
            else
            {
                MessageBox.Show("Hatalı giriş yapıldı.");
            }
            
        }
    }
}
