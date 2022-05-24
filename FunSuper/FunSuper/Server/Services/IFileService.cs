using System.Data;

namespace FunSuper.Server.Services
{
    public interface IFileService
    {
        Task<DataSet> ReadSpreadSheetAsync(Stream stream);
    }
}
