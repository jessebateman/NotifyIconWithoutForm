using System;
using System.Windows.Forms;

namespace NotifyIconWithoutForm
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new AppContext());
        }
    }
}
