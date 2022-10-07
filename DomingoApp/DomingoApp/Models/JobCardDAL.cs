using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models.DataAccess
{
    public class JobCardDAL
    {
        //string connectionStringDEV = "Data Source=LAPTOP-TCM;Initial Catalog=DomingoDatabase;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All JobCards
        public IEnumerable<JobCardModel> GetAllJobCards()
            {
                List<JobCardModel> jCList = new List<JobCardModel>();

                using (SqlConnection con = new SqlConnection(connectionStringPROD))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllJobCards", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        JobCardModel jC = new JobCardModel();
                        jC.jobCardNo = Convert.ToInt32(dr["jobCardNo"].ToString());
                        jC.jobTypeID = Convert.ToInt32(dr["jobTypeID"].ToString());
                        jC.jobType =dr["jobType"].ToString();
                        jC.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());

                        jCList.Add(jC);
                    }
                    con.Close();
                }

                return jCList;
            }

            //Create JobCards

            public void CreateJobCard(JobCardModel jC)
            {
                using (SqlConnection con = new SqlConnection(connectionStringPROD))
                {
                    SqlCommand cmd = new SqlCommand("SP_CreateJobCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@jobCardNo", jC.jobCardNo);
                    cmd.Parameters.AddWithValue("@jobTypeID", jC.jobTypeID);
                    cmd.Parameters.AddWithValue("@NoOfDays", jC.NoOfDays);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            //Get JobCard By JobCardNo

            public JobCardModel GetJobCardByJobCardNo(int? jobCardNo)
            {
                JobCardModel jC = new JobCardModel();
                using (SqlConnection con = new SqlConnection(connectionStringPROD))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetJobCardByJobCardNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@jobCardNo", jobCardNo);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        jC.jobCardNo = Convert.ToInt32(dr["jobCardNo"]);
                        jC.jobTypeID = Convert.ToInt32(dr["jobTypeID"]);
                        jC.jobType = dr["jobType"].ToString();
                        jC.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);
                    }
                    con.Close();
                }
                return jC;
            }

            //Delete JobCard
            public void Delete(int? jobCardNo)
            {
                using (SqlConnection con = new SqlConnection(connectionStringPROD))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteJobCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("jobCardNo", jobCardNo);

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
    }
}
