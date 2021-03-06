﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyKeyToContinueAnimate.cs" author="Lars" company="None">
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
// and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//  
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToContinueAnimate : MonoBehaviour
{
    private bool _startingGame;

    [SerializeField]
    private AudioSource _backgroundAudio;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    private void Update()
    {
        if (_startingGame) return;
        if (Input.anyKeyDown)
        {
            _startingGame = true;

            _backgroundAudio.DOFade(0f, 1.5f);
            _canvasGroup.DOFade(0f, 1.5f).OnComplete(() => { SceneManager.LoadScene("Gameplay"); });
        }
    }

    private void Start()
    {
        var txt = GetComponent<TextMeshProUGUI>();

        var appearSequence = DOTween.Sequence();
        appearSequence.AppendInterval(0.5f);
        appearSequence.Append(txt.DOColor(Color.clear, 1.0f).From());
    }

}