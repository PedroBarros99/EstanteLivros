namespace EstanteLivros.DTO
{
    public class MessagingHelper
    {
        public bool success { get; set; }

        public string message { get; set; }


    }

    public class MessagingHelper<T>
    {
        public bool success { get; set; }

        public string message { get; set; }

        public T obj { get; set; }

    }
}
