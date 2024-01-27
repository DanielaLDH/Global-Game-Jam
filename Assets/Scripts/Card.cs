using UnityEngine;

public class Card : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 initialPosition;

    public bool played = false;

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        // Armazena a posição inicial da carta
        initialPosition = transform.position;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        offset = transform.position - worldPoint;
    }

    void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        if (!played)
        {
            transform.position = initialPosition;
        }

    }
}
