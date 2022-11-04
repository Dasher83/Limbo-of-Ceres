using QuarkJam1Team1.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarkJam1Team1
{
    public class PositionSecondaryBackground : MonoBehaviour
    {
        private void Start()
        {
            gameObject.transform.position = new Vector3(CameraUtils.RightEdgeInRealWorldUnits, 0, 0);
        }
    }
}
