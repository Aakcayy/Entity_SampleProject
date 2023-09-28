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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fs=new Form1();
            fs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun ty=new FrmUrun();
            ty.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmİstatislik ft = new Frmİstatislik();
            ft.Show();
        }
    }
}
