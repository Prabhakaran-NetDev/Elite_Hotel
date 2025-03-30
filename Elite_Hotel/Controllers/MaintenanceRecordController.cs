using Elite_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Elite_Hotel.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<MaintenanceRecord> Obj = new List<MaintenanceRecord>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new MaintenanceRecord
                        {
                            MaintenanceID = Convert.ToInt32(sdr[0]),
                            RoomID = Convert.ToInt32(sdr[1]),
                            MaintenanceDate = Convert.ToDateTime(sdr[2]),
                            Description = sdr[3].ToString(),
                            Cost = Convert.ToDecimal(sdr[4]),
                            ServiceProvider = sdr[5].ToString()
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
                MaintenanceRecord Obj = new MaintenanceRecord();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new MaintenanceRecord
                        {
                            MaintenanceID = Convert.ToInt32(sdr[0]),
                            RoomID = Convert.ToInt32(sdr[1]),
                            MaintenanceDate = Convert.ToDateTime(sdr[2]),
                            Description = sdr[3].ToString(),
                            Cost = Convert.ToDecimal(sdr[4]),
                            ServiceProvider = sdr[5].ToString()
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
        public ActionResult Create(MaintenanceRecord Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", Obj.MaintenanceID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@MaintenanceDate", Obj.MaintenanceDate);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@Cost", Obj.Cost);
                    SqlCmd.Parameters.AddWithValue("@ServiceProvider", Obj.ServiceProvider);

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
                MaintenanceRecord Obj = new MaintenanceRecord();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new MaintenanceRecord
                        {
                            MaintenanceID = Convert.ToInt32(sdr[0]),
                            RoomID = Convert.ToInt32(sdr[1]),
                            MaintenanceDate = Convert.ToDateTime(sdr[2]),
                            Description = sdr[3].ToString(),
                            Cost = Convert.ToDecimal(sdr[4]),
                            ServiceProvider = sdr[5].ToString()
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
        public ActionResult Edit(int id, MaintenanceRecord Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", Obj.MaintenanceID);
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@MaintenanceDate", Obj.MaintenanceDate);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@Cost", Obj.Cost);
                    SqlCmd.Parameters.AddWithValue("@ServiceProvider", Obj.ServiceProvider);

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
                MaintenanceRecord Obj = new MaintenanceRecord();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new MaintenanceRecord
                        {
                            MaintenanceID = Convert.ToInt32(sdr[0]),
                            RoomID = Convert.ToInt32(sdr[1]),
                            MaintenanceDate = Convert.ToDateTime(sdr[2]),
                            Description = sdr[3].ToString(),
                            Cost = Convert.ToDecimal(sdr[4]),
                            ServiceProvider = sdr[5].ToString()
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
        public ActionResult Delete(int id, MaintenanceRecord Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_MaintenanceRecords", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@MaintenanceID", id);

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
