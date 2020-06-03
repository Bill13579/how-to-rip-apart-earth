using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimateChangeController : MonoBehaviour
{
    public SpriteRenderer skyFog;
    public Sprite[] planetSprites;
    public SpriteRenderer planet;
    public ClimateChangeRates rates;
    public Image healthBar;
    public AudioSource audioSource;
    public AnimationCurve audioCurve;
    public AudioClip endScreenAudioClip;
    public GameObject endScreenPanel;
    public Text coinCount;
    public float maxProgress = 100000f;
    
    /*****
        0 => Natural
        10000 => Ok you win
    *****/
    public float m_Progress = 0;
    public ShopManager shopManager;
    private int m_Money = 10;
    private bool m_InvokedEndScreen = false;

    void Start() {
        coinCount.text = m_Money.ToString();
    }

    public void DeltaProgress(float progress, bool makesMoney) {
        m_Progress = Mathf.Clamp(m_Progress + progress, 0f, maxProgress);
        healthBar.fillAmount = GetEarthHP();
        if (makesMoney) {
            m_Money += Mathf.Abs(Mathf.RoundToInt(progress));
            coinCount.text = m_Money.ToString();
            shopManager.UpdateShopListing();
        }
    }

    public float GetProgress() {
        return m_Progress;
    }

    public float GetEarthHP() {
        return (maxProgress - GetProgress()) / maxProgress;
    }

    public int GetMoney() {
        return m_Money;
    }

    public void DeltaMoney(int delta) {
        m_Money += delta;
    }

    void InvokeEndScreen() {
        GameObject[] flames = GameObject.FindGameObjectsWithTag("Flame");
        foreach (GameObject flame in flames) {
            flame.GetComponent<AudioSource>().enabled = false;
        }
        audioSource.clip = endScreenAudioClip;
        audioSource.volume = 1f;
        audioSource.loop = false;
        audioSource.Play();
        endScreenPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (m_Progress >= 99990 && !m_InvokedEndScreen) {
            m_InvokedEndScreen = true;
            audioSource.volume = audioCurve.Evaluate(GetProgress() / maxProgress);
            Invoke("InvokeEndScreen", 15);
        }
        planet.sprite = planetSprites[Mathf.Clamp(Mathf.FloorToInt(m_Progress / (rates.PlanetAnimationDuration / planetSprites.Length)), 0, planetSprites.Length - 1)];
        skyFog.color = new Color(skyFog.color.r, skyFog.color.g, skyFog.color.b, m_Progress / rates.FogDuration);
        if (!m_InvokedEndScreen) {
            audioSource.volume = audioCurve.Evaluate(GetProgress() / maxProgress);
        }
    }
}
