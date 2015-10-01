Microcrumbs [![Build status](https://ci.appveyor.com/api/projects/status/github/dawallin/microcrumbs?branch=master&svg=true)](https://ci.appveyor.com/project/dawallin/microcrumbs) 
===================

Microcrumbs is an open source, .Net tracer library for distributed tracing. 

###What is distributed tracing?
In the world of microservices, responsibilities are broken down into small individual pieces, loosely coupled often connected first at runtime. The connection could be an event where the publisher is even unaware of who is subscribing. 
>**Distributed tracing** binds together what started an interaction and which actors that were involved.

###End-to-End tracing
The tracer data can then be sent to a centralized collector. From there it can be used for monitoring, querying or analysing in end-to-end distributor tracing tools like [Zipkin](https://twitter.github.io/zipkin/),  [PinPoint](https://github.com/naver/pinpoint) or [Phosphor](https://github.com/mattheath/phosphor). All these are based on the technique from the Google [Dapper project](https://research.google.com/pubs/pub36356.html).

### Project scope
Microcrumbs adhere to the Unix Philosophy ("Write programs that do one thing and do it well."), and is specialiced in only one thing, gathering interaction data. Analysis and presentaion is left for other projects.