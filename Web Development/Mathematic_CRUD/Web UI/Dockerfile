FROM node:21-alpine
COPY . /app
WORKDIR /app
RUN npm install && npm run build
CMD ["npm", "run", "preview","--","--host"]
