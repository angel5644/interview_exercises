using System.Runtime.Serialization;
using System.ServiceModel;

namespace Interview.DesktopApp.Service
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        IList<TodoItem> GetTodoItems();

        [OperationContract]
        void AddTodoItem(TodoItem item);

        [OperationContract]
        void RemoveTodoItem(int itemId);

        [OperationContract]
        void UpdateTodoItem(int itemId, bool isCompleted);
    }

    [DataContract]
    public class TodoItem 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public string Description { get; set; } = string.Empty;
    }
}
