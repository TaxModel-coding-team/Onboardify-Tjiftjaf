FROM mcr.microsoft.com/dotnet/sdk:3.1 as build-env
WORKDIR /app

EXPOSE 80
EXPOSE 44329

COPY back-end.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "back-end.dll" ]
