using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainSceneName = "NomDeLaTevaEscenaPrincipal";

    public void PlayGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
