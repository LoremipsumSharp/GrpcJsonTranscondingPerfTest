#!/bin/bash


envoy -c /etc/envoy/envoy.yaml &

dotnet GrpcJsonTranscondingPerfTest.Server.dll
