using ManegmentSystems.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ManegmentSystems.Data
{
    public class callproc
    {
        private   CarMangerContext _context = new CarMangerContext();
       

        public void  updateCapitalShare(string userID)
        {
            //excute the reders proc to increase number of readers 
            var con = _context.Database.GetDbConnection();
            con.Open();
            var command = con.CreateCommand();
            command.CommandText = "CApitalShareMoney";//store proc name
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@USERid", userID));

            command.ExecuteNonQuery();
        }
    }
}
