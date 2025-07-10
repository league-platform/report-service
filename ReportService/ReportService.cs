using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReportService.Models;

namespace ReportService.Services 
{
    public class ReportMongoService
    {
        private readonly IMongoCollection<Report> _reportCollection;

        public ReportMongoService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _reportCollection = database.GetCollection<Report>("reports");
        }

        public async Task CreateReport(Report report) =>
            await _reportCollection.InsertOneAsync(report);

        public async Task<List<Report>> GetReports() =>
            await _reportCollection.Find(_ => true).ToListAsync();
    }
}
