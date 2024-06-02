using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            if (Login(username, password) == true)
            {
                int roleId = GetRoleId(username, password);
                fTableManager ftableManager = new fTableManager();
                string connectionString = GetConnectionString(roleId);
                DataProvider.Instance.UpdateConnectionString(connectionString);
                this.Hide();
                ftableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn đã điền sai tên tài khoản hoặc mật khẩu!");
            }
        }

        int GetRoleId(string username, string password)
        {
            return AccountDAO.Instance.GetRoleId(username, password);
        }

        private string GetConnectionString(int roleId)
        {
            if (roleId == 1)
            {
                return @"Data Source=.;Initial Catalog=QLThuVien;uid=librarian;pwd=123";
            }
            else
            {
                return @"Data Source=.;Initial Catalog=QLThuVien;uid=student;pwd=123";
            }
        }
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e) // Xử lý thoát chương trình
        {
            if(MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK )
            {
                e.Cancel = true;
            }    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
