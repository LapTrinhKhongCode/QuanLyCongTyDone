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
	public partial class NhanVien : Form
	{
		public NhanVien()
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
			command.CommandText = "SELECT MaNV, TenNV, NgaySinh, GioiTinh, ChucVu, TienLuong, TenPB, TenDA From ThongTinNV JOIN PhongBan ON ThongTinNV.MaPB = PhongBan.MaPB JOIN DeAn ON DeAn.MaDA = ThongTinNV.MaDA";
			adapter.SelectCommand = command;
			table.Clear();
			adapter.Fill(table);
			dtgnv.DataSource = table;
		}


		private void NhanVien_Load(object sender, EventArgs e)
		{
			connection = new SqlConnection(sql);
			connection.Open();
			loaddata();



			command.CommandText = "SELECT MaPB FROM PhongBan";
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				// Duyệt qua các dòng dữ liệu
				while (reader.Read())
				{
					// Đọc giá trị từ cột và thêm vào ComboBox
					tbmapb.Items.Add(reader.GetInt32(0));
				}
			}
			reader.Close();
			command.CommandText = "SELECT MaDA FROM DeAn";
			SqlDataReader reader2 = command.ExecuteReader();
			if (reader2.HasRows)
			{
				// Duyệt qua các dòng dữ liệu
				while (reader2.Read())
				{
					// Đọc giá trị từ cột và thêm vào ComboBox
					tbmada.Items.Add(reader2.GetInt32(0));
				}
			}

			reader2.Close();

			tbmapb.KeyPress += tbmapb_KeyPress;
			tbmada.KeyPress += tbmada_KeyPress;
			tbgioitinh.KeyPress += tbgioitinh_KeyPress;





			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter("SELECT TenDA, MaDA FROM DeAn", sql);
			da.Fill(ds, "TenDA");
			tbmada.DataSource = ds.Tables["TenDA"];
			tbmada.DisplayMember = "TenDA";
			tbmada.ValueMember = "MaDA";


			DataSet ds1 = new DataSet();
			SqlDataAdapter da1 = new SqlDataAdapter("SELECT MaPB, TenPB FROM PhongBan", sql);
			da1.Fill(ds1, "TenPB");
			tbmapb.DataSource = ds1.Tables["TenPB"];
			tbmapb.DisplayMember = "TenPB";
			tbmapb.ValueMember = "MaPB";







		}




		private void dtgnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			tbmanv.ReadOnly = true;
			int i = 0;
			i = dtgnv.CurrentRow.Index;
			tbmanv.Text = dtgnv.Rows[i].Cells[0].Value.ToString();
			tbtennv.Text = dtgnv.Rows[i].Cells[1].Value.ToString();
			dtngaysinh.Text = dtgnv.Rows[i].Cells[2].Value.ToString();
			tbgioitinh.Text = dtgnv.Rows[i].Cells[3].Value.ToString();
			tbchucvu.Text = dtgnv.Rows[i].Cells[4].Value.ToString();
			tbtienluong.Text = dtgnv.Rows[i].Cells[5].Value.ToString();
			tbmapb.Text = dtgnv.Rows[i].Cells[6].Value.ToString();
			tbmada.Text = dtgnv.Rows[i].Cells[7].Value.ToString();
		}

		private void bunifuButton21_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();

			command.CommandText = "insert into ThongTinNV values('" + tbmanv.Text + "',N'" + tbtennv.Text + "','" + dtngaysinh.Text + "',N'" + tbgioitinh.Text + "',N'" + tbchucvu.Text + "','" + tbtienluong.Text + "',N'" + tbmapb.GetItemText(tbmapb.SelectedValue) + "',N'" + tbmada.GetItemText(tbmada.SelectedValue) + "')";
			command.ExecuteNonQuery();
			loaddata();
		}




		private void bunifuButton23_Click(object sender, EventArgs e)
		{

		}


		private void bunifuButton24_Click(object sender, EventArgs e)
		{

		}

		private void bunifuButton25_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form1 Home = new Form1();
			Home.Show();
		}

		private void bunifuButton23_Click_1(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "delete from ThongTinNV where MaNV = '" + tbmanv.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btsua_Click(object sender, EventArgs e)
		{
			command = connection.CreateCommand();
			command.CommandText = "update ThongTinNV set TenNV = N'" + tbtennv.Text + "',NgaySinh = '" + dtngaysinh.Text + "',GioiTinh = N'" + tbgioitinh.Text + "',ChucVu = N'" + tbchucvu.Text + "',TienLuong = '" + tbtienluong.Text + "',MaPB = N'" + tbmapb.GetItemText(tbmapb.SelectedValue) + "',MaDA = N'" + tbmada.GetItemText(tbmada.SelectedValue) + "'where MaNV = '" + tbmanv.Text + "'";
			command.ExecuteNonQuery();
			loaddata();
		}

		private void btnclear_Click(object sender, EventArgs e)
		{
			tbmanv.Text = "";
			tbtennv.Text = "";
			dtngaysinh.Text = "1/1/1999";
			tbgioitinh.Text = "";
			tbchucvu.Text = "";
			tbtienluong.Text = "";
			tbmada.Text = "";
			tbmapb.Text = "";
		}

		private void tbmapb_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void tbmada_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void tbgioitinh_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled= true;	
		}
	}
}
