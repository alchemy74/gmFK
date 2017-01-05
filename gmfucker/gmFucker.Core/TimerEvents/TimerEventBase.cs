using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace gmFucker.Core.TimerEvents
{
   public abstract class TimerEventBase : IDisposable
    {
        public TimerEventBase(double interval)
        {
            this.Timer.Interval = interval;
            this.Timer.AutoReset = false;
            this.Timer.Elapsed += Timer_Elapsed;            
        }

        /// <summary>
        /// 表示於TimerEventBase.Timer間隔耗盡時觸發的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        /// <summary>
        /// 將 System.Timers.Timer.Enabled 設定為 true，開始引發 System.Timers.Timer.Elapsed 事件。
        /// </summary>
        public void start()
        {
            this.Timer.Start();
        }
        
        /// <summary>
        /// 將 System.Timers.Timer.Enabled 設定為 false，停止引發 System.Timers.Timer.Elapsed 事件。
        /// </summary>
        public void stop()
        {
            this.Timer.Stop();
        }

        /// <summary>
        /// 釋放 System.Timers.Timer 所使用的所有資源。
        /// </summary>
        public void Dispose()
        {
            this.Timer.Dispose();
        }

        /// <summary>
        /// 產生應用程式中的循環事件
        /// </summary>
        private Timer Timer { get; set; }
    }
}
