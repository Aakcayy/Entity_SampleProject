using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityProje
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        EntityProjeEntities db=new EntityProjeEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {                                                                                      //b.Urun.ToList(); entity de kullandığımız vakit  ilişkili tablolarda geldiği için aşağıdaki gibi eklersek gözükmezler
            dataGridView1.DataSource= (from x in db.Urun  select new
            {
            x.UrunID,x.UrunAD,x.Marka,x.Stok,x.Fiyat,x.kategori1.AD,x.Durum
            }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun T=new Urun();
            T.UrunAD=txtUrun.Text;
            T.Marka = txtMarka.Text;
            T.Stok = short.Parse(txtStok.Text);
            T.Kategori = int.Parse(cmbKategori.SelectedValue.ToString());
            T.Fiyat = decimal.Parse(txtFiyat.Text);
            T.Durum = true;
            db.Urun.Add(T);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Yüklenmiştir.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var ktgr = Convert.ToInt32(txtID.Text);
            db.Urun.Remove(db.Urun.Find(ktgr));
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi.");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            var art = Convert.ToInt32(txtID.Text);
            db.kategori.Find(art);
           
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi.");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler1=(from x in db.kategori 
                             select new
                {
                  x.ID,x.AD
            }
            ).ToList();
            cmbKategori.DisplayMember = "AD";
            cmbKategori.ValueMember = "ID";
            cmbKategori.DataSource= kategoriler1;
        }
    }
}
