using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音樂節點生成系統
    /// </summary>
    public class MusicBeatSpawnSystem : MonoBehaviour
    {
        [SerializeField, Header("歌曲資料")]
        private MusicBeatData data;
        [SerializeField, Header("生成延遲"), Range(0, 10)]
        private float delay;
        [SerializeField, Header("生成間隔"), Range(0, 10)]
        private float interval = 0.8f;
        [Header("節點物件：上、下、障礙物")]
        [SerializeField] private GameObject prefabUp;
        [SerializeField] private GameObject prefabDown;
        [SerializeField] private GameObject prefabObstacle;
        [Header("節點位置：上、下、障礙物")]
        [SerializeField] private Transform pointUp;
        [SerializeField] private Transform pointDown;
        [SerializeField] private Transform pointObstacle;

        private int indexSection;
        private int indexMusicBeat;

        private void Start()
        {
            InvokeRepeating("SpawnMusicBeat", delay, interval);
        }

        /// <summary>
        /// 生成音樂節點
        /// </summary>
        private void SpawnMusicBeat()
        {
            Section[] section = data.musicSections;
            MusicBeatType beat = section[indexSection].beats[indexMusicBeat];
            SpawnObjet(beat);

            indexMusicBeat++;
            if (indexMusicBeat == 4)
            {
                indexMusicBeat = 0;
                indexSection++;
            }

            if (indexSection == section.Length) CancelInvoke("SpawnMusicBeat");
        }

        /// <summary>
        /// 生成物件
        /// </summary>
        private void SpawnObjet(MusicBeatType type)
        {
            switch (type)
            {
                case MusicBeatType.none:
                    break;
                case MusicBeatType.beatUp:
                    Instantiate(prefabUp, pointUp.position, Quaternion.identity);
                    break;
                case MusicBeatType.beatDown:
                    Instantiate(prefabDown, pointDown.position, Quaternion.identity);
                    break;
                case MusicBeatType.obstacle:
                    Instantiate(prefabObstacle, pointObstacle.position, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}
