using UnityEngine;

public class BagelShoot : MonoBehaviour
{
    [SerializeField] private float bagelForce;

    private Rigidbody rbBagel;

    // Start is called before the first frame update
    void Start()
    {
        rbBagel = GetComponent<Rigidbody>();
        rbBagel.AddRelativeForce(Vector3.forward * bagelForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Destroy(gameObject);
    }
}
