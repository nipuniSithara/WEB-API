using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;

namespace ManagementSystem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        IBatchRepository _batchRepository;

        public BatchController(IBatchRepository batchRepository)
        {
            this._batchRepository = batchRepository;
        }

        [HttpGet("Select/{BatchId}")]
        public async Task<ActionResult> Select(string BatchId)
        {
            var results = await _batchRepository.Select(BatchId);
            return Ok(results);

        }

        [HttpPost("Insert")]
        public async Task<ActionResult> insert(Batch batch)
        {
            await _batchRepository.Insert(batch);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(Batch batch)
        {
            await _batchRepository.Update(batch);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string BatchId)
        {
            await _batchRepository.Delete(BatchId);
            return Ok();
        }
    }
}