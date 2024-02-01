using VolunTrackApp.Rabbitmq;

namespace AppVolunTrack
{
    public partial class MainPage : ContentPage
    {
        private readonly RabbitMQService _rabbitMQService;

        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            // Inicializar la instancia de RabbitMQService con la configuración adecuada
            _rabbitMQService = new RabbitMQService("172.26.16.1", "guest", "guest", "testTopic", "notificaciones");
        }

        private void OnCounterClicked2(object sender, EventArgs e)
        {
            _rabbitMQService.SendMessage("Hola, 2");
        }
    }

}
