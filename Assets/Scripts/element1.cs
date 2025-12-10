using UnityEngine;

public class element1 : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Manolita.Instance.BetterWorld();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Manolita.Instance.WorseWorld();
        }
    }
    
}
