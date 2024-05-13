using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCongTyDone
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}
		SqlConnection conn = new SqlConnection(@"Data Source=TUF-DASH-F15\SQLSERVER;Initial Catalog=QLCONGTY;Integrated Security=True;");




		private void btlogin_Click(object sender, EventArgs e)
		{
			String username, password;
			username = tbusername.Text;
			password = tbpassword.Text;
			try
			{
				String query = "SELECT * FROM UserAccount WHERE" +
					" username  = '" + tbusername.Text + "'   AND password = '" + tbpassword.Text + "'";
				SqlDataAdapter sda = new SqlDataAdapter(query, conn);

				DataTable dtable = new DataTable();
				sda.Fill(dtable);

				if (dtable.Rows.Count > 0)
				{
					username = tbusername.Text;
					password = tbpassword.Text;

					Form1 Home = new Form1();
					Home.Show();
					this.Hide();

				}else MessageBox.Show("Tài khoản không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				//textBox1.Text = username ;
				//textBox2.Text=password ;


				MessageBox.Show("Tài khoản không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				tbusername.Clear();
				tbpassword.Clear();
				tbusername.Focus();
			}
			finally
			{
				//MessageBox.Show("Invalid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Login_Load(object sender, EventArgs e)
		{

		}
	}
}
