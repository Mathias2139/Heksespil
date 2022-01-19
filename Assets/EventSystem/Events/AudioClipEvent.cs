using UnityEngine;

namespace MA.Events
{
    [CreateAssetMenu(fileName = "New Clip Event", menuName = "Game Events/AudioClip Event")]
    public class AudioClipEvent : BaseGameEvent<AudioClip> { }
}