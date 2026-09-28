using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Sportolo13A.Models.DTOs;

namespace Sportolo13A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EredmenyController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=sportolo13b;";

        [HttpGet]
        public List<Eredmeny> GetSportolok() { 
        List<Eredmeny> sportolok = new List<Eredmeny>();

        var connection = new MySqlConnection(ConnectionString);

        connection.Open();

            string sql = "SELECT * FROM eredmeny;";

        var cmd = new MySqlCommand(sql, connection);

        var data = cmd.ExecuteReader();

            while (data.Read())
            {
                int idOrd = data.GetOrdinal("id");
                int competitionOrd = data.GetOrdinal("competition");
                int descriptionOrd = data.GetOrdinal("description");
                int resulttimeOrd = data.GetOrdinal("resulttime");
                int updatetimeOrd = data.GetOrdinal("updatetime");
                int sportoloidOrd = data.GetOrdinal("sportoloid");

        var sportolo = new Eredmeny
        {
            Id = data.IsDBNull(idOrd) ? 0 : data.GetInt32(idOrd),
            Competition = data.IsDBNull(competitionOrd) ? string.Empty : data.GetString(competitionOrd),
            Description = data.IsDBNull(descriptionOrd) ? string.Empty : data.GetString(descriptionOrd),
            Resulttime = data.IsDBNull(resulttimeOrd) ? DateTime.MinValue : data.GetDateTime(resulttimeOrd),
            UpdateTime = data.IsDBNull(updatetimeOrd) ? DateTime.MinValue : data.GetDateTime(updatetimeOrd),
            SportoloId = data.IsDBNull(sportoloidOrd) ? 0 : data.GetInt32(sportoloidOrd),
        };

            sportolok.Add(sportolo);
            }


    connection.Close();

            return sportolok;
        }
        [HttpGet("id")]
        public object GetEredmenybyId(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var sql = @"SELECT * FROM `eredmeny` WHERE `id`=@id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            var datareader = cmd.ExecuteReader();
            object? data = null;
            if (datareader.Read() == true)
            {
                var sportolo = new Eredmeny()
                {
                    Id = datareader.GetInt32("id"),
                    Competition = datareader.GetString("competition"),
                    Description = datareader.GetString("description"),
                    Resulttime = datareader.GetDateTime("resulttime"),
                    UpdateTime = datareader.GetDateTime("updatetime"),
                    SportoloId = datareader.GetInt32("sportoloid"),
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

        [HttpPost]
        public object AddNewEredmeny([FromBody] addnewsportoloDTO sportolo)
        {
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            string sql = @"INSERT INTO `eredmeny`(`competition`, `description`, `sportoloId`) VALUES (@competition,@description,@sportoloid)";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@competition", sportolo.Competition);
            cmd.Parameters.AddWithValue("@description", sportolo.Description);

            cmd.Parameters.AddWithValue("@sportoloid", sportolo.SportoloId);

            cmd.ExecuteNonQuery();
            connection.Close();
            return new { message = sportolo };
        }
        [HttpDelete]
        public object DeleteBlogger(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string sql = @"DELETE FROM `eredmeny` WHERE `id`=@id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();


            connection.Close();
            return new { message = "Sikeres törlés", result = "" };
        }
        [HttpPut]
        public object UpdateBlogger([FromQuery] int id, UpdateErdemenyDTO updateeredmenyDto)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var sql = @"UPDATE `eredmeny` SET `competition`='@competition',`description`='@description',`resultTime`='@resttime',`updateTime`='@updatetime',`sportoloId`='@sportoloid' WHERE `id` = @id;";

            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@competition", updateeredmenyDto.Competition);
            cmd.Parameters.AddWithValue("@description", updateeredmenyDto.Description);
            cmd.Parameters.AddWithValue("@resulttime", updateeredmenyDto.Resulttime);
            cmd.Parameters.AddWithValue("@updatetime", updateeredmenyDto.UpdateTime);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
            return new { message = "Sikeres frissités", result = updateeredmenyDto };

        }
    }
}
