using System.Collections.Generic;

namespace Database
{
    public class ComputerDetail
    {

        public int ComputerDetailId { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Cpu { get; set; }
        public int Ram { get; set; }
        public string VideoCard { get; set; }
        public string Ip { get; set; }
        public ICollection<UsageData> UsageDataCollection { get; set; }
    }
}
