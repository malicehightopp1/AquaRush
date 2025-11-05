using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SCameraRig : MonoBehaviour
{
    [SerializeField] float mHeightOffset = 0.5f;
    [SerializeField] float mBackOffset = 1;
    [SerializeField] float mFollowLerpRate = 20f;

    private Camera mCamera;
    Transform mFollowTransform;

    private void Start()
    {
        mCamera = Camera.main;
    }
    private void Update()
    {
        ObjectsDestroy();
    }
    public void SetFollowTransform(Transform followTransform) 
    {
        mFollowTransform = followTransform;
    }
    private void LateUpdate() //changing the cameras distance variables
    {
        if(mFollowTransform == null)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, mFollowTransform.position + (mBackOffset * Vector3.back) + (mHeightOffset * Vector3.up), mFollowLerpRate * Time.deltaTime);
    }
    private void ObjectsDestroy()
    {
        GameObject[] targetObj = GameObject.FindGameObjectsWithTag("Coin");
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mCamera);
        foreach (GameObject obj in targetObj)
        {
            Renderer objRender = obj.GetComponent<Renderer>();
            if (objRender != null && !GeometryUtility.TestPlanesAABB(planes, objRender.bounds)) //checking if objects are in bounds of camera view/frustum plane
            {
                Destroy(obj.transform.gameObject, 1f);
            }
        }
        GameObject[] HitOBJ = GameObject.FindGameObjectsWithTag("HitOBJ");
        Plane[] planes2 = GeometryUtility.CalculateFrustumPlanes(mCamera);
        foreach (GameObject hit in HitOBJ)
        {
            Renderer obj1Render = hit.GetComponent<Renderer>();
            if (obj1Render != null && !GeometryUtility.TestPlanesAABB(planes2, obj1Render.bounds)) //checking if objects are in bounds of camera view/frustum plane
            {
                Destroy(hit.transform.gameObject, 1f);
            }
        }
    }
}
