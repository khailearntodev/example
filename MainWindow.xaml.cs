using QLSV;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;
namespace QLSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string connectionString = "Server=KIARH\\MSSQLSERVER02;Database=SINHVIEN;Trusted_Connection=True;TrustServerCertificate=True;";
        public List<SinhVien> LayDanhSachSinhVien()
        {
            List<SinhVien> danhSachSinhVien = new List<SinhVien>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM SINHVIEN";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SinhVien sv = new SinhVien
                        {
                            MaSo = (int)reader["MaSo"],
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = (DateTime)reader["NgaySinh"],
                            GioiTinh = reader["GioiTinh"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = (int)reader["DienThoai"]
                        };
                        danhSachSinhVien.Add(sv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            return danhSachSinhVien;
        }
        private void HienThiDanhSachSinhVien()
        {
            dataGrid.ItemsSource = LayDanhSachSinhVien();
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDanhSachSinhVien();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                MaSo = int.Parse(txtMSSV.Text),
                HoTen = txtHT.Text,
                NgaySinh = DateTime.Parse(txtNS.Text),
                GioiTinh = txtGT.Text,
                DiaChi = txtDC.Text,
                DienThoai = int.Parse(txtDT.Text)
            };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SINHVIEN (MaSo, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai) " +
                               "VALUES (@MaSo, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @DienThoai)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSo", sv.MaSo);
                command.Parameters.AddWithValue("@HoTen", sv.HoTen);
                command.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                command.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                command.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
                command.Parameters.AddWithValue("@DienThoai", sv.DienThoai);

                connection.Open();
                command.ExecuteNonQuery();
            }
            HienThiDanhSachSinhVien();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                MaSo = int.Parse(txtMSSV.Text),
                HoTen = txtHT.Text,
                NgaySinh = DateTime.Parse(txtNS.Text),
                GioiTinh = txtGT.Text,
                DiaChi = txtDC.Text,
                DienThoai = int.Parse(txtDT.Text)
            };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE SINHVIEN SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, " +
                               "DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaSo = @MaSo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSo", sv.MaSo);
                command.Parameters.AddWithValue("@HoTen", sv.HoTen);
                command.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                command.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                command.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
                command.Parameters.AddWithValue("@DienThoai", sv.DienThoai);

                connection.Open();
                command.ExecuteNonQuery();
            }
            HienThiDanhSachSinhVien();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                MaSo = int.Parse(txtMSSV.Text),
                HoTen = txtHT.Text,
                NgaySinh = DateTime.Parse(txtNS.Text),
                GioiTinh = txtGT.Text,
                DiaChi = txtDC.Text,
                DienThoai = int.Parse(txtDT.Text)
            };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int maSo = int.Parse(txtMSSV.Text);
                string query = "DELETE FROM SINHVIEN WHERE MaSo = @MaSo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSo", maSo);

                connection.Open();
                command.ExecuteNonQuery();
            }
            HienThiDanhSachSinhVien();
        }

        private void button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
