using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bagelPrefab;
    [SerializeField] private Transform bagelSpawnPos;
    [SerializeField] private float fireRate;
    [SerializeField] private InputActionAsset playerControl;
    private AudioSource audioSource;

    private InputAction fireAction;

    private bool isFire;
    private bool cannotFire;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        fireAction = playerControl.FindAction("Fire");
        fireAction.performed += OnFire;
        fireAction.canceled += OnFireCancel;
        fireAction.Enable();
    }

    // When the player fires the bagel
    private void OnFire(InputAction.CallbackContext context)
    {
        isFire = true;
    }

    private void OnFireCancel(InputAction.CallbackContext context)
    {
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire && !cannotFire)
        {
            StartCoroutine(FireDelay());
            Instantiate(bagelPrefab, bagelSpawnPos.position, bagelSpawnPos.rotation);
        }
    }

    IEnumerator FireDelay()
    {
        audioSource.Play();
        cannotFire = true;
        yield return new WaitForSeconds(fireRate);
        cannotFire = false;

    }

    private void OnDestroy()
    {
        fireAction.performed -= OnFire;
        fireAction.canceled -= OnFireCancel;
        fireAction.Disable();
    }
}
