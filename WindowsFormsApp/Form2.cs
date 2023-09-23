using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        private string authToken;
        public Form2(string authToken)
        {
            InitializeComponent();
            this.authToken = authToken; 
        }
        private void CategoryInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "CategoryId"; 
            dataGridView1.Columns[1].Name = "CategoryName";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.Columns[3].Name = "Picture"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void CustomerInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "CustomerId"; 
            dataGridView1.Columns[1].Name = "CompanyName";
            dataGridView1.Columns[2].Name = "ContactName";
            dataGridView1.Columns[3].Name = "ContactTitle"; 
            dataGridView1.Columns[4].Name = "Address"; 
            dataGridView1.Columns[5].Name = "City";
            dataGridView1.Columns[6].Name = "Region";
            dataGridView1.Columns[7].Name = "PostalCode"; 
            dataGridView1.Columns[8].Name = "Country"; 
            dataGridView1.Columns[9].Name = "Phone"; 
            dataGridView1.Columns[10].Name = "Fax"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void EmployeeInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 18;
            dataGridView1.Columns[0].Name = "EmployeeId"; 
            dataGridView1.Columns[1].Name = "LastName"; 
            dataGridView1.Columns[2].Name = "FirstName";
            dataGridView1.Columns[3].Name = "Title"; 
            dataGridView1.Columns[4].Name = "TitleOfCourtesy"; 
            dataGridView1.Columns[5].Name = "BirthDate"; 
            dataGridView1.Columns[6].Name = "HireDate"; 
            dataGridView1.Columns[7].Name = "Address"; 
            dataGridView1.Columns[8].Name = "City"; 
            dataGridView1.Columns[9].Name = "Region";
            dataGridView1.Columns[10].Name = "PostalCode";
            dataGridView1.Columns[11].Name = "Country"; 
            dataGridView1.Columns[12].Name = "HomePhone"; 
            dataGridView1.Columns[13].Name = "Extension";
            dataGridView1.Columns[14].Name = "Photo";
            dataGridView1.Columns[15].Name = "Notes";
            dataGridView1.Columns[16].Name = "ReportsTo"; 
            dataGridView1.Columns[17].Name = "PhotoPath"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void OrderInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 14;
            dataGridView1.Columns[0].Name = "OrderId";
            dataGridView1.Columns[1].Name = "CustomerId";
            dataGridView1.Columns[2].Name = "EmployeeId";
            dataGridView1.Columns[3].Name = "OrderDate";
            dataGridView1.Columns[4].Name = "RequiredDate"; 
            dataGridView1.Columns[5].Name = "ShippedDate"; 
            dataGridView1.Columns[6].Name = "ShipVia"; 
            dataGridView1.Columns[7].Name = "Freight";
            dataGridView1.Columns[8].Name = "ShipName";
            dataGridView1.Columns[9].Name = "ShipAddress";
            dataGridView1.Columns[10].Name = "ShipCity";
            dataGridView1.Columns[11].Name = "ShipRegion"; 
            dataGridView1.Columns[12].Name = "ShipPostalCode"; 
            dataGridView1.Columns[13].Name = "ShipCountry"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ProductInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "ProductId"; 
            dataGridView1.Columns[1].Name = "ProductName";
            dataGridView1.Columns[2].Name = "SupplierId"; 
            dataGridView1.Columns[3].Name = "CategoryId"; 
            dataGridView1.Columns[4].Name = "QuantitiyPerUnit";
            dataGridView1.Columns[5].Name = "UnitPrice";
            dataGridView1.Columns[6].Name = "UnitsInStock"; 
            dataGridView1.Columns[7].Name = "UnitsOnOrder"; 
            dataGridView1.Columns[8].Name = "ReorderLevel";
            dataGridView1.Columns[9].Name = "Discontinued";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void SupplierInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "SupplierId"; 
            dataGridView1.Columns[1].Name = "CompanyName";
            dataGridView1.Columns[2].Name = "ContactName"; 
            dataGridView1.Columns[3].Name = "ContactTitle";
            dataGridView1.Columns[4].Name = "Address"; 
            dataGridView1.Columns[5].Name = "City";
            dataGridView1.Columns[6].Name = "Region"; 
            dataGridView1.Columns[7].Name = "PostalCode";
            dataGridView1.Columns[8].Name = "Country"; 
            dataGridView1.Columns[9].Name = "Phone"; 
            dataGridView1.Columns[9].Name = "Fax"; 
            dataGridView1.Columns[9].Name = "HomePage"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void RegionInitializeDataGridView()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "RegionId"; 
            dataGridView1.Columns[1].Name = "RegionDescription"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ShipperInitializeDataGridView()

        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ShipperId"; 
            dataGridView1.Columns[1].Name = "CompanyName"; 
            dataGridView1.Columns[2].Name = "Phone"; 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void TerritoryInitializeDataGridView()

        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "TerritoryId"; 
            dataGridView1.Columns[1].Name = "TerritoryDescription"; 
            dataGridView1.Columns[2].Name = "RegionId";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
       
        public class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public string Picture { get; set; }

        }
        public class Customer
        {
            public string CustomerId { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }

        }
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Title { get; set; }
            public string TitleOfCourtesy { get; set; }
            public string BirthDate { get; set; }
            public string HireDate { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string HomePhone { get; set; }
            public string Extension { get; set; }
            public string Photo { get; set; }
            public string Notes { get; set; }
            public string ReportsTo { get; set; }
            public string PhotoPath { get; set; }

        }
        public class Order
        {
            public int OrderId { get; set; }
            public string CustomerId { get; set; }
            public string EmployeeId { get; set; }
            public string OrderDate { get; set; }
            public string RequiredDate { get; set; }
            public string ShippedDate { get; set; }
            public string ShipVia { get; set; }
            public string Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }

        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string SupplierId { get; set; }
            public string CategoryId { get; set; }
            public string QuantityPerUnit { get; set; }
            public string UnitPrice { get; set; }
            public string UnitsInStock { get; set; }
            public string UnitsOnOrder { get; set; }
            public string ReorderLevel { get; set; }
            public string Discontinued { get; set; }

        }
        public class Region
        {
            public int RegionId { get; set; }
            public string RegionDescription { get; set; }

        }
        public class Shipper
        {
            public int ShipperId { get; set; }
            public string CompanyName { get; set; }
            public string Phone { get; set; }

        }
        public class Supplier
        {
            public int SupplierId { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string HomePage { get; set; }

        }
        public class Territory
        {
            public int TerritoryId { get; set; }
            public string TerritoryDescription { get; set; }
            public string RegionId { get; set; }
      
        }

        private async void shipperButton_Click(object sender, EventArgs e)
        {
            ShipperInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Shipper";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Shipper> shippers = JsonConvert.DeserializeObject<List<Shipper>>(responseData);

                        dataGridView1.Rows.Clear(); 
                        foreach (var shipper in shippers)
                        {
                            dataGridView1.Rows.Add(shipper.ShipperId, shipper.CompanyName, shipper.Phone);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void categoryButton_Click(object sender, EventArgs e)
        {
            CategoryInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Category"; 

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(responseData);

                        dataGridView1.Rows.Clear(); // Mevcut verileri temizleyin
                        foreach (var category in categories)
                        {
                            dataGridView1.Rows.Add(category.CategoryId, category.CategoryName, category.Description, category.Picture);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void customerButton_Click(object sender, EventArgs e)
        {
            CustomerInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Customer"; 

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(responseData);

                        dataGridView1.Rows.Clear(); 
                        foreach (var customer in customers)
                        {
                            dataGridView1.Rows.Add(customer.CustomerId, customer.CompanyName, customer.ContactName, customer.ContactTitle, customer.Address, customer.City, customer.Region, customer.PostalCode, customer.Country, customer.Country, customer.Phone, customer.Fax);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void employeeButton_Click(object sender, EventArgs e)
        {
            EmployeeInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Employee";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(responseData);

                      
                        dataGridView1.Rows.Clear(); 
                        foreach (var employee in employees)
                        {
                            dataGridView1.Rows.Add(employee.EmployeeId, employee.LastName, employee.FirstName, employee.Title, employee.Title, employee.BirthDate, employee.HireDate, employee.Address, employee.City, employee.Region, employee.PostalCode, employee.Country, employee.HomePhone, employee.Extension, employee.Photo, employee.Notes, employee.ReportsTo, employee.PhotoPath);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void orderButton_Click(object sender, EventArgs e)
        {
            OrderInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Order";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(responseData);

                 
                        dataGridView1.Rows.Clear();
                        foreach (var order in orders)
                        {
                            dataGridView1.Rows.Add(order.OrderId, order.CustomerId, order.EmployeeId, order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void productButton_Click(object sender, EventArgs e)
        {

            ProductInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Product";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseData);

                        dataGridView1.Rows.Clear(); 
                        foreach (var product in products)
                        {
                            dataGridView1.Rows.Add(product.ProductId, product.ProductName,product.SupplierId,product.CategoryId,product.QuantityPerUnit,product.UnitPrice,product.UnitsInStock,product.UnitsOnOrder,product.ReorderLevel,product.Discontinued);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }
        private async void regionButton_Click(object sender, EventArgs e)
        {
            RegionInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Region";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Region> regions = JsonConvert.DeserializeObject<List<Region>>(responseData);

                      
                        dataGridView1.Rows.Clear(); 
                        foreach (var region in regions)
                        {
                            dataGridView1.Rows.Add(region.RegionId, region.RegionDescription);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void supplierButton_Click(object sender, EventArgs e)
        {
            SupplierInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Supplier"; 

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(responseData);

                        dataGridView1.Rows.Clear(); 
                        foreach (var supplier in suppliers)
                        {
                            dataGridView1.Rows.Add(supplier.SupplierId,supplier.CompanyName,supplier.ContactName,supplier.ContactTitle,supplier.Address,supplier.City,supplier.Region,supplier.PostalCode,supplier.Country,supplier.Phone,supplier.Fax,supplier.HomePage);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }
        }

        private async void territoryButton_Click(object sender, EventArgs e)
        {

            TerritoryInitializeDataGridView();

            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string apiEndpoint = "Territory";

                    string modifiedString = authToken.Substring(10);
                    string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);
                    string requestUrl = "http://localhost:5083/api/" + apiEndpoint;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        List<Territory> territories = JsonConvert.DeserializeObject<List<Territory>>(responseData);

                        dataGridView1.Rows.Clear(); 
                        foreach (var territory in territories)
                        {
                            dataGridView1.Rows.Add(territory.TerritoryId,territory.TerritoryDescription,territory.RegionId);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Veri çekme başarısız. Hata Kodu: " + bearerToken + response.StatusCode);
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

