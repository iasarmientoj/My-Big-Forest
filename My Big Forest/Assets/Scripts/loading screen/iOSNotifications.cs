using UnityEngine;
using System.Collections;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSNotifications : MonoBehaviour
{
#if UNITY_IOS
    // Request access to send notifications
    public IEnumerator RequestAuthorization()
    {
        using var request = new AuthorizationRequest(
            AuthorizationOption.Alert | AuthorizationOption.Badge,
            true
        );

        while (!request.IsFinished)
        {
            yield return null;
        }
    }

    // Set up notification template
    public void SendNotificationMinutes(string title, string body, string subtitle, int fireTimeInMinutes)
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger
        {
            TimeInterval = new System.TimeSpan(fireTimeInMinutes, 0, 0),
            Repeats = false
        };

        var notification = new iOSNotification
        {
            Identifier = "lives_full",
            Title = title,
            Body = body,
            Subtitle = subtitle,
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Badge),
            CategoryIdentifier = "default_category",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#endif

}
