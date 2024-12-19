using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController characterController;
    public float speed;
    public float rotationSpeed;

    public Canvas inputCanvas;
    public bool isJoystick;

    public Animator playerAnimator;


    public new Transform camera;
    public float gravity = -9.8f;


    private void Start()
    {
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isJoystick)
        {
            float hor = joystick.Direction.x;
            float ver = joystick.Direction.y;
            Vector3 movement = Vector3.zero;


            float movementSpeed = 0;

            if (hor != 0 || ver != 0)
            {
                Vector3 forward = camera.forward;
                forward.y = 0;
                forward.Normalize();

                Vector3 right = camera.right;
                right.y = 0;
                right.Normalize();


                Vector3 direction = forward * ver + right * hor;
                movementSpeed = Mathf.Clamp01(direction.magnitude);
                direction.Normalize();

                movement = direction * speed * movementSpeed * Time.deltaTime;

                //para que el personaje gire en el sentido del movimiento
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
                var targetDirection = Vector3.RotateTowards(characterController.transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
                characterController.transform.rotation = Quaternion.LookRotation(targetDirection);


                playerAnimator.SetBool("run", true);

            }
            else
            {
                playerAnimator.SetBool("run", false);
            }


            movement.y += gravity * Time.deltaTime;

            characterController.Move(movement);



        }
    }
}
