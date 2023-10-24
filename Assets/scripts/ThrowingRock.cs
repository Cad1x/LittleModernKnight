using UnityEngine;

public class ThrowingRock : MonoBehaviour
{
    public GameObject stonePrefab;
    public float throwForce = 10f;
    public float throwCooldown = 1f; // Czas oczekiwania miêdzy rzutami
    public float stoneLifetime = 1f; // Czas ¿ycia kamienia
    private float lastThrowTime; // Czas ostatniego rzutu
    private GameObject currentStone;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanThrow())
        {
            Throw();
            lastThrowTime = Time.time; // Aktualizuj czas ostatniego rzutu
        }
    }

    public bool CanThrow()
    {
        // SprawdŸ, czy min¹³ odpowiedni czas od ostatniego rzutu
        return Time.time - lastThrowTime >= throwCooldown;
    }

    void Throw()
    {
        if (currentStone != null)
        {
            Destroy(currentStone);
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 throwDirection = (worldMousePosition - transform.position).normalized;

        GameObject stone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
        currentStone = stone;

        Physics2D.IgnoreCollision(stone.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player1").GetComponent<Collider2D>(), true);

        float angle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;
        stone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D stoneRigidbody = stone.GetComponent<Rigidbody2D>();
        stoneRigidbody.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

        Destroy(stone, stoneLifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WeakPoint"))
        {
            Destroy(currentStone);
            // Dodaj tutaj dodatkow¹ logikê, jeœli chcesz
        }
    }
}
