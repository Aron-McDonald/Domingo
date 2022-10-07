using DomingoApp.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class InvoiceDAL
    {
        //string connectionStringDEV = "Data Source=LAPTOP-TCM;Initial Catalog=DomingoDatabase;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Invoices
        public IEnumerable<InvoiceModel> GetAllInvoices()
        {
            List<InvoiceModel> iList = new List<InvoiceModel>();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllInvoices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InvoiceModel invoice = new InvoiceModel();
                    invoice.invoiceNo = Convert.ToInt32(dr["invoiceNo"].ToString());
                    invoice.jobCardNo = Convert.ToInt32(dr["jobCardNo"].ToString());
                    invoice.cutomerName = dr["name"].ToString();
                    invoice.address = dr["address"].ToString();
                    invoice.jobType = dr["jobType"].ToString();
                    invoice.employeeNo = dr["employeeNo"].ToString();
                    invoice.employeeName = dr["employeeName"].ToString();
                    invoice.material = dr["material"].ToString();
                    invoice.quantity = dr["quantity"].ToString();
                    invoice.dailyRate = Convert.ToDouble(dr["dailyRate"].ToString());
                    invoice.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                    invoice.subtotal = Convert.ToDouble(dr["subtotal"].ToString());
                    invoice.VAT = Convert.ToDouble(dr["VAT"].ToString());
                    invoice.total = Convert.ToDouble(dr["total"].ToString());

                    iList.Add(invoice);
                }
                con.Close();
            }

            return iList;
        }

        //Get Invoice By InvoiceNo
        public InvoiceModel GetInvoiceByInvoiceNo(int? invoiceNo)
        {
            InvoiceModel invoice = new InvoiceModel();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceByInvoiceNo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    invoice.invoiceNo = Convert.ToInt32(dr["invoiceNo"].ToString());
                    invoice.jobCardNo = Convert.ToInt32(dr["jobCardNo"].ToString());
                    invoice.cutomerName = dr["name"].ToString();
                    invoice.address = dr["address"].ToString();
                    invoice.jobType = dr["jobType"].ToString();
                    invoice.employeeNo = dr["employeeNo"].ToString();
                    invoice.employeeName = dr["employeeName"].ToString();
                    invoice.material = dr["material"].ToString();
                    invoice.quantity = dr["quantity"].ToString();
                    invoice.dailyRate = Convert.ToDouble(dr["dailyRate"].ToString());
                    invoice.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                    invoice.subtotal = Convert.ToDouble(dr["subtotal"].ToString());
                    invoice.VAT = Convert.ToDouble(dr["VAT"].ToString());
                    invoice.total = Convert.ToDouble(dr["total"].ToString());
                }
                con.Close();
            }
            return invoice;
        }

        //Create Invoice

        public void CreateInvoice(InvoiceModel invoice)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@jobCardNo", invoice.jobCardNo);
                cmd.Parameters.AddWithValue("@customerID", invoice.customerID);
                cmd.Parameters.AddWithValue("@jobTypeID", invoice.jobTypeID);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
