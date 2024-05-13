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
	public partial class PhongBan : Form
	{
		public PhongBan()
		{
			InitializeComponent();
		}

		private void bunifuButton2_Click(object sender, EventArgs e)
		{

		}

		SqlConnection connection;
		SqlCommand command;
		string sql = @"Data Source=TUF-DASH-F15\SQLSERVER;Initial Catalog=QLCONGTY;Integrated Security=True;";
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable table = new DataTable();
		void loaddata()
		{
			command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM PhongBan";
			adapter.SelectCommand = command;
			table.Clear();
			adapter.Fill(table);
			dtgpb.DataSource = table;
		}






		private void PhongBan_Load(object sender, EventArgs e)
		{
			connection = new SqlConnection(sql);
			connection.Open();
			loaddata();
			//tbmada4.rea

			command.CommandText = "SELECT MaDA FROM DeAn";
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				// Duyệt qua các dòng dữ liệu
				while (reader.Read())
				{
					// Đọc giá trị từ cột và thêm vào ComboBox
					tbmada4.Items.Add(reader.GetInt32(0));
				}
			}
			reader.Close();
			command.CommandText = "SELECT MaNV FROM ThongTinNV";
			SqlDataReader reader2 = command.ExecuteReader();
			if (reader2.HasRows)
			{
				// Duyệt qua các dòng dữ liệu
				while (reader2.Read())
				{
					// Đọc giá trị từ cột và thêm vào ComboBox
					tbtentp3.Items.Add(reader2.GetInt32(0));
				}
			}

			reader2.Close();


			tbmada4.KeyPress += tbmada4_KeyPress;
			tbtentp3.KeyPress += tbtentp3_KeyPress;


		}

		private void dtgpb_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			tbmapb1.ReadOnly = true;
			int i = 0;
			i = dtgpb.CurrentRow.Index;
			tbmapb1.Text = dtgpb.Rows[i].Cells[0].Value.ToString();
			tbtenpb2.Text = dtgpb.Rows[i].Cells[1].Value.ToString();
			tbtentp3.Text = dtgpb.Rows[i].Cells[2].Value.ToString();
			tbmada4.Text = dtgpb.Rows[i].Cells[3].Value.ToString();

		}

		private void bunifuButton5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form1 form1 = new Form1();
			form1.Show();
		}

		private void btthempb_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "insert into PhongBan values(N'" + tbmapb1.Text + "',N'" + tbtenpb2.Text + "',N'" + tbtentp3.Text + "',N'" + tbmada4.Text + "')";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btnsuapb_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "update PhongBan set TenPB = N'" + tbtenpb2.Text + "',MaTruongPhong = N'" + tbtentp3.Text + "',MaDA = N'" + tbmada4.Text + "'where MaPB = '" + tbmapb1.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btnxoapb_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "delete from PhongBan where MaPB = '" + tbmapb1.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btnclear_Click(object sender, EventArgs e)
		{
			tbmapb1.Text = "";
			tbtenpb2.Text = "";
			tbtentp3.Text = "";
			tbmada4.Text = "";
		}

		private void tbtentp3_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void tbmada4_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
