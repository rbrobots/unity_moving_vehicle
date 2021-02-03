using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Cameras;
public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    //public GameObject guiObj;
    GameObject player;
    public Camera fpc, cc;


    private CameraSwitch camswitch; // the car controller we want to use


    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        cc.enabled = false;

    }

    // Update is called once per frame
    
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            if (Input.GetKey(KeyCode.E))
            {

                fpc.enabled = false;
                cc.enabled = true;

                print("E WAS CLICKED");
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
                
            }
        }


        if (other.gameObject.tag == "Player" && inVehicle == true)
        {

            if (Input.GetKey(KeyCode.F))
            {
       
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = false;
                player.SetActive(true);
                inVehicle = false;
                fpc.enabled = true;
                cc.enabled = false;



            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fpc.enabled = true;
            cc.enabled = false;
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