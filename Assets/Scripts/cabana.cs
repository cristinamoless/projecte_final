using UnityEngine;

public class cabana : MonoBehaviour
{
    public WorldManager _world;
    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }
    private void OnEnable()
    {
        WorldManager.OnBetterWorld += canviEscala;
        WorldManager.OnWorseWorld += canviEscala;
    }

    private void OnDisable()
    {
        WorldManager.OnBetterWorld -= canviEscala;
        WorldManager.OnWorseWorld -= canviEscala;
    }

    private void canviEscala(WorldManager wm)
    {
        transform.localScale = (baseScale * wm.WorldState);
    }
}

