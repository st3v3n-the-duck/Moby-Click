using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FireScript : MonoBehaviour
{
    [SerializeField] private GameObject harpoon;
    [SerializeField] private Transform harpoonSpawnPoint;
    [SerializeField] private Transform gun;
    [SerializeField] public float harpoonSpeed = 20f;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject sparkle;

    public AudioSource ShootingSoundEffect;
    public AudioClip ShootingSound;

    private void Update()
    {
        if (gun != null && harpoonSpawnPoint != null)
        {
            harpoonSpawnPoint.position = gun.position;
            harpoonSpawnPoint.rotation = gun.rotation;
            // "gun" è l'oggetto la cui posizione e orientamento il proiettile segue, per avere sempre posizione e orientamento corretto
        }
    }

    public void MoveTrigger()
    {
        if (trigger != null)
        {
            Vector3 pos = trigger.transform.localPosition;
            pos.y -= 0.0035f;
            pos.z -= 0.0035f;
            trigger.transform.localPosition = pos;
        }
    }

    public void MoveTriggerBack()
    {
        if (trigger != null)
        {
            Vector3 pos = trigger.transform.localPosition;
            pos.y += 0.0035f;
            pos.z += 0.0035f;
            trigger.transform.localPosition = pos;
        }
    }

    public void FireHarpoon()
    {
        GameObject spawnHarpoon = Instantiate(harpoon, harpoonSpawnPoint.position, harpoonSpawnPoint.rotation);
        Rigidbody rb = spawnHarpoon.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(harpoonSpawnPoint.forward * harpoonSpeed, ForceMode.Impulse);
            ShootingSoundEffect.PlayOneShot(ShootingSound, 0.5f);
        }

        Destroy(spawnHarpoon, 5f);
    }

    public void ActivateSparkle()
    {
        if (sparkle != null)
        {
            sparkle.SetActive(true);
        }
    }

    public void DisableSparkle()
    {
        if (sparkle != null)
        {
            sparkle.SetActive(false);
        }
    }
}

//rb.linearVelocity = harpoonSpawnPoint.forward * harpoonSpeed;