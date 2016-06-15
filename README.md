Microcrumbs [![Build status](https://ci.appveyor.com/api/projects/status/github/dawallin/microcrumbs?branch=master&svg=true)](https://ci.appveyor.com/project/dawallin/microcrumbs) 
===================

Microcrumbs is all about distributed tracing. Here you will find information how to gather trace information for a request jumping between different microservices. 

Microcrumbs supports the Open Source initiative, [Open Tracing API](http://opentracing.io/), which standardize a language independent tracing API without vendor lock-in.

The focus for Microcrumbs is on .Net BUT since the terminology, techniques and visualization tools are language agnostic there is plenty of information even for non .Net visitors.

## What is distributed tracing?
In the world of microservices, responsibilities are broken down into small individual pieces, loosely coupled often connected first at runtime. The connection could be an event where the publisher is even unaware of who is subscribing. 
>**Distributed tracing** binds together what started an interaction and which actors that were involved.

## End-to-End tracing
The tracer data can then be sent to a centralized collector. From there it can be used for monitoring, querying or analysing in end-to-end distributor tracing tools like [Zipkin](https://twitter.github.io/zipkin/),  [PinPoint](https://github.com/naver/pinpoint) or [Phosphor](https://github.com/mattheath/phosphor). All these are based on the technique from the Google [Dapper project](https://research.google.com/pubs/pub36356.html).

## Project scope

Suggested reading
===================

## Projects / Websites
* [Open Tracing](http://opentracing.io/)
* [Open Zipkin](http://zipkin.io/)

## Blog posts
* [A reply to the network is the kingmaker](http://thelastpickle.com/blog/2016/03/16/a-reply-to-the-network-is-the-kingmaker.html)
* [Towards Turnkey Distributed Tracing](Towards Turnkey Distributed Tracing)

## Academic papers
* [Dapper, a Large-Scale Distributed Systems Tracing Infrastructure, B. H. Sigelman et al., 2010](http://research.google.com/pubs/pub36356.html)
* [So, you want to trace your distributed system, R. R. Sambasivan et al., 2014](http://www.pdl.cmu.edu/PDL-FTP/SelfStar/CMU-PDL-14-102_abs.shtml)