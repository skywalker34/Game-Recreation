using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Slider slider;

    public void SetMaxShots(int bullets)
    {
        slider.maxValue = bullets;
        slider.value = bullets;

    }
    public void SetShots(int bullets)
    {
        slider.value = bullets;
    }
}
