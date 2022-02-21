using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectorManager : MonoBehaviour
{
    //serializedField the gameobject and to create a 2*2 array.
    //followed by the online tutorial


    public Text playerName;
    string [,] nameList = {{"red man", "green man"},{"blue man","super man"}};

    public GameObject selector;
    public GameObject[]row1;
    public GameObject[]row2;

    //make a 2 by 2 array
    int cols;
    int rows = 2;

    Vector2 positionIndex;
    GameObject currentSlot;
    bool isMoving = false;

    //declear to make a 2 dimenional array
    GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        cols = row1.Length;
        grid = new GameObject[cols, rows];
        AddRowToGrid(0,row1);
        AddRowToGrid(1,row2);

        //starting point (0,0)
        positionIndex = new Vector2(0,0);
        currentSlot = grid[0,0];
    }


    void AddRowToGrid(int index, GameObject[] row){
    
        for(int i = 0; i < row.Length; i++){

            grid[index, i] = row[i];

        }
    }


    // Update is called once per frame
    void Update()
    {
        playerName.text = nameList[(int)positionIndex.y, (int)positionIndex.x];
        //move the selector
        //checking if the keyboard is pressed or not
        float x = Input.GetAxisRaw( "Horizontal" ); //returns -0,1
        float y = Input.GetAxisRaw( "Vertical" );
        MoveSelector(x,y);

        //if press the enter key
        if(Input.GetKeyDown(KeyCode.Return)){
            
            // string levelID = currentSlot.GetComponet<LevelSelectItemScript>().levelID;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        }
        
        

    }
    //void OnTriggerStay(Collider other){
       
   //}


    void MoveSelector(float x, float y)
    {
         if(isMoving == false)
         {
             
             isMoving = true;

             if(x > 0)
             {
                 if(positionIndex.x < cols -1)
                 {
                    positionIndex.x += 1;
                 }
                
             }
             else if(x < 0){

                 if(positionIndex.x > 0){

                     positionIndex.x -= 1;
                 }
             }
             else if(y > 0){

                 if (positionIndex.y > 0){

                     positionIndex.y -= 1;

                 }
             }
             else if( y < 0){

                 if (positionIndex.y < rows - 1){

                     positionIndex.y += 1;
                 } 
             }
         }
         currentSlot = grid[(int)positionIndex.y, (int)positionIndex.x];
         selector.transform.position = currentSlot.transform.position;
         Invoke("ResetMoving", 0.1f);
    }

    void ResetMoving(){
        isMoving = false;
    }

}

