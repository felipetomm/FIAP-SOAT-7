#!/bin/bash

docker-compose -f docker-compose.build.yml build
docker push felipetomm/fiap-soat-7:tech-challenge-api