using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderCallback : MonoBehaviour
{
    public Slider LoadingBar;
    public GameObject ContinueText;
    private void Start()
    {
        SceneLoader.LoaderBar = LoadingBar;
        SceneLoader.ContinueText = ContinueText;
        SceneLoader.onLoadingSceneCallback();
    }
}