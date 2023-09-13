using MouseKeyboardLibrary;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace WSA_TouchHelper
{
   
    public partial class Main : Form
    {
        public bool shown = false;
        public bool ChatMode = false;





        private KeyboardHook _keyboardHook;
      public static int press = 0;

        public Main()
        {

            InitializeComponent();
            MessageBox.Show("The hotkey to get the cursor position is: F3\nPut the X value into the X Text field\nPut the Y value into the Y Text field\nDo this for as much spells you'd like to add/use.\nHOME Key: Hide WSA Touch window\nINSERT Key: Show WSA Touch window", "Information");
            InitializeKeyboardHook(); //calls the method beneath to init the Hook
            Utilities.LoggerSuccess("Loaded settings");
            X1.Text = Convert.ToString(Properties.Settings.Default.X1);
            X2.Text = Convert.ToString(Properties.Settings.Default.X2);
            X3.Text = Convert.ToString(Properties.Settings.Default.X3);
            X4.Text = Convert.ToString(Properties.Settings.Default.X4);
            X5.Text = Convert.ToString(Properties.Settings.Default.X5);
            X6.Text = Convert.ToString(Properties.Settings.Default.X6);
            X7.Text = Convert.ToString(Properties.Settings.Default.X7);
            X8.Text = Convert.ToString(Properties.Settings.Default.X8);
            X9.Text = Convert.ToString(Properties.Settings.Default.X9);
            X10.Text = Convert.ToString(Properties.Settings.Default.X10);
            X11.Text = Convert.ToString(Properties.Settings.Default.X11);
            X12.Text = Convert.ToString(Properties.Settings.Default.X12);
            X13.Text = Convert.ToString(Properties.Settings.Default.X13);
            X14.Text = Convert.ToString(Properties.Settings.Default.X14);
            X15.Text = Convert.ToString(Properties.Settings.Default.X15);

            Y1.Text = Convert.ToString(Properties.Settings.Default.Y1);
            Y2.Text = Convert.ToString(Properties.Settings.Default.Y2);
            Y3.Text = Convert.ToString(Properties.Settings.Default.Y3);
            Y4.Text = Convert.ToString(Properties.Settings.Default.Y4);
            Y5.Text = Convert.ToString(Properties.Settings.Default.Y5);
            Y6.Text = Convert.ToString(Properties.Settings.Default.Y6);
            Y7.Text = Convert.ToString(Properties.Settings.Default.Y7);
            Y8.Text = Convert.ToString(Properties.Settings.Default.Y8);
            Y9.Text = Convert.ToString(Properties.Settings.Default.Y9);
            Y10.Text = Convert.ToString(Properties.Settings.Default.Y10);
            Y11.Text = Convert.ToString(Properties.Settings.Default.Y11);
            Y12.Text = Convert.ToString(Properties.Settings.Default.Y12);
            Y13.Text = Convert.ToString(Properties.Settings.Default.Y13);
            Y14.Text = Convert.ToString(Properties.Settings.Default.Y14);
            Y15.Text = Convert.ToString(Properties.Settings.Default.Y15);


        }
        private void InitializeKeyboardHook()
        {
            _keyboardHook = new KeyboardHook(); //initialize
            _keyboardHook.KeyUp += new KeyEventHandler(HandleKeyUp); //assign event: when a key gets pressed, call this method
            _keyboardHook.Start();
            
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            var pressedKey = e.KeyCode;
            IntPtr hwnd = Native.GetForegroundWindow();
            uint processId;
            Native.GetWindowThreadProcessId(hwnd, out processId);
            Process process = Process.GetProcessById((int)processId);

            if (pressedKey == Keys.F3)
            {
                Utilities.LoggerInfo("F3 -> CursorPos:");

                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");

                ForegroundWindowBypass.Set(hWnd);
                Native.POINT lpPoint;
                Native.GetCursorPos(out lpPoint);
                Native.ScreenToClient(hWnd, ref lpPoint);
                Console.WriteLine("X : " + lpPoint.X);
                Console.WriteLine("Y : " + lpPoint.Y);

            }

            if (process.ProcessName.ToLower() == "wsaclient")
            {
                if (ChatMode == true)
                {
                  if (pressedKey == Keys.Enter)
                    {
                        Console.WriteLine("Send message");
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X11.Text), Convert.ToInt32(Y11.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X11.Text), Convert.ToInt32(Y11.Text)));
                        press = 0;
                        ChatMode = false;
                    }
                        

                    
                }
                else if(ChatMode == false)
                {
                    if (pressedKey == Keys.F1)
                    {
                        Utilities.LoggerInfo("F1 -> Showing Window");
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);

                    }

                    if (pressedKey == Keys.D1)
                    {
                        Utilities.LoggerInfo("Hotkey #1 -> Clicking to");
                        Console.WriteLine("X : " + X1.Text);
                        Console.WriteLine("Y : " + Y1.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));


                    }

                    if (pressedKey == Keys.D2)
                    {
                        Utilities.LoggerInfo("Hotkey #2 -> Clicking to");
                        Console.WriteLine("X : " + X2.Text);
                        Console.WriteLine("Y : " + Y2.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X2.Text), Convert.ToInt32(Y2.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X2.Text), Convert.ToInt32(Y2.Text)));


                    }
                    if (pressedKey == Keys.D3)
                    {
                        Utilities.LoggerInfo("Hotkey #3 -> Clicking to");
                        Console.WriteLine("X : " + X3.Text);
                        Console.WriteLine("Y : " + Y3.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X3.Text), Convert.ToInt32(Y3.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X3.Text), Convert.ToInt32(Y3.Text)));


                    }
                    if (pressedKey == Keys.D4)
                    {
                        Utilities.LoggerInfo("Hotkey #4 -> Clicking to");
                        Console.WriteLine("X : " + X4.Text);
                        Console.WriteLine("Y : " + Y4.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X4.Text), Convert.ToInt32(Y4.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X4.Text), Convert.ToInt32(Y4.Text)));


                    }
                    if (pressedKey == Keys.D5)
                    {
                        Utilities.LoggerInfo("Hotkey #5 -> Clicking to");
                        Console.WriteLine("X : " + X5.Text);
                        Console.WriteLine("Y : " + Y5.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X5.Text), Convert.ToInt32(Y5.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X5.Text), Convert.ToInt32(Y5.Text)));


                    }
                    if (pressedKey == Keys.D6)
                    {
                        Utilities.LoggerInfo("Hotkey #6 -> Clicking to");
                        Console.WriteLine("X : " + X5.Text);
                        Console.WriteLine("Y : " + Y5.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X6.Text), Convert.ToInt32(Y6.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X6.Text), Convert.ToInt32(Y6.Text)));


                    }
                    if (pressedKey == Keys.X)
                    {
                        Utilities.LoggerInfo("Hotkey #7 -> Clicking to");
                        Console.WriteLine("X : " + X7.Text);
                        Console.WriteLine("Y : " + Y7.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X7.Text), Convert.ToInt32(Y7.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X7.Text), Convert.ToInt32(Y7.Text)));


                    }
                    if (pressedKey == Keys.M)
                    {
                        Utilities.LoggerInfo("Hotkey #8 -> Clicking to");
                        Console.WriteLine("X : " + X8.Text);
                        Console.WriteLine("Y : " + Y8.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X8.Text), Convert.ToInt32(Y8.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X8.Text), Convert.ToInt32(Y8.Text)));


                    }
                    if (pressedKey == Keys.I)
                    {
                        Utilities.LoggerInfo("Hotkey #9 -> Clicking to");
                        Console.WriteLine("X : " + X9.Text);
                        Console.WriteLine("Y : " + Y9.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X9.Text), Convert.ToInt32(Y9.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X9.Text), Convert.ToInt32(Y9.Text)));


                    }
                    if (pressedKey == Keys.Enter)
                    {
                        ChatMode = true;
                        press = press + 1;

                        Utilities.LoggerInfo("Hotkey #10 -> Opening chat to");
                        Console.WriteLine("X : " + X10.Text);
                        Console.WriteLine("Y : " + Y10.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X10.Text), Convert.ToInt32(Y10.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X10.Text), Convert.ToInt32(Y10.Text)));
                       

                    }

                    if (pressedKey == Keys.N)
                    {


                        Utilities.LoggerInfo("Hotkey #12 -> Clicking to");
                        Console.WriteLine("X : " + X12.Text);
                        Console.WriteLine("Y : " + Y12.Text);
                        IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                        ForegroundWindowBypass.Set(hWnd);
                        Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X12.Text), Convert.ToInt32(Y12.Text)));
                        Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X12.Text), Convert.ToInt32(Y12.Text)));


                    }
                    if (pressedKey == Keys.Insert)
                    {

                        Utilities.LoggerInfo("Hotkey #10 -> Showing WSA Touch");
                        this.TopMost = true;
                        this.Show();

                    }
                    if (pressedKey == Keys.Home)
                    {
                        Utilities.LoggerInfo("Hotkey #10 -> Hiding WSA Touch");
                        this.TopMost = false;
                        this.Hide();

                    }
                }
               
            }
            //this gets called automatically by the KeyboardHook when ANY key is released
            // e contains the event information
          

            /*
            It would be better practice to use a "switch statement" (https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch)
            instead of if and else here, but I kept it like that.
            */

    
        

        }

    
        private void BtnSaveCoordinates_Click_1(object sender, EventArgs e)
        {

            Properties.Settings.Default.X1 = Convert.ToInt32(X1.Text);
            Properties.Settings.Default.X2 = Convert.ToInt32(X2.Text);
            Properties.Settings.Default.X3 = Convert.ToInt32(X3.Text);
            Properties.Settings.Default.X4 = Convert.ToInt32(X4.Text);
            Properties.Settings.Default.X5 = Convert.ToInt32(X5.Text);
            Properties.Settings.Default.X6 = Convert.ToInt32(X6.Text);
            Properties.Settings.Default.X7 = Convert.ToInt32(X7.Text);
            Properties.Settings.Default.X8 = Convert.ToInt32(X8.Text);
            Properties.Settings.Default.X9 = Convert.ToInt32(X9.Text);
            Properties.Settings.Default.X10 = Convert.ToInt32(X10.Text);
            Properties.Settings.Default.X11 = Convert.ToInt32(X11.Text);
            Properties.Settings.Default.X12 = Convert.ToInt32(X12.Text);
            Properties.Settings.Default.X13 = Convert.ToInt32(X13.Text);
            Properties.Settings.Default.X14 = Convert.ToInt32(X14.Text);
            Properties.Settings.Default.X15 = Convert.ToInt32(X15.Text);

            Properties.Settings.Default.Y1 = Convert.ToInt32(Y1.Text);
            Properties.Settings.Default.Y2 = Convert.ToInt32(Y2.Text);
            Properties.Settings.Default.Y3 = Convert.ToInt32(Y3.Text);
            Properties.Settings.Default.Y4 = Convert.ToInt32(Y4.Text);
            Properties.Settings.Default.Y5 = Convert.ToInt32(Y5.Text);
            Properties.Settings.Default.Y6 = Convert.ToInt32(Y6.Text);
            Properties.Settings.Default.Y7 = Convert.ToInt32(Y7.Text);
            Properties.Settings.Default.Y8 = Convert.ToInt32(Y8.Text);
            Properties.Settings.Default.Y9 = Convert.ToInt32(Y9.Text);
            Properties.Settings.Default.Y10 = Convert.ToInt32(Y10.Text);
            Properties.Settings.Default.Y11 = Convert.ToInt32(Y11.Text);
            Properties.Settings.Default.Y12 = Convert.ToInt32(Y12.Text);
            Properties.Settings.Default.Y13 = Convert.ToInt32(Y13.Text);
            Properties.Settings.Default.Y14 = Convert.ToInt32(Y14.Text);
            Properties.Settings.Default.Y15 = Convert.ToInt32(Y15.Text);

            Properties.Settings.Default.Save();
            Utilities.LoggerSuccess("Saved settings");
        }

        private void dreamButton1_Click(object sender, EventArgs e)
        {
            _keyboardHook.Stop();
        }

        private void dreamButton2_Click(object sender, EventArgs e)
        {
            _keyboardHook.Start();
        }
    }
}
