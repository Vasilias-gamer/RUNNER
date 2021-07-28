using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target;
    private float distance;
    private float y;
    private Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        distance = -10;
        y = 10;
        angle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 10, target.position.z - 10);
        transform.rotation = angle;
    }
}
