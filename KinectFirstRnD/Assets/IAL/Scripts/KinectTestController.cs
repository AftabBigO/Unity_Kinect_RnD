using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KinectTestController : MonoBehaviour
{
    [SerializeField] private GameObject fallingObjectPrefab, fallingObjectParent;
    [SerializeField] private Text kinectTestText;
    [SerializeField] private GameObject kinectSkeletalView;
    private Texture2D kinectTexture;
    private KinectManager myKinectManager;
    private Renderer kinectViewRenderer;
    private static bool isPlayerFounded=false, isCalledActivate=false, isCalledDeActivate=false;

    private void Start()
    {
        myKinectManager =KinectManager.Instance;
        kinectViewRenderer = kinectSkeletalView.GetComponent<Renderer>();
    }

    private void Update()
    {
        GetKinectStatus();
        
        kinectTestText.text = isPlayerFounded ? "Player founded" : "Player not founded";
        kinectSkeletalView.SetActive(isPlayerFounded ? true : false);
        if(isPlayerFounded)
        {
            //kinectTexture= myKinectManager.GetUsersClrTex();
            kinectTexture = myKinectManager.GetUsersLblTex();
            kinectViewRenderer.material.mainTexture = kinectTexture;
            isCalledDeActivate = false;
            if(!isCalledActivate)
            {
                ActivateFallingObjects();
            }
        }
        else
        {
            isCalledActivate = false;
            if(!isCalledDeActivate)
            {
                DestroyFallingObject();
            }
        }
    }
    
    private bool GetKinectStatus()
    {    
        return isPlayerFounded= myKinectManager.IsUserDetected() ? true : false;
    }

    private void ActivateFallingObjects()
    {
        isCalledActivate = true;
        GameObject fallingGameObject = Instantiate(fallingObjectPrefab, fallingObjectParent.transform);
    }

    private void DestroyFallingObject()
    {
        isCalledDeActivate = true;
        Destroy(GameObject.Find("FallingCube"));
    }
   
}