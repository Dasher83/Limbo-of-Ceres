using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Background
{
    public class MoveBackgroundPanels : MonoBehaviour
    {
        [SerializeField]
        private GameObject _mainBackground;
        [SerializeField]
        private GameObject _secondaryBackground;
        private float _leftEdge;
        private float _rightEdge;

        private void ResetPanel(GameObject panel)
        {
            if (panel.transform.position.x <= _rightEdge)
            {
                panel.transform.position = new Vector3(_leftEdge, 0, 0);
            }
        }

        private void Start()
        {
            _mainBackground.transform.position = Vector3.zero;
            _leftEdge = Camera.main.orthographicSize * 2 * Camera.main.aspect;
            _rightEdge = _leftEdge * -1;
            _secondaryBackground.transform.position = new Vector3(_leftEdge, 0, 0);
        }

        private void Update()
        {
            ResetPanel(_mainBackground);
            ResetPanel(_secondaryBackground);
        }
    }
}
