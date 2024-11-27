using System;
using UnityEngine;

public class camera_controler : MonoBehaviour
{
    public Transform Target;
    public Transform CameraTarget;
    public float triget;

    public Vector2 targetLook;

    private void LateUpdate()
    {
        CameraTarget.transform.position = Target.position;
        CameraTarget.transform.rotation = Quaternion.Euler(targetLook.x, targetLook.y, 0);
    }

    public void IncrementLookRotation(Vector2 look_delta)
    {
        targetLook += look_delta;
    }

}
