using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedCamera = 3.0f;
    public GameObject moveTo;

    private Vector3 _camPosition;
    private Vector3 _moveCamTo;
    // Start is called before the first frame update
    void Start()
    {
        _camPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            _moveCamTo = Vector3.MoveTowards(gameObject.transform.position, moveTo.transform.position,
                    speedCamera * Time.deltaTime);
            gameObject.transform.position = new Vector3(_moveCamTo.x, _camPosition.y, _camPosition.z);
        }
        catch (MissingReferenceException e)
        {
        }

    }
}
