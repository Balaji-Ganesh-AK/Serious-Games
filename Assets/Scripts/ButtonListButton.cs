using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;

    internal int index;

    public void SetText(string text)
    {
        myTextString = text;
        this.text.text = text;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked(this);
    }
}
