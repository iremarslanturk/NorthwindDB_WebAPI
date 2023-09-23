using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
         {
            string authToken = "";
            string apiUrl = "http://localhost:5083/api/Users/authenticate";
            var innerHandler = new HttpClientHandler();
            var logger = new HttpClientLogger(innerHandler);
            var httpClient = new HttpClient(logger);

            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();
            Console.Write("Parola: ");
            string password = Console.ReadLine();

            try
            {
                var authRequest = new
                {
                    name = username,
                    password = password
                };

                string jsonRequest = JsonSerializer.Serialize(authRequest);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpResponseMessage authResponse = await httpClient.PostAsync(apiUrl, content);

                if (authResponse.IsSuccessStatusCode)
                {
                    authToken = await authResponse.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Kimlik Doğrulama Başarısız. Hata Kodu: " + authResponse.StatusCode);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Oluştu: " + ex.Message);
                return;
            }

            Console.WriteLine("Bearer Token: " + authToken);

            Console.WriteLine("Lütfen aşağıdaki işlemlerden birini seçin:");
            Console.WriteLine("1. Category");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Employee");
            Console.WriteLine("4. Order");
            Console.WriteLine("5. Product");
            Console.WriteLine("6. Region");
            Console.WriteLine("7. Shipper");
            Console.WriteLine("8. Supplier");
            Console.WriteLine("9. Territory");
            Console.WriteLine("10 . Users");
            Console.Write("Seçiminizi yapın (1/2/3/4/5/6/7/8/9/10/11): ");

            string choice = Console.ReadLine();
            string apiEndpoint = ""; 

            if (choice == "1")
            {
                apiEndpoint = "Category";
            }
            else if (choice == "2")
            {
                apiEndpoint = "Customer";
            }
            else if (choice == "3")
            {
                apiEndpoint = "Employee";
            }
            else if (choice == "4")
            {
                apiEndpoint = "Order";
            }
            else if (choice == "5")
            {
                apiEndpoint = "Product";
            }
            else if (choice == "6")
            {
                apiEndpoint = "Region";
            }
            else if (choice == "7")
            {
                apiEndpoint = "Shipper";
            }
            else if (choice == "8")
            {
                apiEndpoint = "Supplier";
            }
            else if (choice == "9")
            {
                apiEndpoint = "Territory";
            }
            else if (choice == "10")
            {
                apiEndpoint = "User";
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek. Program sonlandırılıyor.");
                return;
            }

            Console.WriteLine("İşlem seçildi: " + apiEndpoint);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            string modifiedString = authToken.Substring(10);
            string bearerToken = modifiedString.Substring(0, modifiedString.Length - 22);

            string requestUrl = "http://localhost:5083/api/" + apiEndpoint; 
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            Console.WriteLine("Lütfen aşağıdaki işlemlerden birini seçin:");
            Console.WriteLine("1. Get (HTTP GET)");
            Console.WriteLine("2. Get One (HTTP GET)");
            Console.WriteLine("3. Post (HTTP POST)");
            Console.WriteLine("4. Put (HTTP PUT)");
            Console.WriteLine("5. Delete (HTTP DELETE)");
            Console.Write("Seçiminizi yapın (1/2/3/4/5): ");

            string choice_ = Console.ReadLine();
            HttpResponseMessage response = null;

            if (choice_ == "1")
            {
                response = await httpClient.GetAsync(requestUrl);
            }
            else if (choice_ == "2")
            {
                Console.WriteLine("Görmek istedğiniz id'yi giriniz: ");
                string getID = Console.ReadLine();
                response = await httpClient.GetAsync(requestUrl + "/" + getID);
    
            }
            else if (choice_ == "3")
            {
                string jsonRequestData = "";
                var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                if (choice == "1")
                {
                    Console.WriteLine("Category Id: ");
                    string categoryId = Console.ReadLine();

                    Console.WriteLine("Category Name: ");
                    string categoryName = Console.ReadLine();

                    Console.WriteLine("Description: ");
                    string description = Console.ReadLine();

                    Console.WriteLine("Picture: ");
                    string picture = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                        $"\"categoryId\": \"{categoryId}\"," +
                                        $"\"categoryName\": \"{categoryName}\"," +
                                        $"\"description\": \"{description}\"," +
                                        $"\"picture\": \"{picture}\""+
                                        "}}"; 
                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }

                else if (choice == "2")
                {
                    Console.WriteLine("Customer Id: ");
                    string customerId = Console.ReadLine();

                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Contact Name: ");
                    string contactName = Console.ReadLine();

                    Console.WriteLine("Contact Title: ");
                    string contactTitle = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();


                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Fax: ");
                    string fax = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                        $"\"customerId\": \"{customerId}\"," +
                                        $"\"companyName\": \"{companyName}\"," +
                                        $"\"contactName\": \"{contactName}\"," +
                                        $"\"contactTitle\": \"{contactTitle}\"," +
                                        $"\"address\": \"{address}\"," +
                                        $"\"city\": \"{city}\"," +
                                        $"\"region\": \"{region}\"," +
                                        $"\"postalCode\": \"{postalCode}\"," +
                                        $"\"country\": \"{country}\"," +
                                        $"\"phone\": \"{phone}\"," +
                                        $"\"fax\": \"{fax}\"" +
                                        "}}";                                                                                                                                                                                                                                                                                                                                                                                                                           
                                                        content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Employee Id: ");
                    string employeeId = Console.ReadLine();

                    Console.WriteLine("Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("First Name: ");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();

                    Console.WriteLine("Title of Courtesy: ");
                    string titleOfCourtesy = Console.ReadLine();

                    Console.WriteLine("Birth Date: ");
                    string birthDate = Console.ReadLine();

                    Console.WriteLine("Hire Date: ");
                    string hireDate = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();

                    Console.WriteLine("Home Phone: ");
                    string homePhone = Console.ReadLine();

                    Console.WriteLine("Extension: ");
                    string extension = Console.ReadLine();

                    Console.WriteLine("Photo: ");
                    string photo = Console.ReadLine();

                    Console.WriteLine("Notes: ");
                    string notes = Console.ReadLine();

                    Console.WriteLine("Reports To: ");
                    string reportsTo = Console.ReadLine();

                    Console.WriteLine("Photo Path: ");
                    string photoPath = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                        $"\"employeeId\": \"{employeeId}\"," +
                                        $"\"lastName\": \"{lastName}\"," +
                                        $"\"firstName\": \"{firstName}\"," +
                                        $"\"title\": \"{title}\"," +
                                        $"\"titleOfCourtesy\": \"{titleOfCourtesy}\"," +
                                        $"\"birthDate\": \"{birthDate}\"," +
                                        $"\"hireDate\": \"{hireDate}\"," +
                                        $"\"address\": \"{address}\"," +
                                        $"\"city\": \"{city}\"," + 
                                        $"\"region\": \"{region}\"," +
                                        $"\"postalCode\": \"{postalCode}\"," +
                                        $"\"country\": \"{country}\"," +
                                        $"\"homePhone\": \"{homePhone}\"," +
                                        $"\"extension\": \"{extension}\"," +
                                        $"\"photo\": \"{photo}\"," +
                                        $"\"notes\": \"{notes}\"," +
                                        $"\"reportsTo\": \"{reportsTo}\"," +
                                        $"\"photoPath\": \"{photoPath}\"" +
                                        "}}"; 
                    
                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }

                else if (choice == "4")
                {

                    Console.WriteLine("Order Id: ");
                    string orderId = Console.ReadLine();

                    Console.WriteLine("Customer Id: ");
                    string customerId = Console.ReadLine();

                    Console.WriteLine("Employee Id: ");
                    string employeeId = Console.ReadLine();

                    Console.WriteLine("Order Date: ");
                    string orderDate = Console.ReadLine();

                    Console.WriteLine("Required Date: ");
                    string requiredDate = Console.ReadLine();

                    Console.WriteLine("Shipped Date: ");
                    string shippedDate = Console.ReadLine();

                    Console.WriteLine("Ship Via: ");
                    string shipVia = Console.ReadLine();

                    Console.WriteLine("Freight: ");
                    string freight = Console.ReadLine();

                    Console.WriteLine("Ship Name: ");
                    string shipName = Console.ReadLine();

                    Console.WriteLine("Ship Address: ");
                    string shipAdress = Console.ReadLine();

                    Console.WriteLine("Ship City: ");
                    string shipCity = Console.ReadLine();

                    Console.WriteLine("Ship Region: ");
                    string shipRegion = Console.ReadLine();

                    Console.WriteLine("Ship Postal Code: ");
                    string shipPostalCode = Console.ReadLine();

                    Console.WriteLine("Ship Country: ");
                    string shipCountry = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                      $"\"orderId\": \"{orderId}\"," +
                                      $"\"customerId\": \"{customerId}\"," +
                                      $"\"employeeId\": \"{employeeId}\"," +
                                      $"\"orderDate\": \"{orderDate}\"," +
                                      $"\"requiredDate\": \"{requiredDate}\"," +
                                      $"\"shippedDate\": \"{shippedDate}\"," +
                                      $"\"shipVia\": \"{shipVia}\"," +
                                      $"\"freight\": \"{freight}\"," +
                                      $"\"shipName\": \"{shipName}\"," +
                                      $"\"shipAdress\": \"{shipAdress}\"," +
                                      $"\"shipCity\": \"{shipCity}\"," +
                                      $"\"shipRegion\": \"{shipRegion}\"," +
                                      $"\"shipPostalCode\": \"{shipPostalCode}\"," +
                                      $"\"shipCountry\": \"{shipCountry}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "5")
                {
                    Console.WriteLine("Product Id: ");
                    string productId = Console.ReadLine();

                    Console.WriteLine("Product Name: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Supplier Id: ");
                    string supplierId = Console.ReadLine();

                    Console.WriteLine("Category Id: ");
                    string categoryId = Console.ReadLine();

                    Console.WriteLine("Quantity Per Unit: ");
                    string quantityPerUnit = Console.ReadLine();

                    Console.WriteLine("Unit Price: ");
                    string unitPrice = Console.ReadLine();

                    Console.WriteLine("Units in Stock: ");
                    string unitsInStock = Console.ReadLine();

                    Console.WriteLine("Units On Order: ");
                    string unitsOnOrder = Console.ReadLine();

                    Console.WriteLine("Reorder Level: ");
                    string reorderLevel = Console.ReadLine();

                    Console.WriteLine("Discontinued (true/false): ");
                    string discontinued = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                      $"\"productId\": \"{productId}\"," +
                                      $"\"productName\": \"{productName}\"," +
                                      $"\"supplierId\": \"{supplierId}\"," +
                                      $"\"categoryId\": \"{categoryId}\"," +
                                      $"\"quantityPerUnit\": \"{quantityPerUnit}\"," +
                                      $"\"unitPrice\": \"{unitPrice}\"," +
                                      $"\"unitsInStock\": \"{unitsInStock}\"," +
                                      $"\"unitsOnOrder\": \"{unitsOnOrder}\"," +
                                      $"\"reorderLevel\": \"{reorderLevel}\"," +
                                      $"\"discontinued\": \"{discontinued}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);


                }
                else if (choice == "6")
                {
                    Console.WriteLine("Region Id: ");
                    string regionId = Console.ReadLine();

                    Console.WriteLine("Region Description: ");
                    string regionDescription = Console.ReadLine();
                                        
                    jsonRequestData = $"{{" +
                                      $"\"regionId\": \"{regionId}\"," +
                                      $"\"regionDescription\": \"{regionDescription}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
  
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Shipper Id: ");
                    string shipperId = Console.ReadLine();

                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();


                    jsonRequestData = $"{{" +
                                      $"\"shipperId\": \"{shipperId}\"," +
                                      $"\"companyName\": \"{companyName}\"," +
                                      $"\"phone\": \"{phone}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "8")
                {

                    Console.WriteLine("Supplier Id: ");
                    string supplierId = Console.ReadLine();

                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Contact Name: ");
                    string contactName = Console.ReadLine();

                    Console.WriteLine("Contact Title: ");
                    string contactTitle = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Fax: ");
                    string fax = Console.ReadLine();

                    Console.WriteLine("Home Page: ");
                    string homePage = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                      $"\"supplierId\": \"{supplierId}\"," +
                                      $"\"companyName\": \"{companyName}\"," +
                                      $"\"contactName\": \"{contactName}\"," +
                                      $"\"contactTitle\": \"{contactTitle}\"," +
                                      $"\"address\": \"{address}\"," +
                                      $"\"city\": \"{city}\"," +
                                      $"\"region\": \"{region}\"," +
                                      $"\"postalCode\": \"{postalCode}\"," +
                                      $"\"country\": \"{country}\"," +
                                      $"\"phone\": \"{phone}\"," +
                                      $"\"fax\": \"{fax}\"," +
                                      $"\"homePage\": \"{homePage}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "9")
                {

                    Console.WriteLine("Territory Id: ");
                    string territoryId = Console.ReadLine();

                    Console.WriteLine("Territory Description: ");
                    string territoryDescription = Console.ReadLine();

                    Console.WriteLine("Region Id: ");
                    string regionId = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                      $"\"territoryId\": \"{territoryId}\"," +
                                      $"\"territoryDescription\": \"{territoryDescription}\"," +
                                      $"\"regionId\": \"{regionId}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }

            }
            else if (choice_ == "4")
            {
                string jsonRequestData = "";
                var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                Console.WriteLine("Güncellemek istediğiniz id değerini giriniz: ");
                string putId = Console.ReadLine();
                response = await httpClient.GetAsync(requestUrl + "/" + putId);


                if (choice == "1")
                {
                    Console.WriteLine("Category Name: ");
                    string categoryName = Console.ReadLine();

                    Console.WriteLine("Description: ");
                    string description = Console.ReadLine();

                    Console.WriteLine("Picture: ");
                    string picture = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                        $"\"categoryName\": \"{categoryName}\"," +
                                        $"\"description\": \"{description}\"," +
                                        $"\"picture\": \"{picture}\"" +
                                        "}}";

                }
                else if (choice == "2")
                {

                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Contact Name: ");
                    string contactName = Console.ReadLine();

                    Console.WriteLine("Contact Title: ");
                    string contactTitle = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Fax: ");
                    string fax = Console.ReadLine();

                    jsonRequestData = $"{{" +
                                        $"\"companyName\": \"{companyName}\"," +
                                        $"\"contactName\": \"{contactName}\"," +
                                        $"\"contactTitle\": \"{contactTitle}\"," +
                                        $"\"address\": \"{address}\"," +
                                        $"\"city\": \"{city}\"," +
                                        $"\"region\": \"{region}\"," +
                                        $"\"postalCode\": \"{postalCode}\"," +
                                        $"\"country\": \"{country}\"," +
                                        $"\"phone\": \"{phone}\"," +
                                        $"\"fax\": \"{fax}\"" +
                                        "}}";
                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }
                else if (choice == "3")
                {

                    Console.WriteLine("Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("First Name: ");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();

                    Console.WriteLine("Title of Courtesy: ");
                    string titleOfCourtesy = Console.ReadLine();

                    Console.WriteLine("Birth Date: ");
                    string birthDate = Console.ReadLine();

                    Console.WriteLine("Hire Date: ");
                    string hireDate = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();

                    Console.WriteLine("Home Phone: ");
                    string homePhone = Console.ReadLine();

                    Console.WriteLine("Extension: ");
                    string extension = Console.ReadLine();

                    Console.WriteLine("Photo: ");
                    string photo = Console.ReadLine();

                    Console.WriteLine("Notes: ");
                    string notes = Console.ReadLine();

                    Console.WriteLine("Reports To: ");
                    string reportsTo = Console.ReadLine();

                    Console.WriteLine("Photo Path: ");
                    string photoPath = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                        $"\"lastName\": \"{lastName}\"," +
                                        $"\"firstName\": \"{firstName}\"," +
                                        $"\"title\": \"{title}\"," +
                                        $"\"titleOfCourtesy\": \"{titleOfCourtesy}\"," +
                                        $"\"birthDate\": \"{birthDate}\"," +
                                        $"\"hireDate\": \"{hireDate}\"," +
                                        $"\"address\": \"{address}\"," +
                                        $"\"city\": \"{city}\"," +
                                        $"\"region\": \"{region}\"," +
                                        $"\"postalCode\": \"{postalCode}\"," +
                                        $"\"country\": \"{country}\"," +
                                        $"\"homePhone\": \"{homePhone}\"," +
                                        $"\"extension\": \"{extension}\"," +
                                        $"\"photo\": \"{photo}\"," +
                                        $"\"notes\": \"{notes}\"," +
                                        $"\"reportsTo\": \"{reportsTo}\"," +
                                        $"\"photoPath\": \"{photoPath}\"" +
                                        "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);
                }

                else if (choice == "4")
                {

                    Console.WriteLine("Customer Id: ");
                    string customerId = Console.ReadLine();

                    Console.WriteLine("Employee Id: ");
                    string employeeId = Console.ReadLine();

                    Console.WriteLine("Order Date: ");
                    string orderDate = Console.ReadLine();

                    Console.WriteLine("Required Date: ");
                    string requiredDate = Console.ReadLine();

                    Console.WriteLine("Shipped Date: ");
                    string shippedDate = Console.ReadLine();

                    Console.WriteLine("Ship Via: ");
                    string shipVia = Console.ReadLine();

                    Console.WriteLine("Freight: ");
                    string freight = Console.ReadLine();

                    Console.WriteLine("Ship Name: ");
                    string shipName = Console.ReadLine();

                    Console.WriteLine("Ship Address: ");
                    string shipAdress = Console.ReadLine();

                    Console.WriteLine("Ship City: ");
                    string shipCity = Console.ReadLine();

                    Console.WriteLine("Ship Region: ");
                    string shipRegion = Console.ReadLine();

                    Console.WriteLine("Ship Postal Code: ");
                    string shipPostalCode = Console.ReadLine();

                    Console.WriteLine("Ship Country: ");
                    string shipCountry = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                      $"\"customerId\": \"{customerId}\"," +
                                      $"\"employeeId\": \"{employeeId}\"," +
                                      $"\"orderDate\": \"{orderDate}\"," +
                                      $"\"requiredDate\": \"{requiredDate}\"," +
                                      $"\"shippedDate\": \"{shippedDate}\"," +
                                      $"\"shipVia\": \"{shipVia}\"," +
                                      $"\"freight\": \"{freight}\"," +
                                      $"\"shipName\": \"{shipName}\"," +
                                      $"\"shipAdress\": \"{shipAdress}\"," +
                                      $"\"shipCity\": \"{shipCity}\"," +
                                      $"\"shipRegion\": \"{shipRegion}\"," +
                                      $"\"shipPostalCode\": \"{shipPostalCode}\"," +
                                      $"\"shipCountry\": \"{shipCountry}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "5")
                {

                    Console.WriteLine("Product Name: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Supplier Id: ");
                    string supplierId = Console.ReadLine();

                    Console.WriteLine("Category Id: ");
                    string categoryId = Console.ReadLine();

                    Console.WriteLine("Quantity Per Unit: ");
                    string quantityPerUnit = Console.ReadLine();

                    Console.WriteLine("Unit Price: ");
                    string unitPrice = Console.ReadLine();

                    Console.WriteLine("Units in Stock: ");
                    string unitsInStock = Console.ReadLine();

                    Console.WriteLine("Units On Order: ");
                    string unitsOnOrder = Console.ReadLine();

                    Console.WriteLine("Reorder Level: ");
                    string reorderLevel = Console.ReadLine();

                    Console.WriteLine("Discontinued (true/false): ");
                    string discontinued = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                      $"\"productName\": \"{productName}\"," +
                                      $"\"supplierId\": \"{supplierId}\"," +
                                      $"\"categoryId\": \"{categoryId}\"," +
                                      $"\"quantityPerUnit\": \"{quantityPerUnit}\"," +
                                      $"\"unitPrice\": \"{unitPrice}\"," +
                                      $"\"unitsInStock\": \"{unitsInStock}\"," +
                                      $"\"unitsOnOrder\": \"{unitsOnOrder}\"," +
                                      $"\"reorderLevel\": \"{reorderLevel}\"," +
                                      $"\"discontinued\": \"{discontinued}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);


                }
                else if (choice == "6")
                {
                    Console.WriteLine("Region Description: ");
                    string regionDescription = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                      $"\"regionDescription\": \"{regionDescription}\"," +
                                      "}}";
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();


                    jsonRequestData = $"{{" +

                                      $"\"companyName\": \"{companyName}\"," +
                                      $"\"phone\": \"{phone}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "8")
                {


                    Console.WriteLine("Company Name: ");
                    string companyName = Console.ReadLine();

                    Console.WriteLine("Contact Name: ");
                    string contactName = Console.ReadLine();

                    Console.WriteLine("Contact Title: ");
                    string contactTitle = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();

                    Console.WriteLine("Region: ");
                    string region = Console.ReadLine();

                    Console.WriteLine("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    Console.WriteLine("Country: ");
                    string country = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Fax: ");
                    string fax = Console.ReadLine();

                    Console.WriteLine("Home Page: ");
                    string homePage = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                      $"\"companyName\": \"{companyName}\"," +
                                      $"\"contactName\": \"{contactName}\"," +
                                      $"\"contactTitle\": \"{contactTitle}\"," +
                                      $"\"address\": \"{address}\"," +
                                      $"\"city\": \"{city}\"," +
                                      $"\"region\": \"{region}\"," +
                                      $"\"postalCode\": \"{postalCode}\"," +
                                      $"\"country\": \"{country}\"," +
                                      $"\"phone\": \"{phone}\"," +
                                      $"\"fax\": \"{fax}\"," +
                                      $"\"homePage\": \"{homePage}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }
                else if (choice == "9")
                {

                    Console.WriteLine("Territory Description: ");
                    string territoryDescription = Console.ReadLine();

                    Console.WriteLine("Region Id: ");
                    string regionId = Console.ReadLine();

                    jsonRequestData = $"{{" +

                                      $"\"territoryDescription\": \"{territoryDescription}\"," +
                                      $"\"regionId\": \"{regionId}\"," +
                                      "}}";

                    content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(requestUrl, content);

                }

                content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(requestUrl, content);

                Console.WriteLine("Güncelleme işlemi tamamlanmıştır.");
                string bekle = Console.ReadLine();
                
            }
            else if (choice_ == "5")
            {
                Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                string delete_ID = Console.ReadLine();
                response = await httpClient.DeleteAsync(requestUrl + "/" + delete_ID);
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Yanıtı: " + responseContent);
                }
                else
                {
                    Console.WriteLine("API Yanıtı Alınamadı. Hata Kodu: " + response.StatusCode);
                }
            }
        }
    }
}
