using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string HorizontalMouseAxis = "Mouse X";
    private const string VerticalMouseAxis = "Mouse Y";

    public Vector3 InputDirection => new Vector3(Input.GetAxis(HorizontalAxis), 0, Input.GetAxis(VerticalAxis));
    public Vector3 MouseDirection => new Vector3(Input.GetAxis(HorizontalMouseAxis), Input.GetAxis(VerticalMouseAxis), 0);
}
