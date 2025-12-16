using UnityEngine;

public class cabana : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Manolita.Instance.BetterWorld();
            transform.localScale *= 1.20f;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Manolita.Instance.WorseWorld();
            transform.localScale *= 0.80f;
        }
    }
}
