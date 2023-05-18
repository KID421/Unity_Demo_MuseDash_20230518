using UnityEngine;

namespace KID
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        [Header("移動速度"), SerializeField, Range(0, 10)]
        private float moveSpeed = 3.5f;

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
