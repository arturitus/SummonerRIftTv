const axios = require('axios');

// Function to retrieve summoner by name
exports.handler = async (event, context) => {
  try {
    const { region, summonerName } = event.queryStringParameters;
    const apiKey = process.env.API_KEY; // Accessing the API key from environment variable
    const url = `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${apiKey}`;
    
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