using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace WebQLGiaPha
{
    /// <summary>
    /// Summary description for CreatePerson
    /// </summary>
    public class CreatePerson : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            
            try
            {
                var dataForm = context.Request.Form;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=YUU\\SQLEXPRESS;Initial Catalog=THK_QLGP;Integrated Security=True";
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_ThemNguoi";
                        cmd.Parameters.Add("@HoDem", SqlDbType.NVarChar, 50).Value = dataForm["ho"];
                        cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 50).Value = dataForm["ten"];
                        cmd.Parameters.Add("@Ngaysinh", SqlDbType.Date).Value = dataForm["ngaysinh"];
                        cmd.Parameters.Add("@NoiSinh", SqlDbType.NVarChar,100).Value = dataForm["noisinh"];
                        var gt = dataForm["gioitinh"].ToString();
                        bool gioitinh = gt == "1" ? true : false;
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = gioitinh;
                        cmd.Parameters.Add("@NgayMat", SqlDbType.Date).Value = null;
                        cmd.Parameters.Add("@IdBo", SqlDbType.Int).Value = null;
                        cmd.Parameters.Add("@IdMe", SqlDbType.Int).Value = null;
                        cmd.Parameters.Add("@DaMat", SqlDbType.Bit).Value = null;
                        cmd.Parameters.Add("@DaKetHon", SqlDbType.Bit).Value = null;
                        cmd.Parameters.Add("@IdVoChong", SqlDbType.Int).Value = null;
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.StatusCode = 200;
                            context.Response.Write("Thành công");
                        }
                        else
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.StatusCode = 400;
                            context.Response.Write("Không thành công");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
           

            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}