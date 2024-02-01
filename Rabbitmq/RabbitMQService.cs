using System;
using System.Text;
using RabbitMQ.Client;

namespace VolunTrackApp.Rabbitmq
{
    public class RabbitMQService
    {
        private readonly ConnectionFactory _factory;
        private readonly string _exchangeName;
        private readonly string _routingKey;

        public RabbitMQService(string hostname, string username, string password, string exchangeName, string routingKey)
        {
            _factory = new ConnectionFactory()
            {
                //hostname es la ip de mi maquina
                HostName = hostname,
                UserName = username,
                Password = password,
                Port = 5672
            };

            _exchangeName = exchangeName;
            _routingKey = routingKey;
        }

        public void SendMessage(string message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(_exchangeName, _routingKey, null, body);

                Console.WriteLine("Mensaje enviado: {0}", message);
            }
        }
    }
}
