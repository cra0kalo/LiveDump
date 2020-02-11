using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace LiveDump
{
    public class CProcess
    {
        private Process _process;
        private Icon _icon;


        public CProcess()
        {

        }

        public CProcess(Process in_proc, Icon in_icon)
        {
            _process = in_proc;
            _icon = in_icon;
        }

        public CProcess(CProcess copy)
        {
            this._process = copy._process;
            this._icon = copy._icon;
        }

        //public
        public Process iProcess
        {
            get
            {
                return _process;
            }
        }

        public Icon iIcon
        {
            get
            {
                return _icon;
            }
        }

        public Bitmap IconAsBitmap
        {
            get
            {
                return _icon.ToBitmap();
            }
        }

        //private functions

    }
}
