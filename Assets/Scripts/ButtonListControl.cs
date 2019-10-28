using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    public GameObject buttonTemplate;

    public MusicPlayer player;

    void Start()
    {
        var songs = Resources.LoadAll<AudioClip>(MusicPlayer.SONG_DIRECTORY);
        int index = 0;
        foreach (var song in songs)
        {
            GameObject button = Instantiate(buttonTemplate);
            button.SetActive(true);
            ButtonListButton blbc = button.GetComponent<ButtonListButton>();
            blbc.SetText(song.name);
            blbc.index = index++;
            button.transform.SetParent(buttonTemplate.transform.parent.transform.parent, false);
        }
    }

    public void ButtonClicked(MonoBehaviour sender)
    {
        player.ChangeSong((sender as ButtonListButton).index);
    }
}
