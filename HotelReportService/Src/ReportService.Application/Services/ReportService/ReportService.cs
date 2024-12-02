using ReportService.Domain.Documents;
using ReportService.Persistence.Repositories;

namespace ReportService.Application.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportDocuments> hotelRepository;

        public ReportService(IRepository<ReportDocuments> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task GetReportTest()
        {
            try
            {
                ReportDocuments reportDocument = new ReportDocuments()
                {
                    LocationContactName = "test LocationContactName",
                    LocationContactPhone = "05412045792",
                    LocationContactEmail = "dev.mustafa.yener@gmail.com"
                };

                var result = await hotelRepository.CreateAsync(reportDocument);
                var sss = result;
            }
            catch (Exception ex)
            {
                var ssTest = ex;
                 
            }

           
            throw new NotImplementedException();
        }

        public async Task GetReportTest2()
        {
            var result = await hotelRepository.GetAllAsync();
            var testDeneme = result;
        }
    }
}
