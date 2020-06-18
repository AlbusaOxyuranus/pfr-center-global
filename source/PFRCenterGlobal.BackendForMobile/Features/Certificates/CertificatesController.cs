using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PFRCenterGlobal.BackendForMobile.Features.Certificates
{
    [Route("certificates")]
    public class CertificatesController : ControllerBase
    {
        private IReadOnlyCollection<Certificate> _certificateModels = new List<Certificate>()
        {
            new Certificate()
            {
                Id=1
            },
            new Certificate()
            {
                Id=2
            }
        };
        
        [HttpGet]
        [Route("{id}")]
        public Task<Certificate> GetByIdAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        [Route("")]
        public Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id}")]
        public Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [HttpPost]
        [Route("")]
        public Task<Certificate> AddAsync(Certificate certificate, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}