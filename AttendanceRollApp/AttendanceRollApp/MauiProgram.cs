using AttendanceRollApp.LocalDBContext;
using AttendanceRollApp.Services;
using AttendanceRollApp.SharedUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;

namespace AttendanceRollApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFluentUIComponents();


            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IAttendanceTempRepository, AttendanceTempRepository>();

            builder.Services.AddSingleton<INfcService, NfcService>();
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddDbContext<AttrollDBContext>(
            options => options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "attroll.db")}", x => x.MigrationsAssembly(nameof(AttendanceRollApp.LocalDBContext))));
            
            return builder.Build();
        }
    }
}
