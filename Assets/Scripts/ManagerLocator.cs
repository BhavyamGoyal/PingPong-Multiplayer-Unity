using UnityEngine;
using System.Collections;
using Player;
using MultiplayerSystem;
using System.Collections.Generic;

namespace Commons
{
    public class ManagerLocator : Singleton<ManagerLocator>
    {
        PlayerManager playerManager;
        [SerializeField] List<Material> playerMaterial = new List<Material>();
        [SerializeField]private MultiplayerManager multiplayerManager;
        public PlayerScriptable playerSettings;
        // Use this for initialization
        void Start()
        {
            playerManager = new PlayerManager(playerSettings,playerMaterial);
            //multiplayerManager = GameObject.Instantiate()
        }
        public PlayerManager GetPlayerManager()
        {
            return playerManager;
        }
        public MultiplayerManager GetMultiplayerManager()
        {
            return multiplayerManager;
        }
    }
}