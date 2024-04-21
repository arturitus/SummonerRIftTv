const axios = require('axios');

exports.handler = async (event, context) => {
  try {
    const { region, summonerId } = event.queryStringParameters;
    const apiKey = process.env.API_KEY; // Accessing the API key from environment variable
    const url = `https://${region}.api.riotgames.com/lol/spectator/v5/active-games/by-summoner/${summonerId}?api_key=${apiKey}`;
    
    // Fetch data from the API
    const response = await axios.get(url);

    // Return the response to the client
    return {
      statusCode: 200,
      body: JSON.stringify(response.data)
    };
  } catch (error) {
    // If an error occurs, return an error response
    console.error(`Error fetching data: ${error.message}`);
    return {
      statusCode: error.response.status || 500,
      body: JSON.stringify({ error: error.message })
    };
  }
};