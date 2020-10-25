using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject playerCenter;
    public float moveSpeed = 100.0f;
    public float movementAngle = 180.0f;

    public GameObject playerShoots;
    public GameObject bulletPrefab;
    public int bulletsCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    #region Movement
    public void RotateHorary()
    {
        float eulerZ = playerCenter.transform.rotation.eulerAngles.z;
        float realMovement = moveSpeed * Time.deltaTime;

        if ((eulerZ >= (360 - (movementAngle / 2))) || (eulerZ <= (movementAngle / 2)))
        {
            if (((eulerZ - realMovement) >= (360 - (movementAngle / 2))) || ((eulerZ >= 0) && (eulerZ <= (movementAngle / 2))))
            {
                playerCenter.transform.Rotate(new Vector3(0, 0, -realMovement));
            }
        }

    }

    public void RotateAntiHorary()
    {
        float eulerZ = playerCenter.transform.rotation.eulerAngles.z;
        float realMovement = moveSpeed * Time.deltaTime;

        if ((eulerZ >= (360 - (movementAngle / 2))) || (eulerZ <= (movementAngle / 2)))
        {
            if (((eulerZ + realMovement) <= (movementAngle / 2)) || (eulerZ >= (360 - (movementAngle / 2))))
            {
                playerCenter.transform.Rotate(new Vector3(0, 0, realMovement));
            }
        }
    }
    #endregion

    #region shooting
    public void Shoot()
    {
        if (bulletsCount > 0)
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, playerShoots.transform);
            bulletsCount--;
        }
    }
    #endregion
}
