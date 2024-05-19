using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button onlineButton;
    [SerializeField] Button joinButton;
    [SerializeField] Button setingsButton;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        onlineButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        joinButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
    public void LoadGameScene() 
    {
        NetworkManager.Singleton.SceneManager.LoadScene("GameScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void QuitGameButton() 
    {
        Application.Quit();
    }
}
