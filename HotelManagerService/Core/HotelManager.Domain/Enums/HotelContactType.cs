using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Enums
{
    public enum HotelContactType
    {
        [Description("")]
        Null = 0,
        [Description("Phone")]
        PhoneNumber = 1,
        [Description("Email")]
        EmailAddress = 2
    }
}
