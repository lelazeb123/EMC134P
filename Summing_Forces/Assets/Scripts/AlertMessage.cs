using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertMessage : MonoBehaviour
{
    
    public GameObject ship;
    Text textUI;
    private bool flashing;
    public bool isTrue;
   


    // Start is called before the first frame update
    void Start(){
        textUI = GetComponent<Text>();
        ship = GameObject.Find("SpaceFighter");
    }

    // Update is called once per frame
    void Update(){
        if (isTrue == false){
            FlashingText();
            isTrue = true;
        }
    }

    void FlashingText(){
        flashing = ship.GetComponent<PhysicsEngine>().netForceCheck;
        if (flashing){
            StartCoroutine(FlashBalanced());
        }
        else{
            StartCoroutine(FlashUnbalanced());
        }
    }


    IEnumerator FlashBalanced(){   // When the Forces are balanced, this code will display the success message.
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.green;
            textUI.text = "Balanced Force, Spaceship go zooooom!";
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator FlashUnbalanced(){// When the Forces are unbalanced, this code will display the error message.
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(1f);
        }
    }
}