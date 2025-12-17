using UnityEngine;
using TMPro;
public class Flor : MonoBehaviour
{
    public float contadorAccio = 1f;
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;
    private void Start()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }

    public void accioFlor()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
        if (contadorAccio != 2f)
        {
            Millor_text.text = "Dona-li a la tecla P per fer un encanteri";
            if (Input.GetKeyDown(KeyCode.P))
            {
                WorldManager.Instance.BetterWorld();
                transform.rotation *= Quaternion.Euler(20, 0, 0);
                contadorAccio = 2f;
                if(contadorAccio == 0f)
                {
                    WorldManager.Instance.BetterWorld();
                }
            }
        }
        
        if(contadorAccio != 0f)
        {
            Pitjor_text.text = "O dona-li a la tecla O per fer una maledicció";
            if (Input.GetKeyDown(KeyCode.O) && contadorAccio != 0f)
            {
                WorldManager.Instance.WorseWorld();
                transform.rotation *= Quaternion.Euler(-20, 0, 0);
                contadorAccio = 0f;
                if (contadorAccio == 2f)
                {
                    WorldManager.Instance.WorseWorld();
                }
            }
        } 
    }
    public void fiaccio()
    {
        Millor_text.text = " ";
        Pitjor_text.text = " ";
    }
}
