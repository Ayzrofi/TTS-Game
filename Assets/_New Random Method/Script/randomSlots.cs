using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomSlots : MonoBehaviour {

    public int ammountOfSlot;
   
    public Transform SlotsParent;

    ////versi between Two Soul
    //public List<GameObject> SlotsPrefabs = new List<GameObject>();
    //int DeffrentPos, rand;

    //versi manipulasi random gameobject
    public List<GameObject> SlotsPrefabs = new List<GameObject>();

    // versi manipulasi random text
    //public List<string> SlotName = new List<string>();
    //public GameObject SlotsPrefabs;



    private void Start()
    {
        //randomBetweenTwoSoul();

        // use this only for random text or gameobject 
        for (int i = 0; i < ammountOfSlot; i++)
        {

            //versi manipulasi random gameobject
            int rand = Random.Range(0, SlotsPrefabs.Count);

            GameObject go = Instantiate(SlotsPrefabs[rand], SlotsParent.transform, false);
            SlotsPrefabs.RemoveAt(rand);



            //versi manipulasi random text
            //int rand = Random.Range(0, SlotName.Count);
            //GameObject go = Instantiate(SlotsPrefabs, SlotsParent.transform, false) as GameObject;
            //go.name = "Slot";
            //go.transform.GetComponentInChildren<Text>().text = SlotName[rand];
            //SlotName.RemoveAt(rand);

        }
    }
    //versi random between two soul
    //public void randomBetweenTwoSoul()
    //{
    //    DeffrentPos = Random.Range(0, ammountOfSlot);
    //    rand = Random.Range(0, 2);
    //    for (int i = 0; i < ammountOfSlot; i++)
    //    {
    //        if (i == DeffrentPos)
    //        {
    //            if (rand == 0)
    //                CreateSlot(SlotsPrefabs[1], SlotsParent, false);
    //            else
    //                CreateSlot(SlotsPrefabs[0], SlotsParent, false);
    //        }
    //        else
    //        {
    //            if (rand == 0)
    //                CreateSlot(SlotsPrefabs[0], SlotsParent, false);
    //            else
    //                CreateSlot(SlotsPrefabs[1], SlotsParent, false);
    //        }

    //    }
    //}
    //creating slots
    //public void CreateSlot(GameObject Go, Transform parent, bool wordPos)
    //{
    //    Instantiate(Go, parent.transform, wordPos);
    //}
}
