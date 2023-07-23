using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces;

public interface IPasswordHasing
{
    string HassPassword(string password);
    bool VerifyPassword(string password, string base64Hash);
}
