using AttendanceRollApp.LocalDBContext;
using AttendanceRollApp.SharedUI.Models;
using AttendanceRollApp.SharedUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

namespace AttendanceRollApp.Services
{
    public class AttendanceTempRepository : IAttendanceTempRepository
    {
        IConnectivity connectivity;
        AttrollDBContext dbContext;
        IToastService toastService;
        public AttendanceTempRepository(AttrollDBContext dbContext, IConnectivity connectivity, IToastService toastService)
        {
            this.connectivity = connectivity;
            this.dbContext = dbContext;
            this.toastService = toastService;

            this.connectivity.ConnectivityChanged += async (object? sender, ConnectivityChangedEventArgs args) =>
            {

                if (args.NetworkAccess == NetworkAccess.Internet)
                {
                    var notSyncedAttendances = await this.GetAll();
                    var syncedAttendances = new List<Attendance>();

                    if (notSyncedAttendances != null)
                        foreach (var attendance in notSyncedAttendances)
                        {
                            var synced = await ((IAttendanceTempRepository)this).SyncToServer(attendance);

                            if (synced)
                                syncedAttendances.Add(attendance);
                        }

                    if (syncedAttendances.Count > 0)
                    {
                        toastService.ShowToast(ToastIntent.Info, $"{syncedAttendances.Count} {(syncedAttendances.Count > 1 ? "asistencias sincronizadas" : "asistencia sincronizada")}");
                        await this.DeleteRange(syncedAttendances);
                    }

                }

            };
        }
        public async Task Add(Attendance attendance)
        {
            var synced = await ((IAttendanceTempRepository)this).SyncToServer(attendance);
            if (!synced)
            {
                dbContext.Attendances.Add(attendance);
                await dbContext.SaveChangesAsync();
                this.toastService.ShowToast(ToastIntent.Warning, $"Se sincronizará cuando haya conexión");
            }
        }

        public async Task DeleteRange(IEnumerable<Attendance> attendances)
        {
            dbContext.Attendances.RemoveRange(attendances);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>?> GetAll()
        {
            return await dbContext.Attendances.ToListAsync();
        }


    }
}
