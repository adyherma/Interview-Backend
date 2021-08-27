using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Models
{
    public class QuestionThreeModel : BaseModel
    {
        public string Category { get; set; }
    }

    public class QuestionThreeVM : BaseModel
    {
        public string Category { get; set; }
        public List<BaseModel> Items { get; set; }
    }
}
