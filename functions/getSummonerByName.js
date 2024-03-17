// const axios = require('axios');
// Function to retrieve summoner by name
exports.handler = async (event, context) => {
  const { region, summonerName, apiKey } = event.queryStringParameters;

  // Check if required parameters are provided
  if (!region || !summonerName || !apiKey) {
    return {
      statusCode: 400,
      body: JSON.stringify({ error: "Missing required parameters" })
    };
  }

  // Construct the URL
  const url = `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${apiKey}`;

  // Return the URL as JSON
  return {
    statusCode: 200,
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ url: url })
  };
};

// Helper function to fetch data from API
// const fetchData = async (url) => 
// {
//   try 
//   {
//     const response = await axios.get(url);
//     return response.data;
//   } 
//   catch (error)
//   {
//     console.error(`Error fetching data: ${error.message}`);
//     throw error;
//   }
// };
