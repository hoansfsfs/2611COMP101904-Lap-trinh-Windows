using Lab8_SimplePaint.Models;
using Lab8_SimplePaint.Controls;

namespace Lab8_SimplePaint.Forms
{
    public partial class FrmPaint : Form
    {
        private readonly List<DrawItem> items =
            new();

        private DrawItem? currentItem;

        private bool isDrawing = false;

        public FrmPaint()
        {
            InitializeComponent();
        }
    }
}
