using UnityEngine;
public class Animal : MonoBehaviour
{
    float baseSpeed = 1f;
    public float currentSpeed;
    public Animator animator;
    private void Start()
    {
        currentSpeed = baseSpeed;
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
        currentSpeed = baseSpeed * (2 - wm.WorldState);
    }
    private void canviMillor(WorldManager wm)
    {
        currentSpeed = baseSpeed * wm.WorldState;
    }
}
