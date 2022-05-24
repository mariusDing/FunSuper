namespace FunSuper.Shared.ViewModels
{
    public class GetYearQuarterTotalSuperResult
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public decimal TotalOte { get; set; }
        public decimal TotalSuperPayable { get; set; }
        public decimal TotalDisbursement { get; set; }
    }
}
