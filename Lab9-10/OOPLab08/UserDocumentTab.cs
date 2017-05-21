using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPLab08
{
    /// <summary>
    /// Представляет пользовательский документ в виде вкладки и информации о расположении
    /// </summary>
    class UserDocumentTab : TabItem
    {
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}