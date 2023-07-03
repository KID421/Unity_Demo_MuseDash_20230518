using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject goFinal;
    [SerializeField]
    private GameObject goBGM;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        goFinal.SetActive(true);
        goBGM.SetActive(false);
    }
}
