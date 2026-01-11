using UnityEngine;

public class cabana : MonoBehaviour
{
    private Vector3 baseScale;

    void Awake()
    {
        baseScale = transform.localScale;
        WorldManager.OnBetterWorld += canviEscala;
        WorldManager.OnWorseWorld += canviEscala;
    }

    private void canviEscala(WorldManager wm)
    {
        transform.localScale = (baseScale * wm.WorldState);
    }
}


