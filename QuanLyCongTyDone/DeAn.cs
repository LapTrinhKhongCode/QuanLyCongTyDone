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
			command.CommandText = "SELECT * FROM DeAn";
			adapter.SelectCommand = command;
			table.Clear();
			adapter.Fill(table);
			dtgda.DataSource = table;
		}






		private void DeAn_Load(object sender, EventArgs e)
		{
			connection = new SqlConnection(sql);
			connection.Open();
			loaddata();
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
			command = connection.CreateCommand();
			command.CommandText = "insert into DeAn values('" + tbmada.Text + "',N'" + tbtenda.Text + "')";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btsua_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "update DeAn set MaDA = N'" + tbmada.Text + "',TenDA = '" + tbtenda.Text + "'where MaNV = '" + tbtenda.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btxoa_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "delete from DeAn where MaDA = '" + tbmada.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btclear_Click(object sender, EventArgs e)
		{
			tbmada.Text = "";
			tbtenda.Text = "";
		}
	}
}
