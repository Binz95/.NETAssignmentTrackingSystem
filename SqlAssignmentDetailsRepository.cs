using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentTrackingSystemLibrary
{
    public class SqlAssignmentDetailsRepository : IAssignments
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=CCS-IPK-COMP101\SQLEXPRESS;Initial Catalog=AssignmentTrackingManagementSystem;Integrated Security=True");
        public Assignments FindAssignments(int AssignmentId)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AssignmentDetails WHERE AssignmentId=" + AssignmentId, cnn);
            cmd.Parameters.AddWithValue("@AssignmentId", AssignmentId);
            SqlDataReader dr = cmd.ExecuteReader();
            Assignments a = new Assignments();
            while (dr.Read())
            {
                a.AssignmentId = Int32.Parse(dr["AssignmentId"].ToString());
                a.AssignmentName = dr["AssignmentName"].ToString();
                a.EmployeeName = dr["EmployeeName"].ToString();
                a.Date = DateTime.Parse(dr["Date"].ToString());
            };
            cnn.Close();
            return a;
        }

        public List<Assignments> GetAssignments()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AssignmentDetails", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Assignments> GlAssignments = new List<Assignments>();
            while (dr.Read())
            {
                Assignments a = new Assignments
                {
                    AssignmentId = Int32.Parse(dr["AssignmentId"].ToString()),
                    AssignmentName = dr["AssignmentName"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Date = DateTime.Parse(dr["Date"].ToString())
                };
                GlAssignments.Add(a);
            }
            cnn.Close();
            return GlAssignments;
        }

        public void InsertAssignments(Assignments a)
        {

            cnn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO AssignmentDetails VALUES(@AssignmentName,@EmployeeName,@Date)", cnn);
            cmd.Parameters.AddWithValue("@AssignmentName", a.AssignmentName);
            cmd.Parameters.AddWithValue("@EmployeeName", a.EmployeeName);
            cmd.Parameters.AddWithValue("@Date", a.Date);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}

