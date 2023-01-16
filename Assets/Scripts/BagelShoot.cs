using UnityEngine;

public class BagelShoot : MonoBehaviour
{
    [SerializeField] private float bagelForce;

    public float magnetRadius = 5f;
    public float magnetForce = 10f;
    private Rigidbody rbBagel;
    private PowerUpManager powerUpManager;

    private bool hasTarget;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManager = GameObject.Find("Power Up Manager").GetComponent<PowerUpManager>();
        rbBagel = GetComponent<Rigidbody>();
        rbBagel.AddRelativeForce(Vector3.forward * bagelForce, ForceMode.Impulse);
    }

    private void Update()
    {
        if (powerUpManager.foodMagnetActive)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRadius);
            foreach (Collider collider in hitColliders)
            {
                // check if the collider is an NPC
                if (collider.CompareTag("NPC"))
                {
                    if (!hasTarget)
                    {
                        rbBagel.useGravity = false;
                        rbBagel.velocity = Vector3.zero;
                        hasTarget = true;
                    }
                    // apply force towards the NPC
                    Vector3 direction = (collider.transform.position + (Vector3.up/2) - transform.position).normalized;
                    rbBagel.AddForce(direction * magnetForce);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Destroy(gameObject);
    }
}
