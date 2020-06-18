using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PFRCenterGlobal.BackendForMobile.Features.Certificates
{
    [Route("api/certificates")]
    public class CertificatesController : ControllerBase
    {
        private readonly IReadOnlyCollection<Certificate> _certificateModels = new List<Certificate>()
        {
            new Certificate()
            {
                Id=1
            },
            new Certificate()
            {
                Id=2
            },
            new Certificate()
            {
                Id = 3
            }
        };
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(100, ct);
            var result = _certificateModels.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(100, ct);
            return Ok(_certificateModels);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Certificate certificate, CancellationToken ct)
        {
            await Task.Delay(100, ct);
            throw new NotImplementedException();
        }

        [HttpPut]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAsync(Certificate certificate, CancellationToken ct)
        {
            await Task.Delay(100, ct);
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            await Task.Delay(100, ct);
            throw new NotImplementedException();
        }
    }
}