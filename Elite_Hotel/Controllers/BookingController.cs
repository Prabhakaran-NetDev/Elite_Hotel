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
    public class BookingController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Booking> Obj = new List<Booking>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Booking
                        {
                            BookingID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            BookingDate = Convert.ToDateTime(sdr[3]),
                            CheckInDate = Convert.ToDateTime(sdr[4]),
                            CheckOutDate = Convert.ToDateTime(sdr[5]),
                            TotalAmount = Convert.ToDecimal(sdr[6]),
                            Status = sdr[7].ToString()
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
                Booking Obj = new Booking();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@BookingID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Booking
                        {
                            BookingID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            BookingDate = Convert.ToDateTime(sdr[3]),
                            CheckInDate = Convert.ToDateTime(sdr[4]),
                            CheckOutDate = Convert.ToDateTime(sdr[5]),
                            TotalAmount = Convert.ToDecimal(sdr[6]),
                            Status = sdr[7].ToString()
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
        public ActionResult Create(Booking Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@BookingID", Obj.BookingID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@BookingDate", Obj.BookingDate);
                    SqlCmd.Parameters.AddWithValue("@CheckInDate", Obj.CheckInDate);
                    SqlCmd.Parameters.AddWithValue("@CheckOutDate", Obj.CheckOutDate);
                    SqlCmd.Parameters.AddWithValue("@TotalAmount", Obj.TotalAmount);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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
                Booking Obj = new Booking();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@BookingID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Booking
                        {
                            BookingID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            BookingDate = Convert.ToDateTime(sdr[3]),
                            CheckInDate = Convert.ToDateTime(sdr[4]),
                            CheckOutDate = Convert.ToDateTime(sdr[5]),
                            TotalAmount = Convert.ToDecimal(sdr[6]),
                            Status = sdr[7].ToString()
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
        public ActionResult Edit(int id, Booking Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@BookingID", Obj.BookingID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@BookingDate", Obj.BookingDate);
                    SqlCmd.Parameters.AddWithValue("@CheckInDate", Obj.CheckInDate);
                    SqlCmd.Parameters.AddWithValue("@CheckOutDate", Obj.CheckOutDate);
                    SqlCmd.Parameters.AddWithValue("@TotalAmount", Obj.TotalAmount);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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
                Booking Obj = new Booking();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@BookingID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Booking
                        {
                            BookingID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            RoomID = Convert.ToInt32(sdr[2]),
                            BookingDate = Convert.ToDateTime(sdr[3]),
                            CheckInDate = Convert.ToDateTime(sdr[4]),
                            CheckOutDate = Convert.ToDateTime(sdr[5]),
                            TotalAmount = Convert.ToDecimal(sdr[6]),
                            Status = sdr[7].ToString()
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
        public ActionResult Delete(int id, Booking Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Bookings", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue( "@BookingID", id);

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
