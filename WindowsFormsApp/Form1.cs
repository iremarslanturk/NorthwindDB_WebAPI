using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        string authToken = "";
        string apiUrl = "http://localhost:5083/api/Users/authenticate";

        public Form1()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                var authRequest = new
                {
                    name = username,
                    password = password
                };

                string jsonRequest = JsonConvert.SerializeObject(authRequest);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage authResponse = await httpClient.PostAsync(apiUrl, content);

                    if (authResponse.IsSuccessStatusCode)
                    {
                        authToken = await authResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("Giriş Başarılı!");
                        Form2 form2 = new Form2(authToken); 
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kimlik Doğrulama Başarısız. Hata Kodu: " + authResponse.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }
    }
}
