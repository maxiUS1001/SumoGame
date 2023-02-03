using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Relay;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _joinCodeText;

    private void Start()
    {
        StartCoroutine(WaitForJoinCode());
    }

    IEnumerator WaitForJoinCode()
    {
        yield return new WaitUntil(() => JoinCode.Value != null);
        _joinCodeText.text = "Game code: " + JoinCode.Value;
    }
}
