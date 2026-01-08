using UnityEngine;

public class particules : MonoBehaviour
{
    public ParticleSystem particleEffect;
    private ParticleSystem.MainModule main;
    public Mesh meshMosca;
    public Material materialMosca;
    public Mesh meshButterfly;
    public Material materialButterfly;


    private ParticleSystemRenderer psRenderer;


    void Start()
    {
        // Nos aseguramos de que empiece apagado
        particleEffect.Stop();

        psRenderer = particleEffect.GetComponent<ParticleSystemRenderer>();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            particleEffect.Play();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            particleEffect.Stop();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            psRenderer.mesh = meshButterfly;
            psRenderer.sharedMaterial = materialButterfly;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            psRenderer.mesh = meshMosca;
            psRenderer.sharedMaterial = materialMosca;
        }
    }

}
