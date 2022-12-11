namespace BulkyBookweb.Migrations
{
    public abstract class StartupBase
    {

        public IConfiguration Configuration { get; }

        public abstract object ConfigureServices(IServiceCollection services);
    }
}