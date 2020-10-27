using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;

    [Header("Movement")]
    [SerializeField]
    private GameObject playerCenter;
    [SerializeField]
    private float moveSpeed = 100.0f;
    [SerializeField]
    private float movementAngle = 180.0f;
    [SerializeField]
    private GameObject[] limiters;

    [Header("Health")]
    [SerializeField]
    private int maxHP = 5;
    [SerializeField]
    private int currentHP;

    [Header("Shooting")]
    [SerializeField]
    private GameObject playerShoots;
    [SerializeField]
    private GameObject bulletPrefab;

    private int bulletsCount = 5;
    [SerializeField]
    private TextMeshProUGUI bulletsText;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        instance = this;

        // Limiters
        limiters[0].transform.rotation = Quaternion.Euler(0, 0, (movementAngle / 2) + 6);
        limiters[1].transform.rotation = Quaternion.Euler(0, 0, -(movementAngle / 2) - 6);

        // Health
        currentHP = maxHP;
    }

    #region Movement
    public void RotateHorary()
    {
        float eulerZ = playerCenter.transform.localEulerAngles.z;
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
        float eulerZ = playerCenter.transform.localEulerAngles.z;
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
            UpdateBulletsText();
        }
    }
    #endregion

    #region various functions
    private void UpdateBulletsText()
    {
        bulletsText.text = "Bullets: " + bulletsCount + "x";
    }
    #endregion

    #region triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPackage"))
        {
            bulletsCount += 5;
            UpdateBulletsText();
            Destroy(collision.gameObject);
        }
    }

    #endregion

    #region editor
    private void OnValidate()
    {
        // Limiters
        limiters[0].transform.rotation = Quaternion.Euler(0, 0, (movementAngle / 2) + 6);
        limiters[1].transform.rotation = Quaternion.Euler(0, 0, -(movementAngle / 2) - 6);
    }
    #endregion
}
