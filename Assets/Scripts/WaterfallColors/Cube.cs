using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Color _startColor;
    private Color _targetColor;
    private MeshRenderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<MeshRenderer>();
        _startColor = _renderer.material.color;
    }

    public void ChangeColor(Color randomColor, float changeColorTime)
    {
        _targetColor = randomColor;
        StartCoroutine(ChangeColorCoroutine(changeColorTime));
    }

    private IEnumerator ChangeColorCoroutine(float changeColorTime)
    {
        var currentTime = 0f;

        while (currentTime < changeColorTime)
        {
            _renderer.material.color = Color.Lerp(_startColor, _targetColor, currentTime / changeColorTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        _renderer.material.color = _targetColor;
    }
}
