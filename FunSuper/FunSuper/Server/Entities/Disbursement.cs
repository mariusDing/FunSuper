using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Entities
{
    public class Disbursement : Entity
    {
        public int DisbursementId { get; set; }
        public double SgcAmount { get; set; }
        public DateTime PayMadeDate { get; set; }
        public DateTime PayFromDate { get; set; }
        public DateTime PayToDate { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
