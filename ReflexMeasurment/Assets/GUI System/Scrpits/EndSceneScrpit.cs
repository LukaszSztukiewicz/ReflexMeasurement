using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScrpit : MonoBehaviour
{
    public Slider slider;
    public float progress = 0f;

    public IEnumerator ILoadScene(int scene)
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadSceneAsync(scene);
    }
    public IEnumerator SliderGo()
    {
        while (progress < 1)
        {
            slider.value = progress;
            progress += 0.001f;
            yield return null;

        }

    }
    public void End()
    {
        StartCoroutine(SliderGo());
        StartCoroutine(ILoadScene(2));
    }
}
