using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class EmployeeDAL
    {
        //string connectionStringDEV = "Data Source=LAPTOP-TCM;Initial Catalog=DomingoDatabase;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Employees
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> empList = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.employeeNo = dr["employeeNo"].ToString();
                    emp.employeeName = dr["employeeName"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }

            return empList;

        }

        //Insert Employyes

        public void AddEmployee(EmployeeModel emp)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeNo", emp.employeeNo);
                cmd.Parameters.AddWithValue("@employeeName", emp.employeeName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Get Employee By ID

        public EmployeeModel GetEmployeeByEmployeeNo(string employeeNo)
        {
            EmployeeModel emp = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeByEmployeeNo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeNo", employeeNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.employeeNo = dr["employeeNo"].ToString();
                    emp.employeeName = dr["employeeName"].ToString();
                }
                con.Close();
            }
            return emp;
        }

        //Update Employee

        public void UpdateEmployee(EmployeeModel emp)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeNo", emp.employeeNo);
                cmd.Parameters.AddWithValue("@employeeName", emp.employeeName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Delete Employee

        public void Delete(string employeeNo)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeNo", employeeNo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
