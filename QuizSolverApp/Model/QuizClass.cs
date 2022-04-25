using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace QuizMVVM.Model
{
    internal class QuizClass
    {
        [System.Runtime.Serialization.DataMember(Name = "title")]
        public string? Title { get; set; }
        [System.Runtime.Serialization.DataMember(Name = "questions")]
        public List<Questions>? Questions { get; set; }

    }
}
