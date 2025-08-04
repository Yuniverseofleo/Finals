using UnityEngine;

[System.Serializable] public struct MusicTrack
{
    public string trackName;
    public AudioClip clip;
}

public interface IMusicLibrary
{
    AudioClip GetClipFromName(string trackName);
}

public class MusicLibrary : MonoBehaviour, IMusicLibrary
{
    public MusicTrack[] tracks; 

    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == trackName)
            {
                return track.clip;
            }
        }
        return null;
    }
}
