using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    AudioClip[] songs;

    AudioSource source;

    const string SONG_DIRECTORY = "Songs";

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        songs = Resources.LoadAll<AudioClip>(SONG_DIRECTORY);
        if (songs.Length == 0) {
            Debug.LogWarning($"No clips were found in {SONG_DIRECTORY}!");
            return;
        }
        ChangeSong(songs[0]);
    }

    public void ChangeSong(AudioClip nextClip)
    {
        source.Stop();
        source.clip = nextClip;
        source.Play();
    }

    public void ToggleMute()
    {
        source.mute = !source.mute;
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }
}
