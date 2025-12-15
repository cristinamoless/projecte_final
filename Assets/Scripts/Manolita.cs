using UnityEngine;
using System;

public class Manolita : MonoBehaviour
{
    public static Manolita Instance;

    public GameObject Player;
    public static Action<Manolita> OnWorseWorld;
    public static Action<Manolita> OnBetterWorld;
    public float WorldState = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WorseWorld()
    {
        OnWorseWorld?.Invoke(this);
        WorldState -= 0.2f;
    }
    public void BetterWorld()
    {
        OnBetterWorld?.Invoke(this);
        WorldState += 0.2f;
    }
}
