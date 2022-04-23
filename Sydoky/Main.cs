using Sydoky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResolverForm form = new ResolverForm();
            form.Show();
        }

        private void levelsBtn_Click(object sender, EventArgs e)
        {
            Levels form = new Levels();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddLevel form = new AddLevel();
            form.Show();
        }
    }
}
