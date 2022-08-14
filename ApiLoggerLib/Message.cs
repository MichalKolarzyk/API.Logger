using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLoggerLib
{
    public class Message
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public LogLevel LogLevel { get; set; }
        public string? Key { get; set; }
    }
}
