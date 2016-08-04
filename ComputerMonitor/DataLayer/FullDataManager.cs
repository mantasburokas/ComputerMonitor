using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class FullDataManager : DataManager
    {
        public override ComputerSummary GetComputerSummary()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetApplicationList()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetHardwareList()
        {
            throw new NotImplementedException();
        }
    }
}
