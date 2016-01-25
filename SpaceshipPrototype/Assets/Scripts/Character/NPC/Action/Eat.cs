using UnityEngine;
using InteractableObjects;
using Needs;

namespace NPC.Action
{
    public class Eat : MonoBehaviour
    {
        NPCNeed Need;
        void Start()
        {
            NeedContainer nc = gameObject.GetComponent<NeedContainer>();
            Need = (NPCNeed)nc.LookUp("hunger");
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
    },
}
