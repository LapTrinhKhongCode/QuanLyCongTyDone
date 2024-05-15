namespace QuanLyCongTyDone
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void bunifuPictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void bunifuLabel1_Click(object sender, EventArgs e)
		{

		}

		private void btdx_Click(object sender, EventArgs e)
		{
			this.Hide();
			Login login = new Login();
			login.Show();
		}

		private void btnv_Click(object sender, EventArgs e)
		{
			this.Hide();
			NhanVien nhanVien = new NhanVien();
			nhanVien.Show();
		}

		private void btpb_Click(object sender, EventArgs e)
		{
			this.Hide();
			PhongBan phongban = new PhongBan();
			phongban.Show();
		}

		private void btaccount_Click(object sender, EventArgs e)
		{
			this.Hide();
			Account account = new Account();
			account.Show();
		}

		private void btda_Click(object sender, EventArgs e)
		{
			this.Hide();
			DeAn dean = new DeAn();
			dean.Show();
		}
	}
}
