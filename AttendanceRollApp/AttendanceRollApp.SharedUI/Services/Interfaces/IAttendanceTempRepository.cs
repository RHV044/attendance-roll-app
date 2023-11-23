
using AttendanceRollApp.SharedUI.Models;
using System.Xml.Linq;

namespace AttendanceRollApp.SharedUI.Services.Interfaces
{
    public interface IAttendanceTempRepository
    {
        Task<IEnumerable<Attendance>?> GetAll();
        Task Add(Attendance attendance);
        Task DeleteRange(IEnumerable<Attendance> attendances);

        public async Task<bool> SyncToServer(Attendance attendance)
        {
            if (attendance == null) return false;

            var GFormsService = new GoogleFormsSubmissionService(AttendanceGForm.FormUrl);


            var fields = new Dictionary<string, string>
                    {
                       { AttendanceGForm.Fields.Year, attendance.DateTime.Year.ToString() },
                       { AttendanceGForm.Fields.Month, attendance.DateTime.Month.ToString() },
                       { AttendanceGForm.Fields.Day, attendance.DateTime.Day.ToString() },
                       { AttendanceGForm.Fields.Hour, attendance.DateTime.Hour.ToString() },
                       { AttendanceGForm.Fields.Minute, attendance.DateTime.Minute.ToString() },
                       { AttendanceGForm.Fields.AuthMethod, $"{attendance.AuthMethod.Type}({attendance.AuthMethod.Value})" },
                       { AttendanceGForm.Fields.Location, $"{attendance.Latitude};{attendance.Longitude}" },
                       { AttendanceGForm.Fields.Gender, attendance.Person.Gender.ToString() },
                       { AttendanceGForm.Fields.NationalID, attendance.Person.NationalID },
                       { AttendanceGForm.Fields.FullName, $"{attendance.Person.FirstName} {attendance.Person.LastName}" },
                       { AttendanceGForm.Fields.Birthdate, attendance.Person.BirthDate.ToString("yyyy-MM-dd") },
                    };

            GFormsService.SetFieldValues(fields);

            var response = await GFormsService.SubmitAsync();

            return response.IsSuccessStatusCode;
        }

    }
}
