FROM mcr.microsoft.com/dotnet/sdk:3.1 as build-env
WORKDIR /app

COPY "User Back-End.csproj"" ./
RUN dotnet publish "User Back-End.csproj" -c Release -r ubuntu.14.04-x64 --self-contained true -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 44335
ENTRYPOINT ["dotnet", "User Back-End.dll" ]
