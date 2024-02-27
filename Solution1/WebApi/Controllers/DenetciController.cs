using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data;
using System.Net;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenetciController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDateTime(int getPageIndex, int getList, string first, string last) //,string keyword
        {
            try
            {
                veritabaniyonetimsistemleriContext db = new veritabaniyonetimsistemleriContext();

                DateTime date = Convert.ToDateTime(first);
                first = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                date = Convert.ToDateTime(last);
                last = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                List<Ucuslar> myTypeList = new List<Ucuslar>();
                using (var context = new veritabaniyonetimsistemleriContext())
                {
                    DbCommand cmd = context.Database.GetDbConnection().CreateCommand();

                    cmd.CommandText = "dbo.DateParm";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@startdate", SqlDbType.NVarChar) { Value = first });
                    cmd.Parameters.Add(new SqlParameter("@enddate", SqlDbType.NVarChar) { Value = last });
                    cmd.Parameters.Add(new SqlParameter("@sayfala", SqlDbType.Int) { Value = getPageIndex });
                    cmd.Parameters.Add(new SqlParameter("@liste", SqlDbType.Int) { Value = getList });
                    //cmd.Parameters.Add(new SqlParameter("@liste", SqlDbType.NVarChar) { Value = keyword });

                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();

                        try
                        {
                            using (var rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    //Get each column
                                    myTypeList.Add(new Ucuslar() { Id = Convert.ToInt16(rdr.GetInt32(0)), HavaAlaniAdi = (string)rdr.GetString(1), HavaAlaniVaris = (string)rdr.GetString(2), KalkisSaati = Convert.ToDateTime(rdr.GetDateTime(3)), VarisSaati = Convert.ToDateTime(rdr.GetDateTime(4)), HavaYoluSirketi = (string)rdr.GetString(5), UcusNo = (string)rdr.GetString(6), UcusDurumu = true, Tarih = Convert.ToDateTime(rdr.GetDateTime(8)) });
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            cmd.Connection.Close();
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }
                    }

                }

                if (myTypeList.Count == 0)
                {
                    return new ContentResult
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Content = "No resources found.",
                        ContentType = "text/plain"
                    };
                }

                return Ok(myTypeList);
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Content = ex.Message,
                    ContentType = "text/plain"
                };
            }

        }
    }
}
