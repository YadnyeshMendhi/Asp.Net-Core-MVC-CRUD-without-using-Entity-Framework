using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDwithoutEF.Data;
using CRUDwithoutEF.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDwithoutEF.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IConfiguration _configuration;

        public PhoneController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Phone
        public IActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlconnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlconnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("PhoneViewAll", sqlconnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dtbl);

            }
            return View(dtbl);
        }

       



        // GET: Phone/AddorEdit/
        public  IActionResult AddorEdit(int? id)
        {

            PhoneViewModel pvm = new PhoneViewModel();
            if (id > 0)
                pvm = FetchPhoneById(id);
            return View(pvm); 
      
        }

        // POST: Phone/AddorEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(int id, [Bind("PhoneID,Brand,Model,Price")] PhoneViewModel pvm)
        {

            if (ModelState.IsValid)
            {
                using(SqlConnection sqlconnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlconnection.Open();
                    SqlCommand sqlcmd = new SqlCommand("PhoneAddorEdit", sqlconnection);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("PhoneID", pvm.PhoneID);
                    sqlcmd.Parameters.AddWithValue("Brand", pvm.Brand);
                    sqlcmd.Parameters.AddWithValue("Model", pvm.Model);
                    sqlcmd.Parameters.AddWithValue("Price", pvm.Price);
                    sqlcmd.ExecuteNonQuery();
                    
                }
                return RedirectToAction(nameof(Index));

            }
            return View(pvm);
           
            

           
        }

        // GET: Phone/Delete/5
        public IActionResult Delete(int? id)
        {

            PhoneViewModel pvm = FetchPhoneById(id);
                return View(pvm);
            

          
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlconnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlconnection.Open();
                SqlCommand sqlcmd = new SqlCommand("PhoneDeleteByID", sqlconnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("PhoneID", id);
                sqlcmd.ExecuteNonQuery();
       
            }
            return RedirectToAction(nameof(Index));
        }


        [NonAction]
        public PhoneViewModel FetchPhoneById(int? id)
        {
            PhoneViewModel pvm = new PhoneViewModel();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlconnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlconnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("PhoneViewByID", sqlconnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure; 
                sqlDa.SelectCommand.Parameters.AddWithValue("PhoneID", id);
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    pvm.PhoneID = Convert.ToInt32(dtbl.Rows[0]["PhoneID"].ToString());
                    pvm.Brand = dtbl.Rows[0]["Brand"].ToString();
                    pvm.Model = dtbl.Rows[0]["Model"].ToString();
                    pvm.Price = Convert.ToInt32(dtbl.Rows[0]["Price"].ToString());

                }
                return pvm;

            }
        }


    }
}
