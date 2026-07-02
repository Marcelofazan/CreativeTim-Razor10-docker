# 1. Etapa de Runtime (Imagem leve para rodar o app)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# 2. Etapa de Build (Imagem completa para compilar)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia apenas o .csproj e faz restore limpo
COPY ["CreativeTim.Argon.DotNetCore.Free/CreativeTim.Argon.DotNetCore.Free.csproj", "CreativeTim.Argon.DotNetCore.Free/"]
RUN dotnet restore "CreativeTim.Argon.DotNetCore.Free/CreativeTim.Argon.DotNetCore.Free.csproj"

# Copia o restante dos arquivos
COPY . .

# Remove as pastas bin e obj locais trazidas pelo COPY
RUN rm -rf CreativeTim.Argon.DotNetCore.Free/bin CreativeTim.Argon.DotNetCore.Free/obj

WORKDIR "/src/CreativeTim.Argon.DotNetCore.Free"

# Compila isolando os metadados em uma pasta limpa do Linux
RUN dotnet build "CreativeTim.Argon.DotNetCore.Free.csproj" -c Release -o /app/build /p:BaseIntermediateOutputPath=/tmp/obj/

# 3. Etapa de Publicação
FROM build AS publish
RUN dotnet publish "CreativeTim.Argon.DotNetCore.Free.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:BaseIntermediateOutputPath=/tmp/obj/

# 4. Etapa Final (Gera a imagem de produção limpa)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreativeTim.Argon.DotNetCore.Free.dll"]