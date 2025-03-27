using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUiTest.Presentation.Extensions
{
    public static class NotificationWindow
    {
        public static async Task<uint> SendSimpleNotificationAsync(string title,string message, AppNotificationDuration duration=AppNotificationDuration.Default)
        {
            return await Task.Run(() =>
            {
                var toast = new AppNotificationBuilder().
                    AddText(title).
                    AddText(message).
                    SetDuration(duration).
                    BuildNotification();
                AppNotificationManager.Default.Show(toast);
                return toast.Id;
            });
        }
    }
}
