using UnityEngine;

public class areaFlor : MonoBehaviour
{
    public Flor flor;

    private void OnTriggerStay(Collider other)
    {
        flor.accioFlor();
        Debug.Log("Estas a l'area");
    }
    private void OnTriggerExit(Collider other)
    {
        flor.fiaccio();
    }
}
