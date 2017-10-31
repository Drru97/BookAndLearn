using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookAndLearn.Common;

namespace BookAndLearn.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
      //      var connectionString = @"Server=tcp:drru.database.windows.net,1433;Initial Catalog=BookAndLearn.SQL;Persist Security Info=False;User ID=drru;Password=YwX9zTzfwTH0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //    var connection = new SqlConnection(connectionString);
        //    connection.Open();

            var context = new BookAndLearnContext();
            var students = context.Students.Where(s => s.Group.Name == "ФеІ-41/1").ToList();
            var group = context.Students.Where(s => s.Group.LessonGroups.FirstOrDefault() != null).ToList();
            return View();
        }
    }
}