const express = require("express");
const bodyParser = require("body-parser");
const cors = require("cors");

const app = express();
const PORT = 4000;

// Middleware to parse form data
app.use(bodyParser.urlencoded({ extended: true }));
app.use(cors());

// Handle form submission
app.post("/submit", (req, res) => {
  console.log("Received form data:", req.body);
  console.log("Received form data:", req.body);

  res.send(`Form submitted successfully! Received: ${JSON.stringify(req.body)}`);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
