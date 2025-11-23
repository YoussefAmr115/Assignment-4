using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        // Get keyboard input (WASD / arrow keys)
        float h = Input.GetAxisRaw("Horizontal"); // A / D or ← / →
        float v = Input.GetAxisRaw("Vertical");   // W / S or ↑ / ↓

        // Direction on the XZ plane
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // Move the player
        if (direction.sqrMagnitude > 0.01f)
        {
            // Move in world space
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // Face movement direction
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            AnimationManager.Instance.ToggleDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            AnimationManager.Instance.ToggleDoor();
        }
    }
}
