using UnityEngine;
using UnityEngine.UI;

public class KinectTestController : MonoBehaviour
{
    [SerializeField] private Text kinectTestText;
    KinectManager myKinectManager;
    bool isKinectInitialized;
    private void Start()
    {
        myKinectManager =KinectManager.Instance;
    }

    private void Update()
    {
        GetKinectStatus();
    }
    
    private void GetKinectStatus()
    {
        isKinectInitialized = myKinectManager.IsInitialized();
        kinectTestText.text = isKinectInitialized.ToString();
    }
}