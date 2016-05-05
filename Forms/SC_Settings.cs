using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class SC_Settings : Form
    {
        public SC_Settings()
        {
            InitializeComponent();
        }
        //
        public static int HomeworkPct;
        public static int QuizPct;
        public static int AssignmentPct;
        public static int MidtermPct;
        public static int AttendentPct;
        public static int FinalPct;

        private void SC_Settings_Load(object sender, EventArgs e)
        {
            Database.Open();
            btnSave.Enabled = false;
         /*   StudentScoreDB.SettingLoad();
            trbHW.Value = StudentScoreDB.HomeworkPct;
            trbQuiz.Value = StudentScoreDB.QuizPct;
            trbAss.Value = StudentScoreDB.AssignmentPct;
            trbMidterm.Value = StudentScoreDB.MidtermPct;
            trbAtt.Value = StudentScoreDB.AttendentPct;
            trbFinal.Value = StudentScoreDB.FinalPct;
            */
                    //
            lbHomework.Text = trbHW.Value.ToString() + " %";
            lbQuiz.Text = trbQuiz.Value.ToString() + " %";
            lbAssignment.Text = trbAss.Value.ToString() + " %";
            lbMidterm.Text = trbMidterm.Value.ToString() + " %";
            lbAttendent.Text = trbAtt.Value.ToString() + " %";
            lbFinal.Text = trbFinal.Value.ToString() + " %";

            trbHW.Enabled = false;
            trbQuiz.Enabled = false;
            trbAss.Enabled = false;
            trbMidterm.Enabled = false;
            trbAtt.Enabled = false;
            trbFinal.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            Design("Peru", "True");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           //////////////////////////////////////
            HomeworkPct = trbHW.Value;
            QuizPct = trbQuiz.Value;
            AssignmentPct = trbAss.Value;
            MidtermPct = trbMidterm.Value;
            AttendentPct = trbAtt.Value;
            FinalPct = trbFinal.Value;
            ///////////////////////////////////////
            //StudentScoreDB.Setting(HomeworkPct, QuizPct, AssignmentPct, MidtermPct, AttendentPct, FinalPct);
            Design("Silver","false");
        }
        private void Design(string Colors , string Option)
        {
            if (Colors == "Silver" && Option == "false")
            {
                ///////////////////////////////////////
                trbHW.Enabled = false;
                trbQuiz.Enabled = false;
                trbAss.Enabled = false;
                trbMidterm.Enabled = false;
                trbAtt.Enabled = false;
                trbFinal.Enabled = false;
                ///////////////////////////////////////
                trbHW.BackColor = Color.Silver;
                trbQuiz.BackColor = Color.Silver;
                trbAss.BackColor = Color.Silver;
                trbMidterm.BackColor = Color.Silver;
                trbAtt.BackColor = Color.Silver;
                trbFinal.BackColor = Color.Silver;
            }
            else if(Colors == "Peru" && Option == "True")
            {
                pnAss.BackColor = Color.Peru;
                pnAtt.BackColor = Color.Peru;
                pnHw.BackColor = Color.Peru;
                pnMt.BackColor = Color.Peru;
                pnQiuz.BackColor = Color.Peru;
                pnFn.BackColor = Color.Peru;
                trbHW.Enabled = true;
                trbQuiz.Enabled = true;
                trbAss.Enabled = true;
                trbMidterm.Enabled = true;
                trbAtt.Enabled = true;
                trbFinal.Enabled = true;
                /////////////////////////////////
                trbHW.BackColor = Color.Peru;
                trbQuiz.BackColor = Color.Peru;
                trbAss.BackColor = Color.Peru;
                trbMidterm.BackColor = Color.Peru;
                trbAtt.BackColor = Color.Peru;
                trbFinal.BackColor = Color.Peru;
            }
        }
        private void trbHW_Scroll(object sender, EventArgs e)
        {
            lbHomework.Text = trbHW.Value.ToString() + " %";
        }
        private void trbQuiz_Scroll(object sender, EventArgs e)
        {
            lbQuiz.Text = trbQuiz.Value.ToString() + " %";
        }

        private void trbAss_Scroll(object sender, EventArgs e)
        {
            lbAssignment.Text = trbAss.Value.ToString() + " %";
        }

        private void trbMidterm_Scroll(object sender, EventArgs e)
        {
            lbMidterm.Text = trbMidterm.Value.ToString() + " %";
        }

        private void trbAtt_Scroll(object sender, EventArgs e)
        {
            lbAttendent.Text = trbAtt.Value.ToString() + " %";
        }

        private void trbFinal_Scroll(object sender, EventArgs e)
        {
            lbFinal.Text = trbFinal.Value.ToString() + " %";
        }

        private void SC_Settings_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
    }
}
