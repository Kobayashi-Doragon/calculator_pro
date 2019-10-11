using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Q_Key_Click(object sender, EventArgs e)
        {

        }

        private void w_key_Click(object sender, EventArgs e)
        {

        }

        private void e_key_Click(object sender, EventArgs e)
        {

        }

        private void r_key_Click(object sender, EventArgs e)
        {

        }

        private void y_key_Click(object sender, EventArgs e)
        {

        }

        private void t_key_Click(object sender, EventArgs e)
        {

        }

        private void u_key_Click(object sender, EventArgs e)
        {

        }

        private void o_key_Click(object sender, EventArgs e)
        {

        }

        private void i_key_Click(object sender, EventArgs e)
        {

        }

        private void p_key_Click(object sender, EventArgs e)
        {
            formula_box.AppendText("π");
        }

        private void a_key_Click(object sender, EventArgs e)
        {

        }

        private void s_key_Click(object sender, EventArgs e)
        {

        }

        private void d_key_Click(object sender, EventArgs e)
        {

        }

        private void f_key_Click(object sender, EventArgs e)
        {

        }

        private void g_key_Click(object sender, EventArgs e)
        {

        }

        private void h_key_Click(object sender, EventArgs e)
        {

        }

        private void j_key_Click(object sender, EventArgs e)
        {

        }

        private void k_key_Click(object sender, EventArgs e)
        {

        }

        private void l_key_Click(object sender, EventArgs e)
        {

        }

        private void z_key_Click(object sender, EventArgs e)
        {

        }

        private void x_key_Click(object sender, EventArgs e)
        {

        }

        private void c_key_Click(object sender, EventArgs e)
        {

        }

        private void v_key_Click(object sender, EventArgs e)
        {

        }

        private void b_key_Click(object sender, EventArgs e)
        {

        }

        private void n_key_Click(object sender, EventArgs e)
        {

        }

        private void m_key_Click(object sender, EventArgs e)
        {

        }

        private void search_box_MouseUp(object sender, MouseEventArgs e)
        {
            search_box.ResetText();
            search_box.ForeColor=Color.Black;
        }

        private void formula_box_MouseUp(object sender, MouseEventArgs e)
        {
           /// formula_box.ResetText();
           // formula_box.ForeColor = Color.Black;
        }

        private void memory1_but_Click(object sender, EventArgs e)
        {
            formula_box.AppendText(memory1_box.Text);
        }

        private void mamory2_but_Click(object sender, EventArgs e)
        {
            formula_box.AppendText(memory2_box.Text);
        }

        private void mamory3_but_Click(object sender, EventArgs e)
        {
            formula_box.AppendText(memory3_box.Text);
        }

        private void mamory4_but_Click(object sender, EventArgs e)
        {
            formula_box.AppendText(memory4_box.Text);
        }

        private void formula_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode <= Keys.Z && e.KeyCode >= Keys.A) {
                int m = (int)e.KeyCode + 32;
                char key = (char)m;
                Button b1 = p_key;
                b1.PerformClick();
                //formula_box.Text = formula_box.Text.Substring(0,formula_box.Text.Length-1);
            }
        }
    }
}
