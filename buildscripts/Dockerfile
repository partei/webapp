# Version: 0.0.1
FROM microsoft/aspnetcore:1.1.2
MAINTAINER Rob Swartenbroekx "rob.swartenbroekx@gmail.com"
ENV PORT="5001"
ENV AWS_ACCESS_KEY_ID=""
ENV AWS_SECRET_ACCESS_KEY=""
EXPOSE 5001
WORKDIR /app
COPY app .
RUN mkdir /home/app
RUN chmod 777 /home/app
RUN useradd app
USER app
CMD dotnet Application.dll --port $PORT aws_access_key_id $AWS_ACCESS_KEY_ID aws_secret_access_key $AWS_SECRET_ACCESS_KEY