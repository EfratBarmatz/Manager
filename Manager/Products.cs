using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace Manager
{
    internal class Products
    {
        public int InsertProduct(string connaction)
        {
            int categoryId;

            string name, descreaption, price, image;

            Console.WriteLine("please enter product name");
            name = Console.ReadLine();

            Console.WriteLine("please enter product categoryId");
            categoryId =int.Parse( Console.ReadLine());

            Console.WriteLine("please enter product descreaption");
            descreaption = Console.ReadLine();

            Console.WriteLine("please enter product price");
            price = Console.ReadLine();

            Console.WriteLine("please enter product image");
            image = Console.ReadLine();

            string query = "INSERT INTO Products (CategoryId,ProductName,DescreaptionProduct,Price,Image)" +
                "VALUES (@CategoryId,@ProductName,@DescreaptionProduct,@Price,@Image)";
            
            using (SqlConnection cn = new SqlConnection(connaction)) 
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@ProductName", SqlDbType.NChar, 20).Value = name;
                cmd.Parameters.Add("@DescreaptionProduct", SqlDbType.NVarChar, int.MaxValue).Value = descreaption;
                cmd.Parameters.Add("@Price", SqlDbType.NVarChar, 50).Value = price;
                cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 50).Value = image; 
                
                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();

                Console.WriteLine("you want mor? y/n");
                string res= Console.ReadLine();
                if (res == "y")
                    InsertProduct(connaction);
                return rowAffected;
            }
            


        }

        public void getAllProducts(string connaction)
        {
            string query = "select * from Products";
            using (SqlConnection cn = new SqlConnection(connaction))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader product = cmd.ExecuteReader();
                    while (product.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            product[0], product[1], product[2], product[3], product[4], product[5]);
                    }
                    product.Close();
               
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }
        }
    }
}
