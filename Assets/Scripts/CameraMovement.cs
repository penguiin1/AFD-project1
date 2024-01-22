using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;

    private float smooth = 5f;
    private float offsetZ = -10;

    Vector3 target;
    private void LateUpdate()
    {
        target = new Vector3(Player.transform.position.x, Player.transform.position.y, offsetZ);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
    }
}
