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

    public void Interact(){
     buidaText();
            if (Input.GetKeyDown(KeyCode.Space))
        {
            mosca.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            butterfly.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
     if (contadorAccio != 2f)
        {
            Millor_text.text = "Prem la tecla U per deixar anar les papallo es";
        if (Input.GetKeyDown(KeyCode.U))
        {
            WorldManager.Instance.BetterWorld();
            activacioUtopic = true;
            activacioDistopic = false;
            mosca.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            
            EmissioParticules(butterfly, 15f);
            
                if (contadorAccio == 0f)
                {
                    WorldManager.Instance.BetterWorld();
                }
            contadorAccio = 2f;
        }
   }
     if (contadorAccio != 0f)
       {
        Pitjor_text.text = "Prem la tecla I per deixar anar les mosques";
        if (Input.GetKeyDown(KeyCode.I))
        {
            WorldManager.Instance.WorseWorld();
            activacioUtopic = false;
            activacioDistopic = true;
            butterfly.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            
            EmissioParticules(mosca, 15f);
           if (contadorAccio == 2f)
                {
                    WorldManager.Instance.WorseWorld();
                }
            contadorAccio = 0f;
        }
       }
    }
    public void fiInteract()
    {
        buidaText();
    }
    public void buidaText(){
	 Millor_text.text = " ";
        Pitjor_text.text = " ";
    }

}
