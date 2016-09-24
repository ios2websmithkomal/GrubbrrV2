using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Test_Guid_no.wcf;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.Configuration;
using System.Diagnostics;
using System.Drawing;

namespace Test_Guid_no
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wcf.GrubrrV2Client ct = new GrubrrV2Client();
            //1st 
            
//2nd live change
           // Response.Write(ct.ManageCategory(CreateSamplePeople(1).ToArray()));


            //  string query = "select * from city";
            // Stopwatch sw = Stopwatch.StartNew();

            //GridView1.DataSource= GetDataUsingQuery(query, new object[,] { { "IsDeleted", 0 } });
            //GridView1.DataBind();
            // sw.Stop();

            // string Output = " : " + sw.Elapsed.TotalMilliseconds.ToString() + "</br>";
            // ReponseWriteEx(Output, Color.Red);

            // Stopwatch sw1 = Stopwatch.StartNew();
            // GetDataUsingDataReader(query, new object[,] { { "IsDeleted", 0 } });
            // sw1.Stop();

            // Output = " : " + sw1.Elapsed.TotalMilliseconds.ToString() + "</br>";
            // ReponseWriteEx(Output, Color.Red);
            //wcf.GrubrrV2Client CT = new wcf.GrubrrV2Client();
            //EmployeeMasterDataEmployeeMasterSUB obj = new EmployeeMasterDataEmployeeMasterSUB();
            //obj.Address = "abc";
            //obj.CityID = "1";
            //obj.CountryID = "1";
            //obj.CreatedDate = DateTime.Now.ToString();
            //obj.Email = "abc@gmail.com";
            //obj.EmpCode = "12345";
            //obj.EmpDocCopy = "a";
            //obj.EmpImage = "ä.jpeg";

            //obj.EmpName = "purvi";
            //obj.Password = "123";
            //obj.Mobile = "81411212";

            //obj.StateID = "1";
            //obj.CityID = "1";
            //obj.RepotingTo = "1";
            //obj.RoleID = "1";
            //obj.QueryID = "1";
            //obj.ShiftID = "1";
            //obj.SalaryType = "1";
            //obj.SalaryAmt = "1000";
            //Response.Write(CT.AddStaff(obj));

            wcf.LoginDetail obj = new wcf.LoginDetail();
            obj.Username = "123456";
            obj.Password = "123";
            Response.Write(ct.BranchAuthentication(obj));
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        // //  Label1.Text =callsp();
        //}

        //private static List<Person> CreateSamplePeople(int count)
        //{

        //    List<Person> Persons = new List<Person>();
        //    for (int i = 0; i < count; i++)
        //    {

        //        Persons.Add(new Person
        //        {
        //            Name = Guid.NewGuid().ToString(),
        //            DateOfBirth = DateTime.Now.ToString()
        //        });
        //    }

        //    return Persons;

        //}
        private static List<CategoryMasterDataCategoryMasterSUB> CreateSamplePeople(int count)
        {
            List<CategoryMasterDataCategoryMasterSUB> Persons = new List<CategoryMasterDataCategoryMasterSUB>();
            Persons.Add(new CategoryMasterDataCategoryMasterSUB
            {
                CategoryName = Guid.NewGuid().ToString(),
                MainCategoryID = "0",
                ImgPath = "1",
                Status = "0",

                Priority = "1",
                RUserID = "2",
                RUserType = "1",
                CategoryID = "93",
                AttributeID = "1",
                TaxID = "1"

            });

            Persons.Add(new CategoryMasterDataCategoryMasterSUB
            {
                CategoryName = Guid.NewGuid().ToString(),
                MainCategoryID = "0",
                ImgPath = "2",
                Status = "0",

                Priority = "1",
                RUserID = "2",
                RUserType = "1",
                CategoryID = "88",
                AttributeID = "1",
                TaxID = "1"

            });
            return Persons;

        }
        #region

        static SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BankingRulesConnectionString"].ConnectionString.ToString());
        //string asd = ConfigurationManager.ConnectionStrings[""].ConnectionString.ToString();

        static void ReConnection()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        private void ReponseWriteEx(string output, Color color)
        {
            Response.Write(String.Format(@"<span style=""color: #{0}"">{1}</span>", System.Drawing.ColorTranslator.ToHtml(color), output));
        }
        public SqlConnection GetConnection { get { return con; } }
        public List<DataRow> GetDataUsingQuery(string QueryWithParameters, object[,] ParameterValue)
        {
            SqlConnection MYCON = new SqlConnection(con.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = MYCON;
                SqlParameter[] param = new SqlParameter[ParameterValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParameterValue[i, 0].ToString(), ParameterValue[i, 1]);
                }
                cmd.CommandText = QueryWithParameters;
                MYCON.Open();
                cmd.Parameters.AddRange(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
            finally
            {
                //    if (rdr != null)
                //    {
                //        rdr.Close();
                //        dt = null;
                //    }

                // close the connection
                if (MYCON != null)
                {
                    MYCON.Close();
                }
            }
            //List<DataRow> rows = 
            //return dt.Rows.Cast<DataRow>().ToArray();
            return dt.AsEnumerable().ToList();
        }
        public DataTable GetDataUsingDataReader(string QueryWithParameters, object[,] ParameterValue)
        {
            SqlDataReader rdr = null;
            DataTable dt = new DataTable();
            SqlConnection MYCON = new SqlConnection(con.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = MYCON;
                SqlParameter[] param = new SqlParameter[ParameterValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParameterValue[i, 0].ToString(), ParameterValue[i, 1]);
                }
                cmd.CommandText = QueryWithParameters;
                cmd.Parameters.AddRange(param);
                MYCON.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {


                // close the connection
                if (MYCON != null)
                {
                    MYCON.Close();
                }
            }
            return dt;
        }
        #endregion


    }
}
