using UnityEngine;
using TMPro;

public class FlorManager : MonoBehaviour, IInteractable
{
    private Flor[] flors;
    public Animator Animator;
    public float contadorAccio = 1f;
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;

    private void Start()
    {
        flors = FindObjectsOfType<Flor>();
    }
    public void Interact()
    {
        buidaText();
        if (contadorAccio != 2f)
        {
            Millor_text.text = "Prem la tecla 1 per fer un encanteri";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();

                foreach (Flor flor in flors)
                {
                    transform.rotation = flor.baseRotation * Quaternion.Euler(20, 0, 0);
                }
                if (contadorAccio == 0f)
                {
                    WorldManager.Instance.BetterWorld();
                    contadorAccio++;
                }
                contadorAccio++;
            }
        }

        if (contadorAccio != 0f)
        {
            Pitjor_text.text = "Prem la tecla 2 per fer una maledicció";
            if (Input.GetKeyDown(KeyCode.Alpha2) && contadorAccio != 0f)
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                foreach (Flor flor in flors)
                {
                    transform.rotation = flor.baseRotation * Quaternion.Euler(-20, 0, 0);
                }
                if (contadorAccio == 2f)
                {
                    WorldManager.Instance.WorseWorld();
                    contadorAccio--;
                }
                contadorAccio--;
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
