using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarGraph.VittorCloud
{
    public class BarGorup : MonoBehaviour
    {

        #region publicVariables
        public List<GameObject> ListOfBar;
        #endregion


        #region UnityCallBacks

        void Awake()
        {
            ListOfBar = new List<GameObject>();
        }
        #endregion


    }
}

