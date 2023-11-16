using AttendanceRollApp.WebUI.Models;
using AttendanceRollApp.WebUI.Services.Interfaces;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRollApp.Services
{
    public class FingerprintService : IFingerprintService
    {
        public async Task<FingerprintData?> Scan()
        {

            var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            return result.Status == FingerprintAuthenticationResultStatus.Succeeded ?
                new FingerprintData { Hash = result?.ToString() } :
                null;
        }
    }
}
