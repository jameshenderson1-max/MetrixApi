using Microsoft.AspNetCore.Mvc;
using MetrixApi.Data;
using MetrixApi.Models;
using MetrixApi.Dtos;
using MetrixApi.Responses;

namespace MetrixApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcodeScansController : ControllerBase
    {
        private readonly MetrixDbContext _db;

        public BarcodeScansController(MetrixDbContext db)
        {
            _db = db;
        }

        [HttpPost("batch")]
        public async Task<IActionResult> SaveBatch([FromBody] List<BarcodeScanDto> barcodes)
        {
            if (barcodes == null || barcodes.Count == 0)
                return BadRequest("No barcodes provided.");

            var entries = barcodes.Select(b => new BarcodeScan
            {
                Code = b.Code,
                UserId = b.UserId,
                ScannedAt = DateTime.UtcNow
            });

            _db.BarcodeScans.AddRange(entries);
            await _db.SaveChangesAsync();

            return Ok(new SaveBatchResponse
            {
                Saved = barcodes.Count,
                Message = "Barcodes saved successfully"
            });
        }
    }
}