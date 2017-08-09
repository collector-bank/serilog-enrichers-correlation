[![Build status](https://ci.appveyor.com/api/projects/status/deu8u7lck3oorwex/branch/master?svg=true)](https://ci.appveyor.com/project/CollectorHeimdal/serilog-enrichers-correlation/branch/master)

# serilog-enrichers-correlation

Enricher that adds the current correlation id to Serilog log messages.

The enricher requires the [Collector Common Correlation](https://github.com/collector-bank/common-correlation) package to work. The correlation id present in the current correlation state will be used to enrich the log message. If no correlation id is present the property will be empty.
