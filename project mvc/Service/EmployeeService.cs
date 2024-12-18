using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using project_mvc.Models;
using System.Data.SqlClient;
using System.Data;

namespace project_mvc.Service
{
    public class EmployeeService
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public IList<Employeemodel> GetemployeeList()
        {
            IList<Employeemodel> getEmplList = new List<Employeemodel>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeVieworInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Employeemodel obj = new Employeemodel();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.EmpName = Convert.ToString(_ds.Tables[0].Rows[i]["EmpName"]);
                        obj.Emailid = Convert.ToString(_ds.Tables[0].Rows[i]["Emailid"]);
                        obj.MobileNo = Convert.ToString(_ds.Tables[0].Rows[i]["MobileNo"]);
                        getEmplList.Add(obj);
                    }
                }

            }





            return getEmplList;
        }


        public void InsertEmployee(Employeemodel model)


        {

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeVieworInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                cmd.Parameters.AddWithValue("@EmpEmailid", model.Emailid);
                cmd.Parameters.AddWithValue("@EmpMobileNo", model.MobileNo);
                cmd.ExecuteNonQuery();



            }



        }

        public Employeemodel GetEditbyId(int id)
        {
            Employeemodel model = new Employeemodel();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeVieworInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmployeeId");
                cmd.Parameters.AddWithValue("@EmpId", id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.EmpName = Convert.ToString(_ds.Tables[0].Rows[0]["EmpName"]);
                    model.Emailid = Convert.ToString(_ds.Tables[0].Rows[0]["Emailid"]);
                    model.MobileNo = Convert.ToString(_ds.Tables[0].Rows[0]["MobileNo"]);
                }
            }






            return model;
        }

        public void UpdateEmp(Employeemodel model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeVieworInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmployee");
                cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                cmd.Parameters.AddWithValue("@EmpEmailid", model.Emailid);
                cmd.Parameters.AddWithValue("@EmpMobileNo", model.MobileNo);
                cmd.ExecuteNonQuery();



            }

        }

        public void DeleteEmp(int id)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeVieworInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteEmployee");
                cmd.Parameters.AddWithValue("@Empid", id);
                cmd.ExecuteNonQuery();

            }

        }

    }
}






