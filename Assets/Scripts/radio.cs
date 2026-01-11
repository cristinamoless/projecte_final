using UnityEngine;
using TMPro;

public class Radio : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public float contadorAccio = 1f;

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
        if (contadorAccio != 2f)
        {
            Millor_text.text = "Prem la tecla 1 per posar el canal de l'Emerald City";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetCanal(canal1);
                WorldManager.Instance.BetterWorld();
                if (contadorAccio == 0f)
                {
                    WorldManager.Instance.BetterWorld();
                }
                contadorAccio = 2f;
            }
        }
        if (contadorAccio != 0f)
        {
            Pitjor_text.text = "Prem la tecla 2 per posar el canal del Upside Down";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetCanal(canal2);
                WorldManager.Instance.WorseWorld();
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