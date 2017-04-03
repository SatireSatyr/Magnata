using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagnataUnitTest
{
    [TestClass]
    public partial class MagnataTest
    {
        [TestMethod]
        public void Init()
        {
            Magnata.Gameworld gw = Magnata.Gameworld.Instance;
            Assert.IsTrue(1 + 1 == 2);
        }

        [TestMethod]
        public void Gameworld_AddGameobject()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            Magnata.Gameworld.Instance.Add(go);
            Assert.IsNotNull(Magnata.Gameworld.Instance.GetGameobject(g => g.Equals(go)));
        }

        [TestMethod]
        public void Gameworld_RemoveGameObject()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            Magnata.Gameworld.Instance.Add(go);
            Magnata.Gameworld.Instance.Remove(go);
            Assert.IsNull(Magnata.Gameworld.Instance.GetGameobject(g => g.Equals(go)));
        }

        [TestMethod]
        public void Gameobject_GetComponentT()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new Magnata.Components.Transform(go, new Magnata.Other.Vector(0, 0)));
            Assert.IsNotNull(go.GetComponent<Magnata.Components.Transform>());
        }

        [TestMethod]
        public void Gameobject_GetComponentFunc()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new Magnata.Components.Transform(go, new Magnata.Other.Vector(0, 0)));
            Assert.IsNotNull(go.GetComponent(c => c is Magnata.Components.Transform));
        }

        [TestMethod]
        public void GameObject_RemoveComponent()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            Magnata.Components.Component c = new Magnata.Components.Transform(go, new Magnata.Other.Vector(0, 0));
            go.AddComponent(c);
            go.RemoveComponent(c);
            Assert.IsNull(go.GetComponent<Magnata.Components.Transform>());
        }

        [TestMethod]
        public void GameObject_UpdateTest()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new TestComponent(go));
            go.Update(new Microsoft.Xna.Framework.GameTime());
            Assert.IsTrue(go.GetComponent<TestComponent>().Updated);
        }

        [TestMethod]
        public void GameObject_DrawTest()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new TestComponent(go));
            go.Draw(null);
            Assert.IsTrue(go.GetComponent<TestComponent>().Drawed);
        }

        [TestMethod]
        public void GameObject_LoadTest()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new TestComponent(go));
            go.Load();
            Assert.IsTrue(go.GetComponent<TestComponent>().Loaded);
        }

        [TestMethod]
        public void GameObject_UnloadTest()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            go.AddComponent(new TestComponent(go));
            go.Unload();
            Assert.IsTrue(go.GetComponent<TestComponent>().Unloaded);
        }

        [TestMethod]
        public void GameObject_Removed()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            TestComponent tc = new TestComponent(go);
            go.AddComponent(tc);
            go.RemoveComponent(tc);
            Assert.IsTrue(tc.Removed);
        }

        public void GameObject_Added()
        {
            Magnata.Gameobject go = new Magnata.Gameobject();
            TestComponent tc = new TestComponent(go);
            go.AddComponent(tc);
            Assert.IsTrue(tc.Added);
        }
    }
}
