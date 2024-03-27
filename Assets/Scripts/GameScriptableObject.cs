using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameScriptableObject", order = 1)]
public class GameScriptableObject : ScriptableObject
{
    public SoundData audioclips;
}
[System.Serializable]
public struct SoundData
{
    public AudioClip clickSfx;
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip slideClip;
    public AudioClip hurtClip;
    public AudioClip coinCollectSfx;
    public AudioClip gameStartSfx;
    public AudioClip gameplayLoopSfx;
}