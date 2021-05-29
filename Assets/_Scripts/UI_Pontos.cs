using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour
{
   Text textComp;
   GameManager gm;
   void Start()
   {
       textComp = GetComponent<Text>();
       gm = GameManager.GetInstance();
   }
   
   void Update()
   {
        if (gm.playerMoney == 0)
        {
            textComp.text = "0";
        }
        else
        {
            textComp.text = gm.playerMoney.ToString();
        }
    }
}