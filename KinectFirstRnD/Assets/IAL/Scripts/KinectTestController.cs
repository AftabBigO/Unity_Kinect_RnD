using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KinectTestController : MonoBehaviour
{
    [SerializeField] private Text kinectTestText;
    KinectWrapper.NuiSkeletonData kinectNuiSkalatonData;
    KinectManager myKinectManager;
    private void Start()
    {
        myKinectManager = new KinectManager();
    }

    private void Update()
    { 

    }
}
