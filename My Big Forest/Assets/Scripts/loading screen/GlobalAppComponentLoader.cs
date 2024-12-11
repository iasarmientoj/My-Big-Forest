using System.Collections;
using UnityEngine;

public class GlobalAppComponentLoader : MonoBehaviour
{

    [SerializeField] private NotificationController notificationController;
    [SerializeField] private LoadScene loadScene;

    [SerializeField] private Animator animatorLoadBar;



    void Start()
    {
        //ejecutar 50% de animacion de barra de carga
        animatorLoadBar.SetTrigger("barStep0");

        //solicitar permiso de notificaciones
        StartCoroutine(RequestNotificationAfterAnimation());


    }

    private IEnumerator RequestNotificationAfterAnimation()
    {
        // El nombre de la última animación (reemplázalo con el nombre de tu animación final)
        string lastAnimationName = "loading bar"; // Este es el nombre del último estado de la animación

        // Espera a que la última animación haya terminado
        while (animatorLoadBar.GetCurrentAnimatorStateInfo(0).IsName(lastAnimationName) == false || animatorLoadBar.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null; // Espera el siguiente frame
        }

        // La  animación ha terminado, ahora puedes proceder
        notificationController.InitPushNotifications();
        //notificacion de bienvenida para la primer vez que inicia la app
        notificationController.SendNotificationMinutesBoth("Welcome to My Big Forest! 🌲", "Your forest adventure begins now! Get ready to grow, explore, and have fun!", 1);


        //ejecutar 75% de animacion de barra de carga
        animatorLoadBar.SetTrigger("barStep1");

        //cargar escena de juego
        //ejecutar del 75% al 100% de la barra de carga mediante codigo
        StartCoroutine(LoadGameAfterAnimation());
    }

    private IEnumerator LoadGameAfterAnimation()
    {
        // El nombre de la última animación (reemplázalo con el nombre de tu animación final)
        string lastAnimationName = "loading bar 1"; // Este es el nombre del último estado de la animación

        // Espera a que la última animación haya terminado
        while (animatorLoadBar.GetCurrentAnimatorStateInfo(0).IsName(lastAnimationName) == false || animatorLoadBar.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null; // Espera el siguiente frame
        }

        // La última animación ha terminado, ahora puedes proceder con la carga de la escena
        loadScene.SceneLoad(0.75f, 1f);
    }


}
