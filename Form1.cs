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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EntityProjeEntities db= new EntityProjeEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= db.kategori.ToList();
        }
        kategori t = new kategori();
        private void button4_Click(object sender, EventArgs e)
        {
           
            t.AD = textBox2.Text;
            db.kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi.");
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            var ktgr= Convert.ToInt32(textBox1.Text);
            db.kategori.Remove(db.kategori.Find(ktgr));
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi.");
        }
        //remove metodu içerisine kategori tablosu türünde bir değer bekliyor ama textbox1.text int türünde
        // textbox1 de sadece bir id değeri olduğu için remove içine textbox1.text  yazınca hata veriyor
        //Bu yüzden int den dönüştürüyoruz, sonra find ile ona denk gelen değeri bulup remove içine yazıyoruz
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        { 
           var art = Convert.ToInt32(textBox1.Text);
           db.kategori.Find(art);
           t.AD = textBox2.Text;
           db.SaveChanges();
           MessageBox.Show("Kategori Güncellendi.");
        }
    }
}
