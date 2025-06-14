using System.Windows.Forms;
using System.Drawing;

public class FlatTabControl : TabControl
{
    protected override void WndProc(ref Message m)
    {
        // Hide the tab headers by skipping the paint message for them
        if (m.Msg == 0x1328) // TCM_ADJUSTRECT
        {
            if (!DesignMode)
            {
                m.Result = (System.IntPtr)1;
                return;
            }
        }
        base.WndProc(ref m);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Optional: clear any border drawing
        e.Graphics.Clear(this.Parent.BackColor);
    }
}
