# ==============================
# STEP 1: Build the application
# ==============================
FROM mcr.microsoft.com / dotnet / sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY . ./

# Build and publish the app
RUN dotnet publish -c Release -o /app/publish

# ==============================
# STEP 2: Create the runtime image
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app from the build stage
COPY --from=build /app/publish .

# Expose port (adjust if your API runs on a different port)
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

# Run the app
ENTRYPOINT["dotnet", "YourApiName.dll"]
