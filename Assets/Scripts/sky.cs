using UnityEngine;
using UnityEngine.Rendering;

public class sky : MonoBehaviour
{
    public Material worseWorldSkybox;
    public Material neutralWorldSkybox;
    public Material betterWorldSkybox;

    private void OnEnable()
    {
        WorldManager.OnWorseWorld += CanviaCel;
        WorldManager.OnBetterWorld += CanviaCel;
    }

    private void OnDisable()
    {
        WorldManager.OnWorseWorld -= CanviaCel;
        WorldManager.OnBetterWorld -= CanviaCel;
    }

    // rep el WorldManager perquè l'event és Action<WorldManager>
    private void CanviaCel(WorldManager wm)
    {
        float state = wm.WorldState;
        Material target;

        if (state < 1f)
        {
            target = worseWorldSkybox;
        }
        else if (state > 1f)
        {
            target = betterWorldSkybox;
        }
        else
        {
            target = neutralWorldSkybox;
        }

        if (target != null)
        {
            RenderSettings.skybox = target;
            DynamicGI.UpdateEnvironment();
        }
    }
}


