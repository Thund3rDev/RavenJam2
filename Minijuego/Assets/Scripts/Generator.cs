using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPackage_Prefab;
    [SerializeField]
    private GameObject bulletPackages_GameObject;

    [SerializeField]
    private float minItemInterval = 3.0f;
    [SerializeField]
    private float maxItemInterval = 10.0f;
    private float nextItem;

    // Start is called before the first frame update
    void Start()
    {
        nextItem = Time.time + Random.Range(minItemInterval, maxItemInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextItem)
        {
            nextItem = Time.time + Random.Range(minItemInterval, maxItemInterval);
            Instantiate(bulletPackage_Prefab, bulletPackages_GameObject.transform);
        }
    }
}
