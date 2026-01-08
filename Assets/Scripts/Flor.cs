using UnityEngine;
using TMPro;
public class Flor : MonoBehaviour, IInteractable
{
    public Animator Animator;
    public float contadorAccio = 1f;
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;
    private Quaternion baseRotation;
    private void Start()
    {
        buidaText();
        baseRotation = transform.rotation;
    }

    public void Interact()
    {
        buidaText();
        if (contadorAccio != 2f)
        {
            Millor_text.text = "Prem la tecla P per fer un encanteri";
            if (Input.GetKey(KeyCode.P))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();

                transform.rotation = baseRotation * Quaternion.Euler(20, 0, 0);
                contadorAccio = 2f;
                if (contadorAccio == 0f)
                {
                    WorldManager.Instance.BetterWorld();
                }
            }
        }

        if (contadorAccio != 0f)
        {
            Pitjor_text.text = "Prem la tecla O per fer una maledicció";
            if (Input.GetKey(KeyCode.O) && contadorAccio != 0f)
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                transform.rotation = baseRotation * Quaternion.Euler(-20, 0, 0);
                contadorAccio = 0f;
                if (contadorAccio == 2f)
                {
                    WorldManager.Instance.WorseWorld();
                }
            }
        }
    }
    public void fiInteract()
    {
        buidaText();
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
    public void buidaText()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }
}
