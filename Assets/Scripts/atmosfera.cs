using UnityEngine;

public class atmosfera : MonoBehaviour
{
    public Renderer arbre;
    public GameObject arbre1;
    public GameObject arbre2;
    public GameObject arbre3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arbre = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void canviMesh(WorldManager wm)
    {
        if (wm.WorldState < 0.5)
        {
            //arbre.gameObject = arbre1;
        }
    }
}
