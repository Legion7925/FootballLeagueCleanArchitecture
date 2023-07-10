using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Domain.Common.Interfaces;

public interface IAuditableEntity
{
    int? CreatedBy { get; set; }

    DateTime? CreatedDate { get; set; }

    int? UpdatedBy { get; set; }

    DateTime? UpdatedDate { get; set; }
}
