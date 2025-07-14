using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugHelper : MonoBehaviour
{
    private Color highlightColor = Color.red;

    void Start()
    {
        CheckAllAudioSources();
        CheckAllImages();
        CheckAllTextMeshPro();
        CheckAllAnimators();
        CheckAllMeshRenderers();
    }

    void CheckAllAudioSources()
    {
        var sources = FindObjectsOfType<AudioSource>();
        foreach (var src in sources)
        {
            if (src.clip == null)
            {
                Debug.LogWarning($"[DebugHelper] AudioSource on '{src.gameObject.name}' has NO clip assigned.");
                HighlightObject(src.gameObject);
            }
        }
    }

    void CheckAllImages()
    {
        var images = FindObjectsOfType<Image>();
        foreach (var img in images)
        {
            if (img.sprite == null)
            {
                Debug.LogWarning($"[DebugHelper] Image on '{img.gameObject.name}' has NO sprite assigned.");
                HighlightImage(img);
            }
        }
    }

    void CheckAllTextMeshPro()
    {
        var tmpros = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var tmp in tmpros)
        {
            if (string.IsNullOrEmpty(tmp.text))
            {
                Debug.LogWarning($"[DebugHelper] TextMeshProUGUI on '{tmp.gameObject.name}' is EMPTY.");
                tmp.color = highlightColor;
            }
        }
    }

    void CheckAllAnimators()
    {
        var animators = FindObjectsOfType<Animator>();
        foreach (var anim in animators)
        {
            if (anim.runtimeAnimatorController == null)
            {
                Debug.LogWarning($"[DebugHelper] Animator on '{anim.gameObject.name}' has NO controller.");
                HighlightObject(anim.gameObject);
            }
        }
    }

    void CheckAllMeshRenderers()
    {
        var renderers = FindObjectsOfType<MeshRenderer>();
        foreach (var mr in renderers)
        {
            if (mr.sharedMaterial == null)
            {
                Debug.LogWarning($"[DebugHelper] MeshRenderer on '{mr.gameObject.name}' has NO material.");
                HighlightObject(mr.gameObject);
            }
        }
    }

    void HighlightImage(Image img)
    {
        img.color = highlightColor;
    }

    void HighlightObject(GameObject obj)
    {
        // Nếu có SpriteRenderer thì tô màu
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = highlightColor;
            return;
        }

        // Nếu có TextMeshPro thì đổi màu text
        TextMeshProUGUI tmp = obj.GetComponent<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.color = highlightColor;
            return;
        }

        // Nếu có MeshRenderer thì tạo material tạm màu đỏ
        MeshRenderer mr = obj.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            var redMat = new Material(Shader.Find("Standard"));
            redMat.color = highlightColor;
            mr.material = redMat;
        }
    }
}
