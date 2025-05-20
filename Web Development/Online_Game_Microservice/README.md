#### Register a user
```sh
curl -X POST \
  http://localhost/register \
  -H 'Content-Type: application/json' \
  -d '{
    "username": "testuserjame",
    "email": "testuserjame@gmail.com",
    "password": "password123"
  }'
```
#### Login user
```sh
curl -X POST \
  http://localhost/login \
  -H 'Content-Type: application/json' \
  -d '{
    "usernameOrEmail": "testuserjame",
    "password": "password123"
  }'
# Copy the "token" from the response. This will be your JWT.
```
#### Get User Profile (using the obtained JWT)
```sh
curl -X GET \
  http://localhost/profile \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN'
```
#### Create a lobby
```sh
curl -X GET \
  http://localhost/profile \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN'
```

#### Get lobbies
```sh
curl -X GET \
  http://localhost/lobbies
```
#### Add Item to Inventory: (Assuming userId=1 and itemId=1 (Basic Sword))
```sh
curl -X POST \
  http://localhost/inventory/1/add \
  -H 'Content-Type: application/json' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN' \
  -d '{
    "item_id": 1,
    "quantity": 2
  }'
```
#### Get user inventory
```sh
curl -X GET \
  http://localhost/inventory/1 \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN'
```