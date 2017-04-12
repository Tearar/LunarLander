using System.Drawing;

namespace LunarLander_picture
{
    abstract class GameObject
    {
        public virtual void Move(Graphics gfx) { }
        public virtual void Draw(Graphics gfx) { }
    }
}
