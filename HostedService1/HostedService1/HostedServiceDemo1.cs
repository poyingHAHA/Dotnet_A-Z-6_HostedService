namespace HostedService1
{
    public class HostedServiceDemo1 : BackgroundService
    {
        /* 不能直接使用短生命週期的服務
        private readonly TestService testservice;
        public HostedServiceDemo1(TestService testservice)
        {
            this.testservice = testservice;
        }*/

        private IServiceScope _serviceScope;

        public HostedServiceDemo1(IServiceScopeFactory scopeFactory)
        {
            // 創建一個scope來使用其他service
            _serviceScope = scopeFactory.CreateScope();
        }

        public override void Dispose()
        {
            // 當託管程式結束，scope也沒了
            _serviceScope.Dispose();
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var testService = _serviceScope.ServiceProvider.GetRequiredService<TestService>();

                Console.WriteLine("HostedService1啟動" + testService.Add(1,1));
                await Task.Delay(3000); // 不要用Thread.Sleep
                string txt = await File.ReadAllTextAsync("D:/1.txt");
                Console.WriteLine("文件讀取完成");
                await Task.Delay(3000);
                Console.WriteLine(txt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("出現未處裡異常"+ex.ToString());
            }
        }
    }
}
