using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAccess : MonoBehaviour
{
    private InputControls input;

    public delegate void ButtonEvent(Buttons button);
    public event ButtonEvent ButtonDown;
    public event ButtonEvent ButtonUp;

    public Vector2 Movement => input.Gameplay.Movement.ReadValue<Vector2>();

    void Start()
    {
        input = new InputControls();
        input.Enable();

        input.Gameplay.HitStraight.started += ctrl => ButtonDown?.Invoke(Buttons.HitStraight);
        input.Gameplay.HitStraight.canceled += ctrl => ButtonUp?.Invoke(Buttons.HitStraight);

        input.Gameplay.HitLob.started += ctrl => ButtonDown?.Invoke(Buttons.HitLob);
        input.Gameplay.HitLob.canceled += ctrl => ButtonUp?.Invoke(Buttons.HitLob);
    }
}
