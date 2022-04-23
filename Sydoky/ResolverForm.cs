using System;
using System.Windows.Forms;

namespace Sydoky {
    public partial class ResolverForm : Form
    {
        public ResolverForm()
        {
            InitializeComponent();
        }
        public static Label[] labels = new Label[81];
        public static int[] arg = new int[81];
        public static TextBox[] textBoxes = new TextBox[181];
        public static CheckBox[] checkBoxes = new CheckBox[181];

        public void InputArgs()
        {
            TextBoxesToMass();
            for (int i = 0; i < 81; i++) {
                if (textBoxes[i].Text == "")
                    arg[i] = 0;
                else arg[i] = Convert.ToInt32(textBoxes[i].Text);
            }
        }

        public void InputEvenAndOdd()
        {
            CheckBoxesToMass();
            for (int i = 0; i < 81; i++) {
                Data.even[i] = checkBoxes[i].Checked;
            }
            for (int i = 100; i < 181; i++) {
                Data.odd[i - 100] = checkBoxes[i].Checked;
            }
        }

        // Условия отбора
        static bool sCondition(int k, int n,  int[] figures, bool d)
        {
            // Горизонталь
            for (int i = n % 9; i < 81; i += 9){
                if (k == arg[i])
                    return false;
            }

            // Вертикаль
            for (int i = n / 9 * 9; i < ((n / 9) + 1) * 9; i++){
                if (k == arg[i])
                    return false;
            }

            
            // Фигуры
            for(int i = 0; i < 81; i++) {
                if(k == arg[i] && figures[i] == figures[n]) {
                    return false;
                }
            }

            // Четное
            if (Data.even[n] == true && k % 2 == 1)
                return false;
            // Нечетное
            if (Data.odd[n] == true && k % 2 == 0)
                return false;

            // Диагонали
            if (d == true)
            {
                // Слева направо
                if(n % 10 == 0)
                    for(int i = 0; i < 81; i += 10)
                        if (k == arg[i])
                            return false;

                // Справа налево
                if (n % 8 == 0 && n != 80)
                    for (int i = 8; i < 80; i += 8)
                        if (k == arg[i])
                            return false;
            }

            return true;
        }

        // Обнуление
        private void button2_Click(object sender, EventArgs e)
        {
            LabelsToMass();
            TextBoxesToMass();
            CheckBoxesToMass();

            for (int i = 0; i < 81; i++) {
                labels[i].Text = "";
                textBoxes[i].Text = "";
                checkBoxes[i].Checked = false;
            }
            for (int i = 100; i < 181; i++) {
                textBoxes[i].Text = "1";
                checkBoxes[i].Checked = false;
            }

            checkBox82.Checked = false;

            textBox101.Text = "1";
            textBox102.Text = "1";
            textBox103.Text = "1";
            textBox104.Text = "2";
            textBox105.Text = "2";
            textBox106.Text = "2";
            textBox107.Text = "3";
            textBox108.Text = "3";
            textBox109.Text = "3";
            textBox110.Text = "1";
            textBox111.Text = "1";
            textBox112.Text = "1";
            textBox113.Text = "2";
            textBox114.Text = "2";
            textBox115.Text = "2";
            textBox116.Text = "3";
            textBox117.Text = "3";
            textBox118.Text = "3";
            textBox119.Text = "1";
            textBox120.Text = "1";
            textBox121.Text = "1";
            textBox122.Text = "2";
            textBox123.Text = "2";
            textBox124.Text = "2";
            textBox125.Text = "3";
            textBox126.Text = "3";
            textBox127.Text = "3";
            textBox128.Text = "4";
            textBox129.Text = "4";
            textBox130.Text = "4";
            textBox131.Text = "5";
            textBox132.Text = "5";
            textBox133.Text = "5";
            textBox134.Text = "6";
            textBox135.Text = "6";
            textBox136.Text = "6";
            textBox137.Text = "4";
            textBox138.Text = "4";
            textBox139.Text = "4";
            textBox140.Text = "5";
            textBox141.Text = "5";
            textBox142.Text = "5";
            textBox143.Text = "6";
            textBox144.Text = "6";
            textBox145.Text = "6";
            textBox146.Text = "4";
            textBox147.Text = "4";
            textBox148.Text = "4";
            textBox149.Text = "5";
            textBox150.Text = "5";
            textBox151.Text = "5";
            textBox152.Text = "6";
            textBox153.Text = "6";
            textBox154.Text = "6";
            textBox155.Text = "7";
            textBox156.Text = "7";
            textBox157.Text = "7";
            textBox158.Text = "8";
            textBox159.Text = "8";
            textBox160.Text = "8";
            textBox161.Text = "9";
            textBox162.Text = "9";
            textBox163.Text = "9";
            textBox164.Text = "7";
            textBox165.Text = "7";
            textBox166.Text = "7";
            textBox167.Text = "8";
            textBox168.Text = "8";
            textBox169.Text = "8";
            textBox170.Text = "9";
            textBox171.Text = "9";
            textBox172.Text = "9";
            textBox173.Text = "7";
            textBox174.Text = "7";
            textBox175.Text = "7";
            textBox176.Text = "8";
            textBox177.Text = "8";
            textBox178.Text = "8";
            textBox179.Text = "9";
            textBox180.Text = "9";
            textBox181.Text = "9";
        }

