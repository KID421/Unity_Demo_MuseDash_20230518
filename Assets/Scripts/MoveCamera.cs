using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField, Header("²¾°Ê³t«×"), Range(0, 500)]
    private float speedMove = 3.5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(x) <= 0.1f && Mathf.Abs(y) <= 0.1f) return;
        
        Vector3 mouseMove = Vector3.zero;
        mouseMove.x = x;
        mouseMove.y = x;

        transform.position += mouseMove * Time.deltaTime * speedMove;
    }
}
