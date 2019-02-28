using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagBirJoiAnniEmailService
{
    public enum EmailType : byte
    {
        JoiningEmail = 1,
        BirthDayEmail = 2,
        BelatedBirthDayEmail = 3,
        JoiningAnniversary = 4

    }
}
