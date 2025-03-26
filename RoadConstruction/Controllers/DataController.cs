using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadConstruction.Models;
using System.Text.Json;

namespace RoadConstruction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly string filePath = "wwwroot/data.json";

        [HttpGet]

        public IActionResult GetData()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("JSON file not found.");
            }

            var jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<DataModel>(jsonData);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult SaveData([FromBody] DataModel updatedData)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(updatedData, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, jsonData);
                return Ok(new { message = "Data saved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error saving data", error = ex.Message });
            }

        }

    }
}
