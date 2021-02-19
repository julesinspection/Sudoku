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

        public void InputArgs(int[] arg, TextBox[] textBoxes)
        {
            TextBoxesToMass(textBoxes);
            for (int i = 0; i < 81; i++) {
                if (textBoxes[i].Text == "")
                    arg[i] = 0;
                else arg[i] = Convert.ToInt32(textBoxes[i].Text);
            }
        }

        public void InputEvenAndOdd(bool[] even,bool[] odd,CheckBox[] checkBoxes)
        {
            CheckBoxesToMass(checkBoxes);
            for (int i = 0; i < 81; i++) {
                even[i] = checkBoxes[i].Checked;
            }
            for (int i = 100; i < 181; i++) {
                odd[i - 100] = checkBoxes[i].Checked;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Label[] labels = new Label[81];
            TextBox[] textBoxes = new TextBox[81];
            CheckBox[] checkBoxes = new CheckBox[181];

            LabelsToMass(labels);
            TextBoxesToMass(textBoxes);
            CheckBoxesToMass(checkBoxes);

            for (int i = 0; i < 81; i++) {
                labels[i].Text = "";
                textBoxes[i].Text = "";
                checkBoxes[i].Checked = false;
            }
            for (int i = 100; i < 181; i++) {
                checkBoxes[i].Checked = false;
            }

            checkBox82.Checked = false;
        }

        public void Output(int[] arg, Label[] labels)
        {
            LabelsToMass(labels);
            for (int i = 0; i < 81; i++) {
                labels[i].Text = Convert.ToString(arg[i]);
            }
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

            Label[] labels = new Label[81];

            TextBox[] textBoxes = new TextBox[81];
            InputArgs(arg, textBoxes);

            CheckBox[] checkBoxes = new CheckBox[181];
            bool[] even = new bool[81];
            bool[] odd = new bool[81];
            InputEvenAndOdd(even, odd, checkBoxes);


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

            Output(arg, labels);
        }

        public void LabelsToMass(Label[] labels)
        {
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
            labels[5] = label6;
            labels[6] = label7;
            labels[7] = label8;
            labels[8] = label9;
            labels[9] = label10;
            labels[10] = label11;
            labels[11] = label12;
            labels[12] = label13;
            labels[13] = label14;
            labels[14] = label15;
            labels[15] = label16;
            labels[16] = label17;
            labels[17] = label18;
            labels[18] = label19;
            labels[19] = label20;
            labels[20] = label21;
            labels[21] = label22;
            labels[22] = label23;
            labels[23] = label24;
            labels[24] = label25;
            labels[25] = label26;
            labels[26] = label27;
            labels[27] = label28;
            labels[28] = label29;
            labels[29] = label30;
            labels[30] = label31;
            labels[31] = label32;
            labels[32] = label33;
            labels[33] = label34;
            labels[34] = label35;
            labels[35] = label36;
            labels[36] = label37;
            labels[37] = label38;
            labels[38] = label39;
            labels[39] = label40;
            labels[40] = label41;
            labels[41] = label42;
            labels[42] = label43;
            labels[43] = label44;
            labels[44] = label45;
            labels[45] = label46;
            labels[46] = label47;
            labels[47] = label48;
            labels[48] = label49;
            labels[49] = label50;
            labels[50] = label51;
            labels[51] = label52;
            labels[52] = label53;
            labels[53] = label54;
            labels[54] = label55;
            labels[55] = label56;
            labels[56] = label57;
            labels[57] = label58;
            labels[58] = label59;
            labels[59] = label60;
            labels[60] = label61;
            labels[61] = label62;
            labels[62] = label63;
            labels[63] = label64;
            labels[64] = label65;
            labels[65] = label66;
            labels[66] = label67;
            labels[67] = label68;
            labels[68] = label69;
            labels[69] = label70;
            labels[70] = label71;
            labels[71] = label72;
            labels[72] = label73;
            labels[73] = label74;
            labels[74] = label75;
            labels[75] = label76;
            labels[76] = label77;
            labels[77] = label78;
            labels[78] = label79;
            labels[79] = label80;
            labels[80] = label81;
        }

        public void TextBoxesToMass(TextBox[] textboxes)
        {
            textboxes[0] =  textBox1;
            textboxes[1] =  textBox2;
            textboxes[2] =  textBox3;
            textboxes[3] =  textBox4;
            textboxes[4] =  textBox5;
            textboxes[5] =  textBox6;
            textboxes[6] =  textBox7;
            textboxes[7] =  textBox8;
            textboxes[8] =  textBox9;
            textboxes[9] =  textBox10;
            textboxes[10] = textBox11;
            textboxes[11] = textBox12;
            textboxes[12] = textBox13;
            textboxes[13] = textBox14;
            textboxes[14] = textBox15;
            textboxes[15] = textBox16;
            textboxes[16] = textBox17;
            textboxes[17] = textBox18;
            textboxes[18] = textBox19;
            textboxes[19] = textBox20;
            textboxes[20] = textBox21;
            textboxes[21] = textBox22;
            textboxes[22] = textBox23;
            textboxes[23] = textBox24;
            textboxes[24] = textBox25;
            textboxes[25] = textBox26;
            textboxes[26] = textBox27;
            textboxes[27] = textBox28;
            textboxes[28] = textBox29;
            textboxes[29] = textBox30;
            textboxes[30] = textBox31;
            textboxes[31] = textBox32;
            textboxes[32] = textBox33;
            textboxes[33] = textBox34;
            textboxes[34] = textBox35;
            textboxes[35] = textBox36;
            textboxes[36] = textBox37;
            textboxes[37] = textBox38;
            textboxes[38] = textBox39;
            textboxes[39] = textBox40;
            textboxes[40] = textBox41;
            textboxes[41] = textBox42;
            textboxes[42] = textBox43;
            textboxes[43] = textBox44;
            textboxes[44] = textBox45;
            textboxes[45] = textBox46;
            textboxes[46] = textBox47;
            textboxes[47] = textBox48;
            textboxes[48] = textBox49;
            textboxes[49] = textBox50;
            textboxes[50] = textBox51;
            textboxes[51] = textBox52;
            textboxes[52] = textBox53;
            textboxes[53] = textBox54;
            textboxes[54] = textBox55;
            textboxes[55] = textBox56;
            textboxes[56] = textBox57;
            textboxes[57] = textBox58;
            textboxes[58] = textBox59;
            textboxes[59] = textBox60;
            textboxes[60] = textBox61;
            textboxes[61] = textBox62;
            textboxes[62] = textBox63;
            textboxes[63] = textBox64;
            textboxes[64] = textBox65;
            textboxes[65] = textBox66;
            textboxes[66] = textBox67;
            textboxes[67] = textBox68;
            textboxes[68] = textBox69;
            textboxes[69] = textBox70;
            textboxes[70] = textBox71;
            textboxes[71] = textBox72;
            textboxes[72] = textBox73;
            textboxes[73] = textBox74;
            textboxes[74] = textBox75;
            textboxes[75] = textBox76;
            textboxes[76] = textBox77;
            textboxes[77] = textBox78;
            textboxes[78] = textBox79;
            textboxes[79] = textBox80;
            textboxes[80] = textBox81;
        }

        public void CheckBoxesToMass(CheckBox[] checkBoxes)
        {
            checkBoxes[0] =  checkBox1;
            checkBoxes[1] =  checkBox2;
            checkBoxes[2] =  checkBox3;
            checkBoxes[3] =  checkBox4;
            checkBoxes[4] =  checkBox5;
            checkBoxes[5] =  checkBox6;
            checkBoxes[6] =  checkBox7;
            checkBoxes[7] =  checkBox8;
            checkBoxes[8] =  checkBox9;
            checkBoxes[9] =  checkBox10;
            checkBoxes[10] = checkBox11;
            checkBoxes[11] = checkBox12;
            checkBoxes[12] = checkBox13;
            checkBoxes[13] = checkBox14;
            checkBoxes[14] = checkBox15;
            checkBoxes[15] = checkBox16;
            checkBoxes[16] = checkBox17;
            checkBoxes[17] = checkBox18;
            checkBoxes[18] = checkBox19;
            checkBoxes[19] = checkBox20;
            checkBoxes[20] = checkBox21;
            checkBoxes[21] = checkBox22;
            checkBoxes[22] = checkBox23;
            checkBoxes[23] = checkBox24;
            checkBoxes[24] = checkBox25;
            checkBoxes[25] = checkBox26;
            checkBoxes[26] = checkBox27;
            checkBoxes[27] = checkBox28;
            checkBoxes[28] = checkBox29;
            checkBoxes[29] = checkBox30;
            checkBoxes[30] = checkBox31;
            checkBoxes[31] = checkBox32;
            checkBoxes[32] = checkBox33;
            checkBoxes[33] = checkBox34;
            checkBoxes[34] = checkBox35;
            checkBoxes[35] = checkBox36;
            checkBoxes[36] = checkBox37;
            checkBoxes[37] = checkBox38;
            checkBoxes[38] = checkBox39;
            checkBoxes[39] = checkBox40;
            checkBoxes[40] = checkBox41;
            checkBoxes[41] = checkBox42;
            checkBoxes[42] = checkBox43;
            checkBoxes[43] = checkBox44;
            checkBoxes[44] = checkBox45;
            checkBoxes[45] = checkBox46;
            checkBoxes[46] = checkBox47;
            checkBoxes[47] = checkBox48;
            checkBoxes[48] = checkBox49;
            checkBoxes[49] = checkBox50;
            checkBoxes[50] = checkBox51;
            checkBoxes[51] = checkBox52;
            checkBoxes[52] = checkBox53;
            checkBoxes[53] = checkBox54;
            checkBoxes[54] = checkBox55;
            checkBoxes[55] = checkBox56;
            checkBoxes[56] = checkBox57;
            checkBoxes[57] = checkBox58;
            checkBoxes[58] = checkBox59;
            checkBoxes[59] = checkBox60;
            checkBoxes[60] = checkBox61;
            checkBoxes[61] = checkBox62;
            checkBoxes[62] = checkBox63;
            checkBoxes[63] = checkBox64;
            checkBoxes[64] = checkBox65;
            checkBoxes[65] = checkBox66;
            checkBoxes[66] = checkBox67;
            checkBoxes[67] = checkBox68;
            checkBoxes[68] = checkBox69;
            checkBoxes[69] = checkBox70;
            checkBoxes[70] = checkBox71;
            checkBoxes[71] = checkBox72;
            checkBoxes[72] = checkBox73;
            checkBoxes[73] = checkBox74;
            checkBoxes[74] = checkBox75;
            checkBoxes[75] = checkBox76;
            checkBoxes[76] = checkBox77;
            checkBoxes[77] = checkBox78;
            checkBoxes[78] = checkBox79;
            checkBoxes[79] = checkBox80;
            checkBoxes[80] = checkBox81;

            checkBoxes[100] = checkBox101;
            checkBoxes[101] = checkBox102;
            checkBoxes[102] = checkBox103;
            checkBoxes[103] = checkBox104;
            checkBoxes[104] = checkBox105;
            checkBoxes[105] = checkBox106;
            checkBoxes[106] = checkBox107;
            checkBoxes[107] = checkBox108;
            checkBoxes[108] = checkBox109;
            checkBoxes[109] = checkBox110;
            checkBoxes[110] = checkBox111;
            checkBoxes[111] = checkBox112;
            checkBoxes[112] = checkBox113;
            checkBoxes[113] = checkBox114;
            checkBoxes[114] = checkBox115;
            checkBoxes[115] = checkBox116;
            checkBoxes[116] = checkBox117;
            checkBoxes[117] = checkBox118;
            checkBoxes[118] = checkBox119;
            checkBoxes[119] = checkBox120;
            checkBoxes[120] = checkBox121;
            checkBoxes[121] = checkBox122;
            checkBoxes[122] = checkBox123;
            checkBoxes[123] = checkBox124;
            checkBoxes[124] = checkBox125;
            checkBoxes[125] = checkBox126;
            checkBoxes[126] = checkBox127;
            checkBoxes[127] = checkBox128;
            checkBoxes[128] = checkBox129;
            checkBoxes[129] = checkBox130;
            checkBoxes[130] = checkBox131;
            checkBoxes[131] = checkBox132;
            checkBoxes[132] = checkBox133;
            checkBoxes[133] = checkBox134;
            checkBoxes[134] = checkBox135;
            checkBoxes[135] = checkBox136;
            checkBoxes[136] = checkBox137;
            checkBoxes[137] = checkBox138;
            checkBoxes[138] = checkBox139;
            checkBoxes[139] = checkBox140;
            checkBoxes[140] = checkBox141;
            checkBoxes[141] = checkBox142;
            checkBoxes[142] = checkBox143;
            checkBoxes[143] = checkBox144;
            checkBoxes[144] = checkBox145;
            checkBoxes[145] = checkBox146;
            checkBoxes[146] = checkBox147;
            checkBoxes[147] = checkBox148;
            checkBoxes[148] = checkBox149;
            checkBoxes[149] = checkBox150;
            checkBoxes[150] = checkBox151;
            checkBoxes[151] = checkBox152;
            checkBoxes[152] = checkBox153;
            checkBoxes[153] = checkBox154;
            checkBoxes[154] = checkBox155;
            checkBoxes[155] = checkBox156;
            checkBoxes[156] = checkBox157;
            checkBoxes[157] = checkBox158;
            checkBoxes[158] = checkBox159;
            checkBoxes[159] = checkBox160;
            checkBoxes[160] = checkBox161;
            checkBoxes[161] = checkBox162;
            checkBoxes[162] = checkBox163;
            checkBoxes[163] = checkBox164;
            checkBoxes[164] = checkBox165;
            checkBoxes[165] = checkBox166;
            checkBoxes[166] = checkBox167;
            checkBoxes[167] = checkBox168;
            checkBoxes[168] = checkBox169;
            checkBoxes[169] = checkBox170;
            checkBoxes[170] = checkBox171;
            checkBoxes[171] = checkBox172;
            checkBoxes[172] = checkBox173;
            checkBoxes[173] = checkBox174;
            checkBoxes[174] = checkBox175;
            checkBoxes[175] = checkBox176;
            checkBoxes[176] = checkBox177;
            checkBoxes[177] = checkBox178;
            checkBoxes[178] = checkBox179;
            checkBoxes[179] = checkBox180;
            checkBoxes[180] = checkBox181;
        }

    }
}
