using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class AndroidNotifications : MonoBehaviour
{
#if UNITY_ANDROID
    // Request authorization to send notifications
    public void RequestAuthorization()
    {
        // Check if the user has not authorized the permission
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            // Request the notification permission
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }


    // Register a notification channel
    public void RegisterNotificationChannel()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Set up notification template

    public void SendNotificationMinutes(string title, string text, int fireTimeInMinutes)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now.AddMinutes(fireTimeInMinutes),
            SmallIcon = "icon_0",
            LargeIcon = "icon_1"
        };

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
#endif


}
