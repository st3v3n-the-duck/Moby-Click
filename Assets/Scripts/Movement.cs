using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    [SerializeField] private float speed = 2f;

    private Transform target;
    private bool canMove = true;

    private void Start()
    {
        if (pointA != null)
        {
            transform.position = pointA.position;
            target = pointB;
        }
    }

    private void Update()
    {
        if (!canMove || pointA == null || pointB == null) return;

       
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        
        transform.LookAt(target.position);

      
        if (transform.position == target.position)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Harpoon"))
        {
            canMove = false;
        }
    }
}


