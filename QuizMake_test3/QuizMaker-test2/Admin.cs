using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMaker_test2
{
    public partial class Admin : Form
    {
        Quizmaker_Test3_CreateQuizEntities1 db = new Quizmaker_Test3_CreateQuizEntities1();
        DataGridView logs = new DataGridView();
        DataGridView QuizAndQuestions = new DataGridView();



        public Admin()
        {
            InitializeComponent();
            var query = (from result in db.Logs
                         where result.LogStatus==true
                         select result.User_Id).ToList();
            int id = Convert.ToInt32(query[0]);

            //var logstatusUpdate = db.Logs.Find(id);
            //logstatusUpdate.Log_OUT = DateTime.Now;

            var fullName = (from nameSurname in db.Users
                            where id == nameSurname.UserId
                            select nameSurname.UserFullName).ToList();
            lblNameSrNm.Text = fullName[0];


            //MessageBox.Show(id.ToString());
            ///////////////////////////////////////////////////////////////
            // grbCreateQuiz.Visible = false;
            //foreach (var item in db.Quizs)
            //{
            //    cbxQuizName.Items.Add(item.QuizName);
            //}
            ///////////////////////////////////////////////////////////////
            #region quiz adlarinin comboboxa seplendiyi yer 
            var item = (from name in db.Quizs
                        select name.QuizName).ToList();               /////////// cbx quiz name
            cbxQuizName.DataSource = item;
            #endregion
            db.SaveChanges();
        }
        ///
        private void btnLogOut_Click(object sender, EventArgs e)
        {

            var query = (from result in db.Logs
                         where result.LogStatus == true
                         select result.LogId).ToList();

            int id = Convert.ToInt32(query[0]);

            var logstatusUpdate = db.Logs.Find(id);
            logstatusUpdate.Log_OUT = DateTime.Now;
            logstatusUpdate.LogStatus = false;
            // MessageBox.Show(logstatusUpdate.Log_OUT.ToString());
            db.SaveChanges();
            //MessageBox.Show(logstatusUpdate.LogId.ToString());
            this.Hide();
            //db.SaveChanges();
        }
        ///
        private void btnLOG_Click(object sender, EventArgs e)
        {
            #region datagridview
            
            logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            logs.Location = new System.Drawing.Point(210, 90);
            logs.Size = new System.Drawing.Size(750, 400);
            
            logs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            ////////
            ///
            var results = from log in db.Logs
                          join user in db.Users
                          on log.User_Id equals user.UserId
                          select new
                          {
                              LogId = log.LogId,
                              UserName = user.UserFullName,
                              LogInDate = log.Log_IN,
                              LogOutDate = log.Log_OUT,
                              logStatus = log.LogStatus
                          };
            logs.DataSource = results.ToList();
            this.Controls.Add(logs);
            #endregion
            if (grbCreateQuiz.Visible == true)
            {
                logs.Visible = true;
                grbCreateQuiz.Visible = false;
            }
            else
            {
                logs.Visible = true;
            }
            
        }
        
        ///
        private void btnCreateQuiz_Click(object sender, EventArgs e)
        {
            if (logs.Visible == true)
            {
               
                grbCreateQuiz.Visible = true;
                logs.Visible = false;
            }
            else
            {
                grbCreateQuiz.Visible = true;
                logs.Visible = false;
            }
        }
        
        ///
        private void btnAddQuiz_Click(object sender, EventArgs e)
        {

            var Q_name = tbxQuizName.Text;
            var Q_score = tbxQuizMaxScore.Text;
            var query = (from result in db.Logs
                         where result.LogStatus == true
                         select result.User_Id).ToList();
            int id = Convert.ToInt32(query[0]);
            db.Quizs.Add(new Quiz()
            {


                QuizName = Q_name,
                QuizMaxScore = Convert.ToInt32(Q_score),
                OrganiserId = id,
                CreateDateTime = DateTime.Now

            });

           
            db.SaveChanges();
            foreach (Control item in grbCreateQuiz.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }

        }
        ///
        private void btnAddQuestions_Click(object sender, EventArgs e)
        {
            var title = tbxTitle.Text;
            var a = tbxA.Text;
            var b = tbxB.Text;
            var c = tbxC.Text;
            var d = tbxD.Text;
            var rightAnswer = tbxRightAnswer.Text;

            db.Questions.Add(new Question()
            {
                QuestionTitle = title,
                Q_A = a,
                Q_B = b,
                Q_C = c,
                Q_D = d,
                Q_CorrectAnswer = rightAnswer,
                QuizId = db.Quizs.Where(qId => qId.QuizName == cbxQuizName.SelectedItem.ToString()).First().QuizId

            });
            //db.SaveChanges();
           
            foreach (Control item in grbQuestion.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
            //var items = (from name in db.Quizs
            //             select name.QuizName).ToList();
            //BindingSource cbx = new BindingSource();
            //cbx.DataSource = items;
            //cbxQuizName.DataSource = cbx;
        }
        ///
        private void Admin_Form_FormClosed(object sender, FormClosedEventArgs e)
        {

            var query = (from result in db.Logs
                         where result.LogStatus == true
                         select result.LogId).ToList();

            int id = Convert.ToInt32(query[0]);

            var logstatusUpdate = db.Logs.Find(id);
            logstatusUpdate.Log_OUT = DateTime.Now;
            logstatusUpdate.LogStatus = false;
            // MessageBox.Show(logstatusUpdate.Log_OUT.ToString());
            db.SaveChanges();
            // MessageBox.Show(logstatusUpdate.LogId.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var item = (from name in db.Quizs
                        select name.QuizName).ToList();
            BindingSource cbx = new BindingSource();
            cbx.DataSource = item;
            cbxQuizName.DataSource = cbx;
        }
        
    }
}
