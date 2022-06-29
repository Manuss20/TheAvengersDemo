FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/src/Avengers.Web/Avengers.Web.csproj", "Avengers.Web/"]
COPY ["/src/Avengers.Models/Avengers.Models.csproj", "Avengers.Models/"]
RUN dotnet restore "Avengers.Web/Avengers.Web.csproj"
RUN dotnet restore "Avengers.Models/Avengers.Models.csproj"

COPY ["/src/Avengers.Models/", "Avengers.Models/"]
COPY ["/src/Avengers.Web/", "Avengers.Web/"]
WORKDIR "/src/Avengers.Models/"
RUN dotnet publish "Avengers.Models.csproj" -c Release -o /app/build
RUN dotnet publish "Avengers.Models.csproj" -c Release -o /app/publish
WORKDIR "/src/Avengers.Web/"
RUN dotnet build "Avengers.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Avengers.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
EXPOSE 80
EXPOSE 443
WORKDIR /var/www/web
COPY --from=publish /app/publish/wwwroot .
COPY "/src/Avengers.Web/nginx.conf" /etc/nginx/nginx.conf