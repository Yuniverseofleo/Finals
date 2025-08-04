using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}

public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        foreach (var effect in soundEffects)
        {
            if (effect.groupID == name && effect.clips.Length > 0)
            {
                return effect.clips[Random.Range(0, effect.clips.Length)];
            }
        }
        Debug.LogWarning("Sound group not found or empty: " + name);
        return null;
    }

    public void PlaySound(string name, GameObject sourceObject)
    {
        AudioClip clip = GetClipFromName(name);
        if (clip == null) return;

        AudioSource audioSource = sourceObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = sourceObject.AddComponent<AudioSource>();
        }

        audioSource.PlayOneShot(clip);
    }
}
