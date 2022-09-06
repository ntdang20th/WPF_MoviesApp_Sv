using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tempapp.Model;

namespace tempapp.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        
        
        private string _username, _passowrd;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        public string Passowrd { get => _passowrd; set { _passowrd = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }


        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Passowrd = p.Password; });
        }



        void Login(Window p)
        {
            if (p == null)
                return;

            string matkhau = MatKhauMD5(Base64Encode(Passowrd));
            var res = DataProvider.Instance.DB.TaiKhoans.Where(t => t.TenDangNhap == Username && t.MatKhau == matkhau).Count(); 

            if(res > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
            
        }

        //md5 hash
        private string MatKhauMD5( string s)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = getMD5Hash(md5Hash, s);
            return matkhauMH;
        }
        private static string getMD5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        //base64 hash
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
