using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Методы_принятия_решений.Utils
{
    public static class Utils
    {
        private static bool isResizing = false;
        private static Point lastMousePosition;
        private static DataGridView activeDataGridView;

        public static void EnableResizing(DataGridView dataGridView)
        {
            dataGridView.MouseDown += DataGridView_MouseDown;
            dataGridView.MouseMove += DataGridView_MouseMove;
            dataGridView.MouseUp += DataGridView_MouseUp;
        }

        private static void DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.Button == MouseButtons.Left && e.X >= dgv.Width - 10 && e.Y >= dgv.Height - 10)
                {
                    isResizing = true;
                    lastMousePosition = e.Location;
                    activeDataGridView = dgv;
                    dgv.Cursor = Cursors.SizeNWSE;
                }
            }
        }

        private static void DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.X >= dgv.Width - 10 && e.Y >= dgv.Height - 10)
                    dgv.Cursor = Cursors.SizeNWSE;
                else
                    dgv.Cursor = Cursors.Default;

                if (isResizing && activeDataGridView != null)
                {
                    int newWidth = activeDataGridView.Width + (e.X - lastMousePosition.X);
                    int newHeight = activeDataGridView.Height + (e.Y - lastMousePosition.Y);

                    activeDataGridView.Width = Math.Max(100, newWidth);
                    activeDataGridView.Height = Math.Max(100, newHeight);

                    lastMousePosition = e.Location;
                }
            }
        }

        private static void DataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
            activeDataGridView = null;
            if (sender is DataGridView dgv)
                dgv.Cursor = Cursors.Default;
        }
    }
}
