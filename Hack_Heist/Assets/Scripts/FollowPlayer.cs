using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerPos;
    public float Speed;

    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(playerPos.position.x,playerPos.position.y,transform.position.z);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPos = new Vector3(playerPos.position.x,playerPos.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position,newPos,Speed*Time.deltaTime);
    }
}
