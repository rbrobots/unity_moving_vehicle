using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Cameras;
public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    GameObject player;
    public Camera fpc, cc;//player camera and car camera

    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        cc.enabled = false;//initialize car camera to false

    }

    // Update is called once per frame
    
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            if (Input.GetKey(KeyCode.E))//if player presses 'E'
            {

                fpc.enabled = false;//disable first person camera
                cc.enabled = true;//enable car camera
                
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;//enable vehicle control script
                player.SetActive(false);
                inVehicle = true;
                
            }
        }


        if (other.gameObject.tag == "Player" && inVehicle == true)
        {

            if (Input.GetKey(KeyCode.F))//if player presses 'F' - to exit vehicle
            {
       
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = false;//disable vehicle control script
                player.SetActive(true);
                inVehicle = false;

                fpc.enabled = true;//i dont think this is applied here
                cc.enabled = false;



            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {//on trying to exit trigger space
            fpc.enabled = true;//enable player camera
            cc.enabled = false;//disable car camera
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}