using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeButton : MonoBehaviour
{
    public GameObject skillTree;
    public string buffID;
    // Start is called before the first frame update
    void Start()
    {
        skillTree.GetComponent<SkillTreeScript>().AddButtonToSkillTree(buffID, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColorActivated()
    {
        GetComponent<Image>().color = Color.green;
    }

    public void UpdateColorAbleToBuy()
    {
        GetComponent<Image>().color = Color.white;
    }

    public void UpdateColorUnableToBuy()
    {
        GetComponent<Image>().color = Color.grey;
    }
    

    public void OnMouseEnter()
    {
        skillTree.GetComponent<SkillTreeScript>().UpdateDescription(buffID);
    }

    public void OnMouseExit()
    {
        skillTree.GetComponent<SkillTreeScript>().UpdateDescription("none");
    }
}
