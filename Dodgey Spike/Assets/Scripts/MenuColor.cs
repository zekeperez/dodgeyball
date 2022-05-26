using UnityEngine;
using UnityEngine.UI;

public class MenuColor : MonoBehaviour
{
    public Image[] buttons;
    public Text[] texts;

    public Sprite[] blueSpriteBtns;
    public Sprite[] greenSpriteBtns;
    public Sprite[] orangeSpriteBtns;
    public Sprite[] pinkSpriteBtns;
    public Sprite[] yellowSpriteBtns;

    Sprite[][] spriteBtns;

    private void Awake()
    {
        spriteBtns = new Sprite[5][];

        //buttons = FindObjectsOfType<Image>();
        texts = FindObjectsOfType<Text>();

        spriteBtns[0] = blueSpriteBtns;
        spriteBtns[1] = greenSpriteBtns;
        spriteBtns[2] = orangeSpriteBtns;
        spriteBtns[3] = pinkSpriteBtns;
        spriteBtns[4] = yellowSpriteBtns;

        //buttons[0].sprite = spriteBtns[ColorPallette.instance.getColorTheme()][0];

        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log(buttons[i].name);
            buttons[i].sprite = spriteBtns[ColorPallette.instance.getColorTheme()][i];
        }
    }

    private void Start()
    {
        Camera.main.backgroundColor = ColorPallette.instance.getThemeColor(2);
    }
}
