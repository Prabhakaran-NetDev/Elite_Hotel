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
    public class RentalHistoryController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<RentalHistory> Obj = new List<RentalHistory>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new RentalHistory
                        {
                            RentalHistoryID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            CheckInDate = Convert.ToDateTime(sdr[3]),
                            CheckOutDate = Convert.ToDateTime(sdr[4]),
                            TotalAmount = Convert.ToDecimal(sdr[5])
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
                RentalHistory Obj = new RentalHistory();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new RentalHistory
                        {
                            RentalHistoryID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            CheckInDate = Convert.ToDateTime(sdr[3]),
                            CheckOutDate = Convert.ToDateTime(sdr[4]),
                            TotalAmount = Convert.ToDecimal(sdr[5])
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
        public ActionResult Create(RentalHistory Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", Obj.RentalHistoryID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@CheckInDate", Obj.CheckInDate);
                    SqlCmd.Parameters.AddWithValue("@CheckOutDate", Obj.CheckOutDate);
                    SqlCmd.Parameters.AddWithValue("@TotalAmount", Obj.TotalAmount);

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
                RentalHistory Obj = new RentalHistory();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new RentalHistory
                        {
                            RentalHistoryID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            CheckInDate = Convert.ToDateTime(sdr[3]),
                            CheckOutDate = Convert.ToDateTime(sdr[4]),
                            TotalAmount = Convert.ToDecimal(sdr[5])
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
        public ActionResult Edit(int id, RentalHistory Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", Obj.RentalHistoryID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@CheckInDate", Obj.CheckInDate);
                    SqlCmd.Parameters.AddWithValue("@CheckOutDate", Obj.CheckOutDate);
                    SqlCmd.Parameters.AddWithValue("@TotalAmount", Obj.TotalAmount);

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
                RentalHistory Obj = new RentalHistory();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new RentalHistory
                        {
                            RentalHistoryID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            CheckInDate = Convert.ToDateTime(sdr[3]),
                            CheckOutDate = Convert.ToDateTime(sdr[4]),
                            TotalAmount = Convert.ToDecimal(sdr[5])
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
        public ActionResult Delete(int id, RentalHistory Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_RentalHistory", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RentalHistoryID", id);

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
