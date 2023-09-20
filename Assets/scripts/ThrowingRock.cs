using UnityEngine;

public class ThrowingRock : MonoBehaviour
{
    public GameObject stonePrefab;
    public float throwForce = 10f;

    private GameObject currentStone;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
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

        Rigidbody2D stoneRigidbody = stone.GetComponent<Rigidbody2D>();
        stoneRigidbody.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
    }


}
