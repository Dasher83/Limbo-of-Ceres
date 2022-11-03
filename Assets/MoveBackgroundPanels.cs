using UnityEngine;

public class MoveBackgroundPanels : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainBackground;
    [SerializeField]
    private GameObject _secondaryBackground;

    private void Start()
    {
        _mainBackground.transform.position = Vector3.zero;
        float newX = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        _secondaryBackground.transform.position = new Vector3(newX, 0, 0);
    }

    void Update()
    {
        // TODO: Make them move through their rigidbodies
    }
}
