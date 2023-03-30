using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  //List + Name and power of players
    [SerializeField] List<GameObject> Players= new List<GameObject>();
    [SerializeField] string NamePlayer;
    [SerializeField] float PowerPlayer;

    [Header("Leaders")]
    [SerializeField] GameObject Leader;
    [SerializeField] GameObject RightLeader;
    [SerializeField] GameObject LeftLeader;

    [Header("MidCommondant")]
    
    [SerializeField] GameObject MidLeftCommondant;
    [SerializeField] GameObject MidRightCommondant;
    [SerializeField] GameObject MidCommondant;

    [Header("Soldats")]

    [SerializeField] GameObject RightSoldat;
    [SerializeField] GameObject LeftSoldat;
    [SerializeField] GameObject MidSoldat;
    [SerializeField] GameObject MidSoldat2;

    [Header("Sniper")]
    [SerializeField] GameObject Sniper;


    [Header("Leaders Current positions")]
    private Vector3 LeaderPosition;
    private Vector3 RightLeaderPosition;
    private Vector3 LeftLeaderPosition;

    [Header("Commondants Current positions")]
    private Vector3 MidLeftCommondantPosition;
    private Vector3 MidRightCommondantPosition;
    private Vector3 MidCommondantPosition;

    [Header("Soldats Current positions")]
    private Vector3 RightSoldatPosition;
    private Vector3 LeftSoldatPosition;
    private Vector3 MidSoldatPosition;
    private Vector3 MidSoldat2Position;

    [Header("sniper Current positions")]
    private Vector3 SniperPostion;




    // public float LeftLeaderPower;
  //  public float RightLeaderPower;


   private GameObject MidLeader;
    private float MidLeaderPower;
    // Start is called before the first frame update
    void Start()
    {
        LeaderPosition=Leader.transform.position;
        RightLeaderPosition=RightLeader.transform.position;
        LeftLeaderPosition=LeftLeader.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      Elminate();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                //make new gameobject to store hit(like leader) and then check if in the list then remove it and destroy it
                GameObject hitObject=hit.collider.gameObject;
                if (Players.Contains(hitObject)){
                    Players.Remove(hitObject);
                    NamePlayer= hitObject.GetComponent<PlayersSripts>().Name;
                    PowerPlayer= hitObject.GetComponent<PlayersSripts>().Power;
                    print(NamePlayer);
                    print(PowerPlayer);
                 Destroy(hitObject);
                // hitObject.SetActive(false);
                    print("destroy");
                    print(Players.Count);
                    print("Player de 0"+Players[0]);
                }
                for(int i = 1; i < Players.Count; i++)
                {
                    if (NamePlayer == "LeftLeader")
                    {
                        float LeftLeaderPower = Players[i].GetComponent<PlayersSripts>().Power;
                        GameObject LeftMidLeader = Players[i];
                    }
                    else if(NamePlayer == "RightLeader")
                    {
                       float RightLeaderPower= Players[i].GetComponent<PlayersSripts>().Power;
                        GameObject RightMidLeader = Players[i];
                    }
                    else if(NamePlayer == "Leader")
                    {
                        float MidLeaderPower = Players[i].GetComponent<PlayersSripts>().Power;
                        GameObject MidLeader = Players[i];
                    }
                   

                }




                {
                    print("L");
                    // GameObject LeftLeader = Players[0];
                    // print(LeftLeader);
                    //  GameObject MidLeader= Players[0];
                    // LeftLeader.transform.position=  Vector3.Lerp(LeftLeader.transform.position, MidLeader.transform.position, 0.5f);
                    print(Players.Count);
                }    
              //  else if (NamePlayer == "LeftLeader" && MidLeaderPower<= LeftLeaderPower)
                {
                    print("Lf");
                }
                
            }

        }
     
    }

    private void Leaders()
    {
        /*
    for(int i = 1; i < Players.Count; i++)
        {
            
                      string  LeadersNames=Players[i].GetComponent<PlayersSripts>().Name;


                        if (LeadersNames=="Leader")
                        {
                             MidLeader = Players[i];
                         MidLeaderPower=MidLeader.GetComponent<PlayersSripts>().Power;

                        }
                        else if(LeadersNames == "LeftLeader")
                        {
                        GameObject    LeftMidLeader = Players[i];
                        float    MidLeftLeaderPower = LeftMidLeader.GetComponent<PlayersSripts>().Power;
                        }
                        else if(LeadersNames == "RightLeader")
                        {
                      GameObject       RightMidLeader = Players[i];
                        float    MidRightLeaderPower = RightMidLeader.GetComponent<PlayersSripts>().Power;
                        }
                     

        //make new list contain just 3 first players (Leaders)
        List<GameObject> Leaders = Players.GetRange(0, 3);
            GameObject MidLeader = Leaders[0];
            float MidLeaderPower=MidLeader.GetComponent<PlayersSripts>().Power;
            GameObject MidLeftLeader = Leaders[1];
            float MidLeftLeaderPower = MidLeftLeader.GetComponent<PlayersSripts>().Power;
            GameObject MidRightLeader = Leaders[2];
            float MidRightLeaderPower = MidRightLeader.GetComponent<PlayersSripts>().Power;


            if(MidLeftLeader.gameObject==null)
            { 
                
                    print("A");
                
            }

           
        }
    
  
          */
    }


    private void Commondant()
    {
        //make another list contain just 3 player (Commondants)
    }
    private void Soldat()
    {
        //make another list contain just 4 player (Soldats)
    }

    private void Snipe()
    {
        //make another list contain just 1 player (Sniper)
    }


    private void Elminate() {
       if (Leader.gameObject== null) {
             print("leader eleminate ");
            
             if (Leader.gameObject==null && LeftLeader.gameObject!=null && RightLeader.gameObject != null && LeftLeader.GetComponent<PlayersSripts>().Power > RightLeader.GetComponent<PlayersSripts>().Power)

             {
             //   print(RightLeader.GetComponent<PlayersSripts>().Power);
             //   print(LeftLeader.GetComponent<PlayersSripts>().Power);
                 LeftLeader.transform.position = Vector3.Lerp(LeftLeader.transform.position, LeaderPosition, 2 * Time.deltaTime);
             }
            if(Leader.gameObject== null && LeftLeader.gameObject != null && RightLeader.gameObject != null &&  RightLeader.GetComponent<PlayersSripts>().Power > LeftLeader.GetComponent<PlayersSripts>().Power)
            {
                RightLeader.transform.position = Vector3.Lerp(RightLeader.transform.position, LeaderPosition, 2 * Time.deltaTime);;
            }
          

        }
       if(LeftLeader.gameObject== null)
        {
            if (LeftLeader.gameObject == null && MidLeftCommondant.gameObject != null && MidCommondant.gameObject != null && MidLeftCommondant.GetComponent<PlayersSripts>().Power > MidCommondant.GetComponent<PlayersSripts>().Power)
            {
                MidLeftCommondant.transform.position = Vector3.Lerp(MidLeftCommondant.transform.position, LeftLeaderPosition, 2 * Time.deltaTime);
            }
            if (LeftLeader.gameObject == null && MidLeftCommondant.gameObject != null && MidCommondant.gameObject != null && MidCommondant.GetComponent<PlayersSripts>().Power > MidLeftCommondant.GetComponent<PlayersSripts>().Power)
            {
                MidCommondant.transform.position = Vector3.Lerp(MidCommondant.transform.position, LeftLeaderPosition, 2 * Time.deltaTime);

            }
        }

        if (RightLeader.gameObject == null)
        {
            if (RightLeader.gameObject == null && MidRightCommondant.gameObject != null && MidCommondant.gameObject != null && MidRightCommondant.GetComponent<PlayersSripts>().Power > MidCommondant.GetComponent<PlayersSripts>().Power)
            {
                MidRightCommondant.transform.position = Vector3.Lerp(MidRightCommondant.transform.position, RightLeaderPosition, 2 * Time.deltaTime);
            }
            if (RightLeader.gameObject == null && MidRightCommondant.gameObject != null && MidCommondant.gameObject != null && MidCommondant.GetComponent<PlayersSripts>().Power > MidRightCommondant.GetComponent<PlayersSripts>().Power)
            {
                MidCommondant.transform.position = Vector3.Lerp(MidCommondant.transform.position, RightLeaderPosition, 2 * Time.deltaTime);

            }
        }

    }
        
    }

