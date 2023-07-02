using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject GMS;
    [SerializeField]
    public RectTransform scoreRectTransform;
   

    private void Start()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.3f,1.3f),0.4f).setLoopPingPong();
        scoreRectTransform.anchoredPosition = new Vector2(scoreRectTransform.anchoredPosition.x, 185f);
    }

    public void iniciar()
    {
        scoreRectTransform.LeanMoveY(148f, 0.7f).setEaseOutBounce();
        GMS.SetActive(true);
        gameObject.SetActive(false);
    }
}
