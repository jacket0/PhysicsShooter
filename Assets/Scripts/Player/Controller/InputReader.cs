using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Vector3 InputDirection => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    public Vector3 MouseDirection => new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
}
