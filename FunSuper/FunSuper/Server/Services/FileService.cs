using ExcelDataReader;
using System.Data;

namespace FunSuper.Server.Services
{
    public class FileService : IFileService
    {
        // Async wrapper for ExcelDataReader
        public Task<DataSet> ReadSpreadSheetAsync(Stream stream)
        {
            return Task.Run(() => ReadSpreadSheetInternal(stream));
        }

        private DataSet ReadSpreadSheetInternal(Stream stream)
        {
            // Initial excel reader
            using var reader = ExcelReaderFactory.CreateReader(stream);

            // Dataset config
            var dataSetConfig = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            // Convert to DataSet
            var dataSet = reader.AsDataSet(dataSetConfig);

            return dataSet;
        }
    }
}
