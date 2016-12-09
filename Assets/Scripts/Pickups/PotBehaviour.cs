using UnityEngine;
using System.Collections;
public enum RenderMode { Opague, Fade}
public class PotBehaviour : MonoBehaviour {

    public bool activate;
    public float fadeSpeed;
    private bool fadeOut;
    private GameObject pot_b;
    private GameObject pot_w;
    public Material potMat;
    public RenderMode renderMode;
    private Color fade;

    void Start () {
        pot_b = transform.FindChild("Pot_b").gameObject;
        pot_w = transform.FindChild("Pot_w").gameObject;
        Color fade = new Color(18f, 64f, 14f, 0f);
    }
	
	void Update () {
        if (activate) {
            pot_b.SetActive(true);
            GetComponent<Animator>().SetInteger("shatter", 1);
            Destroy(pot_w);
            StartCoroutine("FadeDelay");
        }
        switch (renderMode)
        {
            case RenderMode.Opague:
                potMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                potMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                potMat.SetInt("_ZWrite", 1);
                potMat.DisableKeyword("_ALPHATEST_ON");
                potMat.DisableKeyword("_ALPHABLEND_ON");
                potMat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                potMat.renderQueue = -1;
                break;
            case RenderMode.Fade:
                potMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                potMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                potMat.SetInt("_ZWrite", 0);
                potMat.DisableKeyword("_ALPHATEST_ON");
                potMat.EnableKeyword("_ALPHABLEND_ON");
                potMat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                potMat.renderQueue = 3000;
                break;
            default:
                break;
        }
        if (fadeOut) {
            FadeOut();
        }
	}

    void FadeOut() {
        renderMode = RenderMode.Fade;
        
    }


    IEnumerator DeleteDelay() {
        yield return new WaitForSeconds(1);
        potMat.color = Color.Lerp(potMat.color, fade, fadeSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator FadeDelay() {
        yield return new WaitForSeconds(0.3f);
        fadeOut = true;
    }
}
