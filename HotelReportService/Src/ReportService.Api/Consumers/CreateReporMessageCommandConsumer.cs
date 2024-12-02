using MassTransit;
using ReportService.Api.Message;

namespace ReportService.Api.Consumers
{
    public class CreateReporMessageCommandConsumer : IConsumer<CreateReporMessageCommand>
    {
        //private readonly 
        public async Task Consume(ConsumeContext<CreateReporMessageCommand> context)
        {
            var message = context.Message;

            var deneme = message;
            await Task.Delay(100);

            // Başarılı bir şekilde tamamlandığını belirtmek için

            // Örneğin bir veritabanı işlemi veya API çağrısı
            //return Task.CompletedTask;
        }
    }
}
