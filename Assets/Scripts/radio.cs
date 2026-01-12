using UnityEngine;
using TMPro;

public class Radio : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public float contadorAccio = 1f;
    public Animator Animator;

    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;

    public AudioClip canal1;
    public AudioClip canal2;
    public AudioClip canal3;

    private void Awake()
    {
        buidaText();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        SetCanal(canal3);
    }

    public void Interact()
    {
        buidaText();
        if (contadorAccio == 1)
        {
            Millor_text.text = "Prem la tecla 1 per posar el canal de l'Emerald City";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                SetCanal(canal1);
                contadorAccio++;
            }
            Pitjor_text.text = "Prem la tecla 2 per posar el canal del Upside Down";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                SetCanal(canal2);
                contadorAccio--;
            }
        }
        if (contadorAccio == 0)
        {
            Millor_text.text = "Prem la tecla 1 per posar el canal de l'Emerald City";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                WorldManager.Instance.BetterWorld();
                SetCanal(canal1);
                contadorAccio = 2;
            }
            Pitjor_text.text = "Prem la tecla 3 per posar el canal normal";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
                SetCanal(canal3);
                contadorAccio++;
            }
        }
        if (contadorAccio == 2)
        {
            Millor_text.text = "Prem la tecla 3 per posar el canal normal";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                SetCanal(canal3);
                contadorAccio--;
            }
            Pitjor_text.text = "Prem la tecla 2 per posar el canal del Upside Down";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
                WorldManager.Instance.WorseWorld();
                SetCanal(canal2);
                contadorAccio = 0;
            }
        }
    }

    public void fiInteract()
    {
        buidaText();
    }
    private void SetCanal(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;

        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.clip = clip;
        audioSource.Play();
    }
    public void buidaText()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }

}
