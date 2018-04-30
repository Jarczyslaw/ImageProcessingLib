using ImageProcessingLib;
using ImageProcessingLib.GDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApps.Apps.MemoryLeaks
{
    [App("Memory Leaks")]
    public partial class MemoryLeaksForm : Form
    {
        private List<object> images = new List<object>();
        private int disposeAfter = 30;

        private float? maxUsage = null;
        private float? minUsage = null;

        private int iteration = 0;

        public MemoryLeaksForm()
        {
            InitializeComponent();
            AppAttribute.ApplyTitle(this);
            UpdateStartStopButton();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                return;

            iteration++;
            AddImage();

            float currentUsage = GetMemoryUsage();
            CalcUsages(currentUsage);
            UpdateUsageControls(currentUsage, maxUsage.Value, minUsage.Value, iteration, images.Count);

            if (images.Count > disposeAfter)
                DisposeAll();
        }

        private void MemoryLeaksTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            DisposeAll();
        }

        private void UpdateUsageControls(float current, float max, float min, int iteration, int imagesCount)
        {
            string format = "0.00";
            tbMemoryUsage.Text = current.ToString(format);
            tbMaxMemoryUsage.Text = max.ToString(format);
            tbMinMemoryUsage.Text = min.ToString(format);
            tbIteration.Text = iteration.ToString();
            tbImagesCount.Text = imagesCount.ToString();
        }

        private void CalcUsages(float current)
        {
            if (!minUsage.HasValue)
                minUsage = current;
            else
                minUsage = Math.Min(current, minUsage.Value);

            if (!maxUsage.HasValue)
                maxUsage = current;
            else
                maxUsage = Math.Max(current, maxUsage.Value);
        }

        private float GetMemoryUsage()
        {
            return GC.GetTotalMemory(false) / 1024f / 1024f;
        }

        private void AddImage()
        {
            var size = 2000;
            //var img = new Bitmap(size, size);
            var img = new GDImage32(size, size);
            images.Add(img);
        }

        private void ToggleTimer()
        {
            timer1.Enabled = !timer1.Enabled;
            UpdateStartStopButton();
        }

        private void UpdateStartStopButton()
        {
            btnStartStop.Text = timer1.Enabled ? "STOP" : "START";
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            ToggleTimer();
        }

        private void DisposeAll()
        {
            for (int i = images.Count - 1; i >= 0; i--)
            {
                var disposable = images[i] as IDisposable;
                disposable.Dispose();
                images.RemoveAt(i);
            }
        }
    }
}
