using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private List<GameObject> _spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(_playerPrefab, );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
