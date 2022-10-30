using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float zoomScale;
    [SerializeField] float minZoomDistance = 0f;
    [SerializeField] float maxZoomDistance;

    [SerializeField] float rotationVelocity;

    InputControlls inputControlls;

    private bool rotating;
    private Vector2 previousMousePosition;

    // Start is called before the first frame update
    void Awake()
    {
        inputControlls = new InputControlls();

        transform.LookAt(Vector3.zero);
    }

    private void OnEnable()
    {
        inputControlls.Enable();

        inputControlls.Movement.Zoom.performed += Zoom_performed;

        inputControlls.Movement.Rotate.performed += (_) => { rotating = true; };
        inputControlls.Movement.Rotate.canceled += (_) => rotating = false;
    }

    private void OnDisable()
    {
        inputControlls.Disable();
    }

    private void Update()
    {
        if (rotating)
        {
            float deltaX = inputControlls.Movement.DeltaX.ReadValue<float>();
            float deltaY = inputControlls.Movement.DeltaY.ReadValue<float>();

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                transform.RotateAround(
                    Vector3.zero,
                    transform.up,
                    deltaX * rotationVelocity * Time.deltaTime
                );
            }
            else
            {
                transform.RotateAround(
                    Vector3.zero,
                    transform.right,
                    -deltaY * rotationVelocity * Time.deltaTime
                );
            }
        }
    }

    private void Zoom_performed(InputAction.CallbackContext context)
    {
        Zoom(context.ReadValue<Vector2>().y);
    }

    private void Zoom(float directionValue)
    {
        float direction = Mathf.Sign(directionValue);
        Vector3 currentDirection = transform.forward;

        Vector3 targetPosition = transform.position + BoundsCheck(direction * zoomScale * currentDirection);
        transform.LeanMove(targetPosition, 0.1f).setOnComplete(() => transform.LookAt(Vector3.zero));
    }

    /// <summary>
    /// Check if camera is in between bounds after move distance is aplied 
    /// and return correct movement change if not.
    /// </summary>
    /// <param name="moveDistance">Distance camera is supposed to move</param>
    /// <returns>Corrected movement change</returns>
    private Vector3 BoundsCheck(Vector3 moveDistance)
    {
        Vector3 targetPoint = transform.position + moveDistance;

        // Cameras default z value is negative
        if (targetPoint.magnitude < minZoomDistance | targetPoint.magnitude > maxZoomDistance)
        {
            return Vector3.zero;
        }
        else
        {
            return moveDistance;
        }
    }
}
