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
    public class PaymentController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Payment> Obj = new List<Payment>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Payment
                        {
                            PaymentID = Convert.ToInt32(sdr[0]),
                            BookingID = Convert.ToInt32(sdr[1]),
                            PaymentDate = Convert.ToDateTime(sdr[2]),
                            Amount = Convert.ToDecimal(sdr[3]),
                            PaymentMethod = sdr[4].ToString(),
                            PaymentStatus = sdr[5].ToString(),
                            BillingAddress = sdr[6].ToString()
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
                Payment Obj = new Payment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Payment
                        {
                            PaymentID = Convert.ToInt32(sdr[0]),
                            BookingID = Convert.ToInt32(sdr[1]),
                            PaymentDate = Convert.ToDateTime(sdr[2]),
                            Amount = Convert.ToDecimal(sdr[3]),
                            PaymentMethod = sdr[4].ToString(),
                            PaymentStatus = sdr[5].ToString(),
                            BillingAddress = sdr[6].ToString()
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
        public ActionResult Create(Payment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", Obj.PaymentID);
                    SqlCmd.Parameters.AddWithValue("@BookingID", Obj.BookingID);
                    SqlCmd.Parameters.AddWithValue("@PaymentDate", Obj.PaymentDate);
                    SqlCmd.Parameters.AddWithValue("@Amount", Obj.Amount);
                    SqlCmd.Parameters.AddWithValue("@PaymentMethod", Obj.PaymentMethod);
                    SqlCmd.Parameters.AddWithValue("@PaymentStatus", Obj.PaymentStatus);
                    SqlCmd.Parameters.AddWithValue("@BillingAddress", Obj.BillingAddress);

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
                Payment Obj = new Payment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Payment
                        {
                            PaymentID = Convert.ToInt32(sdr[0]),
                            BookingID = Convert.ToInt32(sdr[1]),
                            PaymentDate = Convert.ToDateTime(sdr[2]),
                            Amount = Convert.ToDecimal(sdr[3]),
                            PaymentMethod = sdr[4].ToString(),
                            PaymentStatus = sdr[5].ToString(),
                            BillingAddress = sdr[6].ToString()
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
        public ActionResult Edit(int id, Payment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", Obj.PaymentID);
                    SqlCmd.Parameters.AddWithValue("@BookingID", Obj.BookingID);
                    SqlCmd.Parameters.AddWithValue("@PaymentDate", Obj.PaymentDate);
                    SqlCmd.Parameters.AddWithValue("@Amount", Obj.Amount);
                    SqlCmd.Parameters.AddWithValue("@PaymentMethod", Obj.PaymentMethod);
                    SqlCmd.Parameters.AddWithValue("@PaymentStatus", Obj.PaymentStatus);
                    SqlCmd.Parameters.AddWithValue("@BillingAddress", Obj.BillingAddress);

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
                Payment Obj = new Payment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Payment
                        {
                            PaymentID = Convert.ToInt32(sdr[0]),
                            BookingID = Convert.ToInt32(sdr[1]),
                            PaymentDate = Convert.ToDateTime(sdr[2]),
                            Amount = Convert.ToDecimal(sdr[3]),
                            PaymentMethod = sdr[4].ToString(),
                            PaymentStatus = sdr[5].ToString(),
                            BillingAddress = sdr[6].ToString()
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
        public ActionResult Delete(int id, Payment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Payments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@PaymentID", id);

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
