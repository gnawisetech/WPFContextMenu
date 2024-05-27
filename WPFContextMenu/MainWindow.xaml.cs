using Microsoft.Web.WebView2.WinForms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Drawing.Point;

namespace WPFContextMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToolStripDropDown toolStripDropDown;
        WebView2 webView2;
        public MainWindow()
        {
            InitializeComponent();
            InitializeToolStripDropDown();
        }

        private void InitializeToolStripDropDown()
        {
            
            webView2 = new WebView2();
            toolStripDropDown = new ToolStripDropDown();

            ToolStripMenuItem item1 = new ToolStripMenuItem("Operation 1");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Operation 2");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Operation 3");
            ToolStripMenuItem item4 = new ToolStripMenuItem("Operation 4");
            ToolStripMenuItem item5 = new ToolStripMenuItem("Operation 5");

            toolStripDropDown.Items.AddRange(new ToolStripItem[] { item1, item2, item3, item4, item5 });
        }

        private void Rectangle_ContextMenuOpening(object sender, MouseButtonEventArgs e)
        { 
            var cursorPositon = System.Windows.Forms.Cursor.Position; 

            var pointToScreen = webView2.PointToScreen(cursorPositon);

            var diff = new Point(pointToScreen.X - cursorPositon.X, pointToScreen.Y - cursorPositon.Y);

            var newPosition = new Point(cursorPositon.X - diff.X, cursorPositon.Y - diff.Y);
            
            toolStripDropDown.Show(webView2, new Point((int)newPosition.X, (int)newPosition.Y), ToolStripDropDownDirection.BelowLeft);
        }

        public static Point AdjustPointForDpi(int scaling, Point size)
        {
            var adjustedX = AdjustDimension(scaling, size.X);
            var adjustedY = AdjustDimension(scaling, size.Y);
            return new Point(adjustedX, adjustedY);
        }

        static int AdjustDimension(double scaling, int dimension)
        {
            return (int)(dimension * scaling);
        }
    }
}