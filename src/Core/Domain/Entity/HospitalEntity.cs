using Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Domain.Entity
{
    public class HospitalEntity : AuditableEntity
    {
        public string? Name { get; set; }
        public string?Code { get; set; }
        public string? Address { get; set; }
    }

}
