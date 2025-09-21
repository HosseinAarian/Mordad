using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroService.Infrastructure.Messaging;

public class RabbitMqPublisher
{
	private readonly IConfiguration configuration;
	private IConnection connection;

	public RabbitMqPublisher(IConfiguration configuration)
	{
		this.configuration = configuration;
		var factory = new ConnectionFactory()
		{
			HostName = configuration["RabbitMQ:HostName"],
			UserName = configuration["RabbitMQ:UserName"],
			Password = configuration["RabbitMQ:Password"],
			Port = int.Parse(configuration["RabbitMQ:Port"])
		};
		connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
	}

	public void Publish<T>(string queueName, T message)
	{
		using var channel = connection.CreateChannelAsync().GetAwaiter().GetResult();
		channel.QueueDeclareAsync(queueName, durable: true, exclusive: false, autoDelete: false);


	}
}
