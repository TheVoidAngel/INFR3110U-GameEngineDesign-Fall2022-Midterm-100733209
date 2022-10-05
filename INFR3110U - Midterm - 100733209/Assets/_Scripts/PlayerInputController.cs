using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    public PlayerCharAction inputAction;


    public static PlayerInputController controller;

    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }

        inputAction = new PlayerCharAction();
    }
}
