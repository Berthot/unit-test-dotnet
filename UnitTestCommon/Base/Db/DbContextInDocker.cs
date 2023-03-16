using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace UnitTestCommon.Base.Db;

public class DbContextInDocker<TContext> : IDisposable where TContext : DbContext
{
    private readonly DockerClient _dockerClient;
    private readonly string _containerId;
    protected string ConnectionString;
    private readonly DbContextOptions<TContext> _options;

    protected DbContextInDocker()
    {
        _dockerClient = new DockerClientConfiguration().CreateClient();

        var images = _dockerClient.Images.ListImagesAsync(new ImagesListParameters
        {
            Filters = new Dictionary<string, IDictionary<string, bool>>
            {
                {
                    "reference", new Dictionary<string, bool>
                    {
                        {"postgres:13-alpine", true}
                    }
                }
            }
        }).Result;

        if (images.Count == 0)
        {
            var pullParameters = new ImagesCreateParameters
            {
                FromImage = "postgres",
                Tag = "13-alpine"
            };
            var authConfig = new AuthConfig();
            _dockerClient.Images.CreateImageAsync(pullParameters, authConfig, new Progress<JSONMessage>()).Wait();
        }

        var containerName = "test-db-" + Guid.NewGuid().ToString("N").Substring(0, 12);
        var port = GetRandomOpenPort();
        var envVars = new List<string>
        {
            "POSTGRES_PASSWORD=senha",
            "POSTGRES_DB=TestDatabase"
        };
        var createResponse = _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
        {
            Image = "postgres:13-alpine",
            Name = containerName,
            Tty = true,
            ExposedPorts = new Dictionary<string, EmptyStruct>
            {
                {"5432/tcp", new EmptyStruct()}
            },
            HostConfig = new HostConfig
            {
                PortBindings = new Dictionary<string, IList<PortBinding>>
                {
                    {
                        "5432/tcp",
                        new List<PortBinding>
                        {
                            new PortBinding
                            {
                                HostPort = port.ToString()
                            }
                        }
                    }
                },
                PublishAllPorts = true,
                AutoRemove = true,
            },
            Env = envVars
        }).Result;

        _containerId = createResponse.ID;

        _dockerClient.Containers.StartContainerAsync(_containerId, null).Wait();

        var ipAddress = _dockerClient.Containers.InspectContainerAsync(_containerId).Result.NetworkSettings.Networks
            .First().Value.IPAddress;
        ConnectionString = $"Host={ipAddress};Port={port};Database=TestDatabase;Username=postgres;Password=senha";

        _options = new DbContextOptionsBuilder<TContext>()
            .UseNpgsql(ConnectionString)
            .Options;

        using var context = CreateContext();
        context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        using var context = CreateContext();
        context.Database.EnsureDeleted();

        _dockerClient.Containers.StopContainerAsync(_containerId, new ContainerStopParameters()).Wait();
        // Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        // _dockerClient.Containers.RemoveContainerAsync(_containerId, new ContainerRemoveParameters()).Wait();
    }

    protected TContext CreateContext()
    {
        return (TContext) Activator.CreateInstance(typeof(TContext), _options);
    }

    private int GetRandomOpenPort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint) listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }
}