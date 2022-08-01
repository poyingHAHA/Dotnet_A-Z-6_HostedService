using Microsoft.EntityFrameworkCore;

namespace HostedService1
{
    public class ScheduledService : BackgroundService
    {
        private readonly IServiceScope _scope;

        public ScheduledService(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public override void Dispose()
        {
            _scope.Dispose();
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var dbctx = _scope.ServiceProvider.GetRequiredService<MyDbContext>();
                while(!stoppingToken.IsCancellationRequested)
                {
                    long c = await dbctx.Users.LongCountAsync();
                    await File.WriteAllTextAsync("D:/userCount.txt", c.ToString());
                    await Task.Delay(5000);
                    Console.WriteLine("成功導出數據"+DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("後臺程式發生錯誤"+ex.ToString());
            }

        }
    }
}
