using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Common
{
    public interface IEntityBase
    {
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
