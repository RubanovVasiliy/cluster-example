#!/bin/bash

docker stop container

docker rmi  image
docker rm container

docker build -t image .  
docker run -d -p 3000:80 --name container image 

