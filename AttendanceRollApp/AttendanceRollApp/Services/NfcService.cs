using AttendanceRollApp.SharedUI.Models;
using AttendanceRollApp.SharedUI.Services.Interfaces;
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
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0);
            NfcData? info = null;
            NdefMessageReceivedEventHandler onMessageReceived = (ITagInfo tagInfo) =>
            {
                info = new()
                {
                    SerialNumber = tagInfo.SerialNumber,
                    Identifier = BitConverter.ToString(tagInfo.Identifier)
                };

                if (tagInfo.Records != null && tagInfo.Records.Length > 0)
                    info.Text = string.Join(Environment.NewLine, tagInfo.Records.Select(x => x.Message));

                semaphoreSlim.Release();
            };
            CrossNFC.Current.OnMessageReceived += onMessageReceived;

            CrossNFC.Current.StartListening();

            await semaphoreSlim.WaitAsync();

            CrossNFC.Current.StopListening();
            CrossNFC.Current.OnMessageReceived -= onMessageReceived;
            semaphoreSlim.Dispose();

            return info;
        }
    }
}
