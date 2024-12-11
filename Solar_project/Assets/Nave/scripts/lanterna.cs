using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public GameObject lampada; 
    private Light luz; 
    public float intensidadeMin = 0f; 
    public float intensidadeMax = 100000f; 
    public float velocidadeScroll = 100f; 

    void Start()
    {
        if (lampada != null)
        {
            luz = lampada.GetComponent<Light>();
        }
    }

    void Update()
    {
        if (lampada != null && luz != null)
        {
            if (Input.GetMouseButton(1))
            {
                lampada.SetActive(true);
            }
            else
            {
                lampada.SetActive(false);
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                luz.intensity = Mathf.Clamp(
                    luz.intensity + scroll * velocidadeScroll,
                    intensidadeMin,
                    intensidadeMax
                );
            }
        }
    }
}
