using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories;
using FunSuper.Server.Models;
using System.Data;
using System.Globalization;
using static FunSuper.Server.Constants.SpreadSheetConst;

namespace FunSuper.Server.Services
{
    public class ContextSeedService : IContextSeedService
    {
        private readonly IDisbursementRepository _disbursementRepository;
        private readonly IPayCodeRepository _payCodeRepository;
        private readonly IPayslipRepository _payslipRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ContextSeedService(IDisbursementRepository disbursementRepository, IPayCodeRepository payCodeRepository,
                                  IPayslipRepository payslipRepository, IEmployeeRepository employeeRepository)
        {
            _disbursementRepository = disbursementRepository;
            _payCodeRepository = payCodeRepository;
            _payslipRepository = payslipRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<SeedSuperContextResult> SeedSuperContext(DataSet dataSet)
        {
            var result = new SeedSuperContextResult();

            if (dataSet.Tables.Contains(SuperSheet.Disbursements.TableName))
            {
                await SeedDisbursements(dataSet.Tables[SuperSheet.Disbursements.TableName]);
            }

            if (dataSet.Tables.Contains(SuperSheet.PayCodes.TableName))
            {
                await SeedPayCodes(dataSet.Tables[SuperSheet.PayCodes.TableName]);
            }

            if (dataSet.Tables.Contains(SuperSheet.Payslips.TableName))
            {
                await SeedPayslips(dataSet.Tables[SuperSheet.Payslips.TableName]);
            }

            result.EmployeeIds = await _employeeRepository.GetIds();

            return result;
        }

        private async Task SeedDisbursements(DataTable dataTable)
        {
            // Employee records get from Disbursements as no seperete table in provided spreadsheet
            var employeeDict = new Dictionary<int, Employee>();

            var disbursements = dataTable.AsEnumerable().Select((s, i) => {
                var employeeId = Convert.ToInt32(s[SuperSheet.Disbursements.EmployeeCodeHeader]);

                if (employeeId != 0 && !employeeDict.ContainsKey(employeeId))
                {
                    employeeDict.Add(employeeId, new Employee { EmployeeID = employeeId });
                }

                return new Disbursement
                {
                    DisbursementId = ++i,
                    SgcAmount = Convert.ToDouble(s[SuperSheet.Disbursements.SgcHeader]),
                    PayFromDate = DateTime.Parse(s[SuperSheet.Disbursements.PayPeriodFromHeader].ToString(), styles: DateTimeStyles.AssumeUniversal),
                    PayToDate = DateTime.Parse(s[SuperSheet.Disbursements.PayPerodToHeader].ToString(), styles: DateTimeStyles.AssumeUniversal),
                    PayMadeDate = DateTime.Parse(s[SuperSheet.Disbursements.PaymentMadeHeader].ToString(), styles: DateTimeStyles.AssumeUniversal),
                    EmployeeID = employeeId
                };
            }).ToList();

            await _employeeRepository.BulkUpsert(employeeDict.Values.ToList());

            await _disbursementRepository.BulkUpsert(disbursements);
        }

        private async Task SeedPayCodes(DataTable dataTable)
        {
            var paycodes = dataTable.AsEnumerable().Select((s, i) =>  new PayCode
            {
                    PayCodeId = s[SuperSheet.PayCodes.PayCodeHeader].ToString(),
                    IsOteTreament = s[SuperSheet.PayCodes.OteTreamentHeader].ToString() == SuperSheet.PayCodes.OteTreamentValue
            }).ToList();

            await _payCodeRepository.BulkUpsert(paycodes);
        }

        private async Task SeedPayslips(DataTable dataTable)
        {
            var payslips = dataTable.AsEnumerable().Select((s, i) => new Payslip
            {
                PayslipId = ++i,
                Amount = Convert.ToDouble(s[SuperSheet.Payslips.AmountHeader]),
                EndDate = DateTime.Parse(s[SuperSheet.Payslips.EndHeader].ToString(), styles: DateTimeStyles.AssumeUniversal),
                PayslipCode = s[SuperSheet.Payslips.PayslipIdHeader].ToString(),
                PayCodeId = s[SuperSheet.Payslips.CodeHeader].ToString(),
                EmployeeId = Convert.ToInt32(s[SuperSheet.Payslips.EmployeeCodeHeader])
            }).ToList();

            await _payslipRepository.BulkUpsert(payslips);
        }
    }
}
