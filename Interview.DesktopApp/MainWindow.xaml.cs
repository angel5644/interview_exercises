using Interview.DesignPatterns.Singleton;
using Interview.DesktopApp.Service;
using System.Windows;
using System.Windows.Controls;

namespace Interview.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoService todoService;

        public MainWindow()
        {
            InitializeComponent();
            todoService = new TodoService(MemoryCacheManager.GetInstance(), RedisCacheManager.GetInstance());

            RefreshTodoList();
        }

        private void RefreshTodoList() 
        {
            dgTodo.ItemsSource = todoService.GetTodoItems();
            dgTodo.Items.Refresh();
        }

        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTodo.Text)) 
            {
                return;
            }

            todoService.AddTodoItem(new TodoItem() { Title = txtTodo.Text, Description = txtDescription.Text });
            txtTodo.Text = "";
            txtDescription.Text = "";
            RefreshTodoList();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e) 
        {
            var checkBox = (CheckBox)sender;

            var item = (TodoItem)checkBox.DataContext;

            todoService.UpdateTodoItem(item.Id, checkBox.IsChecked == true);

            RefreshTodoList();
        }

        private void RemoveTodo_Click(object sender, RoutedEventArgs e)
        {
            var todoItems = dgTodo.SelectedItems.Cast<TodoItem>().ToList();

            foreach (var item in todoItems) 
            {
                todoService.RemoveTodoItem(item.Id);
            }

            RefreshTodoList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoList();
        }
    }
}