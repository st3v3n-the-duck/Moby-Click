using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource Wailing;
    public AudioClip Target_Hit;
    [SerializeField] private Vector3 rotationOnHit = new Vector3(45f, 0f, 0f); // Adjustable in Inspector

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Harpoon"))
        {
            Destroy(other.gameObject);

            // Use adjustable rotation value
            transform.Rotate(rotationOnHit);

            if (Wailing != null && Target_Hit != null)
            {
                Wailing.PlayOneShot(Target_Hit, 0.9f);
            }

            StartCoroutine(DestroyAfterDelay(2f));
        }
    }

    private System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
