using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceObjects : MonoBehaviour
{

    public float rayRange = 100f;
    //public Transform wallTransform;
    public Vector3 placementLocation = new Vector3(0f,0f,-2f);//-z
    public GameObject explosive, crate;
    

    bool isCrateSelected = true;
    bool isExplosiveSelected = false;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            ShootRay();
            //Debug.Log("shot");
        }

      /*  if (Input.GetKeyDown(KeyCode.A))
        {
            isCrateSelected = true;
            isExplosiveSelected = false;
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            isCrateSelected = false;
            isExplosiveSelected = true;
        }

*/
    }//Update

    void ShootRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayRange))
        {

            if (hit.transform.tag == "Wall")
            {
                PlaceObject(hit);
                
            }

        }//ray
    }//ShootRay

    private void PlaceObject(RaycastHit hit)
    {

        if (isCrateSelected)
        {
            Instantiate(crate, hit.point + placementLocation, hit.transform.rotation);
        }else if (isExplosiveSelected)
        {
            Instantiate(explosive, hit.point + placementLocation, hit.transform.rotation);
        }

    }//PlaceObject


    public void ChangeToCrateSelection()
    {
        isCrateSelected = true;
        isExplosiveSelected = false;
    }
    public void ChangeToExplosiveSelection()
    {
        isCrateSelected = false;
        isExplosiveSelected = true;
    }


    public void CrateToggleClicked()
    {
       /* if (explosiveToggle.isOn == true)
        {
            explosiveToggle.isOn = false;
        }

        crateToggle.isOn = true;
*/
        ChangeToCrateSelection();
    }

    public void ExdplosiveToggleClicked()
    {
       /* if (crateToggle.isOn == true)
        {
            crateToggle.isOn = false;
        }

        explosiveToggle.isOn = true;
*/
        ChangeToExplosiveSelection();
    }

}
