using System.Drawing;

namespace Lab8_SimplePaint.Controls
{
    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            Dock = DockStyle.Fill;
        }
    }
}
