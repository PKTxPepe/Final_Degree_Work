using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    // Start is called before the first frame update

    public void LoadScene(int scene)
    {
        StartCoroutine(LoadSceneRoutine(scene));
    }

    IEnumerator LoadSceneRoutine(int scene)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.FadeDuration);
        SceneManager.LoadScene(scene);
    }
}
