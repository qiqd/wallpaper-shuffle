using System;
using System.Drawing;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    public partial class MainForm : Form
    {
        private readonly AutoChangeDarkTask schedule;
        private WindowTopMost windowTopMost;

        public MainForm()
        {
            InitializeComponent();
            RegisterHandle.mainForm = this;
            this.registerHandle = new RegisterHandle();
            this.schedule = new AutoChangeDarkTask() { mainForm = this };
            AutoChangeDarkTask.mainFormHandle = this.Handle;
            InitializeTheme();
        }

        /// <summary>
        /// 根据当前时间初始化主题。
        /// </summary>
        private void InitializeTheme()
        {
            //Console.WriteLine(Properties.Settings.Default.LightStart);
            this.LightStartTimePicker.Value = Properties.Settings.Default.LightStart;
            this.DarkStartTimePicker.Value = Properties.Settings.Default.DarkStart;
            this.EnableAutoDarkModeCheckBox.Checked = Properties.Settings.Default.EnableAutoDarkMode;
            this.EnableTopMostCheckBox.Checked = Properties.Settings.Default.EnableWindowsTopMost;
            DateTime now = DateTime.Now;
            if (now.TimeOfDay >= AutoChangeDarkTask.lightStart.TimeOfDay && now.TimeOfDay < AutoChangeDarkTask.darkStart.TimeOfDay)
            {
                RegisterHandle.ChangeModeToLight(true);
                //ApplyLightTheme(this);
            }
            else
            {
                RegisterHandle.ChangeModeToLight(false);
                //ApplyDarkTheme(this);
            }
        }

        /// <summary>
        /// 应用深色主题到指定控件及其子控件。
        /// </summary>
        /// <param name="control"></param>
        public void ApplyDarkTheme(Control control)
        {
            control.BackColor = Color.FromArgb(45, 45, 48);
            control.ForeColor = Color.White;
            foreach (Control child in control.Controls)
            {
                ApplyDarkTheme(child);
            }
        }

        /// <summary>
        /// 应用浅色主题到指定控件及其子控件。
        /// </summary>
        /// <param name="control"></param>
        public void ApplyLightTheme(Control control)
        {
            control.BackColor = SystemColors.Window;
            control.ForeColor = SystemColors.ControlText;
            foreach (Control child in control.Controls)
            {
                ApplyLightTheme(child);
            }
        }

        /// <summary>
        /// 切换应用本身的主题。
        /// </summary>
        /// <param name="isDarkMode"></param>
        public void ToggleTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                this.ApplyDarkTheme(this);
            }
            else
            {
                this.ApplyLightTheme(this);
            }
        }

        /// <summary>
        /// 浅色模式开始时间的值改变事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LightStart_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            Properties.Settings.Default.LightStart = dateTimePicker.Value;
            Properties.Settings.Default.Save();
            this.schedule.InitializeSchedule();
        }

        /// <summary>
        /// 深色模式开始时间的值改变事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DarkStart_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            Properties.Settings.Default.DarkStart = dateTimePicker.Value;
            Properties.Settings.Default.Save();
            this.schedule.InitializeSchedule();
        }

        /// <summary>
        /// 强制切换到深色或浅色模式的单选按钮点击事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForceChangingMode(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            RegisterHandle.ChangeModeToLight(radioButton?.Tag?.ToString() == "0");
        }

        /// <summary>
        /// 是否启用置顶窗口功能的复选框值改变事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableWindowTopMost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Properties.Settings.Default.EnableWindowsTopMost = checkBox.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 取消所有置顶窗口的菜单项点击事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAllTopMenuItem_Click(object sender, EventArgs e)
        {
            if (this.windowTopMost == null) return;
            windowTopMost.RemoveAllTopWindows();
            this.windowTopMost = null;
        }

        /// <summary>
        /// 状态栏图标双击事件处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.windowTopMost == null)
            {
                this.windowTopMost = new WindowTopMost();
            }
            if (this.EnableTopMostCheckBox.Checked)
            {
                windowTopMost.SetWindowTopMost();
            }
        }

        /// <summary>
        /// 鼠标移动到托盘图标上时显示提示信息。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            this.WallPaperShuffleNotify.Text = this.windowTopMost == null ? "WallpaperShuffle" : $"WallpaperShuffle - 置顶窗口数: {this.windowTopMost.GetTopWindowsCount()}";
        }

        /// <summary>
        /// 启用或禁用自动深色模式切换功能。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableAutoDark_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Properties.Settings.Default.EnableAutoDarkMode = checkBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}