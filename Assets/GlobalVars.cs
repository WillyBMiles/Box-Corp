using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{

    public static GlobalVars instance;
    public int money;

    public Text moneyText;

    public bool overUI;

    public float uiPos;

    public MoneyText textObject;

    public int incinerations = 0;
    public int deliveries = 0;
    public int failures = 0;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        moneyText.text = "Money: $" + money + "\n"+"Incinerations: " + incinerations + "\nDeliveries: " + deliveries + "\nFailures: " + failures;

        overUI = ((float) Input.mousePosition.y) / Screen.height < uiPos;

    }

    public void CostMoney(int cost, Vector3 point)
    {
        money = Mathf.Max(0, money - cost);

        MoneyText newObj = Instantiate(textObject, point, Quaternion.identity);
        newObj.Apply("-$" + cost, Color.red);
    }

    public void GainMoney(int amount, Vector3 point)
    {
        money += amount;

        MoneyText newObj = Instantiate(textObject, point, Quaternion.identity);
        newObj.Apply("+$" + amount, Color.green);
    }
}
