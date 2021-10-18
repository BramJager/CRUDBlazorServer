using System.Collections.Generic;

namespace CRUDBlazorServer.Data
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Dndbook> Dndbooks { get; set; }
    }
}
