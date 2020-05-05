using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.ViewModels
{
    public class BoardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }
    }

    public class BoardJson
    {
        [JsonProperty("data")]
        public IList<BoardVM> data { get; set; }
    }
}
