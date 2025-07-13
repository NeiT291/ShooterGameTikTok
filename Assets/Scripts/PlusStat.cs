using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlusStat : MonoBehaviour
{
    private float xLimit, yLimit;
    private List<string> effectTypes = new List<string> { "Health", "FireRate", "Damage" }; // Các loại hiệu ứng có thể
    [SerializeField] private float speed = 1.5f;
    private float effectValue; // Giá trị hiệu ứng của PlusStat
    private int effectTypeIndex; // Chỉ số loại hiệu ứng đã chọn
    public float EffectValue { get => effectValue; set => effectValue = value; }
    public int EffectTypeIndex { get => effectTypeIndex; set => effectTypeIndex = value; }
    public List<string> EffectTypes { get => effectTypes; set => effectTypes = value; }
    // Start is called before the first frame update

    void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        xLimit = screenBounds.x + 1f;
        yLimit = screenBounds.y + 1f;
        do
        {
            effectValue = Random.Range(-5f, 5f);
        } while (effectValue == 0); // Đảm bảo giá trị hiệu ứng không bằng 0

        int effectType = Random.Range(0, effectTypes.Count); // Chọn ngẫu nhiên loại hiệu ứng
        TMP_Text TMP = GetComponentInChildren<TMP_Text>();
        TMP.text = effectTypes[effectType] + ": " + effectValue.ToString("F1"); // Hiển thị loại hiệu ứng và giá trị
        EffectTypeIndex = effectType; // Lưu chỉ số loại hiệu ứng
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (effectValue > 0)
        {
            spriteRenderer.color = Color.green; // Màu xanh cho hiệu ứng tích cực
        }
        else
        {
            spriteRenderer.color = Color.red; // Màu đỏ cho hiệu ứng tiêu cực
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > xLimit || Mathf.Abs(transform.position.y) > yLimit)
        {
            Destroy(gameObject);
        }
    }
}
