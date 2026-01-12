using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxController : MonoBehaviour
{
    public Material worseWorldSkybox;
    public Material neutralWorldSkybox;
    public Material betterWorldSkybox;

    public float worseMax = 0.4f;
    public float neutralMax = 1.6f;

    private void OnEnable()
    {
        WorldManager.OnWorseWorld += HandleWorseWorld;
        WorldManager.OnBetterWorld += HandleBetterWorld;
    }

    private void OnDisable()
    {
        WorldManager.OnWorseWorld -= HandleWorseWorld;
        WorldManager.OnBetterWorld -= HandleBetterWorld;
    }

    private void HandleWorseWorld(WorldManager wm)
    {
        UpdateSkybox(wm.WorldState);
    }

    private void HandleBetterWorld(WorldManager wm)
    {
        UpdateSkybox(wm.WorldState);
    }

    private void UpdateSkybox(float worldState)
    {
        Material target;

        if (worldState <= worseMax)
        {
            target = worseWorldSkybox;
        }
        else if (worldState <= neutralMax)
        {
            target = neutralWorldSkybox;
        }
        else
        {
            target = betterWorldSkybox;
        }

        if (target != null)
        {
            RenderSettings.skybox = target;
            DynamicGI.UpdateEnvironment();
        }
    }
}
