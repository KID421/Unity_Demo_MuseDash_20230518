using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField, Header("血條圖片")]
    private SpriteRenderer[] imgHealths;

    private int hp = 3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Damage();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    public void Damage()
    {
        if (hp > 0)
        {
            hp--;
            imgHealths[hp].enabled = false;
        }
        else
        {
            print("死亡!");
        }
    }
}
