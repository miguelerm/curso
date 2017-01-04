docker stop mvc-app-1
docker rm mvc-app-1
docker build -t mvc-app --rm .
docker run --name mvc-app-1 -d mvc-app