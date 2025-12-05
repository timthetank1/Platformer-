using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public Button button;
    void Start() {
        button.onClick.AddListener(PlayLevel);
    }
    public void PlayLevel() {
        Debug.Log("tada");
        SceneManager.LoadSceneAsync(1);
    }
}
