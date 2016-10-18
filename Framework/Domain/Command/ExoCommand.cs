using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WS_Hotline.Framework.Domain.Command
{
    public abstract class ExoCommand : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(Expression<Func<string>> propertyExpression)
        {
            if (this.PropertyChanged == null) return;

            var body = propertyExpression.Body as MemberExpression;
            this.PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
        }

        /// <summary>
        /// Methode to launch command Execution with pre action
        /// </summary>
        public async Task Execute()
        {
            if (this.IsValide())
            {

                // On place dans un nouveau thread l'éxécution des commandes qui peux prendre du temps.
                var lBackgroundDbTask = Task.Factory.StartNew(() => this.ExecuteWhenIsValided(),
                    TaskCreationOptions.LongRunning);
                // le retour final de la command si il y, sera fait au niveau de la méthode "SendWhenIsExecuted"
                await
                    lBackgroundDbTask.ContinueWith(pT => this.SendWhenIsExecuted(),
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
           
        }

        /// <summary>
        /// Methode to verify that event is valid.
        /// </summary>
        public virtual bool IsValide()
        {
            return true;
        }

        /// <summary>
        /// Methode executing if event parameters are valid.
        /// </summary>
        public virtual async Task ExecuteWhenIsValided()
        {
            return;
        }

        /// <summary>
        /// Methode to verify that event is valid.
        /// </summary>
        public virtual void SendWhenIsExecuted()
        {
            return;
        }
    }
}