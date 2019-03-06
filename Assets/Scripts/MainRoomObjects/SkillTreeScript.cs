using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkillTreeScript : MonoBehaviour
{
    Dictionary<string, SkillTreeNode> nodes;
    public GameObject SkillTreeUI;
    private GameObject player;
    private Vector3 PlayerPos;
    private int type = 0;
    private float value = 0;

    void Start()
    {
        player = GameObject.Find("Player");

        nodes = new Dictionary<string, SkillTreeNode>();

        CreateSkillTreeFireBall();
        CreateSkillTreeChainLightning();
    }

    private void CreateSkillTreeFireBall()
    {
        SkillTreeNode fb1 = new SkillTreeNode("fb1"); // first node of the fireball tree. Gives +20%dmg
        SkillTreeNode fb2 = new SkillTreeNode("fb2"); // father is fb1. Gives +5range
        fb2.fathers.Add(fb1.id);
        SkillTreeNode fb3 = new SkillTreeNode("fb3"); // father is fb1. Gives -10%cd
        fb3.fathers.Add(fb1.id);
        SkillTreeNode fb4 = new SkillTreeNode("fb4"); // father is fb1. Gives +20%dmg
        fb4.fathers.Add(fb1.id);
        SkillTreeNode fb5 = new SkillTreeNode("fb5"); // father is fb2. Gives +20%dmg
        fb5.fathers.Add(fb2.id);
        SkillTreeNode fb6 = new SkillTreeNode("fb6"); // father is fb3. Gives -20%cd
        fb6.fathers.Add(fb3.id);
        SkillTreeNode fb7 = new SkillTreeNode("fb7"); // father is fb4. Gives +20%dmg
        fb7.fathers.Add(fb4.id);
        SkillTreeNode fb8 = new SkillTreeNode("fb8"); // father is fb5. Gives +50%dmg
        fb8.fathers.Add(fb5.id);
        SkillTreeNode fb9 = new SkillTreeNode("fb9"); // father are fb5 and fb6. Gives +5range
        fb9.fathers.Add(fb5.id); fb9.fathers.Add(fb6.id);
        SkillTreeNode fb10 = new SkillTreeNode("fb10"); // father are fb6 and fb7. Gives +40%dmg
        fb10.fathers.Add(fb6.id); fb10.fathers.Add(fb7.id);
        SkillTreeNode fb11 = new SkillTreeNode("fb11"); // father is fb7. Gives +1projectile
        fb11.fathers.Add(fb7.id);
        SkillTreeNode fb12 = new SkillTreeNode("fb12"); // father are fb8 and fb9. Gives -20%cd
        fb12.fathers.Add(fb8.id); fb12.fathers.Add(fb9.id);
        SkillTreeNode fb13 = new SkillTreeNode("fb13"); // father is fb12. Gives -30%cd
        fb13.fathers.Add(fb12.id);
        SkillTreeNode fb14 = new SkillTreeNode("fb14"); // father are fb10 and fb12. Gives +30%dmg
        fb14.fathers.Add(fb10.id); fb14.fathers.Add(fb12.id);
        SkillTreeNode fb15 = new SkillTreeNode("fb15"); // father are fb10 and fb11. Gives +5range
        fb15.fathers.Add(fb10.id); fb15.fathers.Add(fb11.id);
        SkillTreeNode fb16 = new SkillTreeNode("fb16"); // father is fb11. Gives +1projectile
        fb16.fathers.Add(fb11.id);
        SkillTreeNode fb17 = new SkillTreeNode("fb17"); // father is fb14. Gives +100%dmg
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
        SkillTreeNode chain1 = new SkillTreeNode("chain1"); // first node of the chain tree. Gives +20%dmg
        SkillTreeNode chain2 = new SkillTreeNode("chain2"); // father is chain1. Gives +1bounce
        chain2.fathers.Add(chain1.id);
        SkillTreeNode chain3 = new SkillTreeNode("chain3"); // father is chain1. Gives -20%cd
        chain3.fathers.Add(chain1.id);
        SkillTreeNode chain4 = new SkillTreeNode("chain4"); // father is chain1. Gives +20%dmg
        chain4.fathers.Add(chain1.id);
        SkillTreeNode chain5 = new SkillTreeNode("chain5"); // father is chain2. Gives +20%dmg
        chain5.fathers.Add(chain2.id);
        SkillTreeNode chain6 = new SkillTreeNode("chain6"); // father is chain3. Gives +1bounce
        chain6.fathers.Add(chain3.id);
        SkillTreeNode chain7 = new SkillTreeNode("chain7"); // father is chain4. Gives +30%dmg
        chain7.fathers.Add(chain4.id);
        SkillTreeNode chain8 = new SkillTreeNode("chain8"); // father is chain5. Gives -20%cd
        chain8.fathers.Add(chain5.id);
        SkillTreeNode chain9 = new SkillTreeNode("chain9"); // father are chain5 and chain6. Gives +20%dmg
        chain9.fathers.Add(chain5.id); chain9.fathers.Add(chain6.id);
        SkillTreeNode chain10 = new SkillTreeNode("chain10"); // father are chain6 and chain7. Gives +5range
        chain10.fathers.Add(chain6.id); chain10.fathers.Add(chain7.id);
        SkillTreeNode chain11 = new SkillTreeNode("chain11"); // father is chain7. Gives +1bounce
        chain11.fathers.Add(chain7.id);
        SkillTreeNode chain12 = new SkillTreeNode("chain12"); // father are chain8 and chain9. Gives +10range
        chain12.fathers.Add(chain8.id); chain12.fathers.Add(chain9.id);
        SkillTreeNode chain13 = new SkillTreeNode("chain13"); // father is chain10. Gives -20%cd
        chain13.fathers.Add(chain10.id);
        SkillTreeNode chain14 = new SkillTreeNode("chain14"); // father is chain11. Gives +2bounces
        chain14.fathers.Add(chain11.id);
        SkillTreeNode chain15 = new SkillTreeNode("chain15"); // father is chain12. Gives +10range
        chain15.fathers.Add(chain12.id);
        SkillTreeNode chain16 = new SkillTreeNode("chain16"); // father are chain12 and chain13. Gives -30%cd
        chain16.fathers.Add(chain12.id); chain16.fathers.Add(chain13.id);
        SkillTreeNode chain17 = new SkillTreeNode("chain17"); // father are chain13 and chain14. Gives +50%dmg
        chain17.fathers.Add(chain13.id); chain17.fathers.Add(chain14.id);
        SkillTreeNode chain18 = new SkillTreeNode("chain18"); // father is chain15. Gives +40%dmg
        chain17.fathers.Add(chain15.id);
        SkillTreeNode chain19 = new SkillTreeNode("chain19"); // father are chain16 and chain17. Gives +100%dmg
        chain17.fathers.Add(chain16.id); chain17.fathers.Add(chain17.id);
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
    }

    public void CloseTree()
    {
        SkillTreeUI.SetActive(false);
    }

    public void ChangeType(int type)
    {
        this.type = type;
    }

    public void ChangeValue(float value)
    {
        this.value = value;
    }
    public void UpgradeSkill(string id)
    {
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
        player.GetComponent<PlayerSkills>().UpgradeSkill(type, value);
        nodes[id].Activate();
    }
}

public class SkillTreeNode
{
    public ArrayList fathers;
    private bool isActive = false;
    public string id;

    public SkillTreeNode(string id)
    {
        fathers = new ArrayList();
        this.id = id;
    }

    public void Activate()
    {
        isActive = true;
    }
    public bool IsActive()
    {
        return isActive;
    }
}
