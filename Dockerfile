FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

#copy csproj 
COPY ./*.csproj ./
RUN dotnet restore

#copy build
COPY . .
RUN dotnet publish -c Release -o out

#build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "API.dll" ]