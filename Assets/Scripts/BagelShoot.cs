using UnityEngine;

public class BagelShoot : MonoBehaviour
{
    [SerializeField] private float bagelForce;

    public float magnetRadius = 5f;
    public float magnetForce = 2;
    private Rigidbody rbBagel;
    private PowerUpManager powerUpManager;

    private bool hasTarget;
    private bool isCurrentlyActive;
    private Collider target;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManager = GameObject.Find("Power Up Manager").GetComponent<PowerUpManager>();
        rbBagel = GetComponent<Rigidbody>();
        rbBagel.AddRelativeForce(Vector3.forward * bagelForce, ForceMode.Impulse);
    }

    private void Update()
    {
        if (powerUpManager.foodMagnetActive && !isCurrentlyActive)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRadius);
            if (!hasTarget)
            {
                foreach (Collider collider in hitColliders)
                {
                    // check if the collider is an NPC
                    if (collider.CompareTag("NPC"))
                    {
                        if (!hasTarget)
                        {
                            EnableRbBagel(false);
                            rbBagel.velocity = Vector3.zero;
                            target = collider;
                        }
                    }
                }
            }
            if (target != null && hasTarget)
            {
                // apply force towards the NPC
                Vector3 direction = (target.transform.position + (Vector3.up / 3) - transform.position).normalized;
                transform.Translate(direction * magnetForce * Time.deltaTime);
            }
            else if (target == null && hasTarget)
            {
                EnableRbBagel(true);
            }
        }
        else if (isCurrentlyActive)
        {
            EnableRbBagel(true);
        }
    }

    private void EnableRbBagel(bool isEnable)
    {
        rbBagel.useGravity = isEnable;
        rbBagel.isKinematic = !isEnable;
        isCurrentlyActive = !isEnable;
        hasTarget = !isEnable;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Destroy(gameObject);
    }
}
