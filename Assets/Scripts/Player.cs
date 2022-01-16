using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Untility;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private UIDocument _uiDocument;

    private void Start()
    {
        _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
