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
using Microsoft.VisualBasic.ApplicationServices;

namespace QuanLyCongTyDone
{
	public partial class Account : Form
	{
		public Account()
		{
			InitializeComponent();
		}

		SqlConnection connection;
		SqlCommand command;
		string sql = @"Data Source=TUF-DASH-F15\SQLSERVER;Initial Catalog=QLCONGTY;Integrated Security=True;";
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable table = new DataTable();
		void loaddata()
		{
			command = connection.CreateCommand();
			command.CommandText = "SELECT iduser,Role,username FROM Role JOIN UserAccount ON Role.id = UserAccount.idrole";
			adapter.SelectCommand = command;
			table.Clear();
			adapter.Fill(table);
			dtgac.DataSource = table;



		}



		private void bunifuButton5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form1 form1 = new Form1();
			form1.Show();
		}

		private void Account_Load(object sender, EventArgs e)
		{
			connection = new SqlConnection(sql);
			connection.Open();
			loaddata();
			command.CommandText = "SELECT Role, idrole FROM Role JOIN UserAccount ON Role.id = UserAccount.iduser";
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				// Duyệt qua các dòng dữ liệu
				while (reader.Read())
				{
					// Đọc giá trị từ cột và thêm vào ComboBox
					cbrole2.Items.Add(reader.GetString(0));
				}
			}
			reader.Close();

			//adapter.SelectCommand = command;
			//table.Clear();
			//adapter.Fill(table);


			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter("SELECT Role, idrole FROM Role JOIN UserAccount ON Role.id = UserAccount.iduser", sql);
			da.Fill(ds, "Role");
			cbrole2.DataSource = ds.Tables["Role"];
			cbrole2.DisplayMember = "Role";
			cbrole2.ValueMember = "idrole";

			cbrole2.KeyPress += cbrole2_KeyPress;


		}



		private void dtgac_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			tbid1.ReadOnly = true;
			int i = 0;
			i = dtgac.CurrentRow.Index;
			tbid1.Text = dtgac.Rows[i].Cells[0].Value.ToString();
			cbrole2.Text = dtgac.Rows[i].Cells[1].Value.ToString();
			tbus2.Text = dtgac.Rows[i].Cells[2].Value.ToString();
			//tbpw3.Text = dtgac.Rows[i].Cells[3].Value.ToString();
		}




		private void btthem_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();

			command.CommandText = "insert into UserAccount values(N'" + tbid1.Text + "',N'" + tbus2.Text + "',N'" + tbpw3.Text + "',N'" + cbrole2.GetItemText(cbrole2.SelectedValue) + "')";
			//UPDATE user_account
			//			JOIN role
			//ON user_account.iduser = role.id
			//SET role.role = "Quản trị viên"
			//WHERE user_account.iduser = 1;
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btSua_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();

			command.CommandText = "update UserAccount set iduser = N'" + tbid1.Text + "',username = N'" + tbus2.Text + "',password = N'" + tbpw3.Text + "',idrole = N'" + cbrole2.GetItemText(cbrole2.SelectedValue) + "'where iduser = '" + tbid1.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btXoa_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "delete from UserAccount where iduser = '" + tbid1.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btclear_Click(object sender, EventArgs e)
		{
			tbid1.Text = "";
			cbrole2.Text = "";
			tbus2.Text = "";
			tbpw3.Text = "";
		}

		private void cbrole2_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void cbrole2_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
