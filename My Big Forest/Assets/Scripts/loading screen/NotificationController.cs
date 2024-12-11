using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class NotificationController : MonoBehaviour
{
    [SerializeField] AndroidNotifications androidNotifications;
    [SerializeField] iOSNotifications iosNotifications;

    public void InitPushNotifications()
    {
#if UNITY_ANDROID
        androidNotifications.RequestAuthorization();
        androidNotifications.RegisterNotificationChannel();
#endif
#if UNITY_IOS
        StartCoroutine(iosNotifications.RequestAuthorization());
#endif
    }


    public void SendNotificationMinutesBoth(string title, string text, int fireTimeInMinutes)
    {
#if UNITY_ANDROID
            AndroidNotificationCenter.CancelAllNotifications();
            androidNotifications.SendNotificationMinutes(title, text, fireTimeInMinutes);
#endif
#if UNITY_IOS
            iOSNotificationCenter.RemoveAllScheduledNotifications();
            iosNotifications.SendNotificationMinutes(title, Application.productName, text, fireTimeInMinutes);
#endif
    }


}
