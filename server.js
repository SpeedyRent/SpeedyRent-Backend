// server.js
const express = require('express');
const sequelize = require('../src/config');
const Vehicle = require('../src/models/Vehicle');

const app = express();
const PORT = process.env.PORT || 8080;

app.use(express.json());

app.get('/api/vehicles', async (req, res) => {
  const { marca, modelo, anio, precioMax } = req.query;

  const filters = {};
  if (marca) filters.marca = marca;
  if (modelo) filters.modelo = modelo;
  if (anio) filters.anio = anio;
  if (precioMax) filters.precio = { [Op.lte]: precioMax }; 

  try {
    const vehicles = await Vehicle.findAll({ where: filters });
    res.json(vehicles);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

sequelize.sync().then(() => {
  app.listen(PORT, () => {
    console.log(`Servidor corriendo en http://localhost:${PORT}`);
  });
}).catch((error) => {
  console.error('Error al sincronizar la base de datos:', error);
});
