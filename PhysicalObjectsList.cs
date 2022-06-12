using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Collections;

namespace ZelenskiyGame
{
    class PhysicalObjectsList : IEnumerable<PhysicalObject>
    {
        protected RenderWindow window;
        public int Count { get => physicalObjects.Count; }
        List<PhysicalObject> physicalObjects = new List<PhysicalObject>();

        public PhysicalObjectsList(RenderWindow window)
        {
            this.window = window;
        }

        public PhysicalObjectsList()
        {

        }

        public IEnumerator GetEnumerator()
        {
            return physicalObjects.GetEnumerator();
        }

        public void Add(params PhysicalObject[] @object)
        {
            foreach (PhysicalObject i in @object)
                physicalObjects.Add(i);
        }
        public void Add(PhysicalObjectsList @object)
        {
             physicalObjects.AddRange(@object);
        }

        internal void Remove(PhysicalObject currentObject)
        {
            physicalObjects.Remove(currentObject);
        }

        public void Borders(RenderWindow window, PhysicalObject @object)
        {
            if (@object.body.Position.Y + @object.body.size.Y >= window.Size.Y || @object.body.Position.X + @object.body.size.X >= window.Size.X || @object.body.Position.Y <= 0 || @object.body.Position.X <= 0)
                @object.BorderReact();
        }

        public void Create()
        {
            for (int i = 0; i < physicalObjects.Count; i++)
            {
                PhysicalObject CurrentObject = physicalObjects[i];
                if (!CurrentObject.IsAlive)
                {
                    physicalObjects.Remove(CurrentObject);
                    i--;
                }
                else
                {
                    Borders(window, CurrentObject);
                    Collision(CurrentObject);
                    if (CurrentObject is Character && ((Character)CurrentObject).ChildrenList != null)
                    {
                        physicalObjects.AddRange(((Character)CurrentObject).ChildrenList);
                        ((Character)CurrentObject).ChildrenList.RemoveAll();
                    }
                    CurrentObject.Draw(window);
                }
            }
        }

        public void RemoveByIndex(int index)
        {
            PhysicalObject CurrentObject = physicalObjects[index];
            physicalObjects.Remove(CurrentObject);
        }

        public void RemoveAll()
        {
            for (int i = 0; i < physicalObjects.Count; i++)
            {
                PhysicalObject physical = physicalObjects[i];
                physicalObjects.Remove(physical);
            }
        }

        public bool AlivenessCheckByIndex(int i)
        {
            PhysicalObject CurrentObject = physicalObjects[i];
            if (!CurrentObject.IsAlive)
            {
                 return true;
            }
            return false;
        }

        public void Collision(PhysicalObject CurrentObject)
        {
            int i = physicalObjects.IndexOf(CurrentObject);
            for (int j = i; j < physicalObjects.Count; j++)
            {
                if (i == j)
                    continue;
                PhysicalObject NotCheckedObject = physicalObjects[j];
                if (CurrentObject.GetBox().IsIntersectWith(NotCheckedObject.GetBox()))
                {
                    CurrentObject.OnCollisionReact(NotCheckedObject);
                    NotCheckedObject.OnCollisionReact(CurrentObject);
                    break;
                }
            }
        }
        IEnumerator<PhysicalObject> IEnumerable<PhysicalObject>.GetEnumerator()
        {
            return physicalObjects.GetEnumerator();
        }
    }
}
