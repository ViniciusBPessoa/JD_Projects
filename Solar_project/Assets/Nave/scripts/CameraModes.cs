using System;
using Unity.Cinemachine;
using UnityEngine;
public class CameraModes : MonoBehaviour
{
    public CinemachineOrbitalFollow freeLookCamera; // Refer�ncia � c�mera Cinemachine
    public CinemachineCamera Camera;
    public float closeFOV = 60f; // Campo de vis�o para o modo pr�ximo
    public float distantFOV = 40f; // Campo de vis�o para o modo distante
    public Vector3 closeOrbits = new Vector3(2f, 4f, 2.5f); // Configura��es para o modo pr�ximo (Top, Middle, Bottom)
    public Vector3 distantOrbits = new Vector3(4f, 8f, 5f); // Configura��es para o modo distante (Top, Middle, Bottom)

    public bool is_09 = true;

    private bool isDistant = false; // Estado atual do modo da c�mera

    private void Start()
    {
        freeLookCamera = GetComponent<CinemachineOrbitalFollow>();
        Camera = GetComponent<CinemachineCamera>();
    }

    void Update()
    {
        if (is_09)
        {
            // Alternar entre os modos de c�mera ao pressionar 1 ou 2
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetCloseCameraMode();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetDistantCameraMode();
            }
        }else
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                SetCloseCameraMode();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                SetDistantCameraMode();
            }
        }

    }

    private void SetDistantCameraMode()
    {
        Camera.Lens.FieldOfView = distantFOV;
    }

    private void SetCloseCameraMode()
    {
        Camera.Lens.FieldOfView = closeFOV;
    }
}
