using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ProductManagement
{
    class ProductUI
    {
        //static bool counter = true;
        static int check = 0;
        static int ProductId = 0;
        internal static void Test()
        {
            while (check != 5)
            {
                Console.WriteLine("".PadLeft(100, '*'));
                Console.WriteLine("".PadLeft(40, '*') + " Product Management " + "".PadLeft(40, '*'));
                Console.WriteLine("".PadLeft(100, '*'));
                Console.WriteLine("".PadLeft(10, ' ') + "1. Show all Products");
                Console.WriteLine("".PadLeft(10, ' ') + "2. Products Details");
                Console.WriteLine("".PadLeft(10, ' ') + "3. Add Products");
                Console.WriteLine("".PadLeft(10, ' ') + "4. Update Products");
                Console.WriteLine("".PadLeft(10, ' ') + "5. Quit");
                Console.WriteLine("Enter Your Choice:");

                try
                {
                    check = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Enter a valid Details \npress 'Enter' key to Choose Your Choice again");
                    Console.ReadKey();
                    Console.Clear();
                   // counter = true;
                }


                switch (check)
                {
                    case 1:
                        {
                            GetAllProducts();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            GetProductDetails();
                            break;
                        }
                    case 3:
                        {
                            CreateProduct();
                            break;
                        }
                    case 4:
                        {
                            UpdateProduct();
                            break;
                        }
                    case 5:
                        {
                            // counter = false;
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter a valid Details \npress 'Enter' key to Choose Your Choice again");
                            Console.ReadKey();
                            Console.Clear();
                            //counter = true;
                            
                            break;
                        }
                }
                Console.Clear();
            }

            
        }
        internal static void GetAllProducts()
        {
            string criteria = "";
            ProductProcess process = new ProductProcess();
            Console.WriteLine("Retrieving all Products");
            try
            {
                var list = process.GetProducts(criteria);
                foreach (var item in list)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", item.ProductId, item.ProductName, item.UnitPrice, item.UnitsInStock, item.Discontinued);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
        internal static void GetProductDetails()
        {
            

        }

        internal static void CreateProduct()
        {
            Product obj = new Product();
            Console.WriteLine("ProductName: ");
            obj.ProductName = Console.ReadLine();
            Console.WriteLine("Unit Price:  ");
            obj.UnitPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Units in Stock: ");
            obj.UnitsInStock = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Discontinued[true|false]: ");
            obj.Discontinued = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Category Id[between 1 and 8]: ");
            obj.CategoryId = Convert.ToInt32(Console.ReadLine());
            try
            {
                ProductProcess process = new ProductProcess();
                //process.CreateProduct(obj);
                Console.WriteLine("\n Product successfully added.");
            }catch(Exception ex)
            {
               // PrintException(ex.Message);
            }

        }

        internal static void UpdateProduct()
        {

        }
        
    }
}
