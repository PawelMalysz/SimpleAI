using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        this.transform.position = new Vector3((this.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed),this.transform.position.y ,(this.transform.position.z + Input.GetAxis("Vertical") * Time.deltaTime * speed));
    }
}
