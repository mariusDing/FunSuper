using FunSuper.Server.Constants;

namespace FunSuper.Server.Models
{
    public class TotalQuarterlySuperResult
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public decimal TotalOte { get; set; }
        public decimal TotalSuperPayable  => decimal.Round(TotalOte * SuperConst.FixedSuperRate,2);
        public decimal TotalDisbursement { get; set; }
    }
}
