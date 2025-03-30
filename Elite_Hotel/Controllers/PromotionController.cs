using Elite_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elite_Hotel.Controllers
{
    public class PromotionController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Promotion> Obj = new List<Promotion>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Promotion
                        {
                            PromotionID = Convert.ToInt32(sdr[0]),
                            Code = sdr[1].ToString(),
                            Description = sdr[2].ToString(),
                            DiscountPercentage = Convert.ToDecimal(sdr[3]),
                            StartDate = Convert.ToDateTime(sdr[4]),
                            EndDate = Convert.ToDateTime(sdr[5])
                        });
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET 
        public ActionResult Details(int id)
        {
            try
            {
                Promotion Obj = new Promotion();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Promotion
                        {
                            PromotionID = Convert.ToInt32(sdr[0]),
                            Code = sdr[1].ToString(),
                            Description = sdr[2].ToString(),
                            DiscountPercentage = Convert.ToDecimal(sdr[3]),
                            StartDate = Convert.ToDateTime(sdr[4]),
                            EndDate = Convert.ToDateTime(sdr[5])
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(Promotion Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", Obj.PromotionID);
                    SqlCmd.Parameters.AddWithValue("@Code", Obj.Code);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@DiscountPercentage", Obj.DiscountPercentage);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Edit(int id)
        {
            try
            {
                Promotion Obj = new Promotion();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Promotion
                        {
                            PromotionID = Convert.ToInt32(sdr[0]),
                            Code = sdr[1].ToString(),
                            Description = sdr[2].ToString(),
                            DiscountPercentage = Convert.ToDecimal(sdr[3]),
                            StartDate = Convert.ToDateTime(sdr[4]),
                            EndDate = Convert.ToDateTime(sdr[5])
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // POST
        [HttpPost]
        public ActionResult Edit(int id, Promotion Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", Obj.PromotionID);
                    SqlCmd.Parameters.AddWithValue("@Code", Obj.Code);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@DiscountPercentage", Obj.DiscountPercentage);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Delete(int id)
        {
            try
            {
                Promotion Obj = new Promotion();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Promotion
                        {
                            PromotionID = Convert.ToInt32(sdr[0]),
                            Code = sdr[1].ToString(),
                            Description = sdr[2].ToString(),
                            DiscountPercentage = Convert.ToDecimal(sdr[3]),
                            StartDate = Convert.ToDateTime(sdr[4]),
                            EndDate = Convert.ToDateTime(sdr[5])
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // POST
        [HttpPost]
        public ActionResult Delete(int id, Promotion Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Promotions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PromotionID", id);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }
    }
}
