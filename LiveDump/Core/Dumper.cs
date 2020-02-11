using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveDump
{
    public class Dumper
    {
        RemoteMemory rm;

        bool dumping = false; //are we dumping currently
        System.Timers.Timer dumping_timer;
        IntPtr dumping_address;
        Int32 dumping_size;
        String dumping_filepath;

        public enum DUMPINGSTAT
        {
            DUMPING,
            IDLE
        }

        //events
        public delegate void DumpingStatus(DUMPINGSTAT stat);
        public event DumpingStatus DumpingStatusChanged;

        public delegate void MessageBoxEv(string message, MessageBoxButtons buttons,  MessageBoxIcon icon);
        public event MessageBoxEv RaiseMessagebox;

        public bool Dumping
        {
            get
            {
                return dumping;
            }
        }


        public Dumper(CProcess proc)
        {
            rm = new RemoteMemory(proc.iProcess.Id);
        }


        public bool DumpOnce(IntPtr address, int size, string dmp_filepath)
        {
            try
            {
                byte[] buffer = rm.ReadArray<byte>(address, size);
                if (buffer.Length != size)
                    return false;
                File.WriteAllBytes(dmp_filepath, buffer);
            }
            catch
            {
                return false; //EXCEPTION!
            }

            return true;
        }

        public void DumpCycle(IntPtr address, int size, int cycleFeq, string dmp_filepath)
        {
            StopDumping();

            dumping_address = address;
            dumping_size = size;
            dumping_filepath = dmp_filepath;

            //spawn a new timer
            dumping_timer = new System.Timers.Timer(cycleFeq);
            dumping_timer.AutoReset = true;
            dumping_timer.Elapsed += dumping_timer_Elapsed;

            dumping = true;
            dumping_timer.Start();
            if (DumpingStatusChanged != null)
                DumpingStatusChanged(DUMPINGSTAT.DUMPING);

        }

        void dumping_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool bDumped = true;
            //Every X milsecs this gets executed
            try
            {
                byte[] buffer = rm.ReadArray<byte>(dumping_address, dumping_size);
                if (buffer.Length != dumping_size)
                    bDumped = false;
                File.WriteAllBytes(dumping_filepath, buffer);
            }
            catch
            {
                bDumped = false;
            }

            //if a cycle failed tell the user
            if (!bDumped)
            {
                this.StopDumping();

                if (RaiseMessagebox != null)
                    RaiseMessagebox("Unable to dump memory on cycle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void StopDumping()
        {
            if (dumping_timer != null)
            {
                dumping = false;
                dumping_timer.Stop();
            }

            if (DumpingStatusChanged != null)
                DumpingStatusChanged(DUMPINGSTAT.IDLE);
        }

        public void Close()
        {
            StopDumping();
            if (rm != null)
                rm.Close();
        }




    }
}
