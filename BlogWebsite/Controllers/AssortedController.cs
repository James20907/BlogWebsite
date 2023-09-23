using BlogWebsite.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System.Text;

namespace BlogWebsite.Controllers
{
    public class AssortedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _environment;
        public AssortedController(ILogger<HomeController> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DragAndDrop()
        {
            return View();
        }
        
        public IActionResult CreateData(string count = "0")
        {
            int intCount = 0;
            string strFileName = @"TxtFiles\MyTest.txt";
            string strContent = string.Empty;
            int i = 1;
            bool IsEnabled = true;
            bool DelFlag = false;
            DateTime dtNow = DateTime.Now;
            int intID = 1;

            if (System.IO.File.Exists(strFileName))
            {
                System.IO.File.Delete(strFileName);
            }
            count = "50000";
            if (int.TryParse(count, out intCount))
            {
                while (i < intCount)
                {
                    strContent += string.Format(",0,'title_{0}',content_{0},,{1},{2},{3},{4},," + Environment.NewLine, i, IsEnabled, DelFlag, dtNow.ToString("yyyy-MM-dd hh:mm:ss:ffff"), intID);
                    i++;
                }

                var path = Path.Combine(_environment.ContentRootPath, strFileName);

                using (FileStream fs = System.IO.File.Create(path))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes(strContent);

                    fs.Write(content, 0, content.Length);
                }
            }

            TempData["msg"] = "ha ha";
            return View("Index");
        }

        
        public IActionResult InsertData()
        {
            string strConnectionString = @"Server=.;Database=BlogWeb;User ID=sa;Password=Obiz@12280;Trusted_Connection=True;Integrated Security=False;Encrypt=False;";

            // 新增 Article
            string strSQL = @"BULK INSERT dbo.Article 
FROM 'D:\Project_Git\BlogWebsite\BlogWebsite\TxtFiles\MyTest.txt' 
WITH 
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
);";
            using (var conn = new SqlConnection(strConnectionString))
            {
                var result = conn.Execute(strSQL);
            }

            // 查詢 Article
            using (var conn = new SqlConnection(strConnectionString))
            {
                var result = conn.Query<Article>("SELECT * FROM Article");
            }

            // 查詢 Article by ID = 1
            var parameters = new DynamicParameters();
            parameters.Add("ArticleID", "1", System.Data.DbType.Int64);

            using (var conn = new SqlConnection(strConnectionString))
            {
                var result = conn.QueryFirstOrDefault<Article>("SELECT * FROM Article WHERE 1=1 AND ArticleID = @ArticleID" , parameters);
            }



            return View("DragAndDrop");
        }
    }
}
