using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform coin;
    float smoothTime = 3;
    Vector2 velocity = Vector2.zero;
    Vector3 center;

    private void Update()
    {
        Vector3 a = player.position + coin.position;
        center = a / 2;

        transform.position = center;
        transform.position += new Vector3(0, 0, -10);

        //transform.position = Vector2.SmoothDamp(center,ref velocity, smoothTime);
        
    }
}
