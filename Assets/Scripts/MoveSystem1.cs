using UnityEngine;

public class MoveSystem1 : MonoBehaviour
{
    private Animator ani;
    private string parRun = "¶]";

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        ani.SetBool(parRun, h != 0 || v != 0);
    }
}
