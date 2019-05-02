using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerController
    {
        string playerID;
        string playerName;
        private PlayerView view;
        public PlayerController(string playerID,string playerName)
        {
            this.playerID = playerID;
            this.playerName = playerName;
        }
        public void InitializePlayer(PlayerView playerPrefab, Vector3 position, float speed)
        {
            view = GameObject.Instantiate(playerPrefab.gameObject, position, Quaternion.identity, null).GetComponent<PlayerView>();
            view.SetController(this);
            view.SetSpeed(speed);
        }
        public void SetPlayerMaterial(Material playerMat)
        {

            view.SetPlayerMaterial(playerMat);
        }
        public void MoveUp()
        {
            view.Move(-1);
        }
        public void MoveDown()
        {
            view.Move(1);
        }
        public void Stop()
        {
            view.Move(0);
        }
        public string GetPlayerID()
        {
            return playerID;
        }
        public string GetPlayerName()
        {
            return playerName;
        }
    }
}
