using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField, Header("Perfect 範圍"), Range(0, 10)]
    private float rangePerfect = 1;
    [SerializeField, Header("Good 範圍"), Range(0, 10)]
    private float rangeGood = 2.5f;
    [SerializeField, Header("Miss 範圍"), Range(0, 10)]
    private float rangeMiss = 4.5f;
    [SerializeField, Header("按鍵")]
    private KeyCode key;
    [SerializeField, Header("分數")]
    private TextMeshProUGUI textScore;
    [SerializeField, Header("連擊")]
    private TextMeshProUGUI textCombo;
    [SerializeField, Header("顯示打擊狀態物件")]
    private Animator aniShowState;
    [Header("刪除區域資料")]
    [SerializeField]
    private Vector3 destroyAreaSize = Vector3.one;
    [SerializeField]
    private Vector3 destroyAreaOffset;

    private int scoreTotal, scorePerfect = 100, scoreGood = 50;
    private int combo;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangePerfect);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeGood);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeMiss);

        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position + destroyAreaOffset, destroyAreaSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(key)) ClickAndCheckPoint();
        CheckObjectInDestroyArea();
    }

    private void ClickAndCheckPoint()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeMiss);

        if (hit == null) return;

        Vector2 pointHit = hit.transform.position;
        float distance = Vector2.Distance(transform.position, pointHit);
        Animator aniHit = hit.GetComponent<Animator>();

        if (distance <= rangePerfect)
        {
            ComboAndScore(scorePerfect);
            aniHit.SetTrigger("Perfect");
            aniShowState.SetTrigger("Perfect");
        }
        else if (distance <= rangeGood)
        {
            ComboAndScore(scoreGood);
            aniHit.SetTrigger("Good");
            aniShowState.SetTrigger("Good");
        }
        else
        {
            combo = 0;
            textCombo.text = $"連擊：0";
            aniHit.SetTrigger("Miss");
            aniShowState.SetTrigger("Miss");
        }

        hit.GetComponent<Collider2D>().enabled = false;
    }

    private void CheckObjectInDestroyArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + destroyAreaOffset, destroyAreaSize, 0);

        if (hit)
        {
            hit.GetComponent<Animator>().SetTrigger("Miss");
            hit.GetComponent<Collider2D>().enabled = false;
            Destroy(hit.gameObject, 0.5f);                         // 逗號後面為延遲刪除的秒數
        }
    }

    private void ComboAndScore(int score)
    {
        combo++;
        textCombo.text = $"連擊：{combo}";
        scoreTotal += score;
        textScore.text = $"分數：{scoreTotal}";
    }
}
