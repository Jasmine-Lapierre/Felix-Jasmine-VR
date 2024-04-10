using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    private Renderer _renderer;

    private Color[] _colors;

    private float _tipHeight;
    private RaycastHit _touch;
    private Paintable _paintable;
    private Vector2 _lastTouchPos;
    private Vector2 _touchPos;
    private bool _touchedLastFrame;
    //private Quaternion _lastTouchRot;
  

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, (int)(3.14f) * (_penSize * _penSize)).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("Paintable"))
            {
                if (_paintable == null)
                {
                    _paintable = _touch.transform.GetComponent<Paintable>();
                }

                Debug.Log("Guhguuhg");

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _paintable.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _paintable.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _paintable.textureSize.y || x < 0 || x > _paintable.textureSize.x) return;

                if (_touchedLastFrame)
                {
                    _paintable.texture.SetPixels(x, y, _penSize, _penSize, _colors);
                    for (float f = 0.01f; f < 1.00f; f+= 0.01f)
                    {
                        var lerpx = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpy = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _paintable.texture.SetPixels(lerpx, lerpy, _penSize, _penSize, _colors);
                    }

                    //transform.rotation = _lastTouchRot;

                    _paintable.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                //_lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _paintable = null;
        _touchedLastFrame = false;
    }
}
