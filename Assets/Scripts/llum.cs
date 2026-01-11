using UnityEngine;

public class llum : MonoBehaviour
{
    public Light luz;
    private Color blau = new Color(0.05f, 0.1f, 0.3f);
    private Color blanc = Color.white;
    private Color taronja = new Color(245f / 255f, 170f / 255f, 24f / 255f);
    void Start()
    {
        luz = GetComponent<Light>();
        WorldManager.OnBetterWorld += canviColor;
        WorldManager.OnWorseWorld += canviColor;
    }

    void canviColor(WorldManager wm)
    {
        if (wm.WorldState < 1f)
        {
            luz.color = Color.Lerp(blau, blanc, wm.WorldState);
        }
        if (wm.WorldState > 1f)
        {
            luz.color = Color.Lerp(blanc, taronja, wm.WorldState - 1f);
            if (wm.WorldState == 1f)
            {
                luz.color = blanc;
            }
        }
    }

}
