# Kubernetes ServiceCatalog Models

Tge [Kubernetes Service Catalog](https://kubernetes.io/docs/concepts/extend-kubernetes/service-catalog/) implements the [Open Service Broker](https://www.openservicebrokerapi.org/) specification. It is configured and queried using Kubernetes resources. This library models those resources as .NET DTOs.

Run `build.ps1` to compile the source code and create NuGet packages.
This script takes a version number as an input argument. The source code itself contains no version numbers. Instead version numbers should be determined at build time using [GitVersion](http://gitversion.readthedocs.io/).
