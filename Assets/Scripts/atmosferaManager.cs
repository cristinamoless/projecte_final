using UnityEngine;

public class atmosferaManager : MonoBehaviour
{
    public atmosfera[] arbres;

    private int arbolesAfectados = 0;

    void Start()
    {
        arbres = FindObjectsOfType<atmosfera>();
    }

    private void OnEnable()
    {
        WorldManager.OnWorseWorld += monEmpitjora;
        WorldManager.OnBetterWorld += monMillora;
    }

    private void OnDisable()
    {
        WorldManager.OnWorseWorld -= monEmpitjora;
        WorldManager.OnBetterWorld -= monMillora;
    }

    void monEmpitjora(WorldManager wm)
    {
        arbolesAfectados++;

        arbolesAfectados = Mathf.Clamp(
            arbolesAfectados,
            0,
            arbres.Length
        );

        ActualizarArboles();
    }

    void monMillora(WorldManager wm)
    {
        arbolesAfectados--;

        arbolesAfectados = Mathf.Clamp(
            arbolesAfectados,
            0,
            arbres.Length
        );

        ActualizarArboles();
    }

    void ActualizarArboles()
    {
        for (int i = 0; i < arbres.Length; i++)
        {
            if (i < arbolesAfectados)
            {
                arbres[i].canviPitjor();
            }
            else
            {
                arbres[i].canviMillor();
            }
        }
    }
}
