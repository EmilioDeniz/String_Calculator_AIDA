FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore StringCalculator.sln

# Build and publish a release
RUN dotnet build StringCalculator.sln -c Release --no-restore
RUN dotnet test StringCalculator.sln -c Release --no-restore --no-build
RUN dotnet publish ./StringCalculatorAPI/StringCalculatorAPI.csproj -c Release -o out --no-restore --no-build

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "StringCalculatorAPI.dll"]
