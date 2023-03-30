using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField] List<GameObject> Players;
    [SerializeField] string PlayerName;
    [SerializeField] float PlayerPower;
   private Ray ray;
   private RaycastHit hit;
    public bool isClick;
   
    // Start is called before the first frame update
    void Start()
    {
      
        //make new list of gameobjects
        Players= new List<GameObject>();
        //make loop for this gameobjects
        for(int i = 1; i <= 11; i++)
        {
            //add gameobject Player with index 
            GameObject Player = new GameObject("Player" + i);
          // PlayersSripts playerStats = Player.AddComponent<PlayersSripts>();

            //add this gameobject to list 
            Players.Add(Player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check mouse click
        if (Input.GetMouseButtonDown(0))
        {
            //mouse position store coordinate of mouse click in world coordoniate
               ray=Camera.main.ScreenPointToRay(Input.mousePosition);
         
            if(Physics.Raycast(ray, out hit))
            {
               
                //if mouse position raycast on player then destroy it

                //store the hit object in GameObject and get the gameobject
                GameObject hitObject = hit.transform.gameObject;

                //if hitobjects exist in the list
                if(Players.Contains(hitObject))
                {
                    PlayersSripts playerStats = hitObject.GetComponent<PlayersSripts>();
                    PlayerName = playerStats.Name;
                        PlayerPower =playerStats.Power;
                    Players.Remove(hitObject);
                    Destroy(hitObject);
                }
            }
            
            }
        }
    }

