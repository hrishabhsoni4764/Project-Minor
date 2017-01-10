using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private PlayerBehaviour playerB;
    private int maxHeartAmount = 5;
    private int healthperheart = 2;

    public int startHearts = 5;
    public Image[] healthImages;
    public Sprite[] healthSprites;
        
    void Start()
    {
        playerB = GameManager.instance.playerB;

        playerB.curHealth = maxHeartAmount * healthperheart;
        playerB.maxHealth = maxHeartAmount * healthperheart;
        CheckHealthAmount();
    }

    void Update() {
       
    }

    void CheckHealthAmount() {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    public void UpdateHearts() {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else {
                i++;
                if (playerB.curHealth >= i * healthperheart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else {
                    int curHeartHealth = (int)(healthperheart - (healthperheart * i - playerB.curHealth));
                    int healthPerImage = healthperheart / (healthSprites.Length - 1);
                    int imageIndex = curHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeDamage(int amount) {
        playerB.curHealth += amount;
        playerB.curHealth = Mathf.Clamp(playerB.curHealth, 0, startHearts * healthperheart);
        UpdateHearts();
    }

    public void AddheartContainer() {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);

        playerB.curHealth = startHearts * healthperheart;
        playerB.maxHealth = maxHeartAmount * healthperheart;

        CheckHealthAmount();
    }
}

