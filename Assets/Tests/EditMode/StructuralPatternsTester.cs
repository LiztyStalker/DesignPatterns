using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DesignPatterns;

public class StructuralPatternsTester
{
    [Test]
    public void StructuralPatterns_AdapterPattern()
    {
        var mixer = DesignPatterns.AdapterPattern.Kitchen.GetInstance();
        mixer.Mix(10f);
        mixer.Mix(20f);
        mixer.Mix(30f);
        Debug.Log(mixer.Value);
        Assert.AreEqual(mixer.Value, 60f);
    }
}
