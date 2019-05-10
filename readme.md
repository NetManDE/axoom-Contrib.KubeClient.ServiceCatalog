# Contrib.KubeClient.ServiceCatalog

[![NuGet package](https://img.shields.io/nuget/v/Contrib.KubeClient.ServiceCatalog.svg)](https://www.nuget.org/packages/Contrib.KubeClient.ServiceCatalog/)
[![Build status](https://img.shields.io/appveyor/ci/AXOOM/contrib-kubeclient-servicecatalog.svg)](https://ci.appveyor.com/project/AXOOM/contrib-kubeclient-servicecatalog)

This extends the [KubeClient](https://github.com/tintoy/dotnet-kube-client) library with support for the resources used by the [Kubernetes Service Catalog](https://kubernetes.io/docs/concepts/extend-kubernetes/service-catalog/).

## Usage

You can register clients that allow you to read and write Service Catalog resources with dependency injection:

```csharp
services.AddClusterServiceClassClient()  // registers ICustomResourceClient<ClusterServiceClass>
        .AddClusterServicePlanClient()   // registers ICustomResourceClient<ClusterServicePlan>
        .AddClusterServiceBrokerClient() // registers ICustomResourceClient<ClusterServiceBroker>
        .AddServiceInstanceClient()      // registers ICustomResourceClient<ServiceInstance>
        .AddServiceBindingClient();      // registers ICustomResourceClient<ServiceBinding>
```

You can also register watchers that observe Service Catalog resources for changes:

```csharp
services.AddClusterServiceClassWatcher()  // registers ICustomResourceWatcher<ClusterServiceClass>
        .AddClusterServicePlanWatcher()   // registers ICustomResourceWatcher<ClusterServicePlan>
        .AddClusterServiceBrokerWatcher() // registers ICustomResourceWatcher<ClusterServiceBroker>
        .AddServiceInstanceWatcher()      // registers ICustomResourceWatcher<ServiceInstance>
        .AddServiceBindingWatcher();      // registers ICustomResourceClient<ServiceBinding>
```

The watchers implement the `IHostedService` interface, which causes [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services) to automatically start and stop them with the hosting service.

## Development

Run `build.ps1` to compile the source code and create NuGet packages.
This script takes a version number as an input argument. The source code itself contains no version numbers. Instead version numbers should be determined at build time using [GitVersion](http://gitversion.readthedocs.io/).
