const axios = require('axios');
// Function to retrieve summoner by name
exports.handler = async (event, context) => 
{ 
  const { region, summonerName, apiKey } = event.queryStringParameters;
  
  const url = `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${apiKey}`;
  return fetchData(url);
};

// Helper function to fetch data from API
const fetchData = async (url) => 
{
  try 
  {
    const response = await axios.get(url);
    return response.data;
  } 
  catch (error)
  {
    console.error(`Error fetching data: ${error.message}`);
    throw error;
  }
};
