using UnityEngine;
using System.Collections;

public class Hunger : MonoBehaviour {
    private int hungerLevel;
    public int hungerRate;
    private string currentState;

	// Use this for initialization
	void Start () 
    {
        hungerLevel = 100;
        currentState = "Totally Satisfied";
        InvokeRepeating("IncreaseHunger",0, (5*60));
	}
	
	void IncreaseHunger()
    {
        hungerLevel -= hungerRate;
        SetCurrentState();
    }

    void Eat(int mealValue)
    {
        hungerLevel += mealValue;
        SetCurrentState();
    }

    void SetCurrentState()
    {
        if (hungerLevel > 110)
		{
			Debug.Log("Would totally throw up right now");
		} else if (hungerLevel >= 100 && hungerLevel <= 110)
		{
			currentState = "Totally Satisfied";
			hungerLevel = 100;
		} else if (hungerLevel < 100 && hungerLevel >= 90)
		{
			currentState = "Very Full";
		} else if (hungerLevel < 90 && hungerLevel >= 80)
		{
			currentState = "Full";
		} else if (hungerLevel < 80 && hungerLevel >= 70)
		{
			currentState = "Satisfied";
		} else if (hungerLevel < 70 && hungerLevel >= 60)
		{
            currentState = "Peckish";
        } else if (hungerLevel < 60 && hungerLevel >= 30)
        {
            currentState = "Hungry";
        } else if (hungerLevel < 30 && hungerLevel >= 20)
        {
            currentState = "Starving";
        } else if (hungerLevel < 20 && hungerLevel >= 0)
        {
            currentState = "Dangerously Hungry";
        }
        CancelInvoke("IncreaseHunger");
        InvokeRepeating("IncreaseHunger",0,(5*60)); //reset the hunger timer to be every 5 minutes again
		Debug.Log(currentState);
    }
}
