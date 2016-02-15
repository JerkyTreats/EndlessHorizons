using UnityEngine;
using InteractableObjects;
using Needs;

namespace NPC.Action
{
    public class Eat : MonoBehaviour
    {
        Need Need;
        void Init(Need Need)
        {
            this.Need = Need; 
        }

        public bool EatMeal()
        {
            Meal toEat = GetMealFromInventory();
            if (toEat != null)
            {
                Need.IncreaseCurrentValue(toEat.NeedValue);
                return true;
            }
            return false;
        }

        Meal GetMealFromInventory()
        {
            Characters.Inventory i = gameObject.GetComponent<Characters.Inventory>();
            return (Meal)i.PopItem("meal");
        }
    }
}
