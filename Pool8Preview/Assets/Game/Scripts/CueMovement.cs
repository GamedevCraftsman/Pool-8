using UnityEngine;

public class CueMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 lastMousePosition;
    Vector3 currentMousePosition;

    float xRotation = 0;
    float zRotation = 0;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        CalculationMousePosition();
        CueRotate();
    }

    void CueRotate()
    {
        transform.rotation = Quaternion.Euler(xRotation, (lastMousePosition.x + lastMousePosition.y) * speed, zRotation);
    }

    void CalculationMousePosition()
    {
        currentMousePosition = Input.mousePosition;
        lastMousePosition = currentMousePosition;
    }
}