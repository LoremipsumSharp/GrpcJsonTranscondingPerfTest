FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY --from=envoyproxy/envoy:v1.19.1 /usr/local/bin/envoy /usr/local/bin

COPY proto/echo.pb /data/echo.pb
COPY envoy/envoy.yaml /etc/envoy/envoy.yaml
COPY docker-entrypoint.sh /app/docker-entrypoint.sh
RUN chmod +x /app/docker-entrypoint.sh

COPY ./dist ./app
WORKDIR /app



ENTRYPOINT ["/app/docker-entrypoint.sh"]