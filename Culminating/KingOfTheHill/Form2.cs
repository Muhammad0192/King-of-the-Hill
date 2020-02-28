using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingOfTheHill
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmKingOfTheHill row = new frmKingOfTheHill();
            this.Visible = false;
            row.ShowDialog();
            this.Visible = true;
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            frmControls row = new frmControls();
            this.Visible = false;
            row.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStory row = new frmStory();
            this.Visible = false;
            row.ShowDialog();
            this.Visible = true;
        }
    }
}
