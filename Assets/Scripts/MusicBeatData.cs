using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音樂節點資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Music Beat Data")]
    public class MusicBeatData : ScriptableObject
    {
        [Header("音樂節點")]
        public Section[] musicSections;
    }

    /// <summary>
    /// 小節
    /// </summary>
    [System.Serializable]
    public class Section
    {
        [HideInInspector]
        public string name = "小節";
        public MusicBeatType[] beats;
    }

    /// <summary>
    /// 音樂節點類型：無、上、下、障礙物
    /// </summary>
    public enum MusicBeatType
    {
        none, beatUp, beatDown, obstacle
    }
}
