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
    public class RoomController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Room> Obj = new List<Room>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Room
                        {
                            RoomID = Convert.ToInt32(sdr[0]),
                            RoomNumber = sdr[1].ToString(),
                            Type = sdr[2].ToString(),
                            Capacity = Convert.ToInt32(sdr[3]),
                            PricePerNight = Convert.ToDecimal(sdr[4]),
                            Description = sdr[5].ToString(),
                            Status = sdr[6].ToString()
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
                Room Obj = new Room();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Room
                        {
                            RoomID = Convert.ToInt32(sdr[0]),
                            RoomNumber = sdr[1].ToString(),
                            Type = sdr[2].ToString(),
                            Capacity = Convert.ToInt32(sdr[3]),
                            PricePerNight = Convert.ToDecimal(sdr[4]),
                            Description = sdr[5].ToString(),
                            Status = sdr[6].ToString()
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
        public ActionResult Create(Room Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@RoomNumber", Obj.RoomNumber);
                    SqlCmd.Parameters.AddWithValue("@Type", Obj.Type);
                    SqlCmd.Parameters.AddWithValue("@Capacity", Obj.Capacity);
                    SqlCmd.Parameters.AddWithValue("@PricePerNight", Obj.PricePerNight);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
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
                Room Obj = new Room();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Room
                        {
                            RoomID = Convert.ToInt32(sdr[0]),
                            RoomNumber = sdr[1].ToString(),
                            Type = sdr[2].ToString(),
                            Capacity = Convert.ToInt32(sdr[3]),
                            PricePerNight = Convert.ToDecimal(sdr[4]),
                            Description = sdr[5].ToString(),
                            Status = sdr[6].ToString()
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
        public ActionResult Edit(int id, Room Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", Obj.RoomID);
                    SqlCmd.Parameters.AddWithValue("@RoomNumber", Obj.RoomNumber);
                    SqlCmd.Parameters.AddWithValue("@Type", Obj.Type);
                    SqlCmd.Parameters.AddWithValue("@Capacity", Obj.Capacity);
                    SqlCmd.Parameters.AddWithValue("@PricePerNight", Obj.PricePerNight);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
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
                Room Obj = new Room();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Room
                        {
                            RoomID = Convert.ToInt32(sdr[0]),
                            RoomNumber = sdr[1].ToString(),
                            Type = sdr[2].ToString(),
                            Capacity = Convert.ToInt32(sdr[3]),
                            PricePerNight = Convert.ToDecimal(sdr[4]),
                            Description = sdr[5].ToString(),
                            Status = sdr[6].ToString()
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
        public ActionResult Delete(int id, Room Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Rooms", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@RoomID", id);

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
