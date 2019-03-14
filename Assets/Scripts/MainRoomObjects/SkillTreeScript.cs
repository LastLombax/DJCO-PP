using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkillTreeScript : MonoBehaviour
{
    Dictionary<string, GameObject> buttons;
    Dictionary<string, SkillTreeNode> nodes;
    public GameObject SkillTreeUI;
    private GameObject player;
    private Vector3 PlayerPos;
    
    void Start()
    {
        player = GameObject.Find("Player");
        buttons = new Dictionary<string, GameObject>();
        nodes = new Dictionary<string, SkillTreeNode>();

        if(player.GetComponent<PlayerSkills>().GetFireballTree().Count == 0)
        {
            CreateSkillTreeFireBall();
        } else
        {
            nodes = player.GetComponent<PlayerSkills>().GetFireballTree();
        }
        if (player.GetComponent<PlayerSkills>().GetChainTree().Count == 0)
        {
            CreateSkillTreeChainLightning();
        } else
        {
            nodes = player.GetComponent<PlayerSkills>().GetChainTree();
        }
        if (player.GetComponent<PlayerSkills>().GetPoisonTree().Count == 0)
        {
            CreateSkillTreePoisonPuddle();
        } else
        {
            nodes = player.GetComponent<PlayerSkills>().GetPoisonTree();
        }
        UpdateButtonsStatus();
    }

    private void CreateSkillTreeFireBall()
    {
        SkillTreeNode fb1 = new SkillTreeNode("fb1", 10, 2, (float)0.2); // first node of the fireball tree. Gives +20%dmg
        SkillTreeNode fb2 = new SkillTreeNode("fb2", 10, 0, 5); // father is fb1. Gives +5range
        fb2.fathers.Add(fb1.id);
        SkillTreeNode fb3 = new SkillTreeNode("fb3", 10, 1, (float)-0.1); // father is fb1. Gives -10%cd
        fb3.fathers.Add(fb1.id);
        SkillTreeNode fb4 = new SkillTreeNode("fb4", 10, 2, (float)0.2); // father is fb1. Gives +20%dmg
        fb4.fathers.Add(fb1.id);
        SkillTreeNode fb5 = new SkillTreeNode("fb5", 10, 2, (float)0.2); // father is fb2. Gives +20%dmg
        fb5.fathers.Add(fb2.id);
        SkillTreeNode fb6 = new SkillTreeNode("fb6", 10, 1, (float)-0.2); // father is fb3. Gives -20%cd
        fb6.fathers.Add(fb3.id);
        SkillTreeNode fb7 = new SkillTreeNode("fb7", 10, 2, (float)0.2); // father is fb4. Gives +20%dmg
        fb7.fathers.Add(fb4.id);
        SkillTreeNode fb8 = new SkillTreeNode("fb8", 20, 2, (float)0.5); // father is fb5. Gives +50%dmg
        fb8.fathers.Add(fb5.id);
        SkillTreeNode fb9 = new SkillTreeNode("fb9", 20, 0, 5); // father are fb5 and fb6. Gives +5range
        fb9.fathers.Add(fb5.id); fb9.fathers.Add(fb6.id);
        SkillTreeNode fb10 = new SkillTreeNode("fb10", 20, 2, (float)0.4); // father are fb6 and fb7. Gives +40%dmg
        fb10.fathers.Add(fb6.id); fb10.fathers.Add(fb7.id);
        SkillTreeNode fb11 = new SkillTreeNode("fb11", 20, 3, 1); // father is fb7. Gives +1projectile
        fb11.fathers.Add(fb7.id);
        SkillTreeNode fb12 = new SkillTreeNode("fb12", 30, 1, (float)-0.2); // father are fb8 and fb9. Gives -20%cd
        fb12.fathers.Add(fb8.id); fb12.fathers.Add(fb9.id);
        SkillTreeNode fb13 = new SkillTreeNode("fb13", 40, 1, (float)-0.3); // father is fb12. Gives -30%cd
        fb13.fathers.Add(fb12.id);
        SkillTreeNode fb14 = new SkillTreeNode("fb14", 20, 2, (float)0.3); // father are fb10 and fb12. Gives +30%dmg
        fb14.fathers.Add(fb10.id); fb14.fathers.Add(fb12.id);
        SkillTreeNode fb15 = new SkillTreeNode("fb15", 30, 0, 5); // father are fb10 and fb11. Gives +5range
        fb15.fathers.Add(fb10.id); fb15.fathers.Add(fb11.id);
        SkillTreeNode fb16 = new SkillTreeNode("fb16", 30, 3, 1); // father is fb11. Gives +1projectile
        fb16.fathers.Add(fb11.id);
        SkillTreeNode fb17 = new SkillTreeNode("fb17", 40, 2, (float)1); // father is fb14. Gives +100%dmg
        fb17.fathers.Add(fb14.id);
        nodes.Add(fb1.id, fb1);
        nodes.Add(fb2.id, fb2);
        nodes.Add(fb3.id, fb3);
        nodes.Add(fb4.id, fb4);
        nodes.Add(fb5.id, fb5);
        nodes.Add(fb6.id, fb6);
        nodes.Add(fb7.id, fb7);
        nodes.Add(fb8.id, fb8);
        nodes.Add(fb9.id, fb9);
        nodes.Add(fb10.id, fb10);
        nodes.Add(fb11.id, fb11);
        nodes.Add(fb12.id, fb12);
        nodes.Add(fb13.id, fb13);
        nodes.Add(fb14.id, fb14);
        nodes.Add(fb15.id, fb15);
        nodes.Add(fb16.id, fb16);
        nodes.Add(fb17.id, fb17);
    }

    private void CreateSkillTreeChainLightning()
    {
        SkillTreeNode chain1 = new SkillTreeNode("chain1", 10, 6, (float)0.2); // first node of the chain tree. Gives +20%dmg
        SkillTreeNode chain2 = new SkillTreeNode("chain2", 10, 7, 1); // father is chain1. Gives +1bounce
        chain2.fathers.Add(chain1.id);
        SkillTreeNode chain3 = new SkillTreeNode("chain3", 10, 5, (float)-0.2); // father is chain1. Gives -20%cd
        chain3.fathers.Add(chain1.id);
        SkillTreeNode chain4 = new SkillTreeNode("chain4", 10, 6, (float)0.2); // father is chain1. Gives +20%dmg
        chain4.fathers.Add(chain1.id);
        SkillTreeNode chain5 = new SkillTreeNode("chain5", 10, 6, (float)0.2); // father is chain2. Gives +20%dmg
        chain5.fathers.Add(chain2.id);
        SkillTreeNode chain6 = new SkillTreeNode("chain6", 20, 7, 1); // father is chain3. Gives +1bounce
        chain6.fathers.Add(chain3.id);
        SkillTreeNode chain7 = new SkillTreeNode("chain7", 10, 6, (float)0.3); // father is chain4. Gives +30%dmg
        chain7.fathers.Add(chain4.id);
        SkillTreeNode chain8 = new SkillTreeNode("chain8", 20, 5, (float)-0.2); // father is chain5. Gives -20%cd
        chain8.fathers.Add(chain5.id);
        SkillTreeNode chain9 = new SkillTreeNode("chain9", 10, 6, (float)0.2); // father are chain5 and chain6. Gives +20%dmg
        chain9.fathers.Add(chain5.id); chain9.fathers.Add(chain6.id);
        SkillTreeNode chain10 = new SkillTreeNode("chain10", 10, 4, 5); // father are chain6 and chain7. Gives +5range
        chain10.fathers.Add(chain6.id); chain10.fathers.Add(chain7.id);
        SkillTreeNode chain11 = new SkillTreeNode("chain11", 10, 7, 1); // father is chain7. Gives +1bounce
        chain11.fathers.Add(chain7.id);
        SkillTreeNode chain12 = new SkillTreeNode("chain12", 20, 4, 10); // father are chain8 and chain9. Gives +10range
        chain12.fathers.Add(chain8.id); chain12.fathers.Add(chain9.id);
        SkillTreeNode chain13 = new SkillTreeNode("chain13", 20, 5, (float)-0.2); // father is chain10. Gives -20%cd
        chain13.fathers.Add(chain10.id);
        SkillTreeNode chain14 = new SkillTreeNode("chain14", 30, 7, 2); // father is chain11. Gives +2bounces
        chain14.fathers.Add(chain11.id);
        SkillTreeNode chain15 = new SkillTreeNode("chain15", 30, 4, 10); // father is chain12. Gives +10range
        chain15.fathers.Add(chain12.id);
        SkillTreeNode chain16 = new SkillTreeNode("chain16", 50, 5, (float)-0.3); // father are chain12 and chain13. Gives -30%cd
        chain16.fathers.Add(chain12.id); chain16.fathers.Add(chain13.id);
        SkillTreeNode chain17 = new SkillTreeNode("chain17", 30, 6, (float)0.5); // father are chain13 and chain14. Gives +50%dmg
        chain17.fathers.Add(chain13.id); chain17.fathers.Add(chain14.id);
        SkillTreeNode chain18 = new SkillTreeNode("chain18", 30, 6, (float)0.4); // father is chain15. Gives +40%dmg
        chain18.fathers.Add(chain15.id);
        SkillTreeNode chain19 = new SkillTreeNode("chain19", 40, 6, (float)1); // father are chain16 and chain17. Gives +100%dmg
        chain19.fathers.Add(chain16.id); chain19.fathers.Add(chain17.id);
        nodes.Add(chain1.id, chain1);
        nodes.Add(chain2.id, chain2);
        nodes.Add(chain3.id, chain3);
        nodes.Add(chain4.id, chain4);
        nodes.Add(chain5.id, chain5);
        nodes.Add(chain6.id, chain6);
        nodes.Add(chain7.id, chain7);
        nodes.Add(chain8.id, chain8);
        nodes.Add(chain9.id, chain9);
        nodes.Add(chain10.id, chain10);
        nodes.Add(chain11.id, chain11);
        nodes.Add(chain12.id, chain12);
        nodes.Add(chain13.id, chain13);
        nodes.Add(chain14.id, chain14);
        nodes.Add(chain15.id, chain15);
        nodes.Add(chain16.id, chain16);
        nodes.Add(chain17.id, chain17);
        nodes.Add(chain18.id, chain18);
        nodes.Add(chain19.id, chain19);
    }

    private void CreateSkillTreePoisonPuddle()
    {
        SkillTreeNode poison1 = new SkillTreeNode("poison1", 10, 10, (float)0.2); // first node of the poison tree. Gives +20%dmg
        SkillTreeNode poison2 = new SkillTreeNode("poison2", 10, 9, (float)-0.2); // father is poison1. Gives -20%cd
        poison2.fathers.Add(poison1.id);
        SkillTreeNode poison3 = new SkillTreeNode("poison3", 10, 10, (float)0.3); // father is poison1. Gives +30%dmg
        poison3.fathers.Add(poison1.id);
        SkillTreeNode poison4 = new SkillTreeNode("poison4", 10, 8, 5); // father is poison1. Gives +5range
        poison4.fathers.Add(poison1.id);
        SkillTreeNode poison5 = new SkillTreeNode("poison5", 10, 9, (float)-0.1); // father is poison2. Gives -10%cd
        poison5.fathers.Add(poison2.id);
        SkillTreeNode poison6 = new SkillTreeNode("poison6", 10, 10, (float)0.2); // father are poison2 and poison3. Gives +20%dmg
        poison6.fathers.Add(poison2.id); poison6.fathers.Add(poison3.id);
        SkillTreeNode poison7 = new SkillTreeNode("poison7", 10, 10, (float)0.3); // father are poison3 and poison4. Gives +30%dmg
        poison7.fathers.Add(poison3.id); poison7.fathers.Add(poison4.id);
        SkillTreeNode poison8 = new SkillTreeNode("poison8", 20, 9, (float)-0.2); // father is poison4. Gives -20%cd
        poison8.fathers.Add(poison4.id);
        SkillTreeNode poison9 = new SkillTreeNode("poison9", 10, 8, 5); // father is poison5. Gives +5range
        poison9.fathers.Add(poison5.id);
        SkillTreeNode poison10 = new SkillTreeNode("poison10", 30, 9, (float)-0.2); // father is poison6. Gives -20%cd
        poison10.fathers.Add(poison6.id);
        SkillTreeNode poison11 = new SkillTreeNode("poison11", 30, 11, (float)0.5); // father are poison6 and poison7. Gives +50%ToE
        poison11.fathers.Add(poison6.id); poison11.fathers.Add(poison7.id);
        SkillTreeNode poison12 = new SkillTreeNode("poison12",10, 10, (float)0.2); // father are poison7 and poison8. Gives +20%dmg
        poison12.fathers.Add(poison7.id); poison12.fathers.Add(poison8.id);
        SkillTreeNode poison13 = new SkillTreeNode("poison13", 20, 11, (float)0.5); // father is poison8. Gives +50%ToE
        poison13.fathers.Add(poison8.id);
        SkillTreeNode poison14 = new SkillTreeNode("poison14", 30, 10, (float)0.5); // father is poison9. Gives +50%dmg
        poison14.fathers.Add(poison9.id);
        SkillTreeNode poison15 = new SkillTreeNode("poison15", 20, 10, (float)0.3); // father are poison10 and poison11. Gives +30%dmg
        poison15.fathers.Add(poison10.id); poison15.fathers.Add(poison11.id);
        SkillTreeNode poison16 = new SkillTreeNode("poison16", 30, 8, 10); // father is poison12. Gives +10range
        poison16.fathers.Add(poison12.id);
        SkillTreeNode poison17 = new SkillTreeNode("poison17", 30, 9, (float)-0.2); // father are poison14 and poison15. Gives -20%cd
        poison17.fathers.Add(poison14.id); poison17.fathers.Add(poison15.id);
        SkillTreeNode poison18 = new SkillTreeNode("poison18", 40, 10, (float)1); // father are poison16 and poison17. Gives +100%dmg
        poison18.fathers.Add(poison16.id); poison18.fathers.Add(poison17.id);
        nodes.Add(poison1.id, poison1);
        nodes.Add(poison2.id, poison2);
        nodes.Add(poison3.id, poison3);
        nodes.Add(poison4.id, poison4);
        nodes.Add(poison5.id, poison5);
        nodes.Add(poison6.id, poison6);
        nodes.Add(poison7.id, poison7);
        nodes.Add(poison8.id, poison8);
        nodes.Add(poison9.id, poison9);
        nodes.Add(poison10.id, poison10);
        nodes.Add(poison11.id, poison11);
        nodes.Add(poison12.id, poison12);
        nodes.Add(poison13.id, poison13);
        nodes.Add(poison14.id, poison14);
        nodes.Add(poison15.id, poison15);
        nodes.Add(poison16.id, poison16);
        nodes.Add(poison17.id, poison17);
        nodes.Add(poison18.id, poison18);
    }
    public void Update(){
        if (SkillTreeUI.activeSelf){
            player.transform.position = PlayerPos;
            if (Input.GetKey(KeyCode.Escape))
                CloseTree();
        }
    }

    public void ShowTree()
    {
        PlayerPos = player.transform.position;
        SkillTreeUI.SetActive(true);
        UpdateButtonsStatus();
    }

    public void CloseTree()
    {
        SkillTreeUI.SetActive(false);
        if(gameObject.tag.Equals("FireBallSkillTree"))
        {
            player.GetComponent<PlayerSkills>().StoreFireballTree(nodes);
        }
        if (gameObject.tag.Equals("ChainSkillTree"))
        {
            player.GetComponent<PlayerSkills>().StoreChainTree(nodes);
        }
        if (gameObject.tag.Equals("PoisonSkillTree"))
        {
            player.GetComponent<PlayerSkills>().StorePoisonTree(nodes);
        }
    }
    
    public void UpgradeSkill(string id)
    {
        if(!player.GetComponent<PlayerSkills>().HasEnoughXP(nodes[id].GetXpPrice()))
        {
            Debug.Log("Not enough xp for that");
            return;
        }
        foreach (string fatherId in nodes[id].fathers)
        {
            Debug.Log(fatherId);
            if(!nodes[fatherId].IsActive())
            {
                Debug.Log("Missing some nodes for that one...");
                return;
            }
        }
        if(nodes[id].IsActive())
        {
            Debug.Log("Already picked that node!");
            return;
        }
        player.GetComponent<PlayerSkills>().UpgradeSkill(nodes[id].GetUpgradeType(), nodes[id].GetValue());
        nodes[id].Activate();
        player.GetComponent<PlayerSkills>().UseXP(nodes[id].GetXpPrice());
        UpdateButtonsStatus();
    }

    public void AddButtonToSkillTree(string id, GameObject button)
    {
        buttons.Add(id, button);
        UpdateButtonsStatus();
    }

    public void UpdateButtonsStatus()
    {
        foreach(string id in buttons.Keys)
        {
            if(nodes[id].IsActive())
            {
                buttons[id].GetComponent<SkillTreeButton>().UpdateColorActivated();
                continue;
            }
            if(player.GetComponent<PlayerSkills>().HasEnoughXP(nodes[id].GetXpPrice()))
            {
                bool fathersAreActive = true;
                foreach (string fatherId in nodes[id].fathers)
                {
                    if (!nodes[fatherId].IsActive())
                    {
                        fathersAreActive = false;
                    }
                }
                if(fathersAreActive)
                {
                    buttons[id].GetComponent<SkillTreeButton>().UpdateColorAbleToBuy();
                    continue;
                }
            }
            buttons[id].GetComponent<SkillTreeButton>().UpdateColorUnableToBuy();
        }
    }
}

public class SkillTreeNode
{
    public ArrayList fathers;
    private bool isActive = false;
    public string id;
    private int xpPrice;
    private int upgradeType;
    private float value;

    public SkillTreeNode(string id, int xpPrice, int upgradeType, float value)
    {
        fathers = new ArrayList();
        this.id = id;
        this.xpPrice = xpPrice;
        this.upgradeType = upgradeType;
        this.value = value;
    }

    public void Activate()
    {
        isActive = true;
    }
    public bool IsActive()
    {
        return isActive;
    }

    public int GetXpPrice()
    {
        return xpPrice;
    }
    public int GetUpgradeType()
    {
        return upgradeType;
    }
    public float GetValue()
    {
        return value;
    }
}
