namespace Problem01.CircularQueue
{
    public class Node<T>
    {
       

        public Node(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}