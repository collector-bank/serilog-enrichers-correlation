namespace Collector.Serilog.Enrichers.Correlation
{
    using System.Linq;

    using Collector.Common.Correlation;

    using global::Serilog.Core;
    using global::Serilog.Events;

    public class CorrelationEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var currentCorrelationId = CorrelationState.GetCurrentCorrelationId();
            if (currentCorrelationId.HasValue)
            {
                var correlationDictionary = CorrelationState.GetCorrelationValues().ToDictionary(c => c.Key, c => c.Value);

                correlationDictionary["CorrelationId"] = currentCorrelationId.Value;

                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Correlation", correlationDictionary, destructureObjects: true));
            }
        }
    }
}