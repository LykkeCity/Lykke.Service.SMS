using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SMS.Controllers
{
    public class SmsComtroller : Controller
    {
        public Task<IActionResult> SendMessage(string phoneNumber, string message)
        {
            return null;
        }
    }
}
