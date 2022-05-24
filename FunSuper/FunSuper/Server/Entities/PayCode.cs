using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Entities
{
    public class PayCode : Entity
    {
        public string PayCodeId { get; set; }
        public bool IsOteTreament { get; set; }

        public List<Payslip> Payslips { get; set; }
    }
}
