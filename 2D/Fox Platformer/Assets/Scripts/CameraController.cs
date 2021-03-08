using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform farBackground;
    [SerializeField] Transform middelBackground;
    [SerializeField] float minHeight, maxHeight;

    //private float lastXPosition;
    private Vector2 lastPosition;

    void Start()
    {
        //lastXPosition = transform.position.x;
        lastPosition = transform.position;
    }

    void Update()
    {
        /*transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y,minHeight,maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        */

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);//clamp camera movement


        //float amountToMoveX = transform.position.x - lastXPosition;  //create a parallax for deth to backgrounds
        Vector2 amountToMove = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);//create a parallax for deth to backgrounds

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middelBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;

        //lastXPosition = transform.position.x;
        lastPosition = transform.position;
    }
}
