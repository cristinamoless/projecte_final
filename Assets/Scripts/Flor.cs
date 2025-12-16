using UnityEngine;
using TMPro;
public class Flor : MonoBehaviour
{

    public float contadorAccio = 1f;
    public TMP_Text Millor_text = null;
    public TMP_Text Pitjor_text = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void accioFlor()
    {
        if (Input.GetKeyDown(KeyCode.P) && contadorAccio != 2f)
        {
            Manolita.Instance.BetterWorld();
            transform.rotation *= Quaternion.Euler(20, 0, 0);
            contadorAccio = 2f;
        }
        if (Input.GetKeyDown(KeyCode.O) && contadorAccio != 0f)
        {
            Manolita.Instance.WorseWorld();
            transform.rotation *= Quaternion.Euler(-20, 0, 0);
            contadorAccio = 0f;
        }
    }
}
