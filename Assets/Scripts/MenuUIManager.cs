using TMPro;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private GameObject _createButton;
    [SerializeField] private GameObject _joinButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _joinPanel;
    [SerializeField] private TMP_InputField _joinCodeInput;
    private RelayManager _relayManager;

    void Start()
    {
        _relayManager = GameObject.Find("RelayManager").GetComponent<RelayManager>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeButtonsActiveState()
    {
        _playButton.SetActive(!_playButton.activeSelf);
        _quitButton.SetActive(!_quitButton.activeSelf);

        _createButton.SetActive(!_createButton.activeSelf);
        _joinButton.SetActive(!_joinButton.activeSelf);
        _backButton.SetActive(!_backButton.activeSelf);
    }

    public void ChangeJoinPanelActiveState()
    {
        _joinPanel.SetActive(!_joinPanel.activeSelf);

        _createButton.SetActive(!_createButton.activeSelf);
        _joinButton.SetActive(!_joinButton.activeSelf);
        _backButton.SetActive(!_backButton.activeSelf);
    }

    public void JoinGame()
    {
        _relayManager.JoinGame(_joinCodeInput.text);
    }

    public void CreateGame()
    {
        _relayManager.CreateGame();
    }
}
