using UnityEngine;

public class areaFlor : MonoBehaviour
{
    public Flor flor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        flor.accioFlor();
        Debug.Log("Estas a l'area");
    }
}
