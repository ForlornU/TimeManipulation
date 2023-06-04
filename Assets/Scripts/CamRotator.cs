using UnityEngine;

public class CamRotator : MonoBehaviour
{
    public float speed = 10f;
    private void Update()
    {
        transform.Rotate(Vector2.up * speed);
    }
}
