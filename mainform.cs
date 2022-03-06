using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices;

namespace autosaver
{
    public partial class mainform : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        GFX window;
        KeyboardHook hook;

        private Process ActiveWindow()
        {
            IntPtr handle = GetForegroundWindow();
            uint id;
            GetWindowThreadProcessId(handle, out id);
            return Process.GetProcessById((int)id);
        }

        public mainform()
        {
            InitializeComponent();
        }

        bool contains(Process prc)
        {
            foreach (ListViewItem item in processes.Items)
            {
                if (((Process)item.Tag).Id.Equals(prc.Id)) return true;
            }
            return false;
        }

        bool selected(Process prc)
        {
            foreach (ListViewItem item in processes.Items)
            {
                if (((Process)item.Tag).Id.Equals(prc.Id)) return item.Checked;
            }
            return false;
        }

        void refreshList()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (contains(process)) continue;

                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    string stext = process.MainWindowTitle.Substring(0, Math.Min(process.MainWindowTitle.Length, 24));
                    if (process.MainWindowTitle.Length > 24) stext += "...";

                    ListViewItem test = new ListViewItem();
                    test.Text = stext;
                    test.Tag = process;
                    test.ImageIndex = this.processes.SmallImageList.Images.Count;

                    this.processes.SmallImageList.Images.Add(Icon.ExtractAssociatedIcon(process.MainModule.FileName));
                    this.processes.Items.Add(test);
                }
            }

            foreach (ListViewItem item in this.processes.Items)
            {
                if (!((Process)item.Tag).IsRunning()) this.processes.Items.Remove(item);
            }
        }

        void playSound(System.IO.UnmanagedMemoryStream stream)
        {
            if (!makesounds.Checked) return;
            SoundPlayer player = new SoundPlayer(stream);
            player.Play();
            player.Dispose();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            processes.SmallImageList = new ImageList();
            refreshList();

            window = new GFX();
            Thread thread = new Thread(window.Run);
            thread.Start();

            hook = new KeyboardHook();
            hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.C);
            hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.S);
            hook.KeyPressed += Hook_KeyPressed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshList();
        }

        int time = 0;

        void updateTime()
        {
            TimeSpan timespan = new TimeSpan(0, 0, time);
            label6.Text = timespan.Hours.ToString().PadLeft(2, '0') 
                + ":" + timespan.Minutes.ToString().PadLeft(2, '0')
                + ":" + timespan.Seconds.ToString().PadLeft(2, '0');
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == Keys.S)
            {
                enabled.Checked = !enabled.Checked;
            }

            if (e.Key == Keys.C)
            {
                if (!enabled.Checked)
                {
                    return;
                }

                time = (int)schoice.Value;
                window.active = false;
                updateTime();
            }

            playSound(Properties.Resources.squish);
        }

        private void ticker_Tick(object sender, EventArgs e)
        {
            Process p = ActiveWindow();
            if (!selected(p)) return;

            time--;

            if (dosave.Checked)
            {
                if (time == 10)
                {
                    playSound(Properties.Resources.slide);
                    window.active = true;
                }

                if (time <= 9 && time >= 0)
                {
                    playSound(Properties.Resources.tick);
                    window.active = true;
                }

                if (time < 0)
                {
                    playSound(Properties.Resources.save);
                    time = (int)schoice.Value;
                    SendKeys.Send("^{s}");
                    window.active = false;
                }

                window.window.Height = 110;
                window.toptext = "Auto-saving in " + time + " seconds...";
                window.bottomtext = "Select the program window so that auto-saving can \nwork!\nTo cancel this save, press [CTRL + ALT + C]";
            }
            else
            {
                if (time == 5)
                {
                    playSound(Properties.Resources.save);
                }

                if (time <= 5)
                {
                    window.active = true;
                    window.toptext = "Remember to auto-save!";
                    window.bottomtext = "This will auto-close in " + time + " seconds...";
                    window.window.Height = 75;
                }

                if (time < 0)
                {
                    playSound(Properties.Resources.slide);
                    time = (int)schoice.Value;
                    window.active = false;
                }
            }

            updateTime();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (enabled.Checked)
            {
                ticker.Start();
                time = (int)new TimeSpan(0, 0, (int)schoice.Value).TotalSeconds;
                ticker_Tick(null, null);
            }
            else
            {
                ticker.Stop();
                time = 0;
                window.active = false;
            }

            updateTime();
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            window.Dispose();
        }
    }
}

public static class ProcessExtensions
{
    public static bool IsRunning(this Process process)
    {
        if (process == null)
            throw new ArgumentNullException("process");

        try
        {
            Process.GetProcessById(process.Id);
        }
        catch (ArgumentException)
        {
            return false;
        }
        return true;
    }
}