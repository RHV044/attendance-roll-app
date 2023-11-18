using AttendanceRollApp.WebUI.Models;
using AttendanceRollApp.WebUI.Services.Interfaces;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.NFC;

namespace AttendanceRollApp.Services
{
    public class NfcService : INfcService
    {
        public NfcService()
        {
        //    // Event raised when a ndef message is received.

        //    // Event raised when a ndef message has been published.
        //    CrossNFC.Current.OnMessagePublished += Current_OnMessagePublished;
        //    // Event raised when a tag is discovered. Used for publishing.
        //    CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
        //    // Event raised when NFC listener status changed
        //    CrossNFC.Current.OnTagListeningStatusChanged += Current_OnTagListeningStatusChanged;

        //    // Android Only:
        //    // Event raised when NFC state has changed.
        //    CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;

        //    // iOS Only: 
        //    // Event raised when a user cancelled NFC session.
        //    CrossNFC.Current.OniOSReadingSessionCancelled += Current_OniOSReadingSessionCancelled;
        }
        public bool IsSupported => CrossNFC.IsSupported && CrossNFC.Current.IsAvailable;
        public bool IsEnabled => CrossNFC.Current.IsEnabled;

        public async Task<NfcData?> Read()
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
            NfcData data = new();

            CrossNFC.Current.OnMessageReceived += (ITagInfo tagInfo) =>
            {
                data.Text = string.Join(System.Environment.NewLine, tagInfo.Records.Select(x => x.Message));
                CrossNFC.Current.StopListening();

                semaphoreSlim.Release();
            };


            CrossNFC.Current.StartListening();

            await semaphoreSlim.WaitAsync();

            return data;
        }
    }
}
