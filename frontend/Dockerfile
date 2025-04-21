FROM node:18-alpine3.17 as build

WORKDIR /app
COPY . /app

RUN rm .env
RUN npm install
RUN npm run build

FROM nginx:stable-alpine
COPY --from=build /app/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/dist /usr/share/nginx/html/
EXPOSE 80
CMD ["nginx","-g","daemon off;"]