#!/bin/bash

# Start Minikube
minikube start

# Deploy k8s
kubectl apply -f k8s/app-secrets.yaml
kubectl apply -f k8s/pv-db.yaml
kubectl apply -f k8s/pvc-db.yaml
kubectl apply -f k8s/tech-challenge-db-service.yaml
kubectl apply -f k8s/tech-challenge-db-deployment.yaml
kubectl apply -f k8s/tech-challenge-api-service.yaml
kubectl apply -f k8s/tech-challenge-api-deployment.yaml

# Create tunnel
echo "Aguarda 60 segundos para criar o tunel do service da api"
sleep 60
echo "Criando tunel"
minikube service svc-tech-challenge-api --url