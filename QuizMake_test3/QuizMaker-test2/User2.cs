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
    public partial class User2 : Form
    {
        Quizmaker_Test3_CreateQuizEntities1 db = new Quizmaker_Test3_CreateQuizEntities1();
        public User2()
        {
            InitializeComponent();

            var query = (from result in db.Logs
                         where result.LogStatus == true
                         select result.User_Id).ToList();

            int id = Convert.ToInt32(query[0]);

            //var logstatusUpdate = db.Logs.Find(id);
            //logstatusUpdate.Log_OUT = DateTime.Now;

            var fullName = (from nameSurname in db.Users
                            where id == nameSurname.UserId
                            select nameSurname.UserFullName).ToList();
            lblUser.Text = fullName[0];

            //MessageBox.Show(id.ToString());
            db.SaveChanges();
        }
        

        private void btnLogOUT_Click(object sender, EventArgs e)
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
            this.Hide();
            // MessageBox.Show(logstatusUpdate.LogId.ToString());
        }

        private void BtnStartQuiz_Click(object sender, EventArgs e)
        {
            QuizFm quizFm = new QuizFm();
            quizFm.Show();
        }
    }
}
