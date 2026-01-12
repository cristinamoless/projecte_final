using UnityEngine;
using TMPro;

public class AnimalManager : MonoBehaviour, IInteractable
{
    public Transform player;
    public float contadorAccio = 1f;
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;
    private Animal[] animals;
    public bool playerAprop = false;

    private void Start()
    {
        animals = FindObjectsOfType<Animal>();
    }
    void Update()
    {
        if (playerAprop)
        {
            Vector3 direccio = Vector3.zero;
            GameObject find = GameObject.FindGameObjectWithTag("Player");
            player = find.transform;

            if (WorldManager.Instance.WorldState > 1f)
            {
                direccio = (player.position - transform.position).normalized;
            }
            else if (WorldManager.Instance.WorldState < 1f)
            {
                direccio = (transform.position - player.position).normalized;
            }

            foreach (Animal animal in animals)
            {
                direccio.y = 0;
                animal.transform.position += direccio * animal.currentSpeed * Time.deltaTime;
                animal.animator.SetFloat("speed", animal.currentSpeed);
            }
        }
    }

    public void Interact()
    {
        playerAprop = true;
        Debug.Log("AnimalManager: Player a prop!");
        buidaText();
        if (contadorAccio != 2f)
        {
            Millor_text.text = "Prem la tecla R per fer-te amic dels animals";
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Animator.SetTrigger("Pickup");
                WorldManager.Instance.BetterWorld();
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
            Pitjor_text.text = "Prem la tecla T per espantar els animals";
            if (Input.GetKeyDown(KeyCode.T))
            {
                //Animator.SetTrigger("Pickup");
                WorldManager.Instance.WorseWorld();
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
        playerAprop = false;
        Debug.Log("AnimalManager: Player lluny!");
    }

    public void buidaText()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }
}
