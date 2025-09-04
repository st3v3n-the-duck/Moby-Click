using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemies; 
    [SerializeField] private Transform pointA;  
    [SerializeField] private Transform pointB;   

    private GameObject currentEnemy;

    /*
    public AudioSource Wailing;
    public AudioClip Target_Hit;
    [SerializeField] private Vector3 rotationOnHit = new Vector3(45f, 0f, 0f); // Adjustable in Inspector
    */

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemies != null)
        {
            currentEnemy = Instantiate(enemies, transform.position, transform.rotation);


            Movement movement = currentEnemy.GetComponent<Movement>();
            if (movement != null)
            {
                movement.pointA = pointA;
                movement.pointB = pointB;
            }

            
            StartCoroutine(RespawnAfterDelay(37f));
            
        }
    }

    private System.Collections.IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }

        SpawnEnemy();

    }


   /*
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
   */

}
