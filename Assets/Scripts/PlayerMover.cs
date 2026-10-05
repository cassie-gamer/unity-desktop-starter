using UnityEngine;

// Add this to a Cube in your scene to move it with WASD / arrow keys
public class PlayerMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
