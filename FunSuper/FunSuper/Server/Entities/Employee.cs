using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Entities
{
    public class Employee : Entity 
    {
        public int EmployeeID { get; set; }

        public List<Disbursement> Disbursements { get; set; }
        public List<Payslip> Payslips { get; set; }
    }
}
