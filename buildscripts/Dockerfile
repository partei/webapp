# Version: 0.0.1
FROM microsoft/aspnetcore:1.1.2
MAINTAINER Rob Swartenbroekx "rob.swartenbroekx@gmail.com"
ENV PORT="5001"
WORKDIR /app
COPY app .
RUN useradd app
USER app
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Application.dll