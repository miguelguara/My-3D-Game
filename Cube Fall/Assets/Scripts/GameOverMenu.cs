using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    public GameObject gameManager;
    public TextMeshProUGUI T;
    public TextMeshProUGUI U;
    private void Start()
    {
        T.gameObject.LeanScale(new Vector2(1.3f, 1.3f), 0.7f).setLoopPingPong();
        U.gameObject.LeanScale(new Vector2(1.3f, 1.3f), 0.7f).setLoopPingPong();
    }

    public void Quit()
    {
       Application.Quit();
    }
    public void Restart()
    {
        gameManager.GetComponent<GameManager>().ativar();
        gameObject.SetActive(false);
    }
}
