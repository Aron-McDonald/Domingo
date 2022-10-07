using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class JobTypeDAL
    {
        //string connectionStringDEV = "Data Source=LAPTOP-TCM;Initial Catalog=DomingoDatabase;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All JobTypes
        public IEnumerable<JobTypeModel> GetAllJobTypes()
        {
            List<JobTypeModel> jTList = new List<JobTypeModel>();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllJobTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    JobTypeModel jT = new JobTypeModel();
                    jT.jobTypeID = Convert.ToInt32(dr["jobTypeID"].ToString());
                    jT.jobType = dr["jobType"].ToString();
                    jT.dailyRate = Convert.ToDouble(dr["dailyRate"].ToString());

                    jTList.Add(jT);
                }
                con.Close();
            }

            return jTList;
        }

        //Get JobType By JobTypeID
        public JobTypeModel GetJobTypeByJobTypeID(int? jobTypeID)
        {
            JobTypeModel jT = new JobTypeModel();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobTypeByJobTypeID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@jobTypeID", jobTypeID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    jT.jobTypeID = Convert.ToInt32(dr["jobTypeID"]);
                    jT.jobType = dr["jobType"].ToString();
                    jT.dailyRate = Convert.ToDouble(dr["dailyRate"]);
                }
                con.Close();
            }
            return jT;
        }

        //Update JobType
        public void UpdateJobType(JobTypeModel jT)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateJobTypeRate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@jobTypeID", jT.jobTypeID);
                cmd.Parameters.AddWithValue("@dailyRate", jT.dailyRate);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
