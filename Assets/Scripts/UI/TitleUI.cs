using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button Play = null, Quit = null;

	void Start()
	{
		Play.onClick.AddListener(() => OnPlayGame());
		Quit.onClick.AddListener(() => OnExitGame());
	}
	void OnPlayGame()
	{
		SceneManager.LoadScene(1);
	}
	void OnExitGame()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
