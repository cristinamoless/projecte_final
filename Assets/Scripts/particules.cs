using UnityEngine;
using System.Collections;
using TMPro;

public class particules : MonoBehaviour, IInteractable
{
    public ParticleSystem butterfly;
    public ParticleSystem mosca;
    private ParticleSystemRenderer psRenderer;
    private bool activacioDistopic = false;
    private bool activacioUtopic = false;
    public float contadorAccio = 1f;
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;
    public Animator animator;
    void Start()
    {
        buidaText();
        butterfly.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        mosca.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        // ───────── Mosca ─────────
        var mainM = mosca.main;
        mainM.loop = false;
        mainM.startLifetime = 60f;

        mainM.startSpeed = new ParticleSystem.MinMaxCurve(2.5f, 4.5f);

        mainM.startRotation = new ParticleSystem.MinMaxCurve(0f, 360f);
        mainM.startRotation3D = true;

        var shapeM = mosca.shape;
        shapeM.enabled = true;
        shapeM.shapeType = ParticleSystemShapeType.Sphere;
        shapeM.radius = 0.2f;

        var noiseM = mosca.noise;
        noiseM.enabled = true;
        noiseM.strength = 4f;
        noiseM.frequency = 0.5f;

        var rotationM = mosca.rotationOverLifetime;
        rotationM.enabled = true;
        rotationM.z = new ParticleSystem.MinMaxCurve(-180f, 180f);

        // ───────── Papallona ─────────
        var mainB = butterfly.main;
        mainB.loop = false;
        mainB.startLifetime = 300f;

        mainB.startSpeed = new ParticleSystem.MinMaxCurve(1f, 2.5f);

        mainB.startRotation = new ParticleSystem.MinMaxCurve(0f, 360f);
        mainB.startRotation3D = true;

        var shapeB = butterfly.shape;
        shapeB.enabled = true;
        shapeB.shapeType = ParticleSystemShapeType.Sphere;
        shapeB.radius = 0.6f;

        var noiseB = butterfly.noise;
        noiseB.enabled = true;
        noiseB.strength = 1f;
        noiseB.frequency = 0.5f;

        var rotationB = butterfly.rotationOverLifetime;
        rotationB.enabled = true;
        rotationB.z = new ParticleSystem.MinMaxCurve(-180f, 180f);
    }
    void EmissioParticules(ParticleSystem ps, float temps)
    {
        ps.Play();
        StartCoroutine(PararEmissio(ps, temps));
    }

    IEnumerator PararEmissio(ParticleSystem ps, float temps)
    {
        yield return new WaitForSeconds(temps);
        ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
    }

    public void Interact()
    {
        buidaText();
        if (contadorAccio == 1)
        {
            Millor_text.text = "Prem la tecla 1 per deixar anar les papallones";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                activacioUtopic = true;
                EmissioParticules(butterfly, 15f);
                contadorAccio++;
            }
            Pitjor_text.text = "Prem la tecla 2 per deixar anar les mosques";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                activacioDistopic = true;
                EmissioParticules(mosca, 15f);
                contadorAccio--;
            }
        }
        if (contadorAccio == 0)
        {
            Millor_text.text = "Prem la tecla 1 per deixar anar les papallones";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WorldManager.Instance.BetterWorld();
                activacioUtopic = true;
                activacioDistopic = false;
                mosca.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                EmissioParticules(butterfly, 15f);
                contadorAccio = 2;
            }
            Pitjor_text.text = "Prem la tecla 3 per capturar les mosques ";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                activacioUtopic = false;
                activacioDistopic = false;
                mosca.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                contadorAccio++;
            }
        }
        if (contadorAccio == 2)
        {
            Millor_text.text = "Prem la tecla 3 per capturar les papallones";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                activacioUtopic = false;
                activacioDistopic = false;
                butterfly.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                contadorAccio--;
            }
            Pitjor_text.text = "Prem la tecla 2 per deixar anar les mosques";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                activacioUtopic = false;
                activacioDistopic = true;
                butterfly.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                EmissioParticules(mosca, 15f);
                contadorAccio = 0;
            }
        }

    }
    public void fiInteract()
    {
        buidaText();
    }
    public void buidaText()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }
}
