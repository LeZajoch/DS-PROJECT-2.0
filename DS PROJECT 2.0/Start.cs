using System.Collections;
using System.Configuration;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace DS_PROJECT_2._0;

public class Start
{
    /// <summary>
    /// Runs the program
    /// </summary>
    public static void start()
    {
        MenuPrint();
        SelectLogic();
    }

  /// <summary>
  /// Reads config file that is used to join DBServer 
  /// </summary>
  /// <param name="key"></param>
  /// <returns></returns>
        public static string ReadConfig(string key)
        {
            string value = ConfigurationManager.AppSettings[key].ToString();
            return value;
        }
        
        /// <summary>
        /// Prints the Menu for user
        /// </summary>
    public static void MenuPrint()
    {
        Console.WriteLine("1. Insert data into Database");
        Console.WriteLine("2. Delete data from Database");
        Console.WriteLine("3. Edit data in Database");
        Console.WriteLine("4. Import data from file");
    }
/// <summary>
/// Connects to DBServer, runs the commands on it, lets user chose what to do, uses the logic form DAOs, reads XML and inputs data from it
/// </summary>
    public static void SelectLogic()
    {
        SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
        consStringBuilder.UserID = ReadConfig("Name");
        consStringBuilder.Password = ReadConfig("Password");
        consStringBuilder.InitialCatalog = ReadConfig("DataBase");
        consStringBuilder.DataSource = ReadConfig("DataSource");
        consStringBuilder.ConnectTimeout = 30;
        SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString);
        
        
        
        
        int UserSelection = int.Parse(Console.ReadLine());
        int i = 1;
        switch (UserSelection)
        {
            case 1:
                Console.WriteLine("Write Customer Name you want to submit to table: Customer");
                string CustomerName = Console.ReadLine();
                Console.WriteLine("Write Customer Surname you want to submit to table: Customer");
                string Surname = Console.ReadLine();
                Console.WriteLine("Write Customer Address you want to submit to table: Customer");
                string Address = Console.ReadLine();
                Console.WriteLine("Write Customer Email you want to submit to table: Customer");
                string Email = Console.ReadLine();
                Console.WriteLine("Write Customer Telephone you want to submit to table: Customer");
                string Telephone = Console.ReadLine();
                CustomerDao.CreateCustomer(i, CustomerName, Surname, Address, Email, Telephone,consStringBuilder);

                Console.WriteLine("Write Order Date you want to submit to table: Order");
                DateOnly OrderDate = DateOnly.Parse(Console.ReadLine());
                Console.WriteLine("Write Order State you want to submit to table: Order");
                string OrderState = Console.ReadLine();
                OrderDao.CreateOrder(i, i, OrderDate, OrderState, consStringBuilder);
                
                
                break;
            case 2:
                Console.WriteLine("Write Customer ID you want to delete from table: Customer");
                int CustomerId = int.Parse( Console.ReadLine());
                CustomerDao.DeleteCustomer(CustomerId, consStringBuilder);
                
                Console.WriteLine("write Order ID you want to delete from table: Order");
                int OrderId = int.Parse(Console.ReadLine());
                OrderDao.DeleteOrder(OrderId, consStringBuilder);
                
                break;
            case 3:
                Console.WriteLine("Write Customer ID you want to edit in table: Customer");
                CustomerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Write Customer Name you want to edit in table: Customer");
                CustomerName = Console.ReadLine();
                Console.WriteLine("Write Customer Surname you want to edit in table: Customer");
                Surname = Console.ReadLine();
                Console.WriteLine("Write Customer Address you want to edit in table: Customer");
                Address = Console.ReadLine();
                Console.WriteLine("Write Customer Email you want to edit in table: Customer");
                Email = Console.ReadLine();
                Console.WriteLine("Write Customer Phone you want to edit in table: Customer");
                Telephone = Console.ReadLine();
                CustomerDao.EditCustomer(CustomerId, CustomerName, Surname, Address, Email, Telephone,consStringBuilder);
                
                Console.WriteLine("Write Order ID you want to edit in table: Order");
                OrderId = int.Parse(Console.ReadLine());
                Console.WriteLine("Write Customer ID you want to edit in table: Order");
                CustomerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Write Order Date you want to edit in table: Order");
                OrderDate = DateOnly.Parse(Console.ReadLine());
                Console.WriteLine("Write Order State you want to edit in table: Order");
                OrderState = Console.ReadLine();
                OrderDao.EditOrder(OrderId, CustomerId, OrderDate, OrderState, consStringBuilder);
                break;
            case 4: 
                string path = ReadConfig("File");
                XDocument document = XDocument.Load(path);
                var Objects = from Data in document.Descendants("Data")
                    select new
                    {
                        CustomerID = (int)Data.Element("CustomerID"),
                        CustomerName = (string)Data.Element("CustomerName"),
                        Surname = (string)Data.Element("Surname"),
                        Address = (string)Data.Element("Address"),
                        Email = (string)Data.Element("Email"),
                        Telephone = (int)Data.Element("Telephone")
                    };
                ArrayList FileInput = new ArrayList();
               
                foreach (var Data in Objects)
                {
                    FileInput.Add(Data);
                }
               
                foreach (var DataD in FileInput)
                {
                    // Stores variables from xml file
                    var Variable = (dynamic)DataD;

                    CustomerDao.CreateCustomer(Variable.CustomerId,Variable.CustomerName,Variable.Surname,Variable.Address,Variable.Email,Variable.Telephone,consStringBuilder);
                }
                break;
        }
    }
}
