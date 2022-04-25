using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace QuizMVVM.Model
{
    internal class Answer
    {
        [System.Runtime.Serialization.DataMember(Name = "content")]
        public string? Content { get; set; }
        [System.Runtime.Serialization.DataMember(Name="isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
