using UnityEngine;
public class Flor : MonoBehaviour
{

    public Quaternion baseRotation;
    private void Start()
    {
        baseRotation = transform.rotation;
    }
    private void OnEnable()
    {
        WorldManager.OnBetterWorld += canviMillor;
        WorldManager.OnWorseWorld += canviPitjor;
    }

    private void OnDisable()
    {
        WorldManager.OnBetterWorld -= canviMillor;
        WorldManager.OnWorseWorld -= canviPitjor;
    }
    private void canviPitjor(WorldManager wm)
    {
        transform.rotation *= Quaternion.Euler(-5, 0, 0);
    }
    private void canviMillor(WorldManager wm)
    {
        transform.rotation *= Quaternion.Euler(5, 0, 0);
    }
}
