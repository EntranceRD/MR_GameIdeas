using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class StaticTarget:Target
    {
        #region CONSTRUCTORS
        public StaticTarget()
        {
            
        }
        #endregion

        #region PUBLIC METHODS
        public override void SetObjective(Transform o)
        {
            //Debug.Log(name + " | " + trans.parent.name + " | " + trans.parent.parent.name);
            base.SetObjective(o);
            if (trans == null) trans = GetComponent<Transform>();
            trans.position = o.position;
            var localPos = trans.localPosition;
            localPos.z -= .1f;
            trans.localPosition = localPos;
        }
        #endregion
    }
}