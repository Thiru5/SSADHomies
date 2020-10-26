using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Platformer.Mechanics;
using UnityEngine.Assertions;

namespace Tests
{
    public class TestPopup
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestPopupFreeze()
        {
            // Use the Assert class to test conditions
            var popup = new Popup(); 
            popup.Open();
            AssertEqual(Time.timeScale, 0);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestPopupFreeze()
        {
            // Use the Assert class to test conditions
            var popup = new Popup(); 
            popup.Open();
            popup.Close(); 
            AssertEqual(Time.timeScale, 1); 
        }

        [Test]
        public void TestPopupFreezeWhenFrozen()
        {
            // Use the Assert class to test conditions
            var popup = new Popup(); 
            Time.timescale = 0;
            popup.Open();
            AssertEqual(Time.timeScale, 0);
        }

        [UnityTest]
        public void TestPopupDisplay() { 
            var popup = new Popup();
            popup.Open(); 
            AssertEqual(popup.ui.activeSelf, true); 
        }

        [UnityTest]
        public void TestPopupDisplay() { 
            var popup = new Popup();
            popup.Open(); 
            popup.Close();
            AssertEqual(popup.ui.activeSelf, false); 
        }
    }
}
