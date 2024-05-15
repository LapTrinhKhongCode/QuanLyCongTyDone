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
using System.Text.RegularExpressions;

namespace QuanLyCongTyDone
{
	public partial class DeAn : Form
	{
		public DeAn()
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
			command.CommandText = "SELECT MaDA, TenDA FROM DeAn";
			adapter.SelectCommand = command;
			table.Clear();
			adapter.Fill(table);
			dtgda.DataSource = table;
			tbmada.ReadOnly = true;

		}






		private void DeAn_Load(object sender, EventArgs e)
		{
			connection = new SqlConnection(sql);
			connection.Open();
			loaddata();
			tbmada.ReadOnly=true;
		}


		private void bunifuLabel1_Click(object sender, EventArgs e)
		{

		}

		private void bunifuButton5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form1 home = new Form1();
			home.Show();
		}

		private void btthem_Click(object sender, EventArgs e)
		{
			try
			{


				command = connection.CreateCommand();
				command.CommandText = "insert into DeAn values(N'" + tbtenda.Text + "')";
				command.ExecuteNonQuery();
				loaddata();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			}
		}

		private void btsua_Click(object sender, EventArgs e)
		{
			
			try
			{
				command = connection.CreateCommand();
				command.CommandText = "update DeAn set TenDA = N'" + tbtenda.Text + "'where MaDA = '" + tbmada.Text + "'";
				command.ExecuteNonQuery();
				loaddata();
				
			}
			catch (Exception ex)
			{	
				MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			}
		}

		private void btxoa_Click(object sender, EventArgs e)
		{
			try
			{
				command = connection.CreateCommand();
				command.CommandText = "delete from DeAn where MaDA = '" + tbmada.Text + "'";
				command.ExecuteNonQuery();
				loaddata();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			}
		}

		private void btclear_Click(object sender, EventArgs e)
		{
			tbmada.Text = "";
			tbtenda.Text = "";
		}

		private void dtgda_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i = 0;
			i = dtgda.CurrentRow.Index;
			tbmada.Text = dtgda.Rows[i].Cells[0].Value.ToString();
			tbtenda.Text = dtgda.Rows[i].Cells[1].Value.ToString();
		}
	}
}
