# GladLive.ProxyLoadBalancer

GladLive is network session service comparable to Xboxlive or Stream. 

The GladLive.ProxyLoadBalancer is the entry point to the GladLive distributed network and preforms this role by providing:
  - Acting as a proxy for authentication requests
  - Tracking preformance of authentication subservers and scaling
  - Providing authenticated clients session tokens to connect into the GladLive network

## GladLive Services

GladLive.ProxyLoadBalancer: https://github.com/GladLive/GladLive.ProxyLoadBalancer

GladLive.AuthenticationService: TBA

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015
  - Add Nuget Feed https://www.myget.org/F/hellokitty/api/v2 in VS (Options -> NuGet -> Package Sources)

## Builds

Available on a Nuget Feed: https://www.myget.org/F/hellokitty/api/v2 (N/A)

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/GladLive/GladLive.ProxyLoadBalancer.svg?branch=master)](https://travis-ci.org/HelloKitty/GladLive/GladLive.ProxyLoadBalancer) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/GladLive/GladLive.ProxyLoadBalancer.svg?branch=dev)](https://travis-ci.org/GladLive/GladLive.ProxyLoadBalancer)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license with the additional requirement of adding the GladLive splashscreen to your product.
