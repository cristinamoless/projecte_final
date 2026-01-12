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

        if (state < 1f)
        {
            RenderSettings.skybox.Lerp(worseWorldSkybox, neutralWorldSkybox, state / 1f);
        }
        else if (state > 1f)
        {
            RenderSettings.skybox.Lerp(neutralWorldSkybox, betterWorldSkybox, (state - 1f) / 1f);
        }
        else
        {
            RenderSettings.skybox = neutralWorldSkybox;
        }

        DynamicGI.UpdateEnvironment();
    }
}
