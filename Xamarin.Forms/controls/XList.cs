using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YourProject.Controls
{
    public class XList : ListView
    {
        public XList()
        {
            HasUnevenRows = true;
            ItemTapped += (sender, e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}
