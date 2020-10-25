using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject center;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("Center");
        direction = center.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (direction * Time.deltaTime);
    }
}
