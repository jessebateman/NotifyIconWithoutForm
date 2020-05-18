using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace NotifyIconWithoutForm
{
    public class AppContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private ToolStripLabel programText;
        private ToolStripMenuItem exitButton;
        private System.ComponentModel.IContainer components;

        public AppContext()
        {
            InitializeAppContextComponent();
        }

        private void InitializeAppContextComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new ContextMenuStrip();
            this.programText = new ToolStripLabel();
            this.exitButton = new ToolStripMenuItem();

            this.contextMenu.Items.Add(this.programText);

            // Initialize programText
            this.programText.Text = "Hello World.";

            this.contextMenu.Items.Add(this.exitButton);

            // Initialize exitButton
            this.exitButton.Text = "Exit Program";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);

            // Create the NotifyIcon.
            this.notifyIcon = new NotifyIcon(components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon.ContextMenuStrip = this.contextMenu;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon.Text = "AppContext (NotifyIcon example)";
            notifyIcon.Visible = true;

            // Handle the MouseClick event to show stuff.
            notifyIcon.MouseClick += new MouseEventHandler(this.notifyIcon_MouseClick);
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //left click should also open the context menu
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu",
                 BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }

        private void exitButton_Click(object Sender, EventArgs e)
        {
            notifyIcon.Icon.Dispose();
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
