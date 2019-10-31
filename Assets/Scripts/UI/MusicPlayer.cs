using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    AudioClip[] songs;

    AudioSource source;

    public const string SONG_DIRECTORY = "Songs";

    public MusicMode mode;

    public Canvas canvas;

    int currentSongIndex = -1;
    System.Random generator = new System.Random();

    /// <summary>
    /// A list of the songs that can be played.
    /// </summary>
    public ReadOnlyCollection<AudioClip> Songs
    {
        get => Array.AsReadOnly(songs);
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        songs = Resources.LoadAll<AudioClip>(SONG_DIRECTORY);
        if (songs.Length == 0) {
            Debug.LogWarning($"No clips were found in {SONG_DIRECTORY}!");
            return;
        }
        PlayNextSong();
        Dropdown modeOptions = GetComponentInChildren<Dropdown>(true);
        modeOptions.options.Clear();
        foreach (var mode in Enum.GetNames(typeof(MusicMode)))
            modeOptions.options.Add(new Dropdown.OptionData(mode));

        if (canvas && !canvas.worldCamera)
            Debug.LogWarning("Please register a camera to the manager's UI.");
    }

    /// <summary>
    /// Retrieves the index of the next song according to play mode and plays it.
    /// </summary>
    public void PlayNextSong()
    {
        switch (mode)
        {
            case MusicMode.Random:
                currentSongIndex = new System.Random().Next(songs.Length);
                break;
            case MusicMode.Sequential:
                currentSongIndex = (currentSongIndex + 1) % songs.Length;
                break;
            case MusicMode.Loop:
                break;
            default:
                Debug.LogWarning($"Unsupported music mode {mode}");
                return;
        }

        AudioClip nextSong = songs[currentSongIndex];

        ChangeSong(nextSong);
    }

    public void ChangeSong(AudioClip nextClip)
    {
        // This makes sure that the song selection doesn't get crazy after
        // multiple selections
        if (IsInvoking()) CancelInvoke();
        
        source.Stop();
        source.clip = nextClip;
        source.Play();

        // Make the next song play
        Invoke("PlayNextSong", nextClip.length);
       
    }

    public void ChangeSong(int index)
    {
        ChangeSong(songs[index]);
        currentSongIndex = index;
    }

    public void ToggleMute()
    {
        source.mute = !source.mute;
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }

    public void ToggleMusicMenu()
    {
        canvas.enabled = !canvas.enabled;
    }

    public void ChangeMusicMode(int value)
    {
        mode = (MusicMode)value;
    }
}

public enum MusicMode
{
    Sequential, 
    Random,
    Loop,
}
