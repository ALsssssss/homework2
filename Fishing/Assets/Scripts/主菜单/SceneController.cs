using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private GameObject loadingPanel;
    public Text Text;
    public void LoadSceneWithProgress(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // 显示加载界面
        loadingPanel.SetActive(true);

        // 开始异步加载
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 禁止场景加载完成后自动激活
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // 计算加载进度 (0-0.9)
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            // 更新UI
            loadingSlider.value = progress;

            // 检查是否加载完成
            if (asyncLoad.progress >= 0.9f)
            {
                // 这里可以等待用户输入或延迟几秒
                Text.gameObject.SetActive(true);
                if (Input.anyKeyDown)
                {
                    
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
