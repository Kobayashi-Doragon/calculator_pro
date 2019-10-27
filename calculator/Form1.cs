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
        Button[] key_button =new Button[26];
        TextBox []memory_box =  new TextBox[4];
        private Formula formula1 = new Formula();
        private Memory memory1=new Memory();
        DataSet dataSet = new DataSet();
        DataTable table = new DataTable("Table");
        DataRow[] dRows;
        bool memory_counter = false;//falseはメモリ書き出し、trueはメモリ読み取り
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            key_button[0] = a_key;
            key_button[1] = b_key;
            key_button[2] = c_key;
            key_button[3] = d_key;
            key_button[4] = e_key;
            key_button[5] = f_key;
            key_button[6] = g_key;
            key_button[7] = h_key;
            key_button[8] = i_key;
            key_button[9] = j_key;
            key_button[10] = k_key;
            key_button[11] = l_key;
            key_button[12] = m_key;
            key_button[13] = n_key;
            key_button[14] = o_key;
            key_button[15] = p_key;
            key_button[16] = q_key;
            key_button[17] = r_key;
            key_button[18] = s_key;
            key_button[19] = t_key;
            key_button[20] = u_key;
            key_button[21] = v_key;
            key_button[22] = w_key;
            key_button[23] = x_key;
            key_button[24] = y_key;
            key_button[25] = z_key;

            memory_box[0] = memory1_box;
            memory_box[1] = memory2_box;
            memory_box[2] = memory3_box;
            memory_box[3] = memory4_box;

            table.Columns.Add("定数名", typeof(String));
            table.Columns.Add("記号", typeof(String));
            table.Columns.Add("値", typeof(String));

            // DataSetにDataTableを追加
            dataSet.Tables.Add(table);

            table.Rows.Add("真空中の光速", "cc", "8.854187817 * 10^(-12)");
            table.Rows.Add("万有引力定数", "GG", "6.67408 * 10^(-11)");
            table.Rows.Add("プランク定数", "hh", "6.62606896*10^(−34)");
            table.Rows.Add("真空の透磁率", "μ0μ0", "4π*10^(−7)");
            table.Rows.Add("真空の誘電率", "ε0", "8.854187817*10^(−12)");
            table.Rows.Add("電気素量", "ee", "1.602176487*10^(−19)");
            table.Rows.Add("電子の質量", "meme", "9.10938215*10^(−31)");
            table.Rows.Add("電子の比電荷", "e/mee/me", "1.758820174*10^(11)");
            table.Rows.Add("陽子の質量", "mpmp", "1.672621637*10^(−27)");
            table.Rows.Add("中性子の質量", "mnmn", "1.674927211*10^(−27)");
            table.Rows.Add("原子質量単位", "mumu", "1.660538782*10^(−27)");
            table.Rows.Add("電子の磁気モーメント", "μeμe", "−9.28476377*10^(−24)");
            table.Rows.Add("陽子の磁気モーメント", "μpμp", "1.410606662*10^(−26)");
            table.Rows.Add("中性子の磁気モーメント", "μnμn", "9.6623641*10^(−27)");
            table.Rows.Add("アボガドロ定数", "NANA", "6.02214179*10^(23)");
            table.Rows.Add("気体定数", "R", "8.314472");
            table.Rows.Add("理想気体のモル体積", "VmVm", "2.2413996*10^(−2)");
            table.Rows.Add("ボルツマン定数", "kk", "1.3806504*10^(−23)");
            table.Rows.Add("ファラデー定数", "F", "9.64853399*10^(4)");
            table.Rows.Add("重力加速度", "g", "9.80665");
            table.Rows.Add("標準大気圧", "P0P0", "101325");
            memory_select_box.Hide();
        }

        private void Q_Key_Click(object sender, EventArgs e)
        {

        }

        private void w_key_Click(object sender, EventArgs e)
        {

        }

        private void e_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            formula_box.Text=formula_box.Text.Insert(selection, "e ");
            //formula_box.Text += "e";
            formula_box.SelectionStart = selection+2;
            formula_box.SelectionLength = 0;
        }

        private void r_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "√ ( ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 4, ") ");
                formula_box.SelectionStart = selection + selection_length + 6;
            }
            else
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "√ ( ) ");
                formula_box.SelectionStart = selection + 4;
                formula_box.SelectionLength = 0;
            }
        }

        private void y_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                formula_box.Text = formula_box.Text.Insert(selection, "( ) / ( ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 8, ") ");
                formula_box.SelectionStart = selection + 2 ;
            }
            else{
                string text = formula_box.Text;
                formula_box.Text = "( ) / ( " + text+") ";
                formula_box.SelectionStart = 2;
                formula_box.SelectionLength = 0;
            }
        }
        private void t_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "tan ( ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 6, ") ");
                formula_box.SelectionStart = selection + selection_length + 8;
            }
            else
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "tan ( ) ");
                formula_box.SelectionStart = selection + 6;
                formula_box.SelectionLength = 0;
            }
        }

        private void u_key_Click(object sender, EventArgs e)
        {
            int i;
            formula_box.Text = "";
            for (i = 0; i < 4; i++)
            {
                memory1.memory_delete(i);
            }
        }

        private void o_key_Click(object sender, EventArgs e)
        {
            formula_box.Text = "";
        }

        private void i_key_Click(object sender, EventArgs e)
        {
            int i;
            for (i=0;i<4;i++) {
                memory1.memory_delete(i);
            }
        }

        private void p_key_Click(object sender, EventArgs e){
            int selection = formula_box.SelectionStart;
            formula_box.Text = formula_box.Text.Insert(selection, "π ");
            //formula_box.Text += "e";
            formula_box.SelectionStart = selection + 2;
            formula_box.SelectionLength = 0;
        }

        private void a_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "| ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 2, "| ");
                formula_box.SelectionStart = selection + selection_length + 4;
            }
            else
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "| | ");
                formula_box.SelectionStart = selection + 2;
                formula_box.SelectionLength = 0;
            }
        }

        private void s_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "sin ( ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 6, ") ");
                formula_box.SelectionStart = selection + selection_length + 8;
            }
            else
            {
                selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, "sin ( ) ");
                formula_box.SelectionStart = selection + 6;
                formula_box.SelectionLength = 0;
            }
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
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                formula_box.Text = formula_box.Text.Insert(selection, "log ( ) ( ");
                formula_box.Text = formula_box.Text.Insert(selection + selection_length + 10, ") ");
                formula_box.SelectionStart = selection + 6;
            }
            else
            {
                formula_box.Text = formula_box.Text.Insert(selection, "log ( ) ( ) ");
                formula_box.SelectionStart = selection + 6;
                formula_box.SelectionLength = 0;
            }
        }

        private void z_key_Click(object sender, EventArgs e)
        {

        }

        private void x_key_Click(object sender, EventArgs e)
        {

        }

        private void c_key_Click(object sender, EventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            if (selection_length > 0)
            {
                formula_box.Text = formula_box.Text.Insert(selection, "cos ( ");
                formula_box.Text = formula_box.Text.Insert(selection+ selection_length+6, ") ");
                formula_box.SelectionStart = selection +selection_length+ 9;
            }
            else{
                formula_box.Text = formula_box.Text.Insert(selection, "cos ( ) ");
                formula_box.SelectionStart = selection + 6;
                formula_box.SelectionLength = 0;
            }
        }

        private void v_key_Click(object sender, EventArgs e)
        {
            
        }

        private void b_key_Click(object sender, EventArgs e)
        {

        }

        private void n_key_Click(object sender, EventArgs e){
            memory_select_box.Show();
            memory_select_box.Select();
            memory_counter = false;
            
        }

        private void m_key_Click(object sender, EventArgs e){
            memory_select_box.Show();
            memory_select_box.Select();
            memory_counter = true;
        }

        private void search_box_MouseUp(object sender, MouseEventArgs e)
        {
            //search_box.ResetText();
            search_box.ForeColor=Color.Black;
        }

        private void formula_box_MouseUp(object sender, MouseEventArgs e)
        {
           /// formula_box.ResetText();
           // formula_box.ForeColor = Color.Black;
        }

        private void memory1_but_Click(object sender, EventArgs e)
        {
            int i = 0;
            memory1.memory_save(i, memory1_box.Text);
            if (!memory1.memory_check(i)){
                string text = memory1.memory_read(i);
                int length = text.Length;
                int selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, text);
                selection += length;
                if (selection < formula_box.Text.Length - 1 && formula_box.Text[selection+length] == ')'){
                    formula_box.Text = formula_box.Text.Insert(selection," ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                }
            }
            else
            {
                if (answer_box.Text != "0")
                {
                    memory1.memory_save(i, answer_box.Text);
                }
            }
        }
        private void mamory2_but_Click(object sender, EventArgs e)
        {
            int i = 1;
            memory1.memory_save(i, memory2_box.Text);
            if (!memory1.memory_check(i))
            {
                string text = memory1.memory_read(i);
                int length = text.Length;
                int selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, text);
                selection += length;
                if (selection < formula_box.Text.Length - 1 && formula_box.Text[selection + length] == ')')
                {
                    formula_box.Text = formula_box.Text.Insert(selection, " ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                }
            }
            else
            {
                if (answer_box.Text != "0")
                {
                    memory1.memory_save(i, answer_box.Text);
                }
            }
        }

        private void memory3_but_Click(object sender, EventArgs e){
            int i = 2;
            memory1.memory_save(i, memory3_box.Text);
            if (!memory1.memory_check(i))
            {
                string text = memory1.memory_read(i);
                int length = text.Length;
                int selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, text);
                selection += length;
                if (selection < formula_box.Text.Length - 1 && formula_box.Text[selection + length] == ')')
                {
                    formula_box.Text = formula_box.Text.Insert(selection, " ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                }
            }
            else
            {
                if (answer_box.Text != "0")
                {
                    memory1.memory_save(i, answer_box.Text);
                }
            }
        }

        private void mamory4_but_Click(object sender, EventArgs e)
        {
            int i = 3;
            memory1.memory_save(i, memory4_box.Text);
            if (!memory1.memory_check(i))
            {
                string text = memory1.memory_read(i);
                int length = text.Length;
                int selection = formula_box.SelectionStart;
                formula_box.Text = formula_box.Text.Insert(selection, text);
                selection += length;
                if (selection < formula_box.Text.Length - 1 && formula_box.Text[selection + length] == ')')
                {
                    formula_box.Text = formula_box.Text.Insert(selection, " ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                }
            }
            else
            {
                if (answer_box.Text != "0")
                {
                    memory1.memory_save(i, answer_box.Text);
                }
            }
        }

        private void formula_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selection = formula_box.SelectionStart;
            int selection_length = formula_box.SelectionLength;
            
            if (e.KeyChar <= 'z' && e.KeyChar >= 'a')
            {
                if (selection_length+selection > 0 && (formula_box.Text[selection+selection_length-1] <= '9' && formula_box.Text[selection+selection_length-1] >= '0'))
                {
                    formula_box.Text = formula_box.Text.Insert(selection+selection_length," ");
                    if (selection_length > 0)
                        selection_length++;
                    else
                    {
                        formula_box.SelectionStart = selection + 1;
                        selection++;
                        formula_box.SelectionLength = 0;
                    }
                }
                int m = (int)e.KeyChar;
                Button b1 = key_button[m - 97];
                b1.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar <= '9' && e.KeyChar >= '0') {
                if (selection>0 && formula_box.Text[selection-1] != ' ' && (formula_box.Text[selection-1] <= '0'|| formula_box.Text[selection - 1] >= '9')){
                    formula_box.Text = formula_box.Text.Insert(selection," ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                }
                selection = formula_box.SelectionStart;
                selection_length = formula_box.SelectionLength;
                if (selection <formula_box.Text.Length-1  && (formula_box.Text[selection] == ')' || formula_box.Text[selection] == '|')){
                    formula_box.Text = formula_box.Text.Insert(selection, e.KeyChar+" ");
                    formula_box.SelectionStart = selection + 1;
                    formula_box.SelectionLength = 0;
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)Keys.Enter|| e.KeyChar == '=')
            {
                formula1.setFomula_text(formula_box.Text);
                if (formula1.formula_check()) {
                    int answer = formula1.calculation();
                    answer_box.Text = answer.ToString();
                }
                e.Handled = true;
            }
            else if (e.KeyChar == '*'|| e.KeyChar == '/'|| e.KeyChar == '+'|| e.KeyChar == '-')
            {
                if (selection + selection_length > 0 && formula_box.Text[selection + selection_length - 1] != ' ')
                {
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length, " ");
                    if (selection_length > 0)
                        selection_length++;
                    else
                    {
                        formula_box.SelectionStart = selection + 1;
                        selection++;
                        formula_box.SelectionLength = 0;
                    }
                }
                if (selection_length > 0)
                {
                    formula_box.Text = formula_box.Text.Insert(selection, "( ");
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length + 2, ") ");
                    formula_box.SelectionStart = selection + selection_length + 4;
                }
                selection = formula_box.SelectionStart;
                selection_length = formula_box.SelectionLength;
                formula_box.Text = formula_box.Text.Insert(selection, e.KeyChar+" ");
                formula_box.SelectionStart = selection + 2;
                formula_box.SelectionLength = 0;
                e.Handled = true;
            }
            else if (e.KeyChar == '(')
            {
                if (selection + selection_length > 0 && formula_box.Text[selection + selection_length - 1] != ' ')
                {
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length, " ");
                    if (selection_length > 0)
                        selection_length++;
                    else
                    {
                        formula_box.SelectionStart = selection + 1;
                        selection++;
                        formula_box.SelectionLength = 0;
                    }
                }
                if (selection_length > 0)
                {
                    formula_box.Text = formula_box.Text.Insert(selection, "( ");
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length + 2, ") ");
                    formula_box.SelectionStart = selection + selection_length + 4;
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ')')
            {
                if (formula_box.Text[selection - 1] != ' ')
                {
                    formula_box.Text = formula_box.Text.Insert(selection, " ");
                    formula_box.SelectionStart = selection + 1;
                    selection++;
                    formula_box.SelectionLength = 0;
                }
            }
            else if (e.KeyChar == '|')
            {
                if (selection + selection_length > 0 && formula_box.Text[selection + selection_length - 1] != ' ')
                {
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length, " ");
                    if (selection_length > 0)
                        selection_length++;
                    else
                    {
                        formula_box.SelectionStart = selection + 1;
                        selection++;
                        formula_box.SelectionLength = 0;
                    }
                }
                if (selection_length > 0)
                {
                    formula_box.Text = formula_box.Text.Insert(selection, "| ");
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length + 2, "| ");
                    formula_box.SelectionStart = selection + selection_length + 4;
                    e.Handled = true;
                }

            }
            else if (e.KeyChar == '^')
            {
                if (selection + selection_length > 0 && formula_box.Text[selection + selection_length - 1] != ' ')
                {
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length, " ");
                    if (selection_length > 0)
                        selection_length++;
                    else
                    {
                        formula_box.SelectionStart = selection + 1;
                        selection++;
                        formula_box.SelectionLength = 0;
                    }
                }
                if (selection_length > 0)
                {
                    formula_box.Text = formula_box.Text.Insert(selection, "( ");
                    formula_box.Text = formula_box.Text.Insert(selection + selection_length + 2, ") ");
                    formula_box.SelectionStart = selection + selection_length + 4;
                    e.Handled = true;
                }
                selection = formula_box.SelectionStart;
                selection_length = formula_box.SelectionLength;
                formula_box.Text = formula_box.Text.Insert(selection, "^ ( ) ");
                formula_box.SelectionStart = selection + 4;
                formula_box.SelectionLength = 0;
                e.Handled = true;
            }
        }

        private void search_box_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char)Keys.Enter)
            {
                search_result.Items.Clear();
                String text = search_box.Text;
                int i;
                
                dRows = table.AsEnumerable()
                 .Where(row => row.Field<string>("定数名").Contains(text)).ToArray();
                if (dRows.Length == 0)
                {
                    search_result.Text = "該当する定位数がありません";
                }
                else{
                    search_result.Text = "該当する定数があります";
                    foreach (var row in dRows)
                    {
                        search_result.Items.Add(row[0] + "(" + row[1] + ")" + "   " + row[2]);
                    }
                }
            }
        }
        private void search_result_SelectedIndexChanged(object sender, EventArgs e){
            int selection = formula_box.SelectionStart;
            string search_result_num = dRows[search_result.SelectedIndex][2].ToString();
            formula_box.Text = formula_box.Text.Insert(selection,search_result_num);
            formula_box.SelectionStart = selection + search_result_num.Length;
            formula_box.SelectionLength = 0;
        }

        private void memory_select_box_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char)Keys.Enter)
            {
                string text = memory_select_box.Text;
                if (memory_counter)
                {
                    if (text == "") {
                        int i;
                        for (i=0;i<4;i++) {
                            if (memory1.memory_check(i)) {
                                memory1.memory_save(i, answer_box.Text);
                            }
                        }
                    }
                    int memory_num;
                    if (int.TryParse(text, out memory_num))
                    {
                        switch (memory_num)
                        {
                            case 1:
                                memory1.memory_save(0, answer_box.Text);
                                break;
                            case 2:
                                memory1.memory_save(1, answer_box.Text);
                                break;
                            case 3:
                                memory1.memory_save(2, answer_box.Text);
                                break;
                            case 4:
                                memory1.memory_save(3, answer_box.Text);
                                break;
                            default:
                                break;
                        }
                    }
                    memory1.memory_save(0, memory1_box.Text);
                    memory1.memory_save(1, memory2_box.Text);
                    memory1.memory_save(2, memory3_box.Text);
                    memory1.memory_save(3, memory4_box.Text);
                }
                else {
                    int memory_num;
                    string add_text="0";
                    if (text == "")
                    {
                        int i;
                        for (i = 0; i < 4; i++)
                        {
                            if (!memory1.memory_check(i))
                            {
                                add_text=memory1.memory_read(i);
                            }
                        }
                    }
                    if (int.TryParse(text, out memory_num))
                    {
                        switch (memory_num)
                        {
                            case 1:
                                add_text = memory1.memory_read(0);
                                break;
                            case 2:
                                add_text = memory1.memory_read(1);
                                break;
                            case 3:
                                add_text = memory1.memory_read(2);
                                break;
                            case 4:
                                add_text = memory1.memory_read(3);
                                break;
                            default:
                                break;
                        }
                    }
                    if (add_text != "0"){
                        int selection = formula_box.SelectionStart;
                        formula_box.Text = formula_box.Text.Insert(selection,add_text);
                        formula_box.SelectionStart += add_text.Length;

                    }
                }
                formula_box.Select();
                memory_select_box.Text = "";
                memory_select_box.Hide();
            }
        }
    }
}
