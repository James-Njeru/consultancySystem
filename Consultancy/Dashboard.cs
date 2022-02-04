using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultancy
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void consultancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultancy a = new Consultancy();
            a.Visible = true;
        }

        private void scoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores a = new Scores();
            a.Visible = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student a = new Student();
            a.Visible = true;
        }

        private void universityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            University a = new University();
            a.Visible = true;
        }
    }
}
