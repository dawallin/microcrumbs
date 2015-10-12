namespace java com.twitter.zipkin.gen
namespace rb Zipkin

include "scribe.thrift"
include "zipkinDependencies.thrift"

exception AdjustableRateException {
  1: string msg
}

exception StoreAggregatesException {
  1: string msg
}

service ZipkinCollector extends scribe.Scribe {

    /** Aggregates methods */
    void storeTopAnnotations(1: string service_name, 2: list<string> annotations) throws (1: StoreAggregatesException e);
    void storeTopKeyValueAnnotations(1: string service_name, 2: list<string> annotations) throws (1: StoreAggregatesException e);
    void storeDependencies(1: zipkinDependencies.Dependencies dependencies) throws (1: StoreAggregatesException e);
}