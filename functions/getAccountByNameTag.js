const axios = require('axios');

exports.handler = async (event, context) => {
  try {
    const { riotServerRegion, summonerName, tagLine } = event.queryStringParameters;
    const apiKey = process.env.API_KEY; // Accessing the API key from environment variable

    const encodedSummonerName = encodeURIComponent(summonerName);
    const encodedTagLine = encodeURIComponent(tagLine);
    const url = `https://${riotServerRegion}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/${encodedSummonerName}/${encodedTagLine}?api_key=${apiKey}`;
    
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