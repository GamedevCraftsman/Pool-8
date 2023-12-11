using UnityEngine;

public class CueBlow : MonoBehaviour
{
    [SerializeField] Transform ballPoint;
    [SerializeField] float power = 1.0f;
    
    Rigidbody cueRb;
    private void Start()
    {
        cueRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Blow!!!");
            Vector3 hitDirection = transform.right;
            hitDirection = new Vector3(hitDirection.x, 0, hitDirection.z).normalized;
            cueRb.AddForce(hitDirection * power, ForceMode.Impulse);
        }
    }
}
