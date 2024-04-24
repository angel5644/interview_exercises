using Interview.DesignPatterns.Singleton;
using System.Text.Json;

namespace Interview.DesktopApp.Service
{
    public class TodoService : ITodoService
    {
        private MemoryCacheManager cacheManager_;
        private RedisCacheManager cacheManager;
        private readonly string todosCacheKey = "todos";
        private readonly TimeSpan defaultCacheExpiration = new TimeSpan(0, 5, 0);

        private int nextId = 1;

        public TodoService(MemoryCacheManager cacheManager_, RedisCacheManager cacheManager) 
        {
            this.cacheManager_ = cacheManager_;
            this.cacheManager = cacheManager;

            var todos = GetTodoItems();

            nextId = todos.Count > 0 ? todos.Count + 1 : 1;
        }

        public void AddTodoItem(TodoItem item)
        {
            item.Id = nextId++;

            var currentTodos = GetTodoItems();

            currentTodos.Add(item);

            UpdateTodosInCache(currentTodos);
        }

        public IList<TodoItem> GetTodoItems()
        {
            var todosAsJson = cacheManager.GetStringFromCache(todosCacheKey);

            if (string.IsNullOrEmpty(todosAsJson)) 
            {
                return new List<TodoItem>();
            }

            var todos = JsonSerializer.Deserialize<List<TodoItem>>(todosAsJson);

            return todos ?? new List<TodoItem>();
        }

        public void RemoveTodoItem(int itemId)
        {
            var todos = GetTodoItems();

            var item = todos.FirstOrDefault(_ => _.Id == itemId);

            if (item != null) 
            {
                todos.Remove(item);

                UpdateTodosInCache(todos);
            }
        }

        public void UpdateTodoItem(int itemId, bool isCompleted)
        {
            var todos = GetTodoItems();

            var item = todos.FirstOrDefault(_ => _.Id == itemId);

            if (item != null) 
            {
                item.IsCompleted = isCompleted;

                UpdateTodosInCache(todos);
            }
        }

        private void UpdateTodosInCache(IList<TodoItem> todos) 
        {
            var todosAsJson = JsonSerializer.Serialize(todos);

            cacheManager.AddToCache(todosCacheKey, todosAsJson, defaultCacheExpiration);
        }
    }
}
