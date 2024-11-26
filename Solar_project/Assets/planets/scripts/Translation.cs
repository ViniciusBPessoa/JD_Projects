using UnityEngine;

public class Translation : MonoBehaviour
{
    public float velocidade = 10f; 
    private Vector3 initialLocalPosition; 
    private float raio;
    
    void Start()
    {        
        initialLocalPosition = transform.localPosition;

        raio = - new Vector2(initialLocalPosition.x, initialLocalPosition.z).magnitude;
    }

    void Update()
    {
        transformation();
    }

    void transformation()
    {
        if (transform.parent != null)
        {
            float angle = Time.time * velocidade;

            float x = Mathf.Cos(angle) * raio;
            float z = Mathf.Sin(angle) * raio;

            transform.localPosition = new Vector3(x, initialLocalPosition.y, z);
        }

    }
}
