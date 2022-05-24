using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Entities
{
    public class Payslip : Entity
    {
        public int PayslipId { get; set;}
        public string PayslipCode { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string PayCodeId { get; set; }
        public PayCode PayCode { get; set; }
    }
}
