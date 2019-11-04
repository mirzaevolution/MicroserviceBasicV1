using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;
namespace FxStore.OrderAPI
{
    public class RabbitMQCoreConnection
    {
        private static IConnection _connection;
        
        public static void Init()
        {
            if (_connection == null || (_connection != null && !_connection.IsOpen))
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
                _connection = factory.CreateConnection();
            }
        }
        public static bool Send(string payloadInJson, string targetQueue)
        {
            try
            {
                _connection = OpenIfClosed();
                using(IModel channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(targetQueue,durable:false,exclusive:false,autoDelete:false,arguments:null);
                    var basicProps = channel.CreateBasicProperties();
                    basicProps.Persistent = true;
                    channel.BasicPublish("", targetQueue, basicProps, Encoding.UTF8.GetBytes(payloadInJson));
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        private static IConnection OpenIfClosed()
        {
            if(_connection == null || (_connection!=null && !_connection.IsOpen))
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
                _connection = factory.CreateConnection();
            }
            return _connection;
        }
    }
}
