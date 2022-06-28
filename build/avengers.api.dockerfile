FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/src/Avengers.API/Avengers.API.csproj", "Avengers.API/"]
COPY ["/src/Avengers.Models/Avengers.Models.csproj", "Avengers.Models/"]
RUN dotnet restore "Avengers.API/Avengers.API.csproj"
RUN dotnet restore "Avengers.Models/Avengers.Models.csproj"
COPY ["/src/Avengers.API/", "Avengers.API/"]
COPY ["/src/Avengers.Models/", "Avengers.Models/"]
WORKDIR "/src/Avengers.Models/"
RUN dotnet build "Avengers.Models.csproj"
RUN dotnet publish "Avengers.Models.csproj" -c Release -o /app
WORKDIR "/src/Avengers.API/"
RUN dotnet build "Avengers.API.csproj"
RUN dotnet publish "Avengers.API.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Avengers.API.dll"]