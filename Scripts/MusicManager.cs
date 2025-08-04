using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private MusicLibrary musicLibrary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        StartCoroutine(AnimateMusicCrossFade(musicLibrary.GetClipFromName(trackName), fadeDuration));
    }

    private IEnumerator AnimateMusicCrossFade(AudioClip nextTrack, float fadeDuration)
    {
        float percent = 0f;

        // Fade out
        while (percent < 1f)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0f, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.Play();

        // Fade in
        percent = 0f;
        while (percent < 1f)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(0f, 1f, percent);
            yield return null;
        }
    }
}
