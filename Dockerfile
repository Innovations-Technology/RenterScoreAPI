FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS build
WORKDIR /src/RenterScoreAPI
COPY /RenterScoreAPI .
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

WORKDIR /src/RenterScoreAPI.Test.Integration
COPY /RenterScoreAPI.Test.Integration .
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "RCApi.dll"]