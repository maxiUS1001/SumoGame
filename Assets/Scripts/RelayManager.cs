using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using UnityEngine;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using UnityEngine.SceneManagement;

public class RelayManager : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public void CreateGame()
    {
        CreateRelay();

        SceneManager.LoadScene("GameScene");
    }

    public void JoinGame(string joinCode)
    {
        JoinRelay(joinCode);

        SceneManager.LoadScene("GameScene");
    }

    private async void CreateRelay()
    {
        try
        {
            //Relay
            var allocation = await RelayService.Instance.CreateAllocationAsync(4);

            var joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joinCode);
            JoinCode.Value = joinCode;

            var relayServerData = new RelayServerData(allocation, "dtls");

            //Netcode
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e.Message);
        }
    }

    private async void JoinRelay(string joinCode)
    {
        try
        {
            var joinedAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            var relayServerData = new RelayServerData(joinedAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e.Message);
        }
    }
}