        // Вывод
        public void Output(int[] outputMass, Label[] labels)
        {
            LabelsToMass();
            for (int i = 0; i < 81; i++) {
                labels[i].Text = Convert.ToString(outputMass[i]);
            }
        }

        // Алгоритм
        private void button1_Click(object sender, EventArgs e)
        {
            int i;

            bool flag = false;

            InputArgs();
            InputEvenAndOdd();

            bool diagonal = checkBox82.Checked;

            int[] figures = new int[81];
            for (i = 0; i < 81; i++) {
                    figures[i] = Convert.ToInt32(textBoxes[100 + i].Text);   
            }

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
                        // Нашли подходящее по условию число
                        if (sCondition(k, i, figures, diagonal) == true){
                            arg[i] = k;
                            aDone[i] = k;
                            break;
                        }

                        // Не нашли
                        if (sCondition(k, i, figures, diagonal) == false && k == 9) {
                            if(i == 0){
                                MessageBox.Show("Решения нет");
                                flag = true;
                            }
                            aDone[i] = 1;
                            arg[i] = 0;

                            i--;
                            
                            // Вычисляем путь назад
                            while (true) {
                                if (i > -1 && aDone[i] == -1) {
                                    i--;
                                } else break;
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


        // Ввод данных
        public void LabelsToMass()
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

        public void TextBoxesToMass()
        {
            textBoxes[0] =  textBox1;
            textBoxes[1] =  textBox2;
            textBoxes[2] =  textBox3;
            textBoxes[3] =  textBox4;
            textBoxes[4] =  textBox5;
            textBoxes[5] =  textBox6;
            textBoxes[6] =  textBox7;
            textBoxes[7] =  textBox8;
            textBoxes[8] =  textBox9;
            textBoxes[9] =  textBox10;
            textBoxes[10] = textBox11;
            textBoxes[11] = textBox12;
            textBoxes[12] = textBox13;
            textBoxes[13] = textBox14;
            textBoxes[14] = textBox15;
            textBoxes[15] = textBox16;
            textBoxes[16] = textBox17;
            textBoxes[17] = textBox18;
            textBoxes[18] = textBox19;
            textBoxes[19] = textBox20;
            textBoxes[20] = textBox21;
            textBoxes[21] = textBox22;
            textBoxes[22] = textBox23;
            textBoxes[23] = textBox24;
            textBoxes[24] = textBox25;
            textBoxes[25] = textBox26;
            textBoxes[26] = textBox27;
            textBoxes[27] = textBox28;
            textBoxes[28] = textBox29;
            textBoxes[29] = textBox30;
            textBoxes[30] = textBox31;
            textBoxes[31] = textBox32;
            textBoxes[32] = textBox33;
            textBoxes[33] = textBox34;
            textBoxes[34] = textBox35;
            textBoxes[35] = textBox36;
            textBoxes[36] = textBox37;
            textBoxes[37] = textBox38;
            textBoxes[38] = textBox39;
            textBoxes[39] = textBox40;
            textBoxes[40] = textBox41;
            textBoxes[41] = textBox42;
            textBoxes[42] = textBox43;
            textBoxes[43] = textBox44;
            textBoxes[44] = textBox45;
            textBoxes[45] = textBox46;
            textBoxes[46] = textBox47;
            textBoxes[47] = textBox48;
            textBoxes[48] = textBox49;
            textBoxes[49] = textBox50;
            textBoxes[50] = textBox51;
            textBoxes[51] = textBox52;
            textBoxes[52] = textBox53;
            textBoxes[53] = textBox54;
            textBoxes[54] = textBox55;
            textBoxes[55] = textBox56;
            textBoxes[56] = textBox57;
            textBoxes[57] = textBox58;
            textBoxes[58] = textBox59;
            textBoxes[59] = textBox60;
            textBoxes[60] = textBox61;
            textBoxes[61] = textBox62;
            textBoxes[62] = textBox63;
            textBoxes[63] = textBox64;
            textBoxes[64] = textBox65;
            textBoxes[65] = textBox66;
            textBoxes[66] = textBox67;
            textBoxes[67] = textBox68;
            textBoxes[68] = textBox69;
            textBoxes[69] = textBox70;
            textBoxes[70] = textBox71;
            textBoxes[71] = textBox72;
            textBoxes[72] = textBox73;
            textBoxes[73] = textBox74;
            textBoxes[74] = textBox75;
            textBoxes[75] = textBox76;
            textBoxes[76] = textBox77;
            textBoxes[77] = textBox78;
            textBoxes[78] = textBox79;
            textBoxes[79] = textBox80;
            textBoxes[80] = textBox81;

            textBoxes[100] = textBox101;
            textBoxes[101] = textBox102;
            textBoxes[102] = textBox103;
            textBoxes[103] = textBox104;
            textBoxes[104] = textBox105;
            textBoxes[105] = textBox106;
            textBoxes[106] = textBox107;
            textBoxes[107] = textBox108;
            textBoxes[108] = textBox109;
            textBoxes[109] = textBox110;
            textBoxes[110] = textBox111;
            textBoxes[111] = textBox112;
            textBoxes[112] = textBox113;
            textBoxes[113] = textBox114;
            textBoxes[114] = textBox115;
            textBoxes[115] = textBox116;
            textBoxes[116] = textBox117;
            textBoxes[117] = textBox118;
            textBoxes[118] = textBox119;
            textBoxes[119] = textBox120;
            textBoxes[120] = textBox121;
            textBoxes[121] = textBox122;
            textBoxes[122] = textBox123;
            textBoxes[123] = textBox124;
            textBoxes[124] = textBox125;
            textBoxes[125] = textBox126;
            textBoxes[126] = textBox127;
            textBoxes[127] = textBox128;
            textBoxes[128] = textBox129;
            textBoxes[129] = textBox130;
            textBoxes[130] = textBox131;
            textBoxes[131] = textBox132;
            textBoxes[132] = textBox133;
            textBoxes[133] = textBox134;
            textBoxes[134] = textBox135;
            textBoxes[135] = textBox136;
            textBoxes[136] = textBox137;
            textBoxes[137] = textBox138;
            textBoxes[138] = textBox139;
            textBoxes[139] = textBox140;
            textBoxes[140] = textBox141;
            textBoxes[141] = textBox142;
            textBoxes[142] = textBox143;
            textBoxes[143] = textBox144;
            textBoxes[144] = textBox145;
            textBoxes[145] = textBox146;
            textBoxes[146] = textBox147;
            textBoxes[147] = textBox148;
            textBoxes[148] = textBox149;
            textBoxes[149] = textBox150;
            textBoxes[150] = textBox151;
            textBoxes[151] = textBox152;
            textBoxes[152] = textBox153;
            textBoxes[153] = textBox154;
            textBoxes[154] = textBox155;
            textBoxes[155] = textBox156;
            textBoxes[156] = textBox157;
            textBoxes[157] = textBox158;
            textBoxes[158] = textBox159;
            textBoxes[159] = textBox160;
            textBoxes[160] = textBox161;
            textBoxes[161] = textBox162;
            textBoxes[162] = textBox163;
            textBoxes[163] = textBox164;
            textBoxes[164] = textBox165;
            textBoxes[165] = textBox166;
            textBoxes[166] = textBox167;
            textBoxes[167] = textBox168;
            textBoxes[168] = textBox169;
            textBoxes[169] = textBox170;
            textBoxes[170] = textBox171;
            textBoxes[171] = textBox172;
            textBoxes[172] = textBox173;
            textBoxes[173] = textBox174;
            textBoxes[174] = textBox175;
            textBoxes[175] = textBox176;
            textBoxes[176] = textBox177;
            textBoxes[177] = textBox178;
            textBoxes[178] = textBox179;
            textBoxes[179] = textBox180;
            textBoxes[180] = textBox181;
        }

        public void CheckBoxesToMass()
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

        private void ResolverForm_Load(object sender, EventArgs e)
        {

        }
    }
}
