using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
