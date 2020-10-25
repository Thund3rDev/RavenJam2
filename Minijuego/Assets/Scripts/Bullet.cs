using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject center;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("Center/Circumference");
        direction = center.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (direction * Time.deltaTime);
    }
}
