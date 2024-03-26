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
    public AudioClip dogbarkSfx;
    public AudioClip catJump;
    public AudioClip catDeath;
    public AudioClip catSlide;
    public AudioClip catHurt;
    public AudioClip coinCollectSfx;
}