using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputData inputData;

    private void Update()
    {
        WriteInputData();
    }

    public void WriteInputData()
    {
        inputData.isPressed = Input.GetMouseButtonDown(0);
        inputData.isHeld = Input.GetMouseButton(0);
        inputData.isReleased = Input.GetMouseButtonUp(0);
    }
}
