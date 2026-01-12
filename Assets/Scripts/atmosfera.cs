using UnityEngine;

public class atmosfera : MonoBehaviour
{
    public Renderer arbre;
    public Mesh arbreN;
    public Material[] materialArbre;
    public Mesh arbreU;
    public Material materialArbreU;
    private MeshFilter meshfilter;
    private Vector3 scale1 = new Vector3(10.25f, 10.25f, 10.25f);
    private Vector3 scale2 = new Vector3(1f, 1f, 1f);
    private Vector3 rotation1 = new Vector3(-109.73f, -9.03f, 14.16f);
    private Vector3 rotation2 = new Vector3(0f, 0f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshfilter = GetComponent<MeshFilter>();
        arbre = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void canviPitjor()
    {
        meshfilter.mesh = arbreU;
        arbre.material = materialArbreU;
        transform.localScale = scale2;
        transform.localRotation = Quaternion.Euler(rotation2);
    }
    public void canviMillor()
    {
        meshfilter.mesh = arbreN;
        arbre.materials = materialArbre;
        transform.localScale = scale1;
        transform.localRotation = Quaternion.Euler(rotation1);
    }

}
