#when running container make sure to set port to: anynumber:4200 
FROM node:14.17.6-alpine as build-step
RUN apk update && apk add bash
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . /app
RUN npm run build


FROM nginx:stable-alpine as production-stage
COPY --from=build-step /app/dist /usr/share/nginx/html
COPY --from=build-step /app/entrypoint.sh /usr/share/nginx/html
RUN chmod +X /usr/share/nginx/html/entrypoint.sh
EXPOSE 4200
ENTRYPOINT ["/app/entrypoint.sh"]
