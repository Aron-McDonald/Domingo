using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class CustomerDAL
    {
        //string connectionStringDEV = "Data Source=LAPTOP-TCM;Initial Catalog=DomingoDatabase;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Customers
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> cList = new List<CustomerModel>();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    customer.customerID = Convert.ToInt32(dr["customerID"].ToString());
                    customer.name = dr["name"].ToString();
                    customer.address = dr["address"].ToString();

                    cList.Add(customer);
                }
                con.Close();
            }

            return cList;
        }

        //Get Customer By CustomerID
        public CustomerModel GetCustomerByCustomerID(int? customerID)
        {
            CustomerModel customer = new CustomerModel();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomerByCustomerID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customerID", customerID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    customer.customerID = Convert.ToInt32(dr["customerID"].ToString());
                    customer.name = dr["name"].ToString();
                    customer.address = dr["address"].ToString();
                }
                con.Close();
            }
            return customer;
        }

        //Create customer

        public void CreateCustomer(CustomerModel customer)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@address", customer.address);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                con.Close();

            }
        }

        //Update Customer
        public void UpdateCustomer(CustomerModel cust)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customerID", cust.customerID);
                cmd.Parameters.AddWithValue("@name", cust.name);
                cmd.Parameters.AddWithValue("@address", cust.address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Delete Customer
        public void Delete(int? customerID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customerID", customerID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
