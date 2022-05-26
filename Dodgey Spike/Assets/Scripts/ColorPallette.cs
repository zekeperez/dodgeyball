using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPallette : MonoBehaviour
{
    public static ColorPallette instance;

    [Header("Ball Color")]
    public Color[] colors_Blue;
    public Color[] colors_Green;
    public Color[] colors_Orange;
    public Color[] colors_Pink;
    public Color[] colors_Yellow;

    Color[][] colors;
    int colorTheme = 4;

    [Header("Themes")]
    public Color[] theme_Blue;
    public Color[] theme_Green;
    public Color[] theme_Orange;
    public Color[] theme_Pink;
    public Color[] theme_Yellow;
    Color[][] themes;


    private void Awake()
    {
        instance = this;

        colorTheme = Random.Range(0, 4);
        Debug.Log(colorTheme);

        colors = new Color[5][];
        colors[0] = colors_Blue;
        colors[1] = colors_Green;
        colors[2] = colors_Orange;
        colors[3] = colors_Pink;
        colors[4] = colors_Yellow;

        themes = new Color[5][];
        themes[0] = theme_Blue;
        themes[1] = theme_Green;
        themes[2] = theme_Orange;
        themes[3] = theme_Pink;
        themes[4] = theme_Yellow;

    }

    public void setColorTheme(int index) { colorTheme = index; }

    public Color getThemeColor(int index) { return themes[colorTheme][index]; }

    public int getColorTheme() { return colorTheme; }

    public Color getColorByHealth(int val)
    {
        return colors[colorTheme][val - 1];
    }
}
