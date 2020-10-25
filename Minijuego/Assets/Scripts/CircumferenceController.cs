using UnityEngine;

public class CircumferenceController : MonoBehaviour
{
    [SerializeField]
    private float minChangeInterval = 3.0f;
    [SerializeField]
    private float maxChangeInterval = 5.0f;
    private float nextChange;

    [SerializeField]
    private float rotateSpeed = 10.0f;
    private bool horaryRotate;

    private bool isStarting = true;

    // Start is called before the first frame update
    void Start()
    {
        nextChange = Time.time + Random.Range(minChangeInterval, maxChangeInterval);
        horaryRotate = (Random.Range(0, 2) == 0) ? false : true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextChange)
        {
            horaryRotate = !horaryRotate;
            nextChange = Time.time + Random.Range(minChangeInterval, maxChangeInterval);
            rotateSpeed *= 1.2f;

            if (isStarting)
                isStarting = false;
        }

        if (isStarting)
            return;

        if (horaryRotate)
            this.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        else
            this.transform.Rotate(new Vector3(0, 0, -rotateSpeed) * Time.deltaTime);
    }
}
