using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buton_Yarisi
{
    class mesajver
    {
        public void mesajgetir(string mesaj)
        {
           System.Windows.Forms.MessageBox.Show(mesaj, "Yarış Bitti",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Asterisk);
        }
    }
}
