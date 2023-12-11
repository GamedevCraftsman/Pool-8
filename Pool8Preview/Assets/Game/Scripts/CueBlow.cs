using UnityEngine;

public class CueBlow : MonoBehaviour
{

    [SerializeField] float power = 1.0f;
    
    Rigidbody cueRb;
    private void Start()
    {
        cueRb = GetComponent<Rigidbody>();
    }

    public void BlowButton()
    {
        Vector3 hitdirection = transform.forward;
        hitdirection = new Vector3(hitdirection.x, 0, hitdirection.z).normalized;

        cueRb.AddForce(hitdirection * power, ForceMode.Impulse);
    }
}
