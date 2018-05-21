using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class SyncMessageQueue<T>
    {
        private string mqName;
        MessageQueue mq;

        public SyncMessageQueue(string mqName)
        {
            this.mqName = @".\private$\" + mqName;
            if (!MessageQueue.Exists(this.mqName))
            {
                MessageQueue.Create(this.mqName);
            }

            mq = new MessageQueue(@"FormatName:direct=os:" + this.mqName);
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
        }

        public void Send(T t)
        {
            mq.Send(t);
        }

        public T Receive()
        {
            return (T)mq.Receive().Body;
        }
    }
}

