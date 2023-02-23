using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication1.Model
{
    public class EmailDto
    {
        public string To  { get; set; }= string.Empty;
        public string Subject { get; set; }=string.Empty;   
        public string Body { get; set; } = string.Empty;
        
    }
}
