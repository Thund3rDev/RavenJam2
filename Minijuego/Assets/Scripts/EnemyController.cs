using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Singleton
    public static EnemyController instance;

    [Header("Movement")]
    [SerializeField]
    private GameObject enemyCenter;
    [SerializeField]
    private float moveSpeed = 100.0f;
    [SerializeField]
    private float movementAngle = 120.0f;
    [SerializeField]
    private GameObject[] limiters;

    [Header("Health")]
    [SerializeField]
    private int maxHP = 100;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private Slider hpSlider;

    [Header("Shooting")]
    [SerializeField]
    private GameObject enemyShoots;
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
        limiters[0].transform.rotation = Quaternion.Euler(0, 0, (movementAngle / 2) + 6 + 180);
        limiters[1].transform.rotation = Quaternion.Euler(0, 0, -(movementAngle / 2) - 6 - 180);

        // Health
        currentHP = maxHP;
    }

    #region Movement
    public void RotateHorary()
    {
        float eulerZ = enemyCenter.transform.localEulerAngles.z;
        float realMovement = moveSpeed * Time.deltaTime;

        if ((eulerZ >= (360 - (movementAngle / 2))) || (eulerZ <= (movementAngle / 2)))
        {
            if (((eulerZ - realMovement) >= (360 - (movementAngle / 2))) || ((eulerZ >= 0) && (eulerZ <= (movementAngle / 2))))
            {
                enemyCenter.transform.Rotate(new Vector3(0, 0, -realMovement));
            }
        }
    }

    public void RotateAntiHorary()
    {
        float eulerZ = enemyCenter.transform.localEulerAngles.z;
        float realMovement = moveSpeed * Time.deltaTime;

        if ((eulerZ >= (360 - (movementAngle / 2))) || (eulerZ <= (movementAngle / 2)))
        {
            if (((eulerZ + realMovement) <= (movementAngle / 2)) || (eulerZ >= (360 - (movementAngle / 2))))
            {
                enemyCenter.transform.Rotate(new Vector3(0, 0, realMovement));
            }
        }
    }
    #endregion

    #region Shooting
    public void Shoot()
    {
        if (bulletsCount > 0)
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, enemyShoots.transform);
            bulletsCount--;
            UpdateBulletsText();
        }
    }
    #endregion

    #region Other Functions
    private void TakeDamage(int amount)
    {
        currentHP -= amount;
        UpdateHealthBar();
    }

    #endregion

    #region UI Functions
    private void UpdateBulletsText()
    {
        bulletsText.text = "Bullets: " + bulletsCount + "x";
    }

    private void UpdateHealthBar()
    {
        hpSlider.value = currentHP;
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
        else if (collision.CompareTag("Bullet"))
        {
            if (collision.transform.parent.name == "EnemyShots")
                return;
            else
            {
                TakeDamage(20);
                Destroy(collision.gameObject);
            }
        }
    }

    #endregion

    #region editor
    private void OnValidate()
    {
        // Limiters
        limiters[0].transform.rotation = Quaternion.Euler(0, 0, (movementAngle / 2) + 6 + 180);
        limiters[1].transform.rotation = Quaternion.Euler(0, 0, -(movementAngle / 2) - 6 - 180);
    }
    #endregion
}
