const axios = require('axios');

module.exports = async (req, res) => {
  const { region, summonerId, apiKey } = req.query;
  const url = `https://${region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/${summonerId}?api_key=${apiKey}`;

  try {
    const response = await axios.get(url);
    res.status(200).json(response.data);
  } catch (error) {
    res.status(error.response.status).json(error.response.data);
  }
};