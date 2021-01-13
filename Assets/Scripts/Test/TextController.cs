using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private TownHPSO _townHP = default;
    private Text _text;
    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        _text.text = _townHP.HP + " ";
    }
}
