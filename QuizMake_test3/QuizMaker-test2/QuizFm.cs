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
    public partial class QuizFm : Form
    {

        public List<Question> RandomList { get; set; }

        Quizmaker_Test3_CreateQuizEntities1 db = new Quizmaker_Test3_CreateQuizEntities1();
        public QuizFm()
        {
            InitializeComponent();

            #region quiz adlarinin comboboxa seplendiyi yer 
            var item = (from name in db.Quizs
                        select name.QuizName).ToList();               /////////// cbx quiz name
            cbxQuizName.DataSource = item;
            #endregion
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            var QuizId = db.Quizs.Where(qId => qId.QuizName == cbxQuizName.SelectedItem.ToString()).First().QuizId;
            //  MessageBox.Show(QuizId.ToString());

            // IQueryable<Question> result = db.Questions.OrderBy(c => Guid.NewGuid()).Take(8);
            // var result = db.Questions.OrderBy(c => c.QuestionId).Take(8);
            //var query = db.Questions.OrderBy(question => db.NewId()).Take(6);
            var list = new List<Question>();

            var count = db.Questions.Count();
            var rand = new Random();
            var randomNumber = rand.Next(count);
            list = db.Questions.ToList();

            RandomList = list;
            var firstQuestion = RandomList[randomNumber];

            if (firstQuestion.QuizId == QuizId)
            {
                tbxTitle.Text = firstQuestion.QuestionTitle;
                btnA.Text = firstQuestion.Q_A;
                btnB.Text = firstQuestion.Q_B;
                btnC.Text = firstQuestion.Q_C;
                btnD.Text = firstQuestion.Q_D;
                lblRightAnswer.Text = firstQuestion.Q_CorrectAnswer;
            }
            RandomList.Remove(firstQuestion);


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            //for (int i = 1; i < RandomList.Count; i++)
            //{
            //    if(RandomList.)
            //}
            var QuizId = db.Quizs.Where(qId => qId.QuizName == cbxQuizName.SelectedItem.ToString()).First().QuizId;

            var count = RandomList.Count;
            var rand = new Random();
            var randomNumber = rand.Next(count);

            
            if (RandomList.Count != 0)
            {
                var nextQuestion = RandomList[randomNumber];

                if (nextQuestion.QuizId == QuizId)
                {
                    tbxTitle.Text = nextQuestion.QuestionTitle;
                    btnA.Text = nextQuestion.Q_A;
                    btnB.Text = nextQuestion.Q_B;
                    btnC.Text = nextQuestion.Q_C;
                    btnD.Text = nextQuestion.Q_D;
                    lblRightAnswer.Text = nextQuestion.Q_CorrectAnswer;
                }
                RandomList.Remove(nextQuestion);
                count = RandomList.Count;
            }
        }
    }
}
