using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Sportolo13A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportoloController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=sportolo13b;";
        [HttpGet("id")]
        public object GetSportolobyId(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var sql = @"SELECT * FROM `sportolo` WHERE `id`=@id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            var datareader = cmd.ExecuteReader();
            object? data = null;
            if (datareader.Read() == true)
            {
                var sportolo = new Sportolo()
                {
                    Id=datareader.GetInt32("id"),
                    Name = datareader.GetString("name"),
                    Email = datareader.GetString("email"),
                };
                data = new { message = "Sikeres lekérdezés", result = sportolo };
            }
            else
            {
                data = new { message = "Nincs ilyen sportolo", result = "" };
            }
            connection.Close();
            return data;


        }
        [HttpGet("sporteredmeny")]
        public object GetSportoloWithEredmenyek(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var sql = @"SELECT s.name, e.competition, e.description 
                FROM `sportolo` s 
                LEFT JOIN `eredmeny` e ON s.id = e.sportoloid 
                WHERE s.id = @id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            var datareader = cmd.ExecuteReader();

            object? data = null;
            string name = "";
            var eredmenyek = new List<object>();

            while (datareader.Read() == true)
            {
                name = datareader.GetString("name");

                if (datareader.IsDBNull(datareader.GetOrdinal("competition")) == false)
                {
                    var eredmeny = new
                    {
                        Competition = datareader.GetString("competition"),
                        Description = datareader.IsDBNull(datareader.GetOrdinal("description")) ? "" : datareader.GetString("description")
                    };
                    eredmenyek.Add(eredmeny);
                }
            }

            if (name != "")
            {
                var resultData = new
                {
                    Name = name,
                    Eredmenyek = eredmenyek
                };
                data = new { message = "Sikeres lekérdezés", result = resultData };
            }
            else
            {
                data = new { message = "Nincs ilyen sportolo", result = "" };
            }

            connection.Close();
            return data;
        }
        [HttpGet]
        public IActionResult GetTotalEredmenyekCount()
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            string sql = "SELECT COUNT(*) FROM eredmeny;";
            using var cmd = new MySqlCommand(sql, connection);

            long count = Convert.ToInt64(cmd.ExecuteScalar());

            return Ok(new { message = "Sikeres lekérdezés. Az eredmenyekben levo eredmenyek szama:", osszes = count ,});
        }
        [HttpGet("eredmenyszamok")]
        public object GetEredmenyekCountBySportolo(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var sql = @"SELECT COUNT(*) AS darab FROM `eredmeny` WHERE `sportoloid`=@id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            var datareader = cmd.ExecuteReader();
            object? data = null;
            if (datareader.Read() == true)
            {
                int darab = datareader.GetInt32("darab");
                data = new { message = "Sikeres lekérdezés", Eredményszáma = darab };
            }
            else
            {
                data = new { message = "Nincs ilyen sportolo", Eredményszáma = "" };
            }
            connection.Close();
            return data;
        }
    }
}
