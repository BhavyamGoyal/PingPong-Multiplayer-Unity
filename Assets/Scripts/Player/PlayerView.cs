using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        PlayerController controller;
        Rigidbody rb;
        Vector3 moveingSpeed=new Vector3(0,0,10);
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {

        }
        public void SetPlayerMaterial(Material playerMat)
        {
            Debug.Log("Player spawn"+playerMat.name);
            gameObject.GetComponentInChildren<Renderer>().material = playerMat;
        }
        public void SetSpeed(float speed)
        {
            moveingSpeed.z = moveingSpeed.z * speed;
        }
        public void SetController(PlayerController controller)
        {
            this.controller = controller;
        }
        public void Move(int direction)
        {
            rb.velocity = direction*moveingSpeed;
        }
    }
}
