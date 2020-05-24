using UnityEngine;
using UnityEngine.UI;

public class GemBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxScore(int score)
    {
        slider.maxValue = score;
        slider.value = 0;
    }

    public void setScore(int score)
    {
        slider.value = score;
    }
}
