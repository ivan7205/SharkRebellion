using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Object Shooter")]
public class ObjectShooter : MonoBehaviour
{
    [Header("Object creation")]
    public GameObject prefabToSpawn;
    public KeyCode keyToPress = KeyCode.Space;
    [Header("Other options")]
    public float creationRate = .5f;
    public float shootSpeed = 5f;
    public Vector2 shootDirection = new Vector2(1f, 1f);
    public bool relativeToRotation = true;
    private float timeOfLastSpawn;
    private int playerNumber;
    public Animator animator;

    void Start()
    {
        timeOfLastSpawn = -creationRate;
        playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(keyToPress) && Time.time >= timeOfLastSpawn + creationRate)
        {
            Vector2 actualBulletDirection = (relativeToRotation)
                ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection)
                : shootDirection;

            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = this.transform.position;

            if (actualBulletDirection.x < 0)
                newObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);
            else
                newObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);

            newObject.tag = "Bullet";

            // ✅ Asignar dirección y velocidad a la bala
            BulletDamage bulletDamage = newObject.GetComponent<BulletDamage>();
            if (bulletDamage != null)
            {
                bulletDamage.moveDirection = actualBulletDirection.normalized;
                bulletDamage.moveSpeed = shootSpeed;
            }

            BulletAttribute b = newObject.GetComponent<BulletAttribute>();
            if (b == null)
                b = newObject.AddComponent<BulletAttribute>();
            b.playerId = playerNumber;

            Destroy(newObject, 1f);
            timeOfLastSpawn = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
            Utils.DrawShootArrowGizmo(transform.position, shootDirection, extraAngle, 1f);
        }
    }
}
