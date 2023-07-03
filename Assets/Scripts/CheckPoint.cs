using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    #region ���
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
    [SerializeField, Header("��ܥ������A����")]
    private Animator aniShowState;
    [Header("�R���ϰ���")]
    [SerializeField]
    private Vector3 destroyAreaSize = Vector3.one;
    [SerializeField]
    private Vector3 destroyAreaOffset;

    private int scoreTotal, scorePerfect = 100, scoreGood = 50;
    private int combo;
    #endregion

    int hp = 3;

    private void Dead()
    {
        hp--;
        if (hp == 0) GameManager.instance.GameOver();
    }

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

    [SerializeField]
    private Transform player;
    [SerializeField]
    private List<Collider2D> goHits = new List<Collider2D>();

    private void ClickAndCheckPoint()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, rangeMiss);

        if (hits.Length == 0) return;

        goHits = hits.ToList();
        goHits = goHits.OrderBy(x => Vector2.Distance(x.transform.position, player.position)).ToList(); 
        Collider2D hit = goHits[0];

        #region �P�w����
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
            textCombo.text = $"�s���G0";
            aniHit.SetTrigger("Miss");
            aniShowState.SetTrigger("Miss");
        } 
        #endregion

        hit.GetComponent<Collider2D>().enabled = false;

        Destroy(hit.gameObject);
    }

    private void CheckObjectInDestroyArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + destroyAreaOffset, destroyAreaSize, 0);

        if (hit)
        {
            hit.GetComponent<Animator>().SetTrigger("Miss");
            hit.GetComponent<Collider2D>().enabled = false;
            Destroy(hit.gameObject, 0.5f);                         // �r���᭱������R�������
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
