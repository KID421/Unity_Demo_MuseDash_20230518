using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField, Header("����Ϥ�")]
    private SpriteRenderer[] imgHealths;

    private int hp = 3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Damage();
    }

    /// <summary>
    /// ����
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
            print("���`!");
        }
    }
}
