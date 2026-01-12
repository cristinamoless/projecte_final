using UnityEngine;
using System;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    public static Action<WorldManager> OnWorseWorld;
    public static Action<WorldManager> OnBetterWorld;
    public float WorldState = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void WorseWorld()
    {
        WorldState -= 0.2f;
        OnWorseWorld?.Invoke(this);
    }
    public void BetterWorld()
    {
        WorldState += 0.2f;
        OnBetterWorld?.Invoke(this);
    }
}
