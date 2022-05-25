using FunSuper.Shared.ViewModels;

namespace FunSuper.Server.Models.Mapper
{
    public static class ResultMapper
    {
        public static IEnumerable<YearlySuperSummary> ConvertSuperResultToSuperSummary(List<YearQuarterTotalSuperResult> results)
        {
            var summarys = new List<YearlySuperSummary>();

            results.ForEach(r =>
            {
                var yearSummaryIndex = summarys.FindIndex(s => s.Year == r.Year);

                if (yearSummaryIndex != -1)
                {
                    summarys[yearSummaryIndex].QuarterlySuperSummarys.Add(new QuarterlySuperSummary
                    {
                        Quarter = r.Quarter,
                        TotalOte = r.TotalOte,
                        TotalDisbursement = r.TotalDisbursement,
                        TotalSuperPayable = r.TotalSuperPayable
                    });
                }
                else
                {
                    summarys.Add(new YearlySuperSummary
                    {
                        Year = r.Year,
                        QuarterlySuperSummarys = new List<QuarterlySuperSummary>()
                    {
                        new QuarterlySuperSummary
                        {
                            Quarter = r.Quarter,
                            TotalOte = r.TotalOte,
                            TotalDisbursement = r.TotalDisbursement,
                            TotalSuperPayable = r.TotalSuperPayable
                        }
                    }
                    });
                }
            });

            // Refill missing quarter
            summarys.ForEach(s =>
            {
                for (var i = 1; i < 5; i++)
                {
                    if (!s.QuarterlySuperSummarys.Any(q => q.Quarter == i))
                    {
                        s.QuarterlySuperSummarys.Add(new QuarterlySuperSummary
                        {
                            Quarter = i
                        });
                    }
                }
                s.QuarterlySuperSummarys = s.QuarterlySuperSummarys.OrderBy(q => q.Quarter).ToList();
            });

            return summarys.OrderBy(s => s.Year);
        }
    }
}
