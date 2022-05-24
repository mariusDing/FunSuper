namespace FunSuper.Server.Constants
{
    public class SpreadSheetConst
    {
        public class SuperSheet
        {
            public class Disbursements
            {
                public const string TableName = "Disbursements";

                public const string SgcHeader = "sgc_amount";
                public const string PaymentMadeHeader = "payment_made";
                public const string PayPeriodFromHeader = "pay_period_from";
                public const string PayPerodToHeader = "pay_period_to";
                public const string EmployeeCodeHeader = "employee_code";
            }

            public class Payslips
            {
                public const string TableName = "Payslips";

                public const string PayslipIdHeader = "payslip_id";
                public const string EndHeader = "end";
                public const string EmployeeCodeHeader = "employee_code";
                public const string CodeHeader = "code";
                public const string AmountHeader = "amount";
            }

            public class PayCodes
            {
                public const string TableName = "PayCodes";

                public const string PayCodeHeader = "pay_code";
                public const string OteTreamentHeader = "ote_treament";
                public const string OteTreamentValue = "OTE";
            }
        }
    }
}
