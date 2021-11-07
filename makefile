
IMAGE_NAME = loremipsumsharp/grpc-json-transcoding-perf-test:1.0.0


clean:
	rm -rf dist/

build:clean
	#https://github.com/grpc-ecosystem/grpc-gateway/issues/1879
	protoc  -I ./proto --include_imports --include_source_info --descriptor_set_out=./proto/echo.pb echo.proto
	dotnet publish ./src/GrpcJsonTranscondingPerfTest.Server/GrpcJsonTranscondingPerfTest.Server.csproj -c Release -o ./dist

build-image:build
	docker build -f Dockerfile --no-cache --rm -t $(IMAGE_NAME) .


push-image:build-image
	docker push $(IMAGE_NAME)

benchmark-json:clean
	dotnet publish -c Release ./src/GrpcJsonTranscondingPerfTest.JsonClient -o ./dist
	cd dist && dotnet GrpcJsonTranscondingPerfTest.JsonClient.dll

benchmark-grpc:clean
	dotnet publish -c Release ./src/GrpcJsonTranscondingPerfTest.GrpcClient -o ./dist
	cd dist && dotnet GrpcJsonTranscondingPerfTest.GrpcClient.dll


benchmark-envoy:clean
	dotnet publish -c Release ./src/GrpcJsonTranscondingPerfTest.EnvoyClient -o ./dist
	cd dist && dotnet GrpcJsonTranscondingPerfTest.EnvoyClient.dll

