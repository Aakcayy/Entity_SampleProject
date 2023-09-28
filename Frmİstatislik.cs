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
    public partial class Frmİstatislik : Form
    {
        public Frmİstatislik()
        {
            InitializeComponent();
        }
        EntityProjeEntities db=new EntityProjeEntities();
        private void Frmİstatislik_Load(object sender, EventArgs e)
        {
            label2.Text = db.kategori.Count().ToString();
            label3.Text = db.Urun.Count().ToString();
            label5.Text = db.Musteri.Count(x => x.Durum == true).ToString(); 
            label7.Text = db.Musteri.Count(x=>x.Durum==false).ToString();
            label13.Text = db.Urun.Sum(y=>y.Stok).ToString(); //y yerine x de olurdu
            label21.Text = db.Satıs.Sum(z => z.Fiyat).ToString()+" TL";
            label11.Text = (from x in db.Urun orderby x.Fiyat descending select x.UrunAD).FirstOrDefault();//Ürün tablosunda sıralama yap neye göre fiyatlarda azalana göre sonra en üstteki değerin bana ürün adını seç ve getir
           //descending=azalan ascending=artan
            label9.Text = (from x in db.Urun orderby x.Fiyat ascending select x.UrunAD).FirstOrDefault();
            label15.Text = db.Urun.Count(y => y.Kategori==1).ToString();//kategori tablosunda 1 numaralı ID de beyaz eşya var
            label17.Text = db.Urun.Count(y => y.UrunAD =="BUZDOLABI").ToString();
            label23.Text = (from x in db.Musteri select x.Sehir).Distinct().Count().ToString();//Şehiri seç ama tekrarsız(distinct) olsun ardından sayısını say ve stringe dönüştür sonra da label e yazdır//distinct=tekrarsız
            label19.Text = db.MarkayıBulma().FirstOrDefault();
        }
    }
}
