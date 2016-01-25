using InteractableObjects;
using UnityEngine;

namespace NPC.Action
{
    public class Cook : MonoBehaviour
    {
        static float NODE_MINIMUM_DISTANCE = 1.0f;
        NPC Owner;
        Kitchen Kitchen;
        Meal ToMake;
        float NodeTimeRemaining;
        int CurrentMealNodeIndex;
        GameObject CurrentKitchenNode;

        public void Init(Kitchen kitchen) 
        {
            Kitchen = kitchen;
            ToMake = DetermineMealToMake();
            CurrentMealNodeIndex = 0;
            Owner = gameObject.GetComponent<NPC>();
            SetCurrentNode(CurrentMealNodeIndex);

            Owner.SetDestination(CurrentKitchenNode.transform.position);
        }

        private Meal DetermineMealToMake()
        {
            return Meal.GetMeal("meal");
        }

        void Update()
        {
            if (Vector3.Distance(Owner.transform.position, CurrentKitchenNode.transform.position) < NODE_MINIMUM_DISTANCE)
            {
                UpdateMealProgress(Time.deltaTime);
            }
        }

        //Called during a kitchen update, handles how to use the progress for the cooking.
        private void UpdateMealProgress(float timeAmountToRemove)
        {
            Debug.Log("Cooking!");
            NodeTimeRemaining -= timeAmountToRemove;
            if (NodeTimeRemaining <= 0)
            {
                if (IsMealFinished())
                {
                    FinishCooking();
                }
                else
                {
                    SetCurrentNode(CurrentMealNodeIndex + 1);
                }
            }
        }

        bool IsMealFinished()
        {
            if(ToMake.GetKitchenNodeTotal() <= (CurrentMealNodeIndex + 1))
            {
                return true;
            }
            return false;
        }

        void SetCurrentNode(int IndexToSet)
        {
            CurrentMealNodeIndex = IndexToSet;
            CurrentKitchenNode = Kitchen.GetNode(ToMake.GetKitchenNode(IndexToSet));
            NodeTimeRemaining = ToMake.GetNodeCookTime(IndexToSet);
        }

        void SetCurrentNodeIndex(int IndexToSet)
        {
            CurrentMealNodeIndex = IndexToSet;
        }
        
        public void FinishCooking()
        {
            Debug.Log("Finished Cooking");
            Owner.Inventory.Add("meal", 1, Meal.GetMeal("meal"));
        }
    }
}
