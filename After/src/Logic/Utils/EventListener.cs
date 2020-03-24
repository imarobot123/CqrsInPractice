using NHibernate.Event;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Utils
{
    internal class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public void OnPostUpdate(PostUpdateEvent ev)
        {
            DispatchEvents(ev.Entity);
        }

        public void OnPostDelete(PostDeleteEvent ev)
        {
            DispatchEvents(ev.Entity);
        }

        public void OnPostInsert(PostInsertEvent ev)
        {
            DispatchEvents(ev.Entity);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent ev)
        {
            // Hi Vladimir, please put a breakpoint here.
            // Then try to enroll a student to a course, using WPF app, which would execute EnrollCommand.
            // Once this breakpoint hits, open up SSMS Query Analyzer and execute "select * from Enrollment" sql statement
            // It would just hang, until debugger steps out of this method.
            DispatchEvents(ev.AffectedOwnerOrNull);
        }

        private void DispatchEvents(object obj)
        {
            // No need for real DomainEvent, lets just pretend it's handler runs ADO command that would select from Enrollment and Student tables, in order to project data to "Read" database.
            // Simply use SSMS Query Analyzer to simulate this, by running a select statement on [Enrollment] table. It should be locked at this point.
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}