using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LuminateCamping.Scripts
{

    public interface IPickable
    {
        public void OnPickable(Transform parent, LiftingObjects data);

    }
}