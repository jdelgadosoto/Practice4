using Microsoft.Data.SqlClient;
using Practice4;
using System;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        const string connectionString =
            "Data Source=USQROJDELGADOS1;Initial Catalog=Practice4_Products;Integrated Security=True;Trust Server Certificate=True";

        var AllProducts = ReadProducts(connectionString);
        var AllSales = ReadSales(connectionString);
        var AllPurchases = ReadPurchases(connectionString);

        int CountOfProducts = AllProducts.Count;

        while (true)
        {


            Console.WriteLine("Please type in the number of the activity to be performed.\n" +
                "Press the 1 key to get the data from the products table.\n" +
                "Press the 2 key to request the creation of a new product\n" +
                "Press the 3 key to filter de information by text from  product table\n" +
                "Press the 4 key to group the sales by day and sort them by sales number from highest to lowest\n" +
                "Press the 5 key to get the product and sales information for the month using line joins\n" +
                "Press the 6 key to get products were not purchased or sold\n" +
                "Press the 7 key to perform the sum of the products sold in the month\n");


            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) break;

            switch (input)
            {
                case "1":
                    Console.WriteLine("Displaying all products:\n");
                    Console.WriteLine(case1(AllProducts) + "\n\n");
                    break;


                case "2":
                    Console.WriteLine("Creating new product\n" +
                        "Enter the name of the product: \n");
                    string newProductName = Console.ReadLine();
                    Console.WriteLine("Enter the price of the product:\n");
                    int newPriceProduct = Convert.ToInt32(Console.ReadLine());
                    int NewID = CountOfProducts + 1;
                    new Products(NewID, newProductName, newPriceProduct);
                    Console.WriteLine("The new product is: \n" + showNewProduct(AllProducts) + "\n\n");
                    break;

                case "3":
                    Console.WriteLine("Enter the name of a product:\n");
                    input = Console.ReadLine();

                    var filteredProducts = from p in AllProducts
                                           where p.ProductName == input
                                           select $"ID: {p.ProductID} Name:{p.ProductName}  Price:{p.Price} ";
                    Console.WriteLine(filteredProducts.ToString());

                    break;

                case "4":


                    var filteredByDay = from s in AllSales
                                        orderby s.quantity descending
                                        select s ;


                    foreach (var key in filteredByDay)
                    {
                        Console.WriteLine($"SaleID: {key.sale_id} Name:{key.product_name}  Quantity:{key.quantity}  Date:{key.Date}");
                    }

                    Console.WriteLine("\n");

                    break;

                case "5":



                    break;

                case "6":

                    break;
                case "7":

                    break;
                default:
                    Console.WriteLine("Invalid key");
                    break;


            }

           








        }


       
    }

    public static string case1(List<Products>? AllProducts)
    {

        var displayProducts = from p in AllProducts
                              select $"ID: {p.ProductID} Name:{p.ProductName}  Price:{p.Price} ";

        

        return string.Join("\n",displayProducts);

    }

    public static string showNewProduct(List<Products> AllProducts)
    {
        var showproduct = from p in AllProducts
                          select $"ID: {p.ProductID} Name:{p.ProductName}  Price:{p.Price} ";
        return showproduct.Last();
    }

    






    //////////// ///////READING FROM THE PRODUCTS TABLE ///////////////////////////

    static List<Products> ReadProducts(string connectionString)
    {
        ProductRepository productRepository = new ProductRepository();
        var productsList = productRepository._products;

        
        // Provide the query string with a parameter placeholder.
        const string queryString =
            "SELECT product_id, product_name, Price from dbo.Products";



        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
            new(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new(queryString, connection);


            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productsList.Add(new Products((int)reader[0], (string)reader[1], (int)reader[2]));

                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        return productsList;
    }



    //////////// ///////READING FROM THE SALES TABLE ///////////////////////////
 
    static List<Sales> ReadSales(string connectionString)
    {
        SalesRepository salesRepository = new SalesRepository();
        var salesList = salesRepository._sale;

        const string queryString =
            "SELECT * from dbo.Sales";



        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
            new(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new(queryString, connection);


            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    salesList.Add(new Sales((int)reader[0], (string)reader[2], (int)reader[3], (DateTime)reader[4]));

                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }

        return salesList;
    }



    //////////// ///////READING FROM THE PURCHASES TABLE ///////////////////////////

    static List<Purchases> ReadPurchases(string connectionString)
    {
        PurchasesRepository purchasesRepository = new PurchasesRepository();
        var PurchasesList = purchasesRepository._purchases;

        const string queryString =
            "SELECT * from dbo.Purchases";



        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
            new(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new(queryString, connection);


            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PurchasesList.Add(new Purchases((int)reader[0], (string)reader[2], (int)reader[3], (DateTime)reader[4]));

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        return PurchasesList;
    }

}
 

