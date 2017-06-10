cd $HOME/build/partei/webapp/Application
dotnet publish -c Release -o ./docker_workdir/app 
npm install
npm run build
cp ../Application/wwwroot/* ./docker_workdir/app/wwwroot
cp -r ../Application/uploaded_images ./docker_workdir/app/uploaded_images
cp ../buildscripts/Dockerfile ./docker_workdir
cd docker_workdir
docker build -t robisrob/partei-webapp:$TRAVIS_BUILD_NUMBER .
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push robisrob/partei-webapp:$TRAVIS_BUILD_NUMBER
docker login -u=$HEROKU_USERNAME -p=$HEROKU_AUTH_TOKEN registry.heroku.com;
docker tag robisrob/partei-webapp:$TRAVIS_BUILD_NUMBER registry.heroku.com/partei/web;
docker push registry.heroku.com/partei/web;