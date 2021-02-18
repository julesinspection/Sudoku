using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sydoky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //условия отбора
        static bool sCondition(int k, int[] arg, int n, bool[] even, bool[] odd, bool d)
        {
            //горизонталь
            for (int i = n % 9; i < 81; i += 9){
                if (k == arg[i])
                    return false;
            }

            //вертикаль
            for (int i = n / 9 * 9; i < ((n / 9) + 1) * 9; i++){
                if (k == arg[i])
                    return false;
            }

            //квадраты
            int z = 0;
            if (n < 3 || (n > 8 && n < 12) || (n > 17 && n < 21))
                z = 0;
            if ((n > 2 && n < 6) || (n > 11 && n < 15) || (n > 20 && n < 24))
                z = 3;
            if ((n > 5 && n < 9) || (n > 14 && n < 18) || (n > 23 && n < 27))
                z = 6;

            if ((n > 26 && n < 30) || (n > 35 && n < 39) || (n > 44 && n < 48))
                z = 27;
            if ((n > 29 && n < 33) || (n > 38 && n < 42) || (n > 47 && n < 51))
                z = 30;
            if ((n > 32 && n < 36) || (n > 41 && n < 45) || (n > 50 && n < 54))
                z = 33;

            if ((n > 53 && n < 57) || (n > 62 && n < 66) || (n > 71 && n < 75))
                z = 54;
            if ((n > 56 && n < 60) || (n > 65 && n < 69) || (n > 74 && n < 78))
                z = 57;
            if ((n > 59 && n < 63) || (n > 68 && n < 72) || (n > 77 && n < 81))
                z = 60;

            for (int i = z; i < z + 3; i++)
                for (int j = 0; j < 27; j += 9)
                    if (k == arg[i + j])
                        return false;

            //четные нечетные
            if (even[n] == true && k % 2 == 1)
                return false;

            if (odd[n] == true && k % 2 == 0)
                return false;

            //диагонали
            if (d == true)
            {
                //слева направо
                if(n % 10 == 0)
                    for(int i = 0; i < 81; i += 10)
                        if (k == arg[i])
                            return false;

                //справа налево
                if (n % 8 == 0 && n != 80)
                    for (int i = 8; i < 80; i += 8)
                        if (k == arg[i])
                            return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            int[] arg = new int[81];
            bool flag = false;
            //if (CheckMistakes(arg) == false) {
            //    MessageBox.Show("Введено неверное значение");
            //    flag = true;
            //}
            //else 
                InputArgs(arg);

            bool[] even = new bool[81];
            InputEven(even);

            bool[] odd = new bool[81];
            InputOdd(odd);

            bool diagonal = checkBox82.Checked;

            int[] aDone = new int[81];
            for (i = 0; i < 81; i++) {
                if (arg[i] == 0)
                    aDone[i] = 1;
                else
                    aDone[i] = -1;
            }

            i = -1;

            while (flag == false){
                if (i < 0)
                    i = 0;
                else i++;


                if (aDone[i] != -1){
                    for (int k = aDone[i]; k < 10; k++) {
                        //нашли подходящее по условию число
                        if (sCondition(k, arg, i, even, odd, diagonal) == true){
                            arg[i] = k;
                            aDone[i] = k;
                            break;
                        }

                        //не нашли
                        if (sCondition(k, arg, i, even, odd, diagonal) == false && k == 9) {
                            if(i == 0){
                                MessageBox.Show("Решения нет");
                                flag = true;
                            }
                            aDone[i] = 1;
                            arg[i] = 0;

                            i--;
                            
                            while (true) {
                                if (i > -1){
                                    if (aDone[i] == -1)
                                        i--;
                                    else break;
                                }
                                else break;
                            }
                            i--;

                            break;
                        }
                    }
                }

                if (i == 80)
                    flag = true;
            }

            Output(arg);
        }
        
        public void Output(int[] arg)
        {
            label1.Text = Convert.ToString(arg[0]);
            label2.Text = Convert.ToString(arg[1]);
            label3.Text = Convert.ToString(arg[2]);
            label4.Text = Convert.ToString(arg[3]);
            label5.Text = Convert.ToString(arg[4]);
            label6.Text = Convert.ToString(arg[5]);
            label7.Text = Convert.ToString(arg[6]);
            label8.Text = Convert.ToString(arg[7]);
            label9.Text = Convert.ToString(arg[8]);
            label10.Text = Convert.ToString(arg[9]);
            label11.Text = Convert.ToString(arg[10]);
            label12.Text = Convert.ToString(arg[11]);
            label13.Text = Convert.ToString(arg[12]);
            label14.Text = Convert.ToString(arg[13]);
            label15.Text = Convert.ToString(arg[14]);
            label16.Text = Convert.ToString(arg[15]);
            label17.Text = Convert.ToString(arg[16]);
            label18.Text = Convert.ToString(arg[17]);
            label19.Text = Convert.ToString(arg[18]);
            label20.Text = Convert.ToString(arg[19]);
            label21.Text = Convert.ToString(arg[20]);
            label22.Text = Convert.ToString(arg[21]);
            label23.Text = Convert.ToString(arg[22]);
            label24.Text = Convert.ToString(arg[23]);
            label25.Text = Convert.ToString(arg[24]);
            label26.Text = Convert.ToString(arg[25]);
            label27.Text = Convert.ToString(arg[26]);
            label28.Text = Convert.ToString(arg[27]);
            label29.Text = Convert.ToString(arg[28]);
            label30.Text = Convert.ToString(arg[29]);
            label31.Text = Convert.ToString(arg[30]);
            label32.Text = Convert.ToString(arg[31]);
            label33.Text = Convert.ToString(arg[32]);
            label34.Text = Convert.ToString(arg[33]);
            label35.Text = Convert.ToString(arg[34]);
            label36.Text = Convert.ToString(arg[35]);
            label37.Text = Convert.ToString(arg[36]);
            label38.Text = Convert.ToString(arg[37]);
            label39.Text = Convert.ToString(arg[38]);
            label40.Text = Convert.ToString(arg[39]);
            label41.Text = Convert.ToString(arg[40]);
            label42.Text = Convert.ToString(arg[41]);
            label43.Text = Convert.ToString(arg[42]);
            label44.Text = Convert.ToString(arg[43]);
            label45.Text = Convert.ToString(arg[44]);
            label46.Text = Convert.ToString(arg[45]);
            label47.Text = Convert.ToString(arg[46]);
            label48.Text = Convert.ToString(arg[47]);
            label49.Text = Convert.ToString(arg[48]);
            label50.Text = Convert.ToString(arg[49]);
            label51.Text = Convert.ToString(arg[50]);
            label52.Text = Convert.ToString(arg[51]);
            label53.Text = Convert.ToString(arg[52]);
            label54.Text = Convert.ToString(arg[53]);
            label55.Text = Convert.ToString(arg[54]);
            label56.Text = Convert.ToString(arg[55]);
            label57.Text = Convert.ToString(arg[56]);
            label58.Text = Convert.ToString(arg[57]);
            label59.Text = Convert.ToString(arg[58]);
            label60.Text = Convert.ToString(arg[59]);
            label61.Text = Convert.ToString(arg[60]);
            label62.Text = Convert.ToString(arg[61]);
            label63.Text = Convert.ToString(arg[62]);
            label64.Text = Convert.ToString(arg[63]);
            label65.Text = Convert.ToString(arg[64]);
            label66.Text = Convert.ToString(arg[65]);
            label67.Text = Convert.ToString(arg[66]);
            label68.Text = Convert.ToString(arg[67]);
            label69.Text = Convert.ToString(arg[68]);
            label70.Text = Convert.ToString(arg[69]);
            label71.Text = Convert.ToString(arg[70]);
            label72.Text = Convert.ToString(arg[71]);
            label73.Text = Convert.ToString(arg[72]);
            label74.Text = Convert.ToString(arg[73]);
            label75.Text = Convert.ToString(arg[74]);
            label76.Text = Convert.ToString(arg[75]);
            label77.Text = Convert.ToString(arg[76]);
            label78.Text = Convert.ToString(arg[77]);
            label79.Text = Convert.ToString(arg[78]);
            label80.Text = Convert.ToString(arg[79]);
            label81.Text = Convert.ToString(arg[80]);

        }

        public void InputArgs(int[] arg)
        {
            if (textBox1.Text == "") arg[0] = 0; else arg[0] = Convert.ToInt32(textBox1.Text);
            if (textBox2.Text == "") arg[1] = 0; else arg[1] = Convert.ToInt32(textBox2.Text);
            if (textBox3.Text == "") arg[2] = 0; else arg[2] = Convert.ToInt32(textBox3.Text);
            if (textBox4.Text == "") arg[3] = 0; else arg[3] = Convert.ToInt32(textBox4.Text);
            if (textBox5.Text == "") arg[4] = 0; else arg[4] = Convert.ToInt32(textBox5.Text);
            if (textBox6.Text == "") arg[5] = 0; else arg[5] = Convert.ToInt32(textBox6.Text);
            if (textBox7.Text == "") arg[6] = 0; else arg[6] = Convert.ToInt32(textBox7.Text);
            if (textBox8.Text == "") arg[7] = 0; else arg[7] = Convert.ToInt32(textBox8.Text);
            if (textBox9.Text == "") arg[8] = 0; else arg[8] = Convert.ToInt32(textBox9.Text);
            if (textBox10.Text == "") arg[9] = 0; else arg[9] = Convert.ToInt32(textBox10.Text);
            if (textBox11.Text == "") arg[10] = 0; else arg[10] = Convert.ToInt32(textBox11.Text);
            if (textBox12.Text == "") arg[11] = 0; else arg[11] = Convert.ToInt32(textBox12.Text);
            if (textBox13.Text == "") arg[12] = 0; else arg[12] = Convert.ToInt32(textBox13.Text);
            if (textBox14.Text == "") arg[13] = 0; else arg[13] = Convert.ToInt32(textBox14.Text);
            if (textBox15.Text == "") arg[14] = 0; else arg[14] = Convert.ToInt32(textBox15.Text);
            if (textBox16.Text == "") arg[15] = 0; else arg[15] = Convert.ToInt32(textBox16.Text);
            if (textBox17.Text == "") arg[16] = 0; else arg[16] = Convert.ToInt32(textBox17.Text);
            if (textBox18.Text == "") arg[17] = 0; else arg[17] = Convert.ToInt32(textBox18.Text);
            if (textBox19.Text == "") arg[18] = 0; else arg[18] = Convert.ToInt32(textBox19.Text);
            if (textBox20.Text == "") arg[19] = 0; else arg[19] = Convert.ToInt32(textBox20.Text);
            if (textBox21.Text == "") arg[20] = 0; else arg[20] = Convert.ToInt32(textBox21.Text);
            if (textBox22.Text == "") arg[21] = 0; else arg[21] = Convert.ToInt32(textBox22.Text);
            if (textBox23.Text == "") arg[22] = 0; else arg[22] = Convert.ToInt32(textBox23.Text);
            if (textBox24.Text == "") arg[23] = 0; else arg[23] = Convert.ToInt32(textBox24.Text);
            if (textBox25.Text == "") arg[24] = 0; else arg[24] = Convert.ToInt32(textBox25.Text);
            if (textBox26.Text == "") arg[25] = 0; else arg[25] = Convert.ToInt32(textBox26.Text);
            if (textBox27.Text == "") arg[26] = 0; else arg[26] = Convert.ToInt32(textBox27.Text);
            if (textBox28.Text == "") arg[27] = 0; else arg[27] = Convert.ToInt32(textBox28.Text);
            if (textBox29.Text == "") arg[28] = 0; else arg[28] = Convert.ToInt32(textBox29.Text);
            if (textBox30.Text == "") arg[29] = 0; else arg[29] = Convert.ToInt32(textBox30.Text);
            if (textBox31.Text == "") arg[30] = 0; else arg[30] = Convert.ToInt32(textBox31.Text);
            if (textBox32.Text == "") arg[31] = 0; else arg[31] = Convert.ToInt32(textBox32.Text);
            if (textBox33.Text == "") arg[32] = 0; else arg[32] = Convert.ToInt32(textBox33.Text);
            if (textBox34.Text == "") arg[33] = 0; else arg[33] = Convert.ToInt32(textBox34.Text);
            if (textBox35.Text == "") arg[34] = 0; else arg[34] = Convert.ToInt32(textBox35.Text);
            if (textBox36.Text == "") arg[35] = 0; else arg[35] = Convert.ToInt32(textBox36.Text);
            if (textBox37.Text == "") arg[36] = 0; else arg[36] = Convert.ToInt32(textBox37.Text);
            if (textBox38.Text == "") arg[37] = 0; else arg[37] = Convert.ToInt32(textBox38.Text);
            if (textBox39.Text == "") arg[38] = 0; else arg[38] = Convert.ToInt32(textBox39.Text);
            if (textBox40.Text == "") arg[39] = 0; else arg[39] = Convert.ToInt32(textBox40.Text);
            if (textBox41.Text == "") arg[40] = 0; else arg[40] = Convert.ToInt32(textBox41.Text);
            if (textBox42.Text == "") arg[41] = 0; else arg[41] = Convert.ToInt32(textBox42.Text);
            if (textBox43.Text == "") arg[42] = 0; else arg[42] = Convert.ToInt32(textBox43.Text);
            if (textBox44.Text == "") arg[43] = 0; else arg[43] = Convert.ToInt32(textBox44.Text);
            if (textBox45.Text == "") arg[44] = 0; else arg[44] = Convert.ToInt32(textBox45.Text);
            if (textBox46.Text == "") arg[45] = 0; else arg[45] = Convert.ToInt32(textBox46.Text);
            if (textBox47.Text == "") arg[46] = 0; else arg[46] = Convert.ToInt32(textBox47.Text);
            if (textBox48.Text == "") arg[47] = 0; else arg[47] = Convert.ToInt32(textBox48.Text);
            if (textBox49.Text == "") arg[48] = 0; else arg[48] = Convert.ToInt32(textBox49.Text);
            if (textBox50.Text == "") arg[49] = 0; else arg[49] = Convert.ToInt32(textBox50.Text);
            if (textBox51.Text == "") arg[50] = 0; else arg[50] = Convert.ToInt32(textBox51.Text);
            if (textBox52.Text == "") arg[51] = 0; else arg[51] = Convert.ToInt32(textBox52.Text);
            if (textBox53.Text == "") arg[52] = 0; else arg[52] = Convert.ToInt32(textBox53.Text);
            if (textBox54.Text == "") arg[53] = 0; else arg[53] = Convert.ToInt32(textBox54.Text);
            if (textBox55.Text == "") arg[54] = 0; else arg[54] = Convert.ToInt32(textBox55.Text);
            if (textBox56.Text == "") arg[55] = 0; else arg[55] = Convert.ToInt32(textBox56.Text);
            if (textBox57.Text == "") arg[56] = 0; else arg[56] = Convert.ToInt32(textBox57.Text);
            if (textBox58.Text == "") arg[57] = 0; else arg[57] = Convert.ToInt32(textBox58.Text);
            if (textBox59.Text == "") arg[58] = 0; else arg[58] = Convert.ToInt32(textBox59.Text);
            if (textBox60.Text == "") arg[59] = 0; else arg[59] = Convert.ToInt32(textBox60.Text);
            if (textBox61.Text == "") arg[60] = 0; else arg[60] = Convert.ToInt32(textBox61.Text);
            if (textBox62.Text == "") arg[61] = 0; else arg[61] = Convert.ToInt32(textBox62.Text);
            if (textBox63.Text == "") arg[62] = 0; else arg[62] = Convert.ToInt32(textBox63.Text);
            if (textBox64.Text == "") arg[63] = 0; else arg[63] = Convert.ToInt32(textBox64.Text);
            if (textBox65.Text == "") arg[64] = 0; else arg[64] = Convert.ToInt32(textBox65.Text);
            if (textBox66.Text == "") arg[65] = 0; else arg[65] = Convert.ToInt32(textBox66.Text);
            if (textBox67.Text == "") arg[66] = 0; else arg[66] = Convert.ToInt32(textBox67.Text);
            if (textBox68.Text == "") arg[67] = 0; else arg[67] = Convert.ToInt32(textBox68.Text);
            if (textBox69.Text == "") arg[68] = 0; else arg[68] = Convert.ToInt32(textBox69.Text);
            if (textBox70.Text == "") arg[69] = 0; else arg[69] = Convert.ToInt32(textBox70.Text);
            if (textBox71.Text == "") arg[70] = 0; else arg[70] = Convert.ToInt32(textBox71.Text);
            if (textBox72.Text == "") arg[71] = 0; else arg[71] = Convert.ToInt32(textBox72.Text);
            if (textBox73.Text == "") arg[72] = 0; else arg[72] = Convert.ToInt32(textBox73.Text);
            if (textBox74.Text == "") arg[73] = 0; else arg[73] = Convert.ToInt32(textBox74.Text);
            if (textBox75.Text == "") arg[74] = 0; else arg[74] = Convert.ToInt32(textBox75.Text);
            if (textBox76.Text == "") arg[75] = 0; else arg[75] = Convert.ToInt32(textBox76.Text);
            if (textBox77.Text == "") arg[76] = 0; else arg[76] = Convert.ToInt32(textBox77.Text);
            if (textBox78.Text == "") arg[77] = 0; else arg[77] = Convert.ToInt32(textBox78.Text);
            if (textBox79.Text == "") arg[78] = 0; else arg[78] = Convert.ToInt32(textBox79.Text);
            if (textBox80.Text == "") arg[79] = 0; else arg[79] = Convert.ToInt32(textBox80.Text);
            if (textBox81.Text == "") arg[80] = 0; else arg[80] = Convert.ToInt32(textBox81.Text);
        }

        public void InputOdd(bool[] odd)
        {
            odd[0] = checkBox101.Checked;
            odd[1] = checkBox102.Checked;
            odd[2] = checkBox103.Checked;
            odd[4] = checkBox105.Checked;
            odd[5] = checkBox106.Checked;
            odd[6] = checkBox107.Checked;
            odd[7] = checkBox108.Checked;
            odd[8] = checkBox109.Checked;
            odd[9] = checkBox110.Checked;
            odd[10] = checkBox111.Checked;
            odd[11] = checkBox112.Checked;
            odd[12] = checkBox113.Checked;
            odd[13] = checkBox114.Checked;
            odd[14] = checkBox115.Checked;
            odd[15] = checkBox116.Checked;
            odd[16] = checkBox117.Checked;
            odd[17] = checkBox118.Checked;
            odd[18] = checkBox119.Checked;
            odd[19] = checkBox120.Checked;
            odd[20] = checkBox121.Checked;
            odd[21] = checkBox122.Checked;
            odd[22] = checkBox123.Checked;
            odd[23] = checkBox124.Checked;
            odd[24] = checkBox125.Checked;
            odd[25] = checkBox126.Checked;
            odd[26] = checkBox127.Checked;
            odd[27] = checkBox128.Checked;
            odd[28] = checkBox129.Checked;
            odd[29] = checkBox130.Checked;
            odd[30] = checkBox131.Checked;
            odd[31] = checkBox132.Checked;
            odd[32] = checkBox133.Checked;
            odd[33] = checkBox134.Checked;
            odd[34] = checkBox135.Checked;
            odd[35] = checkBox136.Checked;
            odd[36] = checkBox137.Checked;
            odd[37] = checkBox138.Checked;
            odd[38] = checkBox139.Checked;
            odd[39] = checkBox140.Checked;
            odd[40] = checkBox141.Checked;
            odd[41] = checkBox142.Checked;
            odd[42] = checkBox143.Checked;
            odd[43] = checkBox144.Checked;
            odd[44] = checkBox145.Checked;
            odd[45] = checkBox146.Checked;
            odd[46] = checkBox147.Checked;
            odd[47] = checkBox148.Checked;
            odd[48] = checkBox149.Checked;
            odd[49] = checkBox150.Checked;
            odd[50] = checkBox151.Checked;
            odd[51] = checkBox152.Checked;
            odd[52] = checkBox153.Checked;
            odd[53] = checkBox154.Checked;
            odd[54] = checkBox155.Checked;
            odd[55] = checkBox156.Checked;
            odd[56] = checkBox157.Checked;
            odd[57] = checkBox158.Checked;
            odd[58] = checkBox159.Checked;
            odd[59] = checkBox160.Checked;
            odd[60] = checkBox161.Checked;
            odd[61] = checkBox162.Checked;
            odd[62] = checkBox163.Checked;
            odd[63] = checkBox164.Checked;
            odd[64] = checkBox165.Checked;
            odd[65] = checkBox166.Checked;
            odd[66] = checkBox167.Checked;
            odd[67] = checkBox168.Checked;
            odd[68] = checkBox169.Checked;
            odd[69] = checkBox170.Checked;
            odd[70] = checkBox171.Checked;
            odd[71] = checkBox172.Checked;
            odd[72] = checkBox173.Checked;
            odd[73] = checkBox174.Checked;
            odd[74] = checkBox175.Checked;
            odd[75] = checkBox176.Checked;
            odd[76] = checkBox177.Checked;
            odd[77] = checkBox178.Checked;
            odd[78] = checkBox179.Checked;
            odd[79] = checkBox180.Checked;
            odd[80] = checkBox181.Checked;
        }

        public void InputEven(bool[] even)
        {
            even[0] = checkBox1.Checked;
            even[1] = checkBox2.Checked;
            even[2] = checkBox3.Checked;
            even[4] = checkBox5.Checked;
            even[5] = checkBox6.Checked;
            even[6] = checkBox7.Checked;
            even[7] = checkBox8.Checked;
            even[8] = checkBox9.Checked;
            even[9] = checkBox10.Checked;
            even[10] = checkBox11.Checked;
            even[11] = checkBox12.Checked;
            even[12] = checkBox13.Checked;
            even[13] = checkBox14.Checked;
            even[14] = checkBox15.Checked;
            even[15] = checkBox16.Checked;
            even[16] = checkBox17.Checked;
            even[17] = checkBox18.Checked;
            even[18] = checkBox19.Checked;
            even[19] = checkBox20.Checked;
            even[20] = checkBox21.Checked;
            even[21] = checkBox22.Checked;
            even[22] = checkBox23.Checked;
            even[23] = checkBox24.Checked;
            even[24] = checkBox25.Checked;
            even[25] = checkBox26.Checked;
            even[26] = checkBox27.Checked;
            even[27] = checkBox28.Checked;
            even[28] = checkBox29.Checked;
            even[29] = checkBox30.Checked;
            even[30] = checkBox31.Checked;
            even[31] = checkBox32.Checked;
            even[32] = checkBox33.Checked;
            even[33] = checkBox34.Checked;
            even[34] = checkBox35.Checked;
            even[35] = checkBox36.Checked;
            even[36] = checkBox37.Checked;
            even[37] = checkBox38.Checked;
            even[38] = checkBox39.Checked;
            even[39] = checkBox40.Checked;
            even[40] = checkBox41.Checked;
            even[41] = checkBox42.Checked;
            even[42] = checkBox43.Checked;
            even[43] = checkBox44.Checked;
            even[44] = checkBox45.Checked;
            even[45] = checkBox46.Checked;
            even[46] = checkBox47.Checked;
            even[47] = checkBox48.Checked;
            even[48] = checkBox49.Checked;
            even[49] = checkBox50.Checked;
            even[50] = checkBox51.Checked;
            even[51] = checkBox52.Checked;
            even[52] = checkBox53.Checked;
            even[53] = checkBox54.Checked;
            even[54] = checkBox55.Checked;
            even[55] = checkBox56.Checked;
            even[56] = checkBox57.Checked;
            even[57] = checkBox58.Checked;
            even[58] = checkBox59.Checked;
            even[59] = checkBox60.Checked;
            even[60] = checkBox61.Checked;
            even[61] = checkBox62.Checked;
            even[62] = checkBox63.Checked;
            even[63] = checkBox64.Checked;
            even[64] = checkBox65.Checked;
            even[65] = checkBox66.Checked;
            even[66] = checkBox67.Checked;
            even[67] = checkBox68.Checked;
            even[68] = checkBox69.Checked;
            even[69] = checkBox70.Checked;
            even[70] = checkBox71.Checked;
            even[71] = checkBox72.Checked;
            even[72] = checkBox73.Checked;
            even[73] = checkBox74.Checked;
            even[74] = checkBox75.Checked;
            even[75] = checkBox76.Checked;
            even[76] = checkBox77.Checked;
            even[77] = checkBox78.Checked;
            even[78] = checkBox79.Checked;
            even[79] = checkBox80.Checked;
            even[80] = checkBox81.Checked;
        }

        //public bool CheckMistakes(int[] arg)
        //{
        //    int A;
        //    A = Convert.ToInt32(textBox1.Text); if (textBox1.Text != "" || A > 9 || A < 0) {textBox1.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox2.Text); if (textBox2.Text != "" || A > 9 || A < 0) {textBox2.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox3.Text); if (textBox3.Text != "" || A > 9 || A < 0) {textBox3.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox4.Text); if (textBox4.Text != "" || A > 9 || A < 0) {textBox4.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox5.Text); if (textBox5.Text != "" || A > 9 || A < 0) {textBox5.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox6.Text); if (textBox6.Text != "" || A > 9 || A < 0) {textBox6.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox7.Text); if (textBox7.Text != "" || A > 9 || A < 0) {textBox7.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox8.Text); if (textBox8.Text != "" || A > 9 || A < 0) {textBox8.ForeColor = Color.Red; return false; }
        //    A = Convert.ToInt32(textBox9.Text); if (textBox9.Text != "" || A > 9 || A < 0) { textBox9.ForeColor = Color.Red; return false; }
        //    A = Convert.ToInt32(textBox10.Text); if (textBox10.Text == "" || A > 9 || A < 0) {textBox10.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox11.Text); if (textBox11.Text == "" || A > 9 || A < 0) {textBox11.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox12.Text); if (textBox12.Text == "" || A > 9 || A < 0) {textBox12.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox13.Text); if (textBox13.Text == "" || A > 9 || A < 0) {textBox13.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox14.Text); if (textBox14.Text == "" || A > 9 || A < 0) {textBox14.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox15.Text); if (textBox15.Text == "" || A > 9 || A < 0) {textBox15.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox16.Text); if (textBox16.Text == "" || A > 9 || A < 0) {textBox16.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox17.Text); if (textBox17.Text == "" || A > 9 || A < 0) {textBox17.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox18.Text); if (textBox18.Text == "" || A > 9 || A < 0) {textBox18.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox19.Text); if (textBox19.Text == "" || A > 9 || A < 0) {textBox19.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox20.Text); if (textBox20.Text == "" || A > 9 || A < 0) {textBox20.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox21.Text); if (textBox21.Text == "" || A > 9 || A < 0) {textBox21.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox22.Text); if (textBox22.Text == "" || A > 9 || A < 0) {textBox22.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox23.Text); if (textBox23.Text == "" || A > 9 || A < 0) {textBox23.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox24.Text); if (textBox24.Text == "" || A > 9 || A < 0) {textBox24.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox25.Text); if (textBox25.Text == "" || A > 9 || A < 0) {textBox25.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox26.Text); if (textBox26.Text == "" || A > 9 || A < 0) {textBox26.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox27.Text); if (textBox27.Text == "" || A > 9 || A < 0) {textBox27.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox28.Text); if (textBox28.Text == "" || A > 9 || A < 0) {textBox28.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox29.Text); if (textBox29.Text == "" || A > 9 || A < 0) {textBox29.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox30.Text); if (textBox30.Text == "" || A > 9 || A < 0) {textBox30.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox31.Text); if (textBox31.Text == "" || A > 9 || A < 0) {textBox31.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox32.Text); if (textBox32.Text == "" || A > 9 || A < 0) {textBox32.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox33.Text); if (textBox33.Text == "" || A > 9 || A < 0) {textBox33.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox34.Text); if (textBox34.Text == "" || A > 9 || A < 0) {textBox34.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox35.Text); if (textBox35.Text == "" || A > 9 || A < 0) {textBox35.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox36.Text); if (textBox36.Text == "" || A > 9 || A < 0) {textBox36.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox37.Text); if (textBox37.Text == "" || A > 9 || A < 0) {textBox37.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox38.Text); if (textBox38.Text == "" || A > 9 || A < 0) {textBox38.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox39.Text); if (textBox39.Text == "" || A > 9 || A < 0) {textBox39.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox40.Text); if (textBox40.Text == "" || A > 9 || A < 0) {textBox40.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox41.Text); if (textBox41.Text == "" || A > 9 || A < 0) {textBox41.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox42.Text); if (textBox42.Text == "" || A > 9 || A < 0) {textBox42.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox43.Text); if (textBox43.Text == "" || A > 9 || A < 0) {textBox43.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox44.Text); if (textBox44.Text == "" || A > 9 || A < 0) {textBox44.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox45.Text); if (textBox45.Text == "" || A > 9 || A < 0) {textBox45.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox46.Text); if (textBox46.Text == "" || A > 9 || A < 0) {textBox46.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox47.Text); if (textBox47.Text == "" || A > 9 || A < 0) {textBox47.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox48.Text); if (textBox48.Text == "" || A > 9 || A < 0) {textBox48.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox49.Text); if (textBox49.Text == "" || A > 9 || A < 0) {textBox49.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox50.Text); if (textBox50.Text == "" || A > 9 || A < 0) {textBox50.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox51.Text); if (textBox51.Text == "" || A > 9 || A < 0) {textBox51.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox52.Text); if (textBox52.Text == "" || A > 9 || A < 0) {textBox52.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox53.Text); if (textBox53.Text == "" || A > 9 || A < 0) {textBox53.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox54.Text); if (textBox54.Text == "" || A > 9 || A < 0) {textBox54.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox55.Text); if (textBox55.Text == "" || A > 9 || A < 0) {textBox55.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox56.Text); if (textBox56.Text == "" || A > 9 || A < 0) {textBox56.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox57.Text); if (textBox57.Text == "" || A > 9 || A < 0) {textBox57.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox58.Text); if (textBox58.Text == "" || A > 9 || A < 0) {textBox58.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox59.Text); if (textBox59.Text == "" || A > 9 || A < 0) {textBox59.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox60.Text); if (textBox60.Text == "" || A > 9 || A < 0) {textBox60.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox61.Text); if (textBox61.Text == "" || A > 9 || A < 0) {textBox61.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox62.Text); if (textBox62.Text == "" || A > 9 || A < 0) {textBox62.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox63.Text); if (textBox63.Text == "" || A > 9 || A < 0) {textBox63.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox64.Text); if (textBox64.Text == "" || A > 9 || A < 0) {textBox64.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox65.Text); if (textBox65.Text == "" || A > 9 || A < 0) {textBox65.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox66.Text); if (textBox66.Text == "" || A > 9 || A < 0) {textBox66.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox67.Text); if (textBox67.Text == "" || A > 9 || A < 0) {textBox67.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox68.Text); if (textBox68.Text == "" || A > 9 || A < 0) {textBox68.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox69.Text); if (textBox69.Text == "" || A > 9 || A < 0) {textBox69.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox70.Text); if (textBox70.Text == "" || A > 9 || A < 0) {textBox70.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox71.Text); if (textBox71.Text == "" || A > 9 || A < 0) {textBox71.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox72.Text); if (textBox72.Text == "" || A > 9 || A < 0) {textBox72.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox73.Text); if (textBox73.Text == "" || A > 9 || A < 0) {textBox73.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox74.Text); if (textBox74.Text == "" || A > 9 || A < 0) {textBox74.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox75.Text); if (textBox75.Text == "" || A > 9 || A < 0) {textBox75.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox76.Text); if (textBox76.Text == "" || A > 9 || A < 0) {textBox76.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox77.Text); if (textBox77.Text == "" || A > 9 || A < 0) {textBox77.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox78.Text); if (textBox78.Text == "" || A > 9 || A < 0) {textBox78.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox79.Text); if (textBox79.Text == "" || A > 9 || A < 0) {textBox79.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox80.Text); if (textBox80.Text == "" || A > 9 || A < 0) {textBox80.ForeColor = Color.Red; return false;}
        //    A = Convert.ToInt32(textBox81.Text); if (textBox81.Text == "" || A > 9 || A < 0) {textBox81.ForeColor = Color.Red; return false;}
        //    return true;
        //}


        //Функция обновления
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";
            textBox50.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            textBox54.Text = "";
            textBox55.Text = "";
            textBox56.Text = "";
            textBox57.Text = "";
            textBox58.Text = "";
            textBox59.Text = "";
            textBox60.Text = "";
            textBox61.Text = "";
            textBox62.Text = "";
            textBox63.Text = "";
            textBox64.Text = "";
            textBox65.Text = "";
            textBox66.Text = "";
            textBox67.Text = "";
            textBox68.Text = "";
            textBox69.Text = "";
            textBox70.Text = "";
            textBox71.Text = "";
            textBox72.Text = "";
            textBox73.Text = "";
            textBox74.Text = "";
            textBox75.Text = "";
            textBox76.Text = "";
            textBox77.Text = "";
            textBox78.Text = "";
            textBox79.Text = "";
            textBox80.Text = "";
            textBox81.Text = "";

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label30.Text = "";
            label31.Text = "";
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "";
            label38.Text = "";
            label39.Text = "";
            label40.Text = "";
            label41.Text = "";
            label42.Text = "";
            label43.Text = "";
            label44.Text = "";
            label45.Text = "";
            label46.Text = "";
            label47.Text = "";
            label48.Text = "";
            label49.Text = "";
            label50.Text = "";
            label51.Text = "";
            label52.Text = "";
            label53.Text = "";
            label54.Text = "";
            label55.Text = "";
            label56.Text = "";
            label57.Text = "";
            label58.Text = "";
            label59.Text = "";
            label60.Text = "";
            label61.Text = "";
            label62.Text = "";
            label63.Text = "";
            label64.Text = "";
            label65.Text = "";
            label66.Text = "";
            label67.Text = "";
            label68.Text = "";
            label69.Text = "";
            label70.Text = "";
            label71.Text = "";
            label72.Text = "";
            label73.Text = "";
            label74.Text = "";
            label75.Text = "";
            label76.Text = "";
            label77.Text = "";
            label78.Text = "";
            label79.Text = "";
            label80.Text = "";
            label81.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            checkBox24.Checked = false;
            checkBox25.Checked = false;
            checkBox26.Checked = false;
            checkBox27.Checked = false;
            checkBox28.Checked = false;
            checkBox29.Checked = false;
            checkBox30.Checked = false;
            checkBox31.Checked = false;
            checkBox32.Checked = false;
            checkBox33.Checked = false;
            checkBox34.Checked = false;
            checkBox35.Checked = false;
            checkBox36.Checked = false;
            checkBox37.Checked = false;
            checkBox38.Checked = false;
            checkBox39.Checked = false;
            checkBox40.Checked = false;
            checkBox41.Checked = false;
            checkBox42.Checked = false;
            checkBox43.Checked = false;
            checkBox44.Checked = false;
            checkBox45.Checked = false;
            checkBox46.Checked = false;
            checkBox47.Checked = false;
            checkBox48.Checked = false;
            checkBox49.Checked = false;
            checkBox50.Checked = false;
            checkBox51.Checked = false;
            checkBox52.Checked = false;
            checkBox53.Checked = false;
            checkBox54.Checked = false;
            checkBox55.Checked = false;
            checkBox56.Checked = false;
            checkBox57.Checked = false;
            checkBox58.Checked = false;
            checkBox59.Checked = false;
            checkBox60.Checked = false;
            checkBox61.Checked = false;
            checkBox62.Checked = false;
            checkBox63.Checked = false;
            checkBox64.Checked = false;
            checkBox65.Checked = false;
            checkBox66.Checked = false;
            checkBox67.Checked = false;
            checkBox68.Checked = false;
            checkBox69.Checked = false;
            checkBox70.Checked = false;
            checkBox71.Checked = false;
            checkBox72.Checked = false;
            checkBox73.Checked = false;
            checkBox74.Checked = false;
            checkBox75.Checked = false;
            checkBox76.Checked = false;
            checkBox77.Checked = false;
            checkBox78.Checked = false;
            checkBox79.Checked = false;
            checkBox80.Checked = false;
            checkBox81.Checked = false;

            checkBox82.Checked = false;

            checkBox101.Checked = false;
            checkBox102.Checked = false;
            checkBox103.Checked = false;
            checkBox105.Checked = false;
            checkBox106.Checked = false;
            checkBox107.Checked = false;
            checkBox108.Checked = false;
            checkBox109.Checked = false;
            checkBox110.Checked = false;
            checkBox111.Checked = false;
            checkBox112.Checked = false;
            checkBox113.Checked = false;
            checkBox114.Checked = false;
            checkBox115.Checked = false;
            checkBox116.Checked = false;
            checkBox117.Checked = false;
            checkBox118.Checked = false;
            checkBox119.Checked = false;
            checkBox120.Checked = false;
            checkBox121.Checked = false;
            checkBox122.Checked = false;
            checkBox123.Checked = false;
            checkBox124.Checked = false;
            checkBox125.Checked = false;
            checkBox126.Checked = false;
            checkBox127.Checked = false;
            checkBox128.Checked = false;
            checkBox129.Checked = false;
            checkBox130.Checked = false;
            checkBox131.Checked = false;
            checkBox132.Checked = false;
            checkBox133.Checked = false;
            checkBox134.Checked = false;
            checkBox135.Checked = false;
            checkBox136.Checked = false;
            checkBox137.Checked = false;
            checkBox138.Checked = false;
            checkBox139.Checked = false;
            checkBox140.Checked = false;
            checkBox141.Checked = false;
            checkBox142.Checked = false;
            checkBox143.Checked = false;
            checkBox144.Checked = false;
            checkBox145.Checked = false;
            checkBox146.Checked = false;
            checkBox147.Checked = false;
            checkBox148.Checked = false;
            checkBox149.Checked = false;
            checkBox150.Checked = false;
            checkBox151.Checked = false;
            checkBox152.Checked = false;
            checkBox153.Checked = false;
            checkBox154.Checked = false;
            checkBox155.Checked = false;
            checkBox156.Checked = false;
            checkBox157.Checked = false;
            checkBox158.Checked = false;
            checkBox159.Checked = false;
            checkBox160.Checked = false;
            checkBox161.Checked = false;
            checkBox162.Checked = false;
            checkBox163.Checked = false;
            checkBox164.Checked = false;
            checkBox165.Checked = false;
            checkBox166.Checked = false;
            checkBox167.Checked = false;
            checkBox168.Checked = false;
            checkBox169.Checked = false;
            checkBox170.Checked = false;
            checkBox171.Checked = false;
            checkBox172.Checked = false;
            checkBox173.Checked = false;
            checkBox174.Checked = false;
            checkBox175.Checked = false;
            checkBox176.Checked = false;
            checkBox177.Checked = false;
            checkBox178.Checked = false;
            checkBox179.Checked = false;
            checkBox180.Checked = false;
            checkBox181.Checked = false;
        }
    }
}
