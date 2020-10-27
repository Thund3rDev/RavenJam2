using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField]
    private float itemSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        randomDirection.Normalize();
        direction = randomDirection;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (direction * itemSpeed * Time.deltaTime);
    }
}
