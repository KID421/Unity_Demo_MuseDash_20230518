using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField, Header("Perfect �d��"), Range(0, 10)]
    private float rangePerfect = 1;
    [SerializeField, Header("Good �d��"), Range(0, 10)]
    private float rangeGood = 2.5f;
    [SerializeField, Header("Miss �d��"), Range(0, 10)]
    private float rangeMiss = 4.5f;
    [SerializeField, Header("����")]
    private KeyCode key;
    [SerializeField, Header("����")]
    private TextMeshProUGUI textScore;
    [SerializeField, Header("�s��")]
    private TextMeshProUGUI textCombo;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(key)) ClickAndCheckPoint();
    }

    private void ClickAndCheckPoint()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeMiss);

        Vector2 pointHit = hit.transform.position;
        float distance = Vector2.Distance(transform.position, pointHit);

        if (distance <= rangePerfect)
        {
            ComboAndScore(scorePerfect);
        }
        else if (distance <= rangeGood)
        {
            ComboAndScore(scoreGood);
        }
        else
        {
            combo = 0;
        }
    }

    private void ComboAndScore(int score)
    {
        combo++;
        textCombo.text = $"�s���G{combo}";
        scoreTotal += score;
        textScore.text = $"���ơG{scoreTotal}";
    }
}
