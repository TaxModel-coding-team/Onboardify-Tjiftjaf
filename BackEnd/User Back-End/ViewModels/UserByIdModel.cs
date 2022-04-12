using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json.Serialization;

namespace User_Back_End.ViewModels
{
    public class UserByIdModel
    {
        [JsonPropertyName("userId")]
        public Guid ID { get; set; }
    }
}
