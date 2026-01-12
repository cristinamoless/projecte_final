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
        if (contadorAccio == 1)
        {
            Millor_text.text = "Prem la tecla 1 per fer un encanteri";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(20, 0, 0);
                }
                contadorAccio++;
            }
            Pitjor_text.text = "Prem la tecla 2 per fer una maledicció";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(-20, 0, 0);
                }
                contadorAccio--;
            }
        }
        if (contadorAccio == 0)
        {
            Millor_text.text = "Prem la tecla 1 per fer un encanteri";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                WorldManager.Instance.BetterWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(40, 0, 0);
                }
                contadorAccio = 2;
            }
            Pitjor_text.text = "Prem la tecla 3 per desfer-ho";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(20, 0, 0);
                }
                contadorAccio++;
            }
        }
        if (contadorAccio == 2)
        {
            Millor_text.text = "Prem la tecla 3 per desfer-ho";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(-20, 0, 0);
                }
                contadorAccio--;
            }
            Pitjor_text.text = "Prem la tecla 2 per fer una maledicció";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                WorldManager.Instance.WorseWorld();
                foreach (Flor flor in flors)
                {
                    flor.transform.rotation = flor.baseRotation * Quaternion.Euler(-40, 0, 0);
                }
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
