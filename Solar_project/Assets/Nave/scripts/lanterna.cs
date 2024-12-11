using UnityEngine;

public class lanterna : MonoBehaviour
{
    public GameObject lampada;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            lampada.SetActive(true);
        }
        else
        {
            lampada.SetActive(false);
        }
    }
}
