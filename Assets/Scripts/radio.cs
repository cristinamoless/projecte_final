using UnityEngine;
using TMPro;

public class Radio : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;

    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;

    public AudioClip canal1;
    public AudioClip canal2;
    public AudioClip canal3;

    private bool inRange = false;

    private void Awake()
    {
        buidaText();
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!inRange) return;

        // Text general
        Millor_text.text = "Prem 1, 2 o 3 per canviar de canal";
        Pitjor_text.text = "";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCanal(canal1);
            WorldManager.Instance.BetterWorld();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCanal(canal2);
            WorldManager.Instance.WorseWorld();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetCanal(canal3);
            // Aquí decideixes quin món afecta el 3
            // WorldManager.Instance.NeutralWorld();
        }
    }

    // Cridat per InteractionArea.OnTriggerEnter
    public void Interact()
    {
        inRange = true;
        Millor_text.text = "Prem 1, 2 o 3 per canviar de canal";
        Pitjor_text.text = "";
    }

    // Cridat per InteractionArea.OnTriggerExit
    public void fiInteract()
    {
        inRange = false;
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
        Millor_text.text = "";
        Pitjor_text.text = "";
    }
}
