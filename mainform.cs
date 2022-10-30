using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;

namespace AutoSaver
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private OverlayGraphics Window;
        private KeyboardHook KeyboardEvent;

        private Process ActiveWindow()
        {
            IntPtr handle = GetForegroundWindow();
            uint id;
            GetWindowThreadProcessId(handle, out id);
            return Process.GetProcessById((int)id);
        }

        public MainForm()
        {
            InitializeComponent();

            Window = new OverlayGraphics();
            Thread thread = new Thread(Window.Run);
            thread.Start();

            KeyboardEvent = new KeyboardHook();
            KeyboardEvent.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.C);
            KeyboardEvent.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.S);
            KeyboardEvent.KeyPressed += Hook_KeyPressed;
        }

        bool contains(Process prc)
        {
            foreach (ListViewItem item in AvailableProcesses.Items)
            {
                if (((Process)item.Tag).Id.Equals(prc.Id)) return true;
            }

            foreach (ListViewItem item in SelectedProcesses.Items)
            {
                if (((Process)item.Tag).Id.Equals(prc.Id)) return true;
            }

            return false;
        }

        bool selected(Process prc)
        {
            foreach (ListViewItem item in SelectedProcesses.Items)
            {
                if (((Process)item.Tag).Id.Equals(prc.Id)) return true;
            }
            return false;
        }

        void refreshList()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (contains(process)) continue;

                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    string stext = process.MainWindowTitle.Substring(0, Math.Min(process.MainWindowTitle.Length, 24));
                    if (process.MainWindowTitle.Length > 24) stext += "...";

                    ListViewItem test = new ListViewItem();
                    test.Text = stext;
                    test.Tag = process;
                    test.ImageIndex = AvailableProcesses.SmallImageList.Images.Count;

                    string fileName;
                    try // for whatever reason, trying to access MainModule of some processes throws an access denied win32 exception
                    {
                        fileName = process.MainModule?.FileName ?? "nonelol";
                        Icon? pick = fileName == "nonelol" ? ASResources.program : Icon.ExtractAssociatedIcon(fileName);

                        AvailableProcesses.SmallImageList.Images.Add(pick);
                        SelectedProcesses.SmallImageList.Images.Add(pick);
                    }
                    catch {}

                    AvailableProcesses.Items.Add(test);
                }
            }

            foreach (ListViewItem item in AvailableProcesses.Items)
            {
                if (!((Process)item.Tag).IsRunning()) AvailableProcesses.Items.Remove(item);
            }

            foreach (ListViewItem item in SelectedProcesses.Items)
            {
                if (!((Process)item.Tag).IsRunning()) SelectedProcesses.Items.Remove(item);
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
            AvailableProcesses.SmallImageList = new ImageList();
            SelectedProcesses.SmallImageList = new ImageList();
            refreshList();
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

        private void Hook_KeyPressed(object? sender, KeyPressedEventArgs e)
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
                Window.Active = false;
                updateTime();
            }

            playSound(ASResources.squish);
        }

        private void ticker_Tick(object sender, EventArgs e)
        {
            Process p = ActiveWindow();
            if (!selected(p)) return;

            time--;

            if (dosave.Checked)
            {
                if (time == 5)
                {
                    playSound(ASResources.slide);
                    Window.Active = true;
                }

                if (time <= 4 && time >= 0)
                {
                    playSound(ASResources.tick);
                    Window.Active = true;
                }

                if (time < 0)
                {
                    playSound(ASResources.save);
                    time = (int)schoice.Value;
                    SendKeys.Send("^{s}");
                    Window.Active = false;
                }

                Window.window.Height = 110;
                Window.TopText = "Auto-saving in " + time + " seconds...";
                Window.SubText = "Select the program window so that auto-saving can \nwork!\nTo cancel this save, press [CTRL + ALT + C]";
            }
            else
            {
                if (time == 5)
                {
                    playSound(ASResources.save);
                }

                if (time <= 5)
                {
                    Window.Active = true;
                    Window.TopText = "Remember to auto-save!";
                    Window.SubText = "This will auto-close in " + time + " seconds...";
                    Window.window.Height = 75;
                }

                if (time < 0)
                {
                    playSound(ASResources.slide);
                    time = (int)schoice.Value;
                    Window.Active = false;
                }
            }

            updateTime();
        }

        private void Enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (enabled.Checked)
            {
                TimeTicker.Start();
                time = (int)new TimeSpan(0, 0, (int)schoice.Value).TotalSeconds;
                ticker_Tick(this, e);
            }
            else
            {
                TimeTicker.Stop();
                time = 0;
                Window.Active = false;
            }

            updateTime();
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Window.Dispose();
        }

        /* too lazy
        private void KeybindMouseEnter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = SystemColors.ControlDark;
        }

        private void KeybindMouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = SystemColors.ControlLightLight;
        }*/

        private void AvailableProcesses_Click(object sender, EventArgs e)
        {
            var item = AvailableProcesses.SelectedItems[0];
            AvailableProcesses.Items.Remove(item);
            SelectedProcesses.Items.Add(item);
            playSound(ASResources.squish);
        }

        private void SelectedProcesses_Click(object sender, EventArgs e)
        {
            var item = SelectedProcesses.SelectedItems[0];
            SelectedProcesses.Items.Remove(item);
            AvailableProcesses.Items.Add(item);
            playSound(ASResources.slide);
        }
    }
}

public static class ProcessExtensions
{
    public static bool IsRunning(this Process process)
    {
        if (process == null)
            throw new ArgumentNullException("Process was null");

